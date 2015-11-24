using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 用于处理图纸信息的提示
/// </summary>
public class TuZhiXinXiTIPS : MonoBehaviour {

    public Text texText;
	// Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(gameObject).onClick = CloseBtnOnClick;
	}
    void CloseBtnOnClick(GameObject btn)
    {
        gameObject.SetActive(false);
    }
    public void SetText(string str)
    {
        texText.text = str;
    }
}
