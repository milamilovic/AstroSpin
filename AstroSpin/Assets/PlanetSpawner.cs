using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planet;
    public GameObject fastPlanet;
    public GameObject rotatePlanet;
    public GameObject fastRotatePlanet;
    private float spawnRate = 10;
    private float timer = 0;
    
    void Start()
    {
        Vector3 pos = transform.position - new Vector3(3.5f, 1, 0);
        spawnPlanet(pos, Random.Range(0, 4));
        pos = transform.position - new Vector3(1, -0.5f, 0);
        spawnPlanet(pos, Random.Range(0, 4));
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            float yPos = Random.Range(-1.2f, 1.2f);
            Vector3 pos = transform.position - new Vector3(0, yPos, 0);
            spawnPlanet(pos, Random.Range(0, 4));
            timer = 0;
        }
    }

    void spawnPlanet(Vector3 position, int variant)
    {
        switch(variant)
        {
            case 0:
                Instantiate(planet, position, transform.rotation);
                break;
            case 1:
                Instantiate(fastPlanet, position, transform.rotation);
                break;
            case 2:
                Instantiate(rotatePlanet, position, transform.rotation);
                break;
            case 3:
                Instantiate(fastRotatePlanet, position, transform.rotation);
                break;
        }
        spawnRate = Random.Range(4, 12);
    }
}
