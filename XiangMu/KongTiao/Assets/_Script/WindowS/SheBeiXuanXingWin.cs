using UnityEngine;
using System.Collections;

/// <summary>
/// 设备选型的控制
/// </summary>
public class SheBeiXuanXingWin : MonoBehaviour {

    public GameObject btnClose;
	// Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(btnClose).onClick = CloseBtnOnClick;
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
}
