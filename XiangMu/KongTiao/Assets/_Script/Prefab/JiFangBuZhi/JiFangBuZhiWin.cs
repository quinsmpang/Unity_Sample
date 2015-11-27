using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 用于机房布置的脚本
/// </summary>
public class JiFangBuZhiWin : MonoBehaviour {
    /// <summary>
    /// 安装的实体
    /// </summary>
    public GameObject AnZhuang3D;
    public GameObject btnAZ;
    public GameObject buZhiChaCuoGame;
    public GameObject btnClose;
    /// <summary>
    /// 当前是布置查错还是布置
    /// </summary>
    private bool BOC=true;

    #region 定义UI部分
    public GameObject LDB;
    public GameObject LQSB;
    public GameObject LQSZG;
    public GameObject LDSZG;
    public GameObject ZLZJ;
    public GameObject FJSQ;
    public GameObject FM;
    public GameObject LDBTog;
    public GameObject LQSBTog;
    public GameObject LQSZGTog;
    public GameObject LDSZGTog;
    public GameObject ZLZJTog;
    public GameObject FJSQTog;
    public GameObject FMTog;
    #endregion
    private GameObject tempGame;
    // Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(btnAZ).onClick = AZOnClick;
        UGUIEventTriggerListener.Get(LDB).onClick = GameOnClick;
        UGUIEventTriggerListener.Get(LQSB).onClick = GameOnClick;
        UGUIEventTriggerListener.Get(LQSZG).onClick = GameOnClick;
        UGUIEventTriggerListener.Get(LDSZG).onClick = GameOnClick;
        UGUIEventTriggerListener.Get(ZLZJ).onClick = GameOnClick;
        UGUIEventTriggerListener.Get(FJSQ).onClick = GameOnClick;
        UGUIEventTriggerListener.Get(FM).onClick = GameOnClick;

        UGUIEventTriggerListener.Get(btnClose).onClick = CloseBtnOnClick;
        btnAZ.SetActive(false);
        buZhiChaCuoGame.SetActive(false);
	}
    void AZOnClick(GameObject btn)
    {
        string tempStr;
        tempStr= AnZhuang3D.GetComponent<XiTongAnZhuang>().AnZhuangGame(tempGame);
        switch (tempStr)
        {
            case "LDB":
                LDBTog.GetComponent<Toggle>().isOn = true;
                break;
            case "LQSB":
                LQSBTog.GetComponent<Toggle>().isOn = true;
                break;
            case "LQSZG":
                LQSZGTog.GetComponent<Toggle>().isOn = true;
                break;
            case "LDSZG":
                LDSZGTog.GetComponent<Toggle>().isOn = true;
                break;
            case "ZLZJ":
                ZLZJTog.GetComponent<Toggle>().isOn = true;
                break;
            case "FJSQ":
                FJSQTog.GetComponent<Toggle>().isOn = true;
                break;
            case "FM":
                FMTog.GetComponent<Toggle>().isOn = true;
                break;
        }
        if (BOC)
        {
            btnAZ.SetActive(false);    
        }
        AnZhuang3D.GetComponent<XiTongAnZhuang>().SetActiveJT();
    }
    void GameOnClick(GameObject btn)
    {
        if (LDB == btn)
        {
            tempGame = AnZhuang3D.GetComponent<XiTongAnZhuang>().CameraPostion("LDBC", BOC);
        }
        if (LQSB == btn)
        {
            tempGame = AnZhuang3D.GetComponent<XiTongAnZhuang>().CameraPostion("LQSBC", BOC);
        }
        if (LQSZG == btn)
        {
            tempGame = AnZhuang3D.GetComponent<XiTongAnZhuang>().CameraPostion("LQSZGC", BOC);
        }
        if (LDSZG == btn)
        {
            tempGame = AnZhuang3D.GetComponent<XiTongAnZhuang>().CameraPostion("LDSZGC", BOC);
        }
        if (ZLZJ == btn)
        {
            tempGame = AnZhuang3D.GetComponent<XiTongAnZhuang>().CameraPostion("ZLZJC", BOC);
        }
        if (FJSQ == btn)
        {
            tempGame = AnZhuang3D.GetComponent<XiTongAnZhuang>().CameraPostion("FJSQC", BOC);
        }
        if (FM == btn)
        {
            tempGame = AnZhuang3D.GetComponent<XiTongAnZhuang>().CameraPostion("FMC", BOC);
        }
        if (BOC)
        {
            btnAZ.SetActive(true);
        }
    }

    public void JFBZ(bool b)
    {
        BOC = b;
        if (tempGame!=null)
        {
            btnAZ.SetActive(b);
        }
        if (!b)
        {
            Debugger.Log("是否显示摄像机位置标注为冷冻机组");
            AnZhuang3D.GetComponent<XiTongAnZhuang>().LDBz();
        }
        buZhiChaCuoGame.SetActive(!b);
    }
    #region 关闭
    void CloseBtnOnClick(GameObject btn)
    {
        CloseBtn();
    }
    public void CloseBtn()
    {
        gameObject.SetActive(false);
        transform.parent.parent.gameObject.GetComponent<MenuSheJiWindows>().FalseToggle();
    }
    #endregion
}
