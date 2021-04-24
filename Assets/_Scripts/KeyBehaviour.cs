using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class KeyBehaviour : MonoBehaviour
{
    public PlayerController player;

    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            player.keyCount++;
            Destroy(gameObject);
        }
    }
}
