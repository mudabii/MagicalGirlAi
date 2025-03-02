using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;

    public Vector3 direction;
 
    void Start()
    {
        direction = pointA.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, speed*Time.deltaTime);

        if (Vector3.Distance(transform.position, direction) < 0.1f)
        {
            if (direction == pointA.position)
            {
                direction = pointB.position;
            }
            else
            {
                direction = pointA.position;
            }
        }
    }
}
