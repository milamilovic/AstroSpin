using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AstronautMove : MonoBehaviour
{
    public string currentPlanet;   //rotate1 first certainly
    public UnityEngine.Vector3 astronautStartingPosition;
    private Camera camera;
    public UnityEngine.Vector3 jumpDirection;

    void Start()
    {
        camera = Camera.main;
    }

    public void setParent(GameObject parent)
    {
        //setting that astronaut is child of planet
        if (parent != null)
        {
            //setting that astronaut is child of planet
            gameObject.transform.SetParent(parent.transform);
            //adding rotation starting point reference
            try { 
                GameObject existingReference = parent.transform.Find("reference").gameObject;
                Destroy(existingReference);
            } catch (Exception e) { }
            GameObject reference = new GameObject("reference");
            reference.transform.position = astronautStartingPosition;
            reference.transform.SetParent(parent.transform, false);
        }
        else
        {
            gameObject.transform.SetParent(null);
        }
    }

    void Update()
    {
        if(isOutOfBounds())
        {
            GameObject.Find("LogicManager").gameObject.GetComponent<LogicScript>().gameOver();
            Destroy(gameObject);
        }
        if(currentPlanet != "") // astronaut on planet
        {
           if(Input.GetKey(KeyCode.Space) && jumpDirection == UnityEngine.Vector3.zero) 
           {
                Debug.Log("Jumped");
                jumpDirection = calculateJumpDirection();
                currentPlanet = "";
                delayedWork();
                astronautStartingPosition = UnityEngine.Vector3.zero;
                setParent(null);
           }
        }
        else if (jumpDirection != UnityEngine.Vector3.zero) // astronaut jumping
        {
                transform.position += jumpDirection * Time.deltaTime;
        }
    }

    private async Task delayedWork()
    {
        await Task.Delay(500);
        Rigidbody2D rigidbody = gameObject.AddComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        rigidbody.mass = 0;
    }

    private UnityEngine.Vector3 calculateJumpDirection()
    {
        GameObject planet = GameObject.Find(currentPlanet).gameObject;
        UnityEngine.Vector3 astronautFeet = gameObject.transform.GetChild(0).gameObject.transform.position;
        UnityEngine.Vector3 astronautHead = gameObject.transform.GetChild(1).gameObject.transform.position;
        UnityEngine.Vector3 astronautVector = (astronautHead - astronautFeet).normalized;
        float planetSpeed = planet.GetComponent<PlanetMoveScript>().rotateSpeed;

        Debug.Log("astronaut vector was " + astronautVector);
        UnityEngine.Vector3 planetRotationDirection = planet.GetComponent<PlanetMoveScript>().getForward();
        float angle = 30;
        if (planetRotationDirection != UnityEngine.Vector3.forward)
        {
            angle *= -1;
        }        
        astronautVector = UnityEngine.Quaternion.AngleAxis(angle, UnityEngine.Vector3.forward) * astronautVector;
        if (planetSpeed == 15)
        {
            astronautVector = astronautVector * 0.5f;
        }

        astronautVector = astronautVector.normalized;

        Debug.Log("astronaut vector is " + astronautVector);

        return astronautVector;
    }


    private bool isOutOfBounds()
    {
        //destroy if out of screen
        if (camera.transform.position.x - transform.position.x > 3.2) return true;
        if (camera.transform.position.x - transform.position.x < -3.2) return true;
        if (camera.transform.position.y - transform.position.y > 2) return true;
        if (camera.transform.position.y - transform.position.y < -2) return true;
        return false;
    }

    public void alignWithPlanet()
    {
        GameObject planet = GameObject.Find(currentPlanet).gameObject;
        UnityEngine.Vector3 planetCenter = planet.transform.position;
        UnityEngine.Vector3 astronautFeet = gameObject.transform.GetChild(0).gameObject.transform.position;
        UnityEngine.Vector3 astronautHead = gameObject.transform.GetChild(1).gameObject.transform.position;

        //vector with which we want to align astronaut with
        UnityEngine.Vector3 astronautVector = (astronautHead - astronautFeet).normalized;
        UnityEngine.Vector3 targetVector = (astronautFeet - planetCenter).normalized;

        // Calculate the angle between the forward vector of the object and the target vector
        float angle = (float) (Math.Atan2(astronautVector.y - targetVector.y, astronautVector.x - targetVector.x) * (180 / Math.PI));

        Debug.Log("aligned with planet, angle is " + angle);

        // Apply the rotation to the object
        transform.Rotate(new UnityEngine.Vector3(0, 0, angle));
    }
}
