using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoveScript : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float rotateSpeed = 15;
    public int forward = 0;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (forward == 0)
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        } 
        else
        {
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
        }
    }
}
