using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [Range(1, 200)]
    public float rayDistance;
    [Range(1, 50)]
    public int moveSpeed, rotSpeed;
    public LayerMask layer;
    public Vector3 currentPos;
    public Animator anim;
    public Transform backPos;

    private float yPos = 1f;

    void Update()
    {
        RaycastHit hit;
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Vector3 direction = (currentPos - transform.position).normalized;

        if (Physics.Raycast(ray, out hit, rayDistance, layer))
        {
            currentPos = new Vector3(hit.point.x, 0.1f, hit.point.z);
            if (Input.GetMouseButton(0))
            {
               
                anim.Play("Running");
                
                transform.position = Vector3.MoveTowards(transform.position, currentPos, moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            }
            if (Input.GetMouseButtonUp(0))
            {
                anim.Play("Dynamic Idle");
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stack"))
        {
            AddBack(other.gameObject);
        }
        if (other.gameObject.CompareTag("Bridge"))
        {
            Bridge(other.gameObject);
        }
        if (other.gameObject.CompareTag("FinishWay"))
        {
            Time.timeScale = 0;
            anim.Play("Chicken Dance");
       }
    }

    private void Bridge(GameObject bridgeObj)
    {
        if (backPos.transform.childCount > 0)
        {
            MeshRenderer mesh = bridgeObj.GetComponent<MeshRenderer>();
            mesh.enabled = true;
            mesh.material.color = Color.blue;
            int obstacleNumber = backPos.transform.childCount - 1;
            Destroy(backPos.GetChild(obstacleNumber).gameObject);
            yPos -= 0.3f;
            bridgeObj.GetComponent<BoxCollider>().enabled = false;
        }

    }
    private void AddBack(GameObject obj)
    {
        obj.transform.SetParent(backPos.transform);
        obj.transform.rotation = backPos.rotation;
        obj.transform.position = new Vector3(backPos.position.x, yPos, backPos.position.z);
        yPos += 0.3f;
    }

    
}