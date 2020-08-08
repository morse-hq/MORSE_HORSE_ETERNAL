using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : ScriptableObject
{
    public static bool isTimeStopped = false;

    public void setTimeStopped(bool newTimeStopped)
    {
        isTimeStopped = newTimeStopped;
    }

    public void toggleTimeStopped()
    {
        isTimeStopped = !isTimeStopped;
    }

    public bool getIsTimeStopped()
    {
        return isTimeStopped;
    }
}
