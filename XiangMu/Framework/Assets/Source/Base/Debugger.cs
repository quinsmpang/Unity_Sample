using UnityEngine;
using System.Collections;

public static class Debugger
{
    public static bool IsDebug = true;
    public static void Log(string str, params object[] args)
    {
        str = string.Format(str, args);
        if (IsDebug)
            Debug.Log(str);
    }

    public static void LogWarning(string str, params object[] args)
    {
        str = string.Format(str, args);
        if (IsDebug)
            Debug.LogWarning(str);
    }

    public static void LogError(string str, params object[] args)
    {
        str = string.Format(str, args);
        if (IsDebug)
            Debug.LogError(str);
    }
}
