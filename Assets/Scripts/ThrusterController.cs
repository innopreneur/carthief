using UnityEngine;
using System.Collections;

public class ThrusterController : MonoBehaviour {

    private Transform thrusterTransform;

    [SerializeField]
    private GameObject thrusterAngle;

    private bool isThrusterAngleActive;
    private float targetRot;

    [SerializeField]
    private float thrusterAngleFactor;
    private float hitPositionX;
    private float hitPositionY;

    void Awake () {

        thrusterTransform = GetComponent<Transform>();
        thrusterAngle.SetActive(false);
        isThrusterAngleActive = false;
    }

    void Start()
    {
        targetRot = thrusterTransform.rotation.z;
    }
    
	
	// Update is called once per frame
	void Update () {
        
	}

   
}
