using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
    bool isKeyPressed = false;
    public GameObject MenuPanel, StartPanel;

    // Update is called once per frame
    void Update()
    {
       if(!isKeyPressed && Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            isKeyPressed = true;
            MenuPanel.SetActive(true);
            StartPanel.SetActive(false);
        } 
    }
}
