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
            Debug.Log("astronaut is in planet atmosphere");
            /*GameObject planet = GameObject.Find(currentPlanet);
            PlanetMoveScript script = planet.GetComponent<PlanetMoveScript>();
            float rotationSpeed = script.getRotateSpeed();
            Vector3 planetRotationDirection = script.getForward();*/

            /*GameObject planet = GameObject.Find(currentPlanet);
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
            astronautStartingPosition = transform.position;*/
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
}
