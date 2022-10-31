using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    public int Amount = 0;
    void Start()
    {
        Amount = balls.Length;
        Debug.Log(Amount + " - balls count");

        for (int i = 0; i < balls.Length; i++)
        {
            KillableSphere script = balls[i].GetComponent<KillableSphere>();
            script.RandomColor();
        }
    }
}
