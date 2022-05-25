using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [Range(1, 10)]
    public int width, height;
    Vector3 origin;

    public GameObject[] cubes;
    void Start()
    {
        for (int i = -5; i < width; i++) 
        {
            for (int j = -4; j < height; j++)
            {
                int randomValue = Random.Range(0, 4);
                GameObject obj = Instantiate(cubes[randomValue], origin, transform.rotation, transform);
                origin = new Vector3(transform.position.x + i, 0.1f, transform.position.z + j);
            }
        }
    }
    /*private void Update()
    {
        for (int i = -5; i < widht; i++)
        {
            for (int j = -4; j < height; j++)
            {
                int randomValue = Random.Range(0, 3);
                GameObject obj = Instantiate(cubes[randomValue], origin, transform.rotation, transform);
                origin = new Vector3(transform.position.x + i, 0.1f, transform.position.z + j);
            }
        }
    } */
}