using UnityEngine;
using System.Collections;

public class TrafficSpawner : MonoBehaviour {

    public float Xmin;
    public float Xmax;
    public float Ymax;

    
    public GameObject[] cars;
    public float spawnDelay;

    private GameObject spawnedCar;
    private float[] spawnRotations = { 0f, 180f };

    private float timer;

    void Start()
    {
        timer = spawnDelay;
    }

	// Update is called once per frame
	void Update () {

        SpawnCar();
	}

    //spawn a car randomly
    void SpawnCar()
    {

        timer -= Time.deltaTime;
        Vector3 spawnPosition = new Vector3(Random.Range(Xmin, Xmax), Ymax);

        if (timer <= 0)
        {
            spawnedCar = Instantiate(cars[Random.Range(0, cars.Length)], spawnPosition, Quaternion.Euler(Vector3.forward * spawnRotations[Random.Range(0, spawnRotations.Length)])) as GameObject;
            timer = spawnDelay;
            Debug.Log("Car Spawned");
        }

        
    }
}
