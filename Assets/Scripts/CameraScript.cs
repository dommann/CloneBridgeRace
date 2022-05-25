using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;
    public float speed;
    void Update()
    {
       transform.position = player.transform.position + offset;
    }
}
