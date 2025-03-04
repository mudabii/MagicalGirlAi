using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootItem
{
    public GameObject itemPrefab;
    public int points;    
}

public class RandomLoot : MonoBehaviour
{
    [Header("Loot Settings")]
    public int[] table = { 70, 20, 10 };
    public LootItem[] lootItems;         
    private int total;

    void Start()
    { 
        foreach (var item in table)
        {
            total += item;
        }
    }

    
    public LootItem GetRandomItem()
    {
        int randomNum = Random.Range(0, total);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNum <= table[i])
            {
                return lootItems[i]; 
            }
            else
            {
                randomNum -= table[i];
            }
        }
    
        return lootItems[lootItems.Length - 1];
    }
}
