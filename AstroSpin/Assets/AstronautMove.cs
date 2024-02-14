using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AstronautMove : MonoBehaviour
{
    public string currentPlanet;   //rotate1 certainly
    public Vector3 collisionPosition;

    void Start()
    {
        
    }

    void Update()
    {
        if(currentPlanet != "")
        {
            GameObject planet = GameObject.Find(currentPlanet);
            PlanetMoveScript script = planet.GetComponent<PlanetMoveScript>();
            float planetSpeed = script.getRotateSpeed();
            Vector3 planetRotation = script.getForward();
            //gameObject.transform.RotateAround(planet.transform.position, planetRotation, planetSpeed * Time.deltaTime);
            transform.position = planet.transform.TransformPoint(new Vector3(0.3f, 0, 0) - collisionPosition);
            transform.Rotate(planetRotation, planetSpeed * Time.deltaTime);
            //transform.position = planet.transform.position + (Vector3.left * planetSpeed) * Time.deltaTime;
        }
    }


}
