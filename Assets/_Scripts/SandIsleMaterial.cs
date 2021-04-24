using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandIsleMaterial : MonoBehaviour
{
    public MovementComponent playerMovement;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Slow");
            playerMovement.walkSpeed /= 2;
            playerMovement.runSpeed /= 2;
            //playerMovement.jumpForce /= 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Normal");
            playerMovement.walkSpeed *= 2;
            playerMovement.runSpeed *= 2;
            //playerMovement.jumpForce *= 2;
        }
    }
}
