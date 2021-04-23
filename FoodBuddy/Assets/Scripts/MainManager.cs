using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public Player player;


    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            if (player != null)
            {
                string data = player.currentLevel + ";" + player.currentHealth + ";" + player.currentXP + ";" + DateTime.Now;
                File.WriteAllText(Application.persistentDataPath + "\\PlayerData.txt", data);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (player != null)
                {
                    string data = player.currentLevel + ";" + player.currentHealth + ";" + player.currentXP + ";" + DateTime.Now;
                    File.WriteAllText(Application.persistentDataPath + "\\PlayerData.txt", data);
                }
                SceneManager.LoadScene("Menu");
            }

        }
    }
}
