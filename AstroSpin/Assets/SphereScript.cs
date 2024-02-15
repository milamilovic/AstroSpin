using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    public GameObject astronaut;
    private AstronautMove script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        astronaut = collision.gameObject;
        script = astronaut.GetComponent<AstronautMove>();
        if(collision.gameObject.name == "Astronaut")
        {
            Debug.Log("planet changed: " + gameObject.transform.parent.gameObject.name);
            astronaut.GetComponent<AstronautMove>().currentPlanet = gameObject.transform.parent.gameObject.name;
            astronaut.GetComponent<AstronautMove>().planetStartingPosition = gameObject.transform.parent.gameObject.transform.position;
            astronaut.GetComponent<AstronautMove>().astronautStartingPosition = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Astronaut")
        {
            Debug.Log("exited planet sphere");
            astronaut.GetComponent<AstronautMove>().currentPlanet = "";
            astronaut.GetComponent<AstronautMove>().planetStartingPosition = Vector3.zero;
            astronaut.GetComponent<AstronautMove>().astronautStartingPosition = Vector3.zero;
        }
    }
}
