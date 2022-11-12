using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableSphere : MonoBehaviour
{
    public SphereColor ballColor;
    public CheckAround checkScript;
    Director dir;
    [SerializeField] MeshRenderer mesh;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        dir = FindObjectOfType<Director>();
    }

    private void Awake()
    {
        mat = mesh.material;
    }

    private void OnDestroy()
    {
        dir.BallDestroyed(ballColor);
        PlayerProjectile player = FindObjectOfType<PlayerProjectile>();
        player.InitColor();
    }

    public void SetColor(SphereColor color)
    {
        if (color == SphereColor.Blue)
        {
            ballColor = SphereColor.Blue;
            mat.color = new Color(0, 0, 1);
            checkScript.selfcolor = color;
        }

        if (color == SphereColor.Green)
        {
            ballColor = SphereColor.Green;
            mat.color = new Color(0, 1, 0);
            checkScript.selfcolor = color;
        }

        if (color == SphereColor.Red)
        {
            ballColor = SphereColor.Red;
            mat.color = new Color(1, 0, 0);
            checkScript.selfcolor = color;
        }
        checkScript.gameObject.SetActive(true);
    }

    public SphereColor RandomColor()
    {
        int rng = Random.Range(0, 3);
        switch (rng)
        {
            case 0:
                SetColor(SphereColor.Blue);
                return SphereColor.Blue;
            case 1:
                SetColor(SphereColor.Green);
                return SphereColor.Green;
            case 2:
                SetColor(SphereColor.Red);
                return SphereColor.Red;
        }
        return SphereColor.Green;
    }

    public bool IsSameColor(SphereColor playerColor)
    {
        if (playerColor == ballColor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
