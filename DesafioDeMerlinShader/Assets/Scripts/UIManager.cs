using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Pause pauseMenu;
    [SerializeField] GameObject controls;
    void Despausar()
    {
        Pause.pausado = false;
        pauseMenu.pauseBox.SetActive(false);
        Time.timeScale = 1;
    }
    void ShowControls()
    {
        controls.SetActive(true);
    }
    void HideControls()
    {
        controls.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            HideControls();
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
                case "Quit":
                    Debug.LogWarning("Are You Sure You Wanna QUIT?");
                    Application.Quit();
                    break;
                case "Controls":
                    ShowControls();
                    iTween.PunchScale(controls.gameObject,iTween.Hash("z", 10f, "y", 0.5f, "amount", botao.transform.localScale, "time", 1f, "ignoretimescale", true));
                    iTween.PunchScale(pauseMenu.gameObject, iTween.Hash("z", 10f, "y", 0.5f, "amount", botao.transform.localScale, "time", 1f, "ignoretimescale", true));
                    Debug.LogWarning("Controls ON");
                    break;
            }
        }
    }

}
