using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 机房设备选型中的型号选择的Item
/// </summary>
public class XingHaoItem : MonoBehaviour
{
    public Text xingHaoTex;
    public string names;
    void Awake()
    {
        names = xingHaoTex.text;
    }
   
    public void SetName(string str)
    {
        xingHaoTex.text = str;
    }
}
