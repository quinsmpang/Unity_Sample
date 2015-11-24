using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SheBeiXuanXingWin : MonoBehaviour {
    /// <summary>
    /// 关闭按钮
    /// </summary>
    public GameObject btnClose;
    // Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(btnClose).onClick = CloseBtnOnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
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
