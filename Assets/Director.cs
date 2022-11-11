using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Director : MonoBehaviour
{
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject victory;
    [SerializeField] LineController lineC;
    [SerializeField] LevelScript[] levels;
    [SerializeField] GameObject level;
    [SerializeField] PlayerProjectile player;
    public int redBallsCount = 0;
    public int greenBallsCount = 0;
    public int blueBallsCount = 0;
    int levelIndex = 0;
    public int currentBalls = 0;
    public bool gameStarted = false;

    public void AcceptColorsInfo(int red, int green, int blue)
    {
        redBallsCount = red;
        greenBallsCount = green;
        blueBallsCount = blue;

        Debug.Log("red: " + redBallsCount);
        Debug.Log("green: " + greenBallsCount);
        Debug.Log("blue: " + blueBallsCount);
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
        Vector3 vect = new Vector3(0.77f, -0.5f, 0);
        GameObject lvl = Instantiate(level, vect, Quaternion.identity);
        LevelScript lvlScript = lvl.GetComponent<LevelScript>();
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
        if (levelIndex < levels.Length - 1)
        levelIndex++;
        victory.SetActive(true);
        nextButton.SetActive(true);
        gameStarted = false;
        lineC.gameObject.SetActive(false);
    }
}
