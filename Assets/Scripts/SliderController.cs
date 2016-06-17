using UnityEngine;
using System.Collections;

public class SliderController : MonoBehaviour {

    [SerializeField]
    private Transform knob;
    private Vector3 targetPos;

    [SerializeField]
    private LayerMask touchLayer;

	void Start () {

        targetPos = knob.position;
	}
	
	
	void Update () {
	
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, touchLayer))
                {
                   if(hit.transform.tag == "Knob")
                    {
                        MoveKnob(hit.point);  
                    }
                }
            }
        }

        knob.position = Vector3.Lerp(knob.position, targetPos, Time.deltaTime * 7);
	}

    void MoveKnob(Vector3 point)
    {
        targetPos = new Vector3(point.x, targetPos.y, targetPos.z);
    }
}
