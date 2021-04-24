using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtIsleBehaviour : MonoBehaviour
{
    private float timeCounter;

    public PlayerController player;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Raaaa");

            timeCounter += Time.deltaTime;

            Debug.Log(timeCounter);

            if (timeCounter >= 1.0f && (int)timeCounter % 1 == 0)
            {
                player.TakeDame(2.0f);
                timeCounter = 0.0f;
            }
        }
    }
}
