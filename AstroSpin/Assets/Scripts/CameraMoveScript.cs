using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    private Vector3 moveDir = new Vector3(0.2f, 0, -10);
    public Camera camera;
    private float moveSpeed = 0.2f;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        //move to the right
        if (Time.time - startTime > 3)
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        }

    }
}
