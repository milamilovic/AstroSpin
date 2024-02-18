using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoveScript : MonoBehaviour
{
    public float rotateSpeed = 15;
    public int forward = 0;
    private Camera camera;


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
        camera = Camera.main;
    }

    void Update()
    {
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
        if(camera.transform.position.x - transform.position.x > 3.5)
        {
            Destroy(gameObject);
        }
    }
}
