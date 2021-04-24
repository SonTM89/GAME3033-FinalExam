using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseIsleBehaviour : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Reverse");
            player.onReverseIsle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Normal");
            player.onReverseIsle = false;
        }
    }
}
