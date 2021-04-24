using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBehavour : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.diamondCount++;
            Destroy(gameObject);
        }
    }
}
