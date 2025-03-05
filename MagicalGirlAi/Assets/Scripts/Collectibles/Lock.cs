using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Key") == null)
        {        
            Destroy(gameObject);
        }
    }
}
