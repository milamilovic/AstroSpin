using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AstronautMove : MonoBehaviour
{
    public string currentPlanet;   //rotate1 certainly
    public Vector3 astronautStartingPosition;
    public Vector3 planetStartingPosition;

    void Start()
    {
        
    }

    void Update()
    {
        if(currentPlanet != "")
        {
            GameObject planet = GameObject.Find(currentPlanet);
            PlanetMoveScript script = planet.GetComponent<PlanetMoveScript>();
            float rotationSpeed = script.getRotateSpeed();
            Vector3 planetRotationDirection = script.getForward();
            //transform.position = planet.transform.TransformPoint(0.2f, 0, 0);
            transform.position = astronautStartingPosition - (planet.transform.position - planetStartingPosition);
            planetStartingPosition = planet.transform.position;
            astronautStartingPosition = transform.position;
            transform.Rotate(planetRotationDirection, rotationSpeed * Time.deltaTime);
            //transform.position = planet.transform.position + (Vector3.left * rotationSpeed) * Time.deltaTime;
        }
    }


}
