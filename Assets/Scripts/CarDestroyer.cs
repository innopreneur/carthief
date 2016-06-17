using UnityEngine;
using System.Collections;

public class CarDestroyer : MonoBehaviour {

    private Transform carTransform;
    public float destroyPosY;
    public float carSpeed = 5f;
    public float Xmin;
    public float Xmax;


	void Start () {

        carTransform = GetComponent<Transform>();
	}
	

	void Update () {

        //destroy this car if it reaches end of road
        DestroyCar();

        //Move car downwards
        MoveCar();

	}

    void DestroyCar()
    {
        Debug.Log("Destroy called");
        if(carTransform.position.y <= destroyPosY)
        {
            Destroy(this.gameObject);
        }
    }

    void MoveCar()
    {
        float zRotation = carTransform.rotation.z;
        if(zRotation == 0)
        {
            carTransform.Translate(Vector3.down * carSpeed * Time.deltaTime);
        }
        else
        {
            carTransform.Translate(Vector3.up * carSpeed * Time.deltaTime * 2);
        }
    }
}
