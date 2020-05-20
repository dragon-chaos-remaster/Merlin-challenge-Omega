﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Pause pauseMenu;
    [SerializeField] GameObject showControls;
    void Despausar()
    {
        Pause.pausado = false;
        pauseMenu.pauseBox.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Escape))
        {
            showControls.SetActive(false);
        }
    }
    public void CheckButtonTagOnClick(GameObject botao)
    {
        if (Pause.pausado)
        {
            switch (botao.tag)
            {
                case "Resume":
                    Despausar();
                    break;
                case "Options":
                    Debug.LogWarning("NO OPTIONS SETTINGS HERE");
                    break;
                case "Controls":
                    showControls.SetActive(true);
                    break;
                case "Quit":
                    Debug.LogWarning("Are You Sure You Wanna QUIT?");
                    Application.Quit();
                    break;
            }
        }
    }

}
