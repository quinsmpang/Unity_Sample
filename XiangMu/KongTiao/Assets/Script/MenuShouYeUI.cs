using UnityEngine;
using System.Collections;

public class MenuShouYeUI : MonoBehaviour {
    public GameObject xingWeiRenZhiTog;
    public GameObject zhuanYeXueXiTog;
    public GameObject kaoHeTiKuTog;
    public GameObject shengChanShiXiTog;
	// Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(xingWeiRenZhiTog).onClick += ToggleOnClick;
        UGUIEventTriggerListener.Get(zhuanYeXueXiTog).onClick += ToggleOnClick;
        UGUIEventTriggerListener.Get(kaoHeTiKuTog).onClick += ToggleOnClick;
        UGUIEventTriggerListener.Get(shengChanShiXiTog).onClick += ToggleOnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ToggleOnClick(GameObject tog)
    {
        if (tog==xingWeiRenZhiTog)
        {
            Debugger.LogText("行业认知");
        }
        if (tog==zhuanYeXueXiTog)
        {
            Debugger.LogText("专业学习");
        }
        if (tog==kaoHeTiKuTog)
        {
            Debugger.LogText("考核题库");
        }
        if (tog==shengChanShiXiTog)
        {
            Debugger.Log("生产实习");
            GameSceneUI.Instance.ChangeYeMian("shengchanshixi");
        }
    }
}
