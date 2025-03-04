using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private float movX, movY;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal") * speed;
        movY = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = new Vector2(movX, movY);
    }

}
