using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityCillter;

/// <summary>
/// 打磨工具
/// </summary>
public class Polish : ColliterWindow
{
    public Toggle togPolish;
	// Use this for initialization
	void Start () {
        FindGame();
        EventTriggerListener.Get(togPolish.gameObject).onClick = ToggleOnClick;
	}
    void ToggleOnClick(GameObject tog)
    {
        CustDebug.Log("点击了打磨工具" + togPolish.isOn);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
