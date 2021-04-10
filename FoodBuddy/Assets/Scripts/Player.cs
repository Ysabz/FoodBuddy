using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int maxHealth = 20;
    public int maxXP = 100;
    public int currentHealth;
    public int currentXP;
    public int currentLevel;

    public GameObject level;
    public HealthBarController healthBar;
    public XPBarController XPBar;
    public GameObject happyAvatar;
    public GameObject sadAvatar;

    private void Start()
    {
        currentHealth = maxHealth;
        currentXP = maxXP;
        currentLevel = 1;
        XPBar.SetMaxXP(maxXP);
        healthBar.SetMaxHealth(maxHealth);
        level.GetComponent<TextMeshPro>().SetText("LVL 1");
    }

    public void PrintHappyAvatar(bool found)
    {
        if (found)
        {
            if (!healthBar.IsMax())
            {
                currentHealth = currentHealth + 1;
                healthBar.SetHealth(currentHealth);
            }
            if (!XPBar.IsMax())
            {
                currentXP = currentXP + 5;
                XPBar.SetXP(currentXP);
            }

            else
            {
                currentLevel = currentLevel + 1;
                level.GetComponent<TextMeshPro>().SetText("LVL " + currentLevel);
            }

            happyAvatar.SetActive(true);
        }

        else
        {
            happyAvatar.SetActive(false);
        }

    }

    public void PrintSadAvatar(bool found)
    {
        if (found)
        {

            if (healthBar.IsMin())
            {
                Debug.Log("Robot died");
                // death
            }
            else
            {
                currentHealth = currentHealth - 1;
                healthBar.SetHealth(currentHealth);
            }
            sadAvatar.SetActive(true);
        }

        else
        {
            sadAvatar.SetActive(false);
        }

    }
}
