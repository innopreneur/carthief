using UnityEngine;
using System.Collections;

public class TrafficSpawner : MonoBehaviour {

    public float Xmin;
    public float Xmax;
    public float Ymax;
    public float stolenCarXPosFactor;

    
    public GameObject[] cars;
    public GameObject collectable;
    public float carSpawnDelay;
    public float collectibleSpawnDelay;

    private GameObject spawnedCar, spawnedCollectable;
    private float[] spawnRotations = { 0f, 180f };

    private float carTimer, collectibleTimer;
    public int stealableCarsCount = 3;
    int i = 0;

    void Start()
    {
        carTimer = carSpawnDelay;
        collectibleTimer = collectibleSpawnDelay;
    }

	// Update is called once per frame
	void Update () {

        SpawnCar();
        SpawnCollectable();
	}

    //spawn a car randomly
    void SpawnCar()
    {

        carTimer -= Time.deltaTime;
        Vector3 spawnPosition = new Vector3(Random.Range(Xmin, Xmax), Ymax);
        if (carTimer <= 0)
        {
            spawnedCar = Instantiate(cars[Random.Range(0, cars.Length)], spawnPosition, Quaternion.Euler(Vector3.forward * spawnRotations[Random.Range(0, spawnRotations.Length)])) as GameObject;
            carTimer = carSpawnDelay;
     
        }
    }


    void SpawnCollectable()
    {

        collectibleTimer -= Time.deltaTime;
        Vector3 spawnPosition = new Vector3(Random.Range(Xmin, Xmax), Ymax);
        if (collectibleTimer <= 0)
        {
            spawnedCollectable = Instantiate(collectable, spawnPosition, Quaternion.identity) as GameObject;
            collectibleTimer = collectibleSpawnDelay;
        }
    }

}
