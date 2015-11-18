using UnityEngine;
using System.Collections;

namespace SimpleFramework
{
    public class CustDebug
    {
        public static bool isDebugLog = true;
        public static void Log(object obj)
        {
            if (isDebugLog)
                Debug.Log(obj);
        }
        public static void LogWarning(object obj)
        {
            if (isDebugLog)
                Debug.LogWarning(obj);
        }
        public static void LogError(object obj)
        {
            if (isDebugLog)
                Debug.LogError(obj);
        }
    }
}