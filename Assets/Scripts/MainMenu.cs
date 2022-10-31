using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] LineController lineC;
    [SerializeField] Camera menuCam;
    [SerializeField] Camera gameCam;
    public void StartGame()
    {
        lineC.StartGame();
        menuCam.enabled = false;
        gameCam.enabled = true;
        mainMenuPanel.SetActive(false);
    }

    public void OpenLevelSelection()
    {

    }

    public void SelectLevel()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
