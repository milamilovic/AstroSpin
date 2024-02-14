using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoveScript : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float rotateSpeed = 15;
    public int forward = 0;
    private float outOfScreenXCoordinate = -3.5f;

    public float getRotateSpeed()
    {
        return rotateSpeed;
    }

    public Vector3 getForward()
    {
        if(forward == 0) { return Vector3.forward; } else { return Vector3.back; }
    }

    void Start()
    {
        
    }

    void Update()
    {
        //move to the left
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        //rotate
        if (forward == 0)
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        } 
        else
        {
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
        }

        //destroy if out of screen
        if(transform.position.x < outOfScreenXCoordinate)
        {
            Destroy(gameObject);
        }
    }
}
