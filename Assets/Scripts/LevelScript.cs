using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    public Grid grid;
    Director dir;
    public int redAmount = 0;
    public int greenAmount = 0;
    public int blueAmount = 0;
    public int Amount = 0;
    void Start()
    {
        Amount = balls.Length;
        dir = FindObjectOfType<Director>();
        for (int i = 0; i < balls.Length; i++)
        {
            KillableSphere script = balls[i].GetComponent<KillableSphere>();
            CalcColors(script.RandomColor());
        }
        dir.currentBalls = Amount;
        dir.redBallsCount = redAmount;
        dir.greenBallsCount = greenAmount;
        dir.blueBallsCount = blueAmount;
    }

    void CalcColors(SphereColor clr)
    {
        if (clr == SphereColor.Red)
            redAmount++;
        if (clr == SphereColor.Green)
            greenAmount++;
        if (clr == SphereColor.Blue)
            blueAmount++;
    }
}
