using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CameraController : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public Vector3 cameraOffset;
    public float SmoothFactor = 0.5f;
    Vector3 relativePos;
    public bool lookAtPlayer = false;


    private void Start()
    {

        
            cam = Camera.main;
            cameraOffset = new Vector3(0, 15, -10);
        
        
            
        
        

    }
    private void Update()
    {
        
    }

    private void LateUpdate()
    {

        Vector3 newPos = target.transform.position + cameraOffset;
        
        cam.transform.position = Vector3.Slerp(cam.transform.position, newPos, SmoothFactor );
        cam.transform.LookAt(target.transform);
        
            

    }
    
}
