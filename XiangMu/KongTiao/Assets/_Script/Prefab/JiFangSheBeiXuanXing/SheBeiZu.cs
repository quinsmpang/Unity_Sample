using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

/// <summary>
/// 用于管理单个的设备选择
/// </summary>
public class SheBeiZu : MonoBehaviour
{
    #region 以下变量均为访问方便设置公开, 并不可以在外部赋值
    public bool IsXingHao = false;
    public bool IsNum = false;
    public string XH;
    public int NUM;
    #endregion
    /// <summary>
    /// 接收型号信息
    /// </summary>
    public void SetInputXingHao(string xh)
    {
        IsXingHao = true;
        XH = xh;
        Debugger.Log(xh);
    }
    /// <summary>
    /// 接收数量信息
    /// </summary>
    /// <param name="num"></param>
    public void SetInputNum(string num)
    {
        try
        {
            IsNum = true;
            int nums = int.Parse(num);
            NUM = nums;
            Debugger.Log(nums);
        }
        catch (Exception e)
        {
            Debugger.LogError("输入值有误, 请重新输入数值");
        }
    }
    public void ResetInput()
    {
        transform.FindChild("XingHao").FindChild("XingHaoInput").GetComponent<InputField>().interactable = false;
        transform.FindChild("XingHao").FindChild("XingHaoInput").GetComponent<InputField>().text = "自定义";
        transform.FindChild("ShuLiang").FindChild("ShuLiangInput").GetComponent<InputField>().interactable = false;
        transform.FindChild("ShuLiang").FindChild("ShuLiangInput").GetComponent<InputField>().text = "自定义";
        IsXingHao = false;
        IsNum = false;
        XH = "";
        NUM = 0;
    }
}
