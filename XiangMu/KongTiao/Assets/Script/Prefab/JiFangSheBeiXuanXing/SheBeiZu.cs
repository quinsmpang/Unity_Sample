using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 用于管理单个的设备选择
/// </summary>
public class SheBeiZu : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// 接收型号信息
    /// </summary>
    public void SetInputXingHao(string xh)
    {
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
           // Debugger.Log(num);
            int nums = int.Parse(num);
            Debugger.Log(nums);
        }
        catch (Exception e)
        {
            Debugger.LogError("输入值有误, 请重新输入数值");
        }
    }
}
