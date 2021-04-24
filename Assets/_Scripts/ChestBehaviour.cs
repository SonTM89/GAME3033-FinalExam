using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestBehaviour : MonoBehaviour
{
    public PlayerController player;
    public GameObject Message;
    public GameObject WinText;
    public Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(player.canWin == true)
            {
                Debug.Log("Open");
                _animator.SetBool("IsOpen", true);
                Message.SetActive(false);
                WinText.SetActive(true);

                StartCoroutine(Win("GameOverScene", 2.0f));
            }
        }
    }


    IEnumerator Win(string _name, float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_name);
    }
}
