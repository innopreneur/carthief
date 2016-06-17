using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class VirtualJoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {

    private Image backgroundImg;
    private Image rollerImg;
    private Vector3 inputVector;
    private Transform joyStickTransform;

    private void Start()
    {
        joyStickTransform = GetComponent<Transform>();
        backgroundImg = GetComponent<Image>();
        rollerImg = joyStickTransform.GetChild(0).GetComponent<Image>();
        Debug.Log("Size  - " + backgroundImg.rectTransform.sizeDelta);
    }
    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / backgroundImg.rectTransform.sizeDelta.x) * 2 + 1;
            pos.y = (pos.y / backgroundImg.rectTransform.sizeDelta.y) * 2 - 1;

            inputVector = new Vector3(pos.x, 0, pos.y);

            //if input vector magnitude is gretaer than 1, normalize it
            inputVector = inputVector.magnitude > 1 ? inputVector.normalized : inputVector;

            //move the joystick roller
            rollerImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (backgroundImg.rectTransform.sizeDelta.x/3), inputVector.z * (backgroundImg.rectTransform.sizeDelta.y / 3), 0);


        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        rollerImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float GetX()
    {
        return inputVector.x;
    }

    public float GetZ()
    {
        return inputVector.z;
    }
}
