using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
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

}
