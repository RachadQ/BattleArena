using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple joystick implementation without UI dependencies
// This version uses Input system instead of UI components

public class Joystick : MonoBehaviour
{
    public Vector3 inputDirection;
    public float joystickRadius = 50f;
    
    private bool isDragging = false;
    private Vector2 joystickCenter;
    private Vector2 currentTouchPosition;

    void Start()
    {
        inputDirection = Vector3.zero;
        joystickCenter = transform.position;
    }

    void Update()
    {
        // Handle mouse input for testing
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            if (Vector2.Distance(mousePos, joystickCenter) <= joystickRadius)
            {
                isDragging = true;
            }
        }
        
        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 direction = mousePos - joystickCenter;
            
            if (direction.magnitude > joystickRadius)
            {
                direction = direction.normalized * joystickRadius;
            }
            
            inputDirection = new Vector3(direction.x / joystickRadius, direction.y / joystickRadius, 0);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            inputDirection = Vector3.zero;
        }
        
        // Handle touch input for mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (Vector2.Distance(touch.position, joystickCenter) <= joystickRadius)
                    {
                        isDragging = true;
                    }
                    break;
                    
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (isDragging)
                    {
                        Vector2 direction = touch.position - joystickCenter;
                        
                        if (direction.magnitude > joystickRadius)
                        {
                            direction = direction.normalized * joystickRadius;
                        }
                        
                        inputDirection = new Vector3(direction.x / joystickRadius, direction.y / joystickRadius, 0);
                    }
                    break;
                    
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isDragging = false;
                    inputDirection = Vector3.zero;
                    break;
            }
        }
    }
}
