using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
   private GameObject menu;

    void Start()
    {
        menu = GameObject.Find("Menu");
        menu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            menu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
