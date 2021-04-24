using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBehavour : MonoBehaviour
{
    public PlayerController player;

    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            player.diamondCount++;
            Destroy(gameObject);
        }
    }
}
