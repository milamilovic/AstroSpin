using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AstronautMove : MonoBehaviour
{
    public string currentPlanet;   //rotate1 first certainly
    public UnityEngine.Vector3 astronautStartingPosition;
    public UnityEngine.Vector3 referenceStartingPosition;
    public UnityEngine.Vector3 collisionPoint;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    public void setParent(GameObject parent, UnityEngine.Vector3 collisionPosition)
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
            referenceStartingPosition = reference.transform.position;
            collisionPoint = collisionPosition;
        }
        else
        {
            gameObject.transform.SetParent(null);
            referenceStartingPosition = UnityEngine.Vector3.zero;
        }
    }

    void Update()
    {
        if(isOutOfBounds())
        {
            GameObject.Find("LogicManager").gameObject.GetComponent<LogicScript>().gameOver();
            Destroy(gameObject);
        }
        if(currentPlanet != "")
        {
            //TODO: register tap or space press
                //jump in right direction
        }
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
        UnityEngine.Vector3 collidePoistion = planet.transform.position;
        UnityEngine.Vector3 planetCenter = planet.transform.position;
        UnityEngine.Vector3 astronautFeet = gameObject.transform.GetChild(0).gameObject.transform.position;
        UnityEngine.Vector3 astronautHead = gameObject.transform.GetChild(1).gameObject.transform.position;

        //vector with which we want to align astronaut with
        UnityEngine.Vector3 astronautVector = (astronautHead - astronautFeet).normalized;
        UnityEngine.Vector3 targetVector = (astronautFeet - planetCenter).normalized;

        // Calculate the angle between the forward vector of the object and the target vector
        float angle = (float) (Math.Atan2(astronautVector.y - targetVector.y, astronautVector.x - targetVector.x) * (180 / Math.PI));

        Debug.Log("astronaut vector: " + astronautVector);
        Debug.Log("target vector: " + targetVector);
        Debug.Log("angle: " + angle);


        // Apply the rotation to the object
        transform.Rotate(new UnityEngine.Vector3(0, 0, angle));
    }
}
