using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Key : MonoBehaviour
{
    public PolygonCollider2D col;
    public SpriteRenderer spriteKey;

    void Start()
    {
        col.enabled = false;
        spriteKey.color = new UnityEngine.Color(1, 1, 1, 0.5f);
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int totalEnemies = enemies.Length;


        //if (totalEnemies <= GameObject.FindGameObjectsWithTag("Enemy").Length * 0.1f)
        if (totalEnemies <= GameObject.FindGameObjectsWithTag("Enemy").Length * 0.5f)
        {
            col.enabled = true; 
            spriteKey.color = new UnityEngine.Color(1, 1, 1, 1f);
            enabled = false;
        }
    }
}
