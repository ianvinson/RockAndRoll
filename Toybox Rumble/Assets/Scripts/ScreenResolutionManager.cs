using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenResolutionManager
{
    private static int width, height;

    public static void setWidth(int w)
    {
        width = w;
    }

    public static void setHeight(int h)
    {
        height = h;
    }

    public static void SetRes()
    {
        Screen.SetResolution(width, height, false);
    }
}
