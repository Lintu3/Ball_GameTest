using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Gravity_Front : MonoBehaviour
{

    public MoveBall.Movementdir newDir;

    public bool _bool = false;
    //public Transform player;
    //Space.World for Whole Scene Rotation = (x,y,z,Space.World)
   
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("etu");
            Physics.gravity = new Vector3(0, 0, -150.81f);
            MoveBall playerController = other.GetComponent<MoveBall>();
            if (playerController != null)
            {
                playerController.dir = MoveBall.Movementdir.FORWARD;
            }
            

        }

    }
 
}