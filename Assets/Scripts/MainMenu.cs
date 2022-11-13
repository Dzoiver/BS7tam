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

    [SerializeField] GameObject levelSelectionPanel;
    public void NewGame(int level = 0)
    {
        Destroy(dir.currentlevel);
        dir.levelIndex = level;
        HideMenuOpenGame();
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
        levelSelectionPanel.SetActive(false);
    }

    public void HideMenuOpenGame()
    {
        dir.lineC.gameObject.SetActive(true);
        gearButton.SetActive(true);
        menuCam.enabled = false;
        gameCam.enabled = true;
        mainMenuPanel.SetActive(false);
        levelSelectionPanel.SetActive(false);
    }

    public void OpenLevelSelection()
    {
        mainMenuPanel.SetActive(false);
        levelSelectionPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
