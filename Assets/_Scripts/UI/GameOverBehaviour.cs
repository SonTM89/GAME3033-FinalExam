using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverBehaviour : MonoBehaviour
{
    public GameObject WinText;
    public GameObject LoseText;     

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.isDead == false)
        {
            WinText.SetActive(true);
        }
        else
        {
            LoseText.SetActive(true);
        }
    }
}
