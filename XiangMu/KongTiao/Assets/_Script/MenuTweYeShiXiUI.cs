using UnityEngine;
using System.Collections;

public class MenuTweYeShiXiUI : MonoBehaviour {
    public GameObject dianXingLouCengSheJiBtn;
    public GameObject moDuanSheJiBtn;
    public GameObject lengQueTaSheJiBtn;
    public GameObject jiFangZongTiSheJiBtn;
    public GameObject xiTongYunXingGuanLiBtn;
    public GameObject xiTongGuZhangChuLiBtn;
	// Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(dianXingLouCengSheJiBtn).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(moDuanSheJiBtn).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(lengQueTaSheJiBtn).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(jiFangZongTiSheJiBtn).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(xiTongYunXingGuanLiBtn).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(xiTongGuZhangChuLiBtn).onClick += ButtonOnClick;
	}

    private void ButtonOnClick(GameObject btn)
    {
        if (btn==dianXingLouCengSheJiBtn)
        {
            Debugger.LogText("典型楼层设计");
        }
        if (btn==moDuanSheJiBtn)
        {
            Debugger.LogText("末端设计");
        }
        if (btn==lengQueTaSheJiBtn)
        {
            Debugger.LogText("冷却塔设计");
        }
        if (btn==jiFangZongTiSheJiBtn)
        {
            GameSceneUI.Instance.ChangeYeMian("jifangsheji");
            Debugger.Log("机房总体设计");
        }
        if (btn==xiTongYunXingGuanLiBtn)
        {
            Debugger.LogText("系统运行管理");
        }
        if (btn==xiTongGuZhangChuLiBtn)
        {
            Debugger.LogText("系统故障处理");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
