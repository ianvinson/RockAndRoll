using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeterminePlayerCharacter
{
    private static int skeletonNum;
    private static int robotNum;

    public static void setNum(int n)
    {
        if (n == 0)
        {
            skeletonNum = 0;
            robotNum = 1;
        }
        if (n == 1)
        {
            skeletonNum = 1;
            robotNum = 0;
        }
    }

    public static int getSkeletonNum()
    {
       return skeletonNum;
    }
    public static int getRobotNum()
    {
        return robotNum;
    }
}
