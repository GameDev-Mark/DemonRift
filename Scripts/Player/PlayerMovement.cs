using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    private float PlayerMoveSpeed;   //playerMovementspeed

    public new Camera camera;   //camera raycast

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //Initalizing Variables
        PlayerMoveSpeed = 10.0f;  // player movement speed

        animator.GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        PlayerMovementControls();
        PlayerRotate();
    }


    // Movement of player
    public void PlayerMovementControls()

    {
        if (Input.GetKey(KeyCode.A))
        {
           transform.Translate(Vector3.left * PlayerMoveSpeed * Time.deltaTime);
           animator.SetBool("isRunningLeft", true);
        }
        else
        {
            animator.SetBool("isRunningLeft", false);
        }
        
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * PlayerMoveSpeed * Time.deltaTime);
            animator.SetBool("isRunningRight", true);
        }
        else
        {
            animator.SetBool("isRunningRight", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * PlayerMoveSpeed * Time.deltaTime);
            animator.SetBool("isRunningBackwards", true);
        }
        else
        {
            animator.SetBool("isRunningBackwards", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * PlayerMoveSpeed * Time.deltaTime);
            animator.SetBool("isRunningForward", true);
        }
        else
        {
            animator.SetBool("isRunningForward", false);
        }
    }


    // Player rotates towards mouse position
    public void PlayerRotate()
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.transform.position.y));

        transform.LookAt(mousePosition + Vector3.up * transform.position.y);
    }

}
