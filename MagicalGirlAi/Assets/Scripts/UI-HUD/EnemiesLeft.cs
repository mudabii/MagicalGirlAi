using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class EnemiesLeft : MonoBehaviour
{
    GameObject[] enemies;
    GameObject[] key;
    [SerializeField] private Image EnemyAsset;
    [SerializeField] private Image KeyAsset;
    [SerializeField] private Text txtEnemies;

    private void Start()
    {
        KeyAsset.gameObject.SetActive(false);
    }
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        txtEnemies.text= enemies.Length.ToString();
        if (enemies.Length == 0)
        {
            txtEnemies.gameObject.SetActive(false);
            EnemyAsset.gameObject.SetActive(false);
        }
        else
        {
            txtEnemies.gameObject.SetActive(true);
            EnemyAsset.gameObject.SetActive(true);
        }

        key = GameObject.FindGameObjectsWithTag("Key");
        if (key.Length == 0)
        {
           KeyAsset.gameObject.SetActive(true);
        }
        else
        {
            KeyAsset.gameObject.SetActive(false);
        }
    }
}
