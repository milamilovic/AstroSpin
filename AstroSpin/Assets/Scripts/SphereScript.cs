using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    public GameObject astronaut;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!!!!!!");
        astronaut = collision.gameObject;
        if(collision.gameObject.name == "Astronaut")
        {
            Debug.Log("planet changed: " + gameObject.transform.parent.gameObject.name);
            astronaut.GetComponent<AstronautMove>().currentPlanet = gameObject.transform.parent.gameObject.name;
            astronaut.GetComponent<AstronautMove>().astronautStartingPosition = collision.gameObject.transform.position;
            astronaut.GetComponent<Rigidbody2D>().gravityScale = 0;
            astronaut.GetComponent<AstronautMove>().setParent(gameObject, collision.ClosestPoint(gameObject.transform.position));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Astronaut")
        {
            Debug.Log("exited planet sphere");
            astronaut.GetComponent<AstronautMove>().currentPlanet = "";
            astronaut.GetComponent<AstronautMove>().astronautStartingPosition = UnityEngine.Vector3.zero;
            astronaut.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            astronaut.GetComponent<AstronautMove>().setParent(null, UnityEngine.Vector2.zero);
        }
    }
}
