using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class JournalManager : MonoBehaviour
{

    public AudioSource audio;
    public GameObject[] pages;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

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

    public void IncrementPage()
    {
        audio.Play();
        if (counter < pages.Length - 1)
        {
            counter++;
            pages[counter - 1].SetActive(false);
            pages[counter].SetActive(true);
        }
    }

    public void DecrementPage()
    {
        audio.Play();
        if (counter > 0)
        {
            counter--;
            pages[counter + 1].SetActive(false);
            pages[counter].SetActive(true);
        }
    }

}
