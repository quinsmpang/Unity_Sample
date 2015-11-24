using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 用于控制相关计算的计算辅助的小窗口的控制
/// </summary>
public class XiangGuanJiSuanXiaoChuangKouWin : MonoBehaviour {
    /// <summary>
    /// 关闭按钮
    /// </summary>
    public GameObject btnClose;
    /// <summary>
    /// 焓湿图查询
    /// </summary>
    public GameObject btnHanShiTu;
    /// <summary>
    /// 计算辅助
    /// </summary>
    public GameObject btnJiSuanFuZhu;
    /// <summary>
    /// 计算辅助的窗口
    /// </summary>
    public GameObject JiSuanFZWin;
    /// <summary>
    /// 焓湿图查询窗口
    /// </summary>
    public GameObject HanShiTCXWin;
    /// <summary>
    /// 
    /// </summary>
    public GameObject JSFZToogle;
    /// <summary>
    /// 计算辅助的ToggleGroup集合
    /// </summary>
    public GameObject[] JSFZGroup;
    /// <summary>
    /// 计算辅助的图片集合
    /// </summary>
    public Sprite[] JSFZ;
    /// <summary>
    /// 焓湿图查询的图片集合
    /// </summary>
    public Sprite[] HSTCX;
    // Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(btnClose).onClick = ButtonClose;
        JSFZToogle.SetActive(false);
        for (int i = 0; i < JSFZGroup.Length; i++)
        {
            UGUIEventTriggerListener.Get(JSFZGroup[i]).onClick += ToggleOnClick;
        }
        UGUIEventTriggerListener.Get(btnHanShiTu).onClick += WinOnClick;
        UGUIEventTriggerListener.Get(btnJiSuanFuZhu).onClick += WinOnClick;
	}
    void ToggleOnClick(GameObject tog)
    {
        for (int i = 0; i < JSFZGroup.Length; i++)
        {
            if (tog==JSFZGroup[i])
            {
                ChangeJSFZ(JSFZ[i], JSFZGroup[i].transform.FindChild("Label").GetComponent<Text>().text);
                JSFZToogle.SetActive(false);
            }
        }
    }
    void WinOnClick(GameObject btn)
    {
        HanShiTCXWin.SetActive((btn == btnHanShiTu));
        JSFZToogle.SetActive(btn == btnJiSuanFuZhu);
        JiSuanFZWin.SetActive((btn == btnJiSuanFuZhu));
    }
    void ChangeJSFZ(Sprite spr,string nametex)
    {
        JiSuanFZWin.transform.FindChild("FuZhu").GetComponent<Image>().sprite = spr;
        JiSuanFZWin.transform.FindChild("NameTex").GetComponent<Text>().text = nametex;
    }
    void ButtonClose(GameObject btn)
    {
        gameObject.SetActive(false);
    }
}
