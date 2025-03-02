using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click izquierdo");
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Disparo");
        GameObject bullet = Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
