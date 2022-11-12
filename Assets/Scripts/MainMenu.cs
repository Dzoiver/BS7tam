using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] Director dir;
    [SerializeField] GameObject gearButton;
    public GameObject resumeButton;
    [SerializeField] Camera menuCam;
    [SerializeField] Camera gameCam;
    public void StartGame()
    {
        HideMenu();
        resumeButton.SetActive(true);
        gearButton.SetActive(true);
        dir.StartGame();
    }

    public void BringMenu()
    {
        dir.lineC.gameObject.SetActive(false);
        gearButton.SetActive(false);
        gameCam.enabled = false;
        mainMenuPanel.SetActive(true);
        menuCam.enabled = true;
    }

    public void HideMenu()
    {
        dir.lineC.gameObject.SetActive(true);
        gearButton.SetActive(true);
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
