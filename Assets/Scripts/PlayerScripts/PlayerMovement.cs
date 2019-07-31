using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick movement;
    public Joystick rotation;
    private readonly float moveSpeed = 0.2f;
    private readonly float rotateSpeed = 0.02f;
    
    Rigidbody playerRb;
    Vector3 moveDirection;
    public Vector3 lookAtDirection;
    public bool isRotating;
    public GameObject target;

    void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();

       
       
    }



    // Update is called once per frame
    void Update()
    {
      //  Move();
    }
    
   

    public void Move()
    {
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
        lookAtDirection.x = rotation.inputDirection.x;
        lookAtDirection.z = rotation.inputDirection.y;
        
        
        //if joystick is moving
        if (lookAtDirection.magnitude != 0)
        {

            isRotating = true;
            // Vector3 newDir = Vector3.RotateTowards(this.transform.GetChild(0).forward, lookAtDirection, (20 * Time.deltaTime), 0);
            // transform.GetChild(0).rotation = Quaternion.LookRotation(newDir);
            transform.GetChild(0).forward = lookAtDirection;
           
           
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
