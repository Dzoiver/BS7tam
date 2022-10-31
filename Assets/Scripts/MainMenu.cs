using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] Director dir;
    [SerializeField] Camera menuCam;
    [SerializeField] Camera gameCam;
    public void StartGame()
    {
        menuCam.enabled = false;
        gameCam.enabled = true;
        mainMenuPanel.SetActive(false);
        dir.StartGame();
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
