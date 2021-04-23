using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JournalManager : MonoBehaviour
{
    public GameObject[] pages;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void incrementPage()
    {
        if (counter < pages.Length - 1)
        {
            counter++;
            pages[counter - 1].SetActive(false);
            pages[counter].SetActive(true);
        }
    }

    public void decrementPage()
    {
        if (counter > 0)
        {
            counter--;
            pages[counter + 1].SetActive(false);
            pages[counter].SetActive(true);
        }
    }

}
