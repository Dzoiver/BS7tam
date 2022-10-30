using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableSphere : MonoBehaviour
{
    public SphereColor color;
    public CheckAround checkScript;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        RandomColor();
    }

    private void RandomColor()
    {
        int rng = Random.Range(0, 3);
        switch (rng)
        {
            case 0:
                color = SphereColor.Blue;
                mat.color = new Color(0, 0, 1);
                checkScript.selfcolor = color;
                break;
            case 1:
                color = SphereColor.Green;
                mat.color = new Color(0, 1, 0);
                checkScript.selfcolor = color;
                break;
            case 2:
                color = SphereColor.Red;
                mat.color = new Color(1, 0, 0);
                checkScript.selfcolor = color;
                break;
        }
    }

    public void Explode()
    {
        checkScript.Explode();
    }

    public bool IsSameColor(SphereColor playerColor)
    {
        if (playerColor == color)
            return true;
        else
            return false;
    }
}
