using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBarController healthBar;
    public GameObject happyAvatar;
    public GameObject sadAvatar;
    private bool hasTracked = false;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void PrintHappyAvatar(bool found)
    {
        if (found)
        {
           Debug.Log("Healthy food found");
            if (!hasTracked) {
                currentHealth = currentHealth - 1;
                healthBar.SetHealth(currentHealth);
                hasTracked = true;
            }
            happyAvatar.SetActive(true);
        }

        else
        {
            Debug.Log("Healthy food lost");
            happyAvatar.SetActive(false);
        }

    }

    public void PrintSadAvatar(bool found)
    {
        if (found)
        {
            Debug.Log("Healthy food found");
            if (!hasTracked)
            {
                currentHealth = currentHealth - 1;
                healthBar.SetHealth(currentHealth);
                hasTracked = true;
            }
            sadAvatar.SetActive(true);
        }

        else
        {
            Debug.Log("Healthy food lost");
            sadAvatar.SetActive(false);
        }

    }
}
