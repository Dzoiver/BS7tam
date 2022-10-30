using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableSphere : MonoBehaviour
{
    SphereColor color;
    MeshRenderer mesh;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        InitColor();
    }

    private void InitColor()
    {
        int rng = Random.Range(0, 3);
        switch (rng)
        {
            case 0:
                color = SphereColor.Blue;
                mat.color = new Color(0, 0, 1);
                break;
            case 1:
                color = SphereColor.Green;
                mat.color = new Color(0, 1, 0);
                break;
            case 2:
                color = SphereColor.Red;
                mat.color = new Color(1, 0, 0);
                break;
        }
    }

    public void SearchAround()
    {

    }

    public bool IsSameColor(SphereColor playerColor)
    {
        if (playerColor == color)
        {
            Destroy(gameObject);
            SearchAround();
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
