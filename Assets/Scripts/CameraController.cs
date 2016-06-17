using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    private Transform camTransform, playerTransform;


	
	void Awake () {

        playerTransform = player.GetComponent<Transform>();
        camTransform = GetComponent<Transform>();


    }
	

    void Update () {

        camTransform.position = playerTransform.position - Vector3.forward * 20;
        
	}
}
