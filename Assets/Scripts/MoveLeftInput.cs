using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class MoveLeftInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool clicked = false;


    public virtual void OnPointerDown(PointerEventData eventData)
    {
        clicked = true;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        clicked = false;
    }

    public bool GetLeftInput()
    {
        return clicked;
    }

}
