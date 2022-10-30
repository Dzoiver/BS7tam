using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SphereColor
{
    Green = 0,
    Red = 1,
    Blue = 2
}
public class ColorScript
{
    public Color GetColor(SphereColor clr)
    {
        switch (clr)
        {
            case SphereColor.Green:
                return new Color(0, 1, 0, 1);
            case SphereColor.Blue:
                return new Color(0, 0, 1, 1);
            case SphereColor.Red:
                return new Color(1, 0, 0, 1);
        }
        return new Color(0, 0, 0, 1);
    }
}
