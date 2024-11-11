using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Gravity_Right : MonoBehaviour
{
 
    public MoveBall.Movementdir newDir;

    public bool _bool = false;
    //public Transform player;
    //Space.World for Whole Scene Rotation = (x,y,z,Space.World)
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("oikea");
            Physics.gravity = new Vector3(-150.81f, 0, 0);
            MoveBall playerController = other.GetComponent<MoveBall>();
            if (playerController != null)
            {
                playerController.dir = MoveBall.Movementdir.RIGHT;
            }
            if (playerController != null)
            {
                playerController.camRotate = MoveBall.RotateCam.right;

            }

        }
        
    }
  
}
