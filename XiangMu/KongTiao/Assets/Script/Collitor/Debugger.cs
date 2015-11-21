using UnityEngine;
using System.Collections;

public class Debugger : MonoBehaviour
{

    public static bool IsDebugger = true;
    /// <summary>
    /// 打印和左上角
    /// </summary>
    /// <param name="obj"></param>
    public static void Log(object obj)
    {
        if (IsDebugger)
        {
            Debug.Log(obj);
            texDebugLog.Instance.SetText(obj);
        }
    }
    /// <summary>
    /// 打印和左上角
    /// </summary>
    /// <param name="obj"></param>
    public static void LogError(object obj)
    {
        if (IsDebugger)
        {
            Debug.LogError(obj);
            texDebugLog.Instance.SetText(obj, "ff0000ff");
        }
    }
    /// <summary>
    /// 左上角
    /// </summary>
    /// <param name="obj"></param>
    public static void LogText(object obj)
    {
        if (IsDebugger)
        {
            texDebugLog.Instance.SetText(obj);
        }
    }
    /// <summary>
    /// 左上角
    /// </summary>
    /// <param name="obj"></param>
    public static void LogErrorText(object obj)
    {
        if (IsDebugger)
        {
            texDebugLog.Instance.SetText(obj, "ff0000ff");
        }
    }
}
