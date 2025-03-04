using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public int enemyHealth = 30;

    public enum EnemyStateMachine
    {
        Idle,
        Perseguir,
        Atacar,
        Morir
    }
    [Header("Movement")]
    private EnemyStateMachine currentState;
    public Transform jugador;
    public float attrange = 2f;
    public float detrange = 5f;
    public float speed = 3f;
    public bool isDead = false;

    [Header("Attack")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 2f;
    public float intervalTime = 2f;
    private float lastShotTime;

    [Header("Loot")]
    public RandomLoot randomLoot;
    void Start()
    {
        currentState = EnemyStateMachine.Idle;
        lastShotTime = Time.time;
    }

    void Update()
    {
        if (jugador == null || isDead) return;

        switch (currentState)
        {
            case EnemyStateMachine.Idle:
                Idle();
                break;

            case EnemyStateMachine.Perseguir:
                Perseguir();
                break;

            case EnemyStateMachine.Atacar:
                Atacar();
                break;

            case EnemyStateMachine.Morir:
                Morir();
                break;
        }
    }
    public void TakesDmgP(int cantidad)
    {
        if (isDead) return;
        enemyHealth -= cantidad;

        if (enemyHealth <= 0)
        {
            Morir();
        }
    }

    void Idle()
    {

        if (Vector3.Distance(transform.position, jugador.position) < detrange && !isDead)
        {
            currentState = EnemyStateMachine.Perseguir;
        }
    }

    void Perseguir()
    {
        {
            if (Vector3.Distance(transform.position, jugador.position) > detrange && !isDead)
            {
                currentState = EnemyStateMachine.Idle;
            }

            else if (Vector3.Distance(transform.position, jugador.position) <= attrange)
            {
                currentState = EnemyState.EnemyStateMachine.Atacar;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, jugador.position, speed * Time.deltaTime);
            }
        }




    }

    void Atacar()
    {
        if (Vector3.Distance(transform.position, jugador.position) > attrange)
        {
            currentState = EnemyStateMachine.Perseguir;
        }
        else
        {
            if (Time.time - lastShotTime >= intervalTime)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }
    }

    void Morir()
    {

        if (randomLoot != null)
        {
            LootItem droppedLoot = randomLoot.GetRandomItem();
            if (droppedLoot != null && droppedLoot.itemPrefab != null)
            {
                Instantiate(droppedLoot.itemPrefab, transform.position, Quaternion.identity);
            }

            currentState = EnemyStateMachine.Morir;
            Destroy(gameObject, 0.2f);
            isDead = true;
        }
    }
        void Shoot()
        {

            Vector2 direction = (jugador.position - transform.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }
    }


