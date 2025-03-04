using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public Transform player;
    public float z = 1;
    private Vector3 lastPlayerPosition;
    void Update()
    {
        if (player == null)
        {
            return;
        }
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,z);
        lastPlayerPosition = new Vector3(player.position.x, player.position.y, z);
    }
}
