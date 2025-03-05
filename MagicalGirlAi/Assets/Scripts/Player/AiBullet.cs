using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBullet : MonoBehaviour
{
    [SerializeField] public float lifeTime = 3f;
    public int dmg = 1;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyPatrol blue =collision.gameObject.GetComponent<EnemyPatrol>();
        if (blue != null)
        {
            blue.TakesDmgB(dmg);
        }

            EnemyState purple = collision.gameObject.GetComponent<EnemyState>();
        if (purple != null)
        {
            purple.TakesDmgP(dmg);
        }

        GreenEnemy green = collision.gameObject.GetComponent<GreenEnemy>();
        if (green != null)
        {
            green.TakesDmgB(dmg);
        }

        Destroy(gameObject);
    }

}

