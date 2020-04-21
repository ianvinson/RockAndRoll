using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    public void set1920x1080()
    {
        ScreenResolutionManager.setWidth(1920);
        ScreenResolutionManager.setHeight(1080);
        ScreenResolutionManager.SetRes();
    }
    public void set1280x720()
    {
        ScreenResolutionManager.setWidth(1280);
        ScreenResolutionManager.setHeight(720);
        ScreenResolutionManager.SetRes();
    }
    public void set1366x768()
    {
        ScreenResolutionManager.setWidth(1366);
        ScreenResolutionManager.setHeight(768);
        ScreenResolutionManager.SetRes();
    }
}
