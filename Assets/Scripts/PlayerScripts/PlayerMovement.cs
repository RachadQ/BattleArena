using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick movement;
    public Joystick rotation;
    private readonly float moveSpeed = 0.2f;
  //  private readonly float rotateSpeed = 0.2f;
    
    Vector3 moveDirection;
    public Vector3 lookAtDirection;
    public bool isRotating;
    public GameObject target;

    void Start()
    {
       

       
       
    }



    // Update is called once per frame
    void Update()
    {
      //  Move();
    }
    
   

    public void Move()
    {
        if (movement == null) return;
        
        moveDirection.x = movement.inputDirection.x;
        moveDirection.z = movement.inputDirection.y;
        //if joystick is moving
        if (moveDirection.magnitude != 0)
        {




            transform.position += moveDirection * moveSpeed;
      
        }
    }

    public void LookAt()
    {
        if (rotation == null || target == null) return;
        
        lookAtDirection.x = rotation.inputDirection.x;
        lookAtDirection.z = rotation.inputDirection.y;

        //if joystick is moving
        if (lookAtDirection.magnitude != 0)
        {

            isRotating = true;
            target.transform.forward = lookAtDirection;
           
           
        }
        else
        {
            isRotating = false;
        }
    }

    private void FixedUpdate()
    {

        Move();
        LookAt();
    }
}
