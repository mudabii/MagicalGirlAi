using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public Transform player;
    public float z = 1;
    void Update()
    {

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,z);
    }
}
