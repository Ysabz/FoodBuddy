using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBarController healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void Print(bool found)
    {
        if (found)
        {
           Debug.Log("Healthy food found");
            currentHealth = currentHealth - 2;
            healthBar.SetHealth(currentHealth - 2);
        }

        else
        {
            Debug.Log("Healthy food lost");
            currentHealth = currentHealth - 2;
            healthBar.SetHealth(currentHealth - 2);
        }

    }


}
