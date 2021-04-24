using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public bool isJumping;
    public bool isRunning;
    public static bool isDead;

    public bool onReverseIsle;
    public bool canWin;

    public float maxHealth = 100;
    public float currentHealth = 0;

    public HealthBar healthBar;

    public int diamondCount;
    public int coinCount;
    public int keyCount;

    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI keyText;

    public GameObject Message;
    public GameObject chestLock;
    public GameObject chestFrameTop;


    private void Start()
    {
        isDead = false;
        onReverseIsle = false;
        canWin = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        diamondCount = 0;
        coinCount = 0;
        keyCount = 0;
    }


    private void Update()
    {
        diamondText.text = diamondCount.ToString();
        coinText.text = coinCount.ToString();
        keyText.text = keyCount.ToString();

        if(canWin == false)
        {
            if (diamondCount == 5 && coinCount == 8 && keyCount == 3)
            {
                canWin = true;
                chestLock.SetActive(false);
                chestFrameTop.SetActive(false);
                Message.SetActive(true);
            }
        }

        if(currentHealth <= 0)
        {
            isDead = true;
            SceneManager.LoadScene("GameOverScene");
        }
    }


    public void TakeDame(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
