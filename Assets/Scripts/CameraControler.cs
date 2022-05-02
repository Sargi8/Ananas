using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // (2.64) (6.76) (-9.21)

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }

    }
}
