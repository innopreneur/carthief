using UnityEngine;
using System.Collections;

public class NonPlayerController : MonoBehaviour {

    private Transform objTransform;
    public float destroyPosY;
    public float speed = 5f;
    public float Xmin;
    public float Xmax;


	void Start () {

        objTransform = GetComponent<Transform>();
	}
	

	void Update () {

        //destroy this car if it reaches end of road
        DestroyObject();

        //Move car downwards
        MoveObject();  
	}

    void DestroyObject()
    {
        if (objTransform.position.y <= destroyPosY)
        {
            Destroy(this.gameObject);
        }
    }
    void MoveObject()
    {
        float zRotation = objTransform.rotation.z;
        if(zRotation == 0)
        {
            objTransform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            objTransform.Translate(Vector3.up * speed * Time.deltaTime * 2);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.score += 1;
            Destroy(gameObject);
        }
    }
}
