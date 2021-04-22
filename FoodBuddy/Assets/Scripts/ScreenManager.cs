using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public Canvas infoWindow;
    public GameObject textUI;
    public GameObject titleUI;
    public Button red;
    public Button green;
    public Button yellow;
    public Button healthyDrink1;
    public Button healthyDrink2;
    public Button healthyDrink3;

    // Start is called before the first frame update
    void Start()
    {
        red.onClick.AddListener(() => OpenInfoWindow("Badge awarded for eating 10 red healthy foods during one month", "Healthy Red Champion"));
        green.onClick.AddListener(() => OpenInfoWindow("Badge awarded for eating 10 green healthy foods during one month", "Healthy Green Champion"));
        yellow.onClick.AddListener(() => OpenInfoWindow("Badge awarded for eating 10 yellow healthy foods during one month", "Healthy Yellow Champion"));
        healthyDrink1.onClick.AddListener(() => OpenInfoWindow("Badge awarded for drinking 10 yellow healthy drinks during one month", "Yellow Potion Champion"));
        healthyDrink2.onClick.AddListener(() => OpenInfoWindow("Badge awarded for drinking 10 green healthy drinks during one month", "Green Potion Champion"));
        healthyDrink3.onClick.AddListener(() => OpenInfoWindow("Badge awarded for drinking 10 orange healthy drinks during one month", "Orange Potion Champion"));
    }

    public void OpenInfoWindow(string text, string title)
    {
        textUI.GetComponent<TextMeshProUGUI>().text = text;
        titleUI.GetComponent<TextMeshProUGUI>().text = title;
        infoWindow.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        // Check if there is a touch
        if (infoWindow.gameObject.activeSelf && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            infoWindow.gameObject.SetActive(false);
        }
    }


}
