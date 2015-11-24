using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 本脚本用于对相关计算的控制
/// </summary>
public class XiangGuanJiSuanWin : MonoBehaviour {

    public GameObject btnClose;
    /// <summary>
    /// 远洋大厦相关信息
    /// </summary>
    public Text texXinXi;
    public GameObject btnJiSuanFuZhu;
    public GameObject btnJiSuanJiGuo;
    public GameObject btnYuanShiSheJi;
    public GameObject JSFZ;
    public GameObject JSJG;
    public GameObject YSSJ;
    private GameObject tempGame;
	// Use this for initialization
	void Start () {
        texXinXi.text = GameSceneUI.YuanYangDaShaXiangGuanXinXi;
        UGUIEventTriggerListener.Get(btnClose).onClick = CloseBtnOnClick;
        UGUIEventTriggerListener.Get(btnJiSuanFuZhu).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(btnJiSuanJiGuo).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(btnYuanShiSheJi).onClick += ButtonOnClick;
        if (JSFZ != null)
        {
            JSFZ.SetActive(false);
        }
        if (JSJG != null)
        {
            JSJG.SetActive(false);
        }
        if (YSSJ != null)
        {
            YSSJ.SetActive(false);
        }
	}
    void ButtonOnClick(GameObject btn)
    {
        if (tempGame!=null)
        {
            tempGame.SetActive(false);
        }
        if (btn==btnJiSuanFuZhu)
        {
            tempGame = JSFZ;
        }
        if (btn==btnJiSuanJiGuo)
        {
            tempGame = JSJG;
        }
        if (btn==btnYuanShiSheJi)
        {
            tempGame = YSSJ;
        }
        if (tempGame!=null)
        {
            tempGame.SetActive(true);
        }
    }

    void CloseBtnOnClick(GameObject btn)
    {
        CloseBtn();
    }
    public void CloseBtn()
    {
        gameObject.SetActive(false);
        transform.parent.parent.gameObject.GetComponent<MenuSheJiWindows>().FalseToggle();
    }

    /// <summary>
    /// 更换远洋大厦相关信息
    /// </summary>
    /// <param name="str"></param>
    public void SetStringXinXi(string str)
    {
        texXinXi.text = str;
    }
}
