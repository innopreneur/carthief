using UnityEngine;
using System.Collections;

public class RoadRunner : MonoBehaviour {

    public float roadRunnerSpeed;
    private Vector2 offset;
    private Renderer roadRenderer;
	// Use this for initialization
	void Start () {

        roadRenderer = GetComponent<Renderer>();
        
    }
	
	// Update is called once per frame
	void Update () {
        
            offset = Vector2.up * roadRunnerSpeed * Time.time;
            roadRenderer.material.mainTextureOffset = offset;
        
       
	}
}
