using System;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Player player;
    public GameObject journalInfo;
    public AudioSource audio1;
    public Color pushedColor;


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


    public void OpenJournalWindow()
    {
        audio1.Play();
        journalInfo.gameObject.SetActive(true);
    }

    public void ChangeButtonColor(Button button)
    {
        audio1.Play();
        if (button.GetComponent<Image>().color.Equals(Color.white))
        {
            button.GetComponent<Image>().color = pushedColor;
        }
        else
        {
            button.GetComponent<Image>().color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Check if there is a touch
        if (journalInfo.gameObject.activeSelf && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Check if finger is over a UI element
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                journalInfo.gameObject.SetActive(false);
            }
           
        }

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
