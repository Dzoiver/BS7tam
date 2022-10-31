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
    int levelIndex = 0;
    int currentBalls = 0;
    bool gameStarted = false;

    public void StartGame()
    {
        currentBalls = levels[levelIndex].Amount;
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

    public void BallDestroyed()
    {
        currentBalls--;
        if (currentBalls <= 0)
            LevelComplete();
        Debug.Log(currentBalls);
    }

    private void LevelComplete()
    {
        if (levelIndex < levels.Length)
        levelIndex++;
        // Victory message then Next button appear
        victory.SetActive(true);
        nextButton.SetActive(true);
        gameStarted = false;
    }
}
