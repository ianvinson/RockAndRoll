using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetMenuItems
{
    private static string levelName;
    private static string menuName;

    public static void setLevelName(string str)
    {
        levelName = str;
    }

    public static string getLevelName()
    {
        return levelName;
    }
    public static void setMenuName(string str)
    {
        menuName = str;
    }

    public static string getMenuName()
    {
        return menuName;
    }
}
