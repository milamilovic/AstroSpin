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
    private int num = 1;
    private float startTime;
    private float moveSpeed = 0.2f;

    void Start()
    {
        startTime = Time.time;
        Vector3 pos = transform.position - new Vector3(3.5f, 1, 0);
        spawnPlanet(pos, 2);
        pos = transform.position - new Vector3(1, -0.5f, 0);
        spawnPlanet(pos, Random.Range(0, 4));
    }

    void Update()
    {
        if (Time.time - startTime > 1)
        {
            //move to the right
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        }
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
        GameObject newPlanet = null;
        switch(variant)
        {
            case 0:
                newPlanet = Instantiate(planet, position, transform.rotation);
                newPlanet.name = "regular" + num.ToString();
                break;
            case 1:
                newPlanet = Instantiate(fastPlanet, position, transform.rotation);
                newPlanet.name = "fast" + num.ToString();
                break;
            case 2:
                newPlanet = Instantiate(rotatePlanet, position, transform.rotation);
                newPlanet.name = "rotate" + num.ToString();
                break;
            case 3:
                newPlanet = Instantiate(fastRotatePlanet, position, transform.rotation);
                newPlanet.name = "fastRotate" + num.ToString();
                break;
        }
        num++;
        spawnRate = Random.Range(5, 12);
    }
}
