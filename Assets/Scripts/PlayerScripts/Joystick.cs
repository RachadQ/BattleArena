using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Joystick : MonoBehaviour, IDragHandler,IPointerUpHandler, IPointerDownHandler
{
  

    private Image jsContainer;
    private Image joystick;
    
    public Vector3 inputDirection;

    void Start()
    {
        jsContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        inputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;

        //to get input direction
        RectTransformUtility.ScreenPointToLocalPointInRectangle(jsContainer.rectTransform, ped.position, ped.pressEventCamera, out position);

        position.x = (position.x / jsContainer.rectTransform.sizeDelta.x);
        position.y = (position.y / jsContainer.rectTransform.sizeDelta.y);

        float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        float z = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        inputDirection = new Vector3(x, y, 0);
        inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;
        joystick.rectTransform.anchoredPosition = new Vector3(inputDirection.x * (jsContainer.rectTransform.sizeDelta.x / 3), inputDirection.y * (jsContainer.rectTransform.sizeDelta.y) / 3);
    }

    public void OnPointerDown(PointerEventData ped)
    {
        
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
