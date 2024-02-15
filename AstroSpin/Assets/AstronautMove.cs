using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AstronautMove : MonoBehaviour
{
    public string currentPlanet;   //rotate1 certainly
    public UnityEngine.Vector3 astronautStartingPosition;
    public UnityEngine.Vector3 referenceStartingPosition;

    void Start()
    {
        
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
            referenceStartingPosition = reference.transform.position;
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
        }
        if(currentPlanet != "")
        {
            /*GameObject planet = GameObject.Find(currentPlanet);
            PlanetMoveScript script = planet.GetComponent<PlanetMoveScript>();
            float rotationSpeed = script.getRotateSpeed();
            Vector3 planetRotationDirection = script.getForward();*/

            GameObject planet = GameObject.Find(currentPlanet);
            GameObject reference = null;
            try
            {
                reference = planet.transform.GetChild(3).gameObject;
            }
            catch (Exception e)
            {
                reference = planet.transform.GetChild(2).gameObject;
            }
            Debug.Log("reference: " + reference.name);
            transform.position = astronautStartingPosition + (referenceStartingPosition - reference.transform.position);
            referenceStartingPosition = reference.transform.position;
            astronautStartingPosition = transform.position;
        }
    }

    private bool isOutOfBounds()
    {
        if (gameObject.transform.position.x < -3f) return true;
        if (gameObject.transform.position.x > 3f) return true;
        if (gameObject.transform.position.y > 2f) return true;
        if (gameObject.transform.position.y < -2f) return true;
        return false;
    }
}
