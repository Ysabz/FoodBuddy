using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource audio;
    private bool changeScene = false;
    private string scene;

    public void LoadScene(string scene)
    {
        audio.Play();
        changeScene = true;
        this.scene = scene;
    }

    public void Update()
    {
        if (changeScene && !audio.isPlaying)
        {
            SceneManager.LoadScene(scene);
        }
       
    }
}
