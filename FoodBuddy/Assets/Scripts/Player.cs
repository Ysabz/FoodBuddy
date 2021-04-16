using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int maxHealth = 20;
    public int maxXP = 100;
    public int currentHealth;
    public int currentXP;
    public int currentLevel;

    public TextAsset file;
    public GameObject level;
    public HealthBarController healthBar;
    public XPBarController XPBar;
    public GameObject happyAvatar;
    public GameObject sadAvatar;

    private void Start()
    {
        string path = Application.persistentDataPath + "\\PlayerData.txt";
        if (File.Exists(path))
        {
            StreamReader file = new StreamReader(path);
            string data = file.ReadLine();
            currentLevel = Int32.Parse(data.Split(';')[0]);
            currentHealth = Int32.Parse(data.Split(';')[1]);
            currentXP = Int32.Parse(data.Split(';')[2]);
            DateTime saveTime = DateTime.Parse(data.Split(';')[3]);
            if ((DateTime.Now - saveTime).TotalDays >= 1)
            {
                currentHealth = currentHealth - 2;
            }
        }
        else
        {
            StreamWriter file = File.CreateText(path);
            file.WriteLine("1;20;0;" + DateTime.Now);
            file.Close();
            currentHealth = maxHealth;
            currentXP = 0;
            currentLevel = 1;
        }
        XPBar.SetMaxXP(maxXP);
        healthBar.SetMaxHealth(maxHealth);
        XPBar.SetXP(currentXP);
        healthBar.SetHealth(currentHealth);
        level.GetComponent<TextMeshProUGUI>().SetText("LVL " + currentLevel);

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
                currentXP = 0;
                XPBar.SetXP(currentXP);
                level.GetComponent<TextMeshProUGUI>().SetText("LVL " + currentLevel);
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
                currentLevel = 0;
                currentXP = 0;
                currentHealth = maxHealth;
                XPBar.SetXP(currentXP);
                healthBar.SetHealth(currentHealth);
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

    public void OnApplicationQuit()
    {
        Debug.Log("Hello");
        string data = currentLevel + ";" + currentHealth + ";" + currentXP + ";" + DateTime.Now;
        File.WriteAllText(Application.persistentDataPath + "\\PlayerData.txt", data);
    }
}
