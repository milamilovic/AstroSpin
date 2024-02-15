using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
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

    public void setParent(GameObject parent)
    {
        if (parent != null)
        {
            gameObject.transform.SetParent(parent.transform);
        }
        else
        {
            gameObject.transform.SetParent(null);
        }
    }

    void Update()
    {
        if(currentPlanet != "")
        {
            /*GameObject planet = GameObject.Find(currentPlanet);
            PlanetMoveScript script = planet.GetComponent<PlanetMoveScript>();
            float rotationSpeed = script.getRotateSpeed();
            Vector3 planetRotationDirection = script.getForward();*/

            GameObject planet = GameObject.Find(currentPlanet);
            transform.position = astronautStartingPosition + (planet.transform.position - planetStartingPosition);
            planetStartingPosition = planet.transform.position;
            astronautStartingPosition = transform.position;
        }
    }


}
