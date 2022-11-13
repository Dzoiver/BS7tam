using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Director : MonoBehaviour
{
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject gameCompletionMessage;
    [SerializeField] GameObject confetti;
    public LineController lineC;
    [SerializeField] GameObject[] levels;
    [SerializeField] PlayerProjectile player;
    [SerializeField] MainMenu menu;
    public GameObject currentlevel;
    public int redBallsCount = 0;
    public int greenBallsCount = 0;
    public int blueBallsCount = 0;
    public int levelIndex = 0;
    public int currentBalls = 0;
    public bool gameStarted = false;

    public void AcceptColorsInfo(int red, int green, int blue)
    {
        redBallsCount = red;
        greenBallsCount = green;
        blueBallsCount = blue;
    }

    public bool IsRedLeft()
    {
        if (redBallsCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsGreenLeft()
    {
        if (greenBallsCount > 0)
            return true;
        else
            return false;
    }

    public bool IsBlueLeft()
    {
        if (blueBallsCount > 0)
            return true;
        else
            return false;
    }

    public void StartGame()
    {
        confetti.SetActive(false);
        if (levelIndex >= levels.Length)
        {
            menu.BringMenu();
            menu.resumeButton.SetActive(false);
            gameCompletionMessage.SetActive(false);
            levelIndex = 0;
            nextButton.SetActive(false);
            gameStarted = false;
            return;
        }
        Vector3 vect = new Vector3(0.77f, -0.5f, 0);
        currentlevel = Instantiate(levels[levelIndex], vect, Quaternion.identity);
        LevelScript lvlScript = currentlevel.GetComponent<LevelScript>();
        player.InitGrid(lvlScript.grid);
        nextButton.SetActive(false);
        victory.SetActive(false);
        gameStarted = true;
        Sequence seq = DOTween.Sequence();
        seq.PrependInterval(0.1f);
        seq.onComplete = Seq;
    }

    private void Seq()
    {
        lineC.gameObject.SetActive(true);
    }

    public void BallCreated(SphereColor clr)
    {
        if (clr == SphereColor.Red)
            redBallsCount++;
        if (clr == SphereColor.Green)
            greenBallsCount++;
        if (clr == SphereColor.Blue)
            blueBallsCount++;
        currentBalls++;
        Debug.Log(currentBalls);
    }

    public void BallDestroyed(SphereColor clr)
    {
        if (clr == SphereColor.Red)
            redBallsCount--;
        if (clr == SphereColor.Green)
            greenBallsCount--;
        if (clr == SphereColor.Blue)
            blueBallsCount--;

        currentBalls--;
        if (currentBalls <= 0)
            LevelComplete();
        Debug.Log(currentBalls);
    }

    private void LevelComplete()
    {
        Destroy(currentlevel);
        levelIndex++;
        confetti.SetActive(true);
        gameStarted = false;
        lineC.gameObject.SetActive(false);
        nextButton.SetActive(true);
        if (levelIndex <= levels.Length - 1)
        {
            victory.SetActive(true);
        }
        else
        {
            gameCompletionMessage.SetActive(true);
        }
    }
}
