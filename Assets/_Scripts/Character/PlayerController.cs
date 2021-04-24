using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isJumping;
    public bool isRunning;

    public bool onReverseIsle;

    public float maxHealth = 100;
    public float currentHealth = 0;

    public HealthBar healthBar;


    private void Start()
    {
        onReverseIsle = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    private void Update()
    {
        
    }


    public void TakeDame(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
