using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public bool isJumping;
    public bool isRunning;

    public bool onReverseIsle;

    public float maxHealth = 100;
    public float currentHealth = 0;

    public HealthBar healthBar;

    public int diamondCount;
    public int coinCount;
    public int keyCount;

    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI keyText;


    private void Start()
    {
        onReverseIsle = false;
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
    }


    public void TakeDame(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
