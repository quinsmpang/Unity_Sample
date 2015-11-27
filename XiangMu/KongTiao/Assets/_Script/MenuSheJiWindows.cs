using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 本脚本用于机房设计中的菜单栏控制, 点击响应的菜单将控制不同的页面出现
/// </summary>
public class MenuSheJiWindows : MonoBehaviour
{
    #region 按钮
    /// <summary>
    /// 图纸查看
    /// </summary>
    public GameObject TuZhiChaKanBtn;
    /// <summary>
    /// 相关计算
    /// </summary>
    public GameObject XiangGuanJiSuanBtn;
    /// <summary>
    /// 设备选型
    /// </summary>
    public GameObject SheBeiXuanXingBtn;
    /// <summary>
    /// 机房布置
    /// </summary>
    public GameObject JiFangBuZhiBtn;
    /// <summary>
    /// 布置查错
    /// </summary>
    public GameObject BuZhiChaCuoBtn;
    /// <summary>
    /// 系统运行
    /// </summary>
    public GameObject XiTongYunXingBtn;
    /// <summary>
    /// 典型故障
    /// </summary>
    public GameObject DianXingGuZhangBtn;

    #endregion
    #region 页面
    /// <summary>
    /// 图纸查看
    /// </summary>
    public GameObject TuZhiChaKanWin;
    /// <summary>
    /// 相关计算
    /// </summary>
    public GameObject XiangGuanJiSuanWin;
    /// <summary>
    /// 设备选型
    /// </summary>
    public GameObject SheBeiXuanXingWin;
    /// <summary>
    /// 机房布置
    /// </summary>
    public GameObject JiFangBuZhiWin;
    /// <summary>
    /// 布置查错
    /// </summary>
    public GameObject BuZhiChaCuoWin;
    /// <summary>
    /// 系统运行
    /// </summary>
    public GameObject XiTongYunXingWin;
    /// <summary>
    /// 典型故障
    /// </summary>
    public GameObject DianXingGuZhangWin;
    #endregion

    private GameObject tempWin;
    // Use this for initialization
    void Start()
    {
        UGUIEventTriggerListener.Get(TuZhiChaKanBtn).onClick += ToggleOnClick;
        UGUIEventTriggerListener.Get(XiangGuanJiSuanBtn).onClick += ToggleOnClick;
        UGUIEventTriggerListener.Get(SheBeiXuanXingBtn).onClick += ToggleOnClick;
        UGUIEventTriggerListener.Get(JiFangBuZhiBtn).onClick += ToggleOnClick;
        UGUIEventTriggerListener.Get(BuZhiChaCuoBtn).onClick += ToggleOnClick;
        UGUIEventTriggerListener.Get(XiTongYunXingBtn).onClick += ToggleOnClick;
        UGUIEventTriggerListener.Get(DianXingGuZhangBtn).onClick += ToggleOnClick;
    }
    void ToggleOnClick(GameObject _tog)
    {
        GameSceneUI.Instance.SetActiveFirstMan(JiFangBuZhiBtn.GetComponent<Toggle>().isOn);
        if (tempWin != null)
        {
            tempWin.SetActive(false);
        }
        //-----------------------------------------
        if (_tog == TuZhiChaKanBtn)
        {
            ChangeTempWin(TuZhiChaKanWin, TuZhiChaKanBtn);
        }
        if (_tog == XiangGuanJiSuanBtn)
        {
            ChangeTempWin(XiangGuanJiSuanWin, XiangGuanJiSuanBtn);
        }
        if (_tog == SheBeiXuanXingBtn)
        {
            ChangeTempWin(SheBeiXuanXingWin, SheBeiXuanXingBtn);
        }
        if (_tog == JiFangBuZhiBtn)
        {
            ChangeTempWin(JiFangBuZhiWin, JiFangBuZhiBtn);
            JiFangBuZhiWin.GetComponent<JiFangBuZhiWin>().JFBZ(true);
        }
        if (_tog == BuZhiChaCuoBtn)
        {
            ChangeTempWin(JiFangBuZhiWin, BuZhiChaCuoBtn);
            JiFangBuZhiWin.GetComponent<JiFangBuZhiWin>().JFBZ(false);
        }
        if (_tog == XiTongYunXingBtn)
        {
            ChangeTempWin(XiTongYunXingWin, XiTongYunXingBtn);
        }
        if (_tog == DianXingGuZhangBtn)
        {
            ChangeTempWin(DianXingGuZhangWin, DianXingGuZhangBtn);
        }
        //TuZhiChaKanWin.SetActive(_tog == TuZhiChaKanBtn);
        //XiangGuanJiSuanWin.SetActive(_tog == XiangGuanJiSuanBtn);
        //SheBeiXuanXingWin.SetActive(_tog == SheBeiXuanXingBtn);
        //JiFangBuZhiWin.SetActive(_tog == JiFangBuZhiBtn);
        //BuZhiChaCuoWin.SetActive(_tog == BuZhiChaCuoBtn);
        //BuZhiChaCuoWin.SetActive(_tog == XiTongYunXingBtn);
        //DianXingGuZhangWin.SetActive(_tog == DianXingGuZhangBtn);

    }
    void ChangeTempWin(GameObject go,GameObject to)
    {
        if (tempWin != go)
        {
            tempWin = go;
            tempWin.SetActive(true);
            Debugger.Log(tempWin.gameObject.name);
        }
        else
        {
            tempWin = null;
            to.GetComponent<Toggle>().isOn = false;
        }
        if (to == BuZhiChaCuoBtn || to == JiFangBuZhiBtn)
        {
            //tempWin = go;
            //if (!to.GetComponent<Toggle>().isOn)
            //{
                
            //    tempWin.SetActive(true);
            //    to.GetComponent<Toggle>().isOn = true;
            //}
            //else
            //{
            //    tempWin.SetActive(false);
            //    to.GetComponent<Toggle>().isOn = false;
            //}
            tempWin = go;
            tempWin.SetActive(true);
            to.GetComponent<Toggle>().isOn = true;
        }
    }
    public void FalseToggle()
    {
        TuZhiChaKanBtn.GetComponent<Toggle>().isOn = false;
        XiangGuanJiSuanBtn.GetComponent<Toggle>().isOn = false;
        SheBeiXuanXingBtn.GetComponent<Toggle>().isOn = false;
        JiFangBuZhiBtn.GetComponent<Toggle>().isOn = false;
        BuZhiChaCuoBtn.GetComponent<Toggle>().isOn = false;
        XiTongYunXingBtn.GetComponent<Toggle>().isOn = false;
        DianXingGuZhangBtn.GetComponent<Toggle>().isOn = false;
        tempWin = null;
    }
}
