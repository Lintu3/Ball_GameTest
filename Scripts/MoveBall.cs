

// This script moves a game object left, right, forwards, backwards...
// using input from keyboard/gamepad (set in the Input Manager)
// 'Update' Method is used for the Input (keyboard/Gamepad)
// 'Fixed' Method is used for physics movement
// The Input is 'Normalized' to prevent faster diagonal movement
// 'Time.fixedDeltaTime' is used to keep the physics framrate consistant on all devices

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    // Add the variables
    public float speed = 300f; // Speed variable
    public Rigidbody rb; // Set the variable 'rb' as Rigibody
    public Vector3 movement; // Set the variable 'movement' as a Vector3 (x,y,z)
    public Camera cam;
    public Movementdir dir = Movementdir.UP;
    public RotateCam camRotate = RotateCam.up;
    public float distanceFromPlayer = 5f; // Adjust as needed
    public Vector3 jump = new Vector3(0.0f, 20f, 0.0f); // Adjust the jump direction
    public float jumpForce = 2000f;
    public bool Grounded;


    // 'Start' Method run once at start for initialisation purposes
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();   
        Physics.gravity = new Vector3(0, -150.81f, 0);
        
        
}



    // 'Update' Method is called once per frame
    void Update()
    {
        
        if (dir == Movementdir.UP)
        {
            Debug.Log("TOp liikkuu");
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            jump = new Vector3(0.0f, 20f, 0.0f);
        }
        if (dir == Movementdir.DOWN)
        {
            Debug.Log("Bottom liikkuu");
            movement = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")).normalized;
            jump = new Vector3(0.0f, -20f, 0.0f);
        }
        if (dir == Movementdir.LEFT)
        {
            Debug.Log("Vasen liikkuu");
            movement = new Vector3(0, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            jump = new Vector3(-20f, 0f, 0f);
        }
        if (dir == Movementdir.RIGHT)
        {
            Debug.Log("oikee liikkuu");
            movement = new Vector3(0, -Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            jump = new Vector3(20f, 0f, 0f);
        }

        if (dir == Movementdir.FORWARD)
        {
            Debug.Log("Etu liikkuu");
            movement = new Vector3(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"), 0).normalized;
            jump = new Vector3(0f, 0f, 20f);

        }
        if (dir == Movementdir.BACK)
        {
            Debug.Log("taka liikkuu");
            movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
            jump = new Vector3(0f, 0f, -20f);

        }

        // Apply the rotation to the camera
        Quaternion gravityRotation = Quaternion.FromToRotation(Vector3.up, -Physics.gravity);
        if (camRotate == RotateCam.down)
        {
            gravityRotation = Quaternion.FromToRotation(Vector3.down, -Physics.gravity);
        }
        
        cam.transform.rotation = gravityRotation;
        Vector3 targetPosition = rb.position + gravityRotation * Vector3.back * distanceFromPlayer;
        cam.transform.position = targetPosition;
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            Grounded = false;
        }
    }

    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
       moveCharacter(movement);
    }

    // 'moveCharacter' Function for moving the game object
    void moveCharacter(Vector3 direction)
    {

        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.collider.tag == "canjump" )
        {
            Grounded = true;
        }
    }


    public enum Movementdir
    {
        UP, DOWN,
        LEFT, RIGHT,
        FORWARD, BACK
    }


    //Tis is enum for camRotate
    public enum RotateCam
    {
        up,
        down,
        left,
        right,
        front,
        back
    }

}
        //camRotate is in all triggerscripts... Can be used if needed to manipulate something as the gravity changes.
       
/*
        if (camRotate == RotateCam.up) 
        { 
            cam.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            cam.transform.position = new Vector3(0, 0, -5); 
        }
        if (camRotate == RotateCam.left) 
        {
            cam.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            cam.transform.position = new Vector3(0, 0, -5);
        }
        if (camRotate == RotateCam.right) 
        {
            cam.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            cam.transform.position = new Vector3(0, 0, -5);
        }
        if (camRotate == RotateCam.down) 
        { 
            cam.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            cam.transform.position = new Vector3(0, 0, -5); 
        }
            if (camRotate == RotateCam.front)
        {
            cam.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            cam.transform.position = new Vector3(0, 5, 0);
        }
        if (camRotate == RotateCam.back)
        {
            cam.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
            cam.transform.position = new Vector3(0, -5, 0);
        }
        */





    

