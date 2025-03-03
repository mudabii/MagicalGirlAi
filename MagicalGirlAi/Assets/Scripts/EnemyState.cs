using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private bool isFacingRight=true;
        public enum EnemyStateMachine
        {
            Idle,
            Perseguir,
            Atacar,
            Morir
        }
        private EnemyStateMachine currentState;
        public Transform jugador;
        public float attrange = 2f;
        public float detrange = 5f;
        public float speed = 3f;

        public bool isDead = false;
        void Start()
        {
            currentState = EnemyStateMachine.Idle;
        }

        void Update()
        {
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

        void Idle()
        {
            
            if (Vector3.Distance(transform.position, jugador.position) < detrange && !isDead)
            {
                currentState = EnemyStateMachine.Perseguir;
            }
        }

        void Perseguir()
        {
            Debug.Log("Perseguir");

        {
            if (Vector2.Distance(transform.position, jugador.position) > detrange)
            {
                transform.position = Vector2.MoveTowards(transform.position, jugador.position, speed * Time.deltaTime);
            }
        }

            

        bool isPlayerRight = transform.position.x < jugador.transform.position.x;
        Flip(isPlayerRight);
    }

        void Atacar()
        {
            Debug.Log("Siendo atacado");
            //quitar vida jugador
            //ingresar script vida del player y restarle 1
        }

        void Morir()
        {
            Debug.Log("Enemigo muerto");
            //si lo ataco muere (bool)
            //animacion de morir
            //destruyo objeto
            //vueva a activarse arranque otra vez el idle
        }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}

