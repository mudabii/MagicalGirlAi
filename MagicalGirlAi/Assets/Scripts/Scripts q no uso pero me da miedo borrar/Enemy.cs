using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Transform jugador;
    public GameObject bulletPrefab;
    public float bulletSpeed = 2f;
    public float intervalTime = 2f;
    public float attrange = 5f;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (Vector2.Distance(transform.position, jugador.position) <= attrange)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;

                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = direction * bulletSpeed;
            }

            yield return new WaitForSeconds(intervalTime);

        }
    }
}
