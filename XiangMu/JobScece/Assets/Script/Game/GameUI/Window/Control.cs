using UnityEngine;
using System.Collections;
using UnityCillter;
/// <summary>
/// 控制器
/// </summary>
public class Control : MonoBehaviour {
    public GameObject _out;
    public GameObject _in;
    public GameObject _Control;
    public GameObject btnButton;
    public GameObject btnUp;
    public GameObject btnDown;

    public GameObject HuaGanUp;
    public GameObject HuaGanDown;
    public GameObject HuaGanLeft;
    public GameObject HuaGanRight;
    private Sub_Objects huaGanUp;
    private Sub_Objects huaGanDown;
    private Sub_Objects huaGanLeft;
    private Sub_Objects huaGanRight;

    bool IoO = false;
    
	// Use this for initialization
	void Start () {
        EventTriggerListener.Get(btnButton).onClick = ButtonClick;
        EventTriggerListener.Get(btnUp).onClick = UpClick;
        EventTriggerListener.Get(btnDown).onClick = DownClick;
        huaGanUp = HuaGanUp.GetComponent<Sub_Objects>();
        huaGanDown = HuaGanDown.GetComponent<Sub_Objects>();
        huaGanLeft = HuaGanLeft.GetComponent<Sub_Objects>();
        huaGanRight = HuaGanRight.GetComponent<Sub_Objects>();
	}
    void ButtonClick(GameObject btn)
    {
        if (IoO)
        {
            btnButton.transform.localScale = new Vector3(1, 1, 1);
            iTween.MoveTo(_Control, _out.transform.position, 0.5f);
            IoO = false;
        }
        else
        {
            btnButton.transform.localScale = new Vector3(-1, 1, 1);
            iTween.MoveTo(_Control, _in.transform.position, 0.5f);
            IoO = true;
        }
    }
    public void SetActives()
    {
        _Control.SetActive(!_Control.activeSelf);
    }
    void UpClick(GameObject btn)
    {
        huaGanUp.TieSuoKouUpOrDown(true);
        huaGanDown.TieSuoKouUpOrDown(true);
        huaGanLeft.TieSuoKouUpOrDown(true);
        huaGanRight.TieSuoKouUpOrDown(true);
        CustDebug.Log("上");
    }
    void DownClick(GameObject btn)
    {
        huaGanUp.TieSuoKouUpOrDown(false);
        huaGanDown.TieSuoKouUpOrDown(false);
        huaGanLeft.TieSuoKouUpOrDown(false);
        huaGanRight.TieSuoKouUpOrDown(false);
        CustDebug.Log("下");
    }
}
