using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ButtonInput : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {

    private Transform playerTransform;
	// Use this for initialization
	void Start () {

        playerTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void OnDrag(PointerEventData eventData)
    {
        playerTransform.position = eventData.position;
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer down");
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        

    }
   
}
