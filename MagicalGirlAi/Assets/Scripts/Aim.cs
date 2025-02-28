using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Camera cam;
    Vector2 posicionMouse;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        //Cursor.visible = false
    }
    void Update()
    {
        posicionMouse = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 aim = posicionMouse - rb.position;
        float angle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
