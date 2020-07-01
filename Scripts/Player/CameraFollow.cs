using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables
    public Rigidbody playerRB;   // player rigidbody
    private Vector3 offset;    // offset vector 


    // unity's start function
    void Start()
    {

        offset = transform.position - playerRB.transform.position;   // start off at player position
        offset.Set(0, 11, 0);
    }


    void FixedUpdate()
    {
        transform.position = playerRB.transform.position + offset;    // Constantly follow player position
        
    }
}
