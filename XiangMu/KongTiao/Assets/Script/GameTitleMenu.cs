using UnityEngine;
using System.Collections;
/// <summary>
/// 响应标题栏的UI
/// </summary>
public class GameTitleMenu : MonoBehaviour
{

    public GameObject shouYeBtn;
    public GameObject zhangHuMingBtn;
    public GameObject bangZhuBtn;
    public GameObject sheZhiBtn;
    public GameObject tuiChuBtn;
    // Use this for initialization
    void Start()
    {
        UGUIEventTriggerListener.Get(shouYeBtn).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(zhangHuMingBtn).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(bangZhuBtn).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(sheZhiBtn).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(tuiChuBtn).onClick += ButtonOnClick;
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 响应对应的UI按钮
    /// </summary>
    /// <param name="btn"></param>
    void ButtonOnClick(GameObject btn)
    {
        if (btn == shouYeBtn)
        {
            GameSceneUI.Instance.ChangeYeMian("shouye");
            Debugger.Log("首页");
        }
        if (btn == zhangHuMingBtn)
        {
            Debugger.Log("账户名");
        }
        if (btn == bangZhuBtn)
        {
            Debugger.Log("帮助");
        }
        if (btn == sheZhiBtn)
        {
            Debugger.Log("设置");
        }
        if (btn == tuiChuBtn)
        {
            Debugger.Log("退出");
            Application.Quit();
        }
    }
}