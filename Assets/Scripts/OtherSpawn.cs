using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSpawn : MonoBehaviour
{
    [Range(1, 10)]
    public int width, height;
    Vector3 otherorigin;
    public GameObject[] cubes;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = -3; i < width; i++)
            {
                for (int j = -1; j < height; j++)
                {
                    int randomValue = Random.Range(0, 4);
                    GameObject obj = Instantiate(cubes[randomValue], otherorigin, transform.rotation, transform);
                    otherorigin = new Vector3(transform.position.x + i, 0.1f, transform.position.z + j);
                    width = 0;
                }
            }

        }
        
    }
}
