using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public Player player;
    public void NextScene(string scene)
    {
        if(player != null)
        {
            string data = player.currentLevel + ";" + player.currentHealth + ";" + player.currentXP + ";" + DateTime.Now;
            File.WriteAllText(Application.persistentDataPath + "\\PlayerData.txt", data);
        }
        SceneManager.LoadScene(scene);
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }

        }
    }
}
