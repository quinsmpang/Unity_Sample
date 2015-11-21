﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 用来控制二级界面的隐藏和显示, 标题栏的名称显示
/// </summary>
public class GameSceneUI : MonoBehaviour {
    private static GameSceneUI _instance;
    public static GameSceneUI Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = GameObject.Find("GameSceneUI").GetComponent<GameSceneUI>();
            }
            return _instance;
        }
    }


    /// <summary>
    /// 标题
    /// </summary>
    public GameObject titleUI;
    /// <summary>
    /// 标题显示
    /// </summary>
    public Text titleNameUI;
    /// <summary>
    /// 首页UI
    /// </summary>
    public GameObject shouYeUI;
    /// <summary>
    /// 二级界面
    /// </summary>
    public GameObject shengChanShiXiUI;
    /// <summary>
    /// 机房总体设计
    /// </summary>
    public GameObject JiFangSheJiSceneUI;

    /// <summary>
    /// 临时变量, 用来记录当前需要显示的是那一个页面
    /// </summary>
    private GameObject tempGameYeMian;
    void Awake()
    {
        tempGameYeMian = shouYeUI;
        tempGameYeMian.SetActive(true);
    }
    /// <summary>
    /// 接收需要替换的界面
    /// shouye==>>首页
    /// shengchanshixi==>>生产实习
    /// jifangsheji==>>机房总体设计
    /// </summary>
    /// <param name="str"></param>
    public void ChangeYeMian(string str)
    {
        tempGameYeMian.SetActive(false);
        titleNameUI.text = "建筑环境与能源应用资源库";
        switch (str)
        {
            case "shouye":
                tempGameYeMian = shouYeUI;
                break;
            case "shengchanshixi":
                tempGameYeMian = shengChanShiXiUI;
                titleNameUI.text = "建筑环境与能源应用--  中央空调企业案例";
                break;
            case "jifangsheji":
                tempGameYeMian = JiFangSheJiSceneUI;
                titleNameUI.text = "建筑环境与能源应用资源库";
                break;
        }
        tempGameYeMian.SetActive(true);
    }
}