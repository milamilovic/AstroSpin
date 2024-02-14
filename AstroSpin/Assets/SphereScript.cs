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
            astronaut.GetComponent<AstronautMove>().currentPlanet = gameObject.transform.parent.gameObject.name;
            astronaut.GetComponent<AstronautMove>().collisionPosition = gameObject.transform.parent.gameObject.transform.position;
        }
    }
}
