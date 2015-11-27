using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 控制scrollrect的一个方法, 目前正在寻找替换方法
/// </summary>
public class BtnColliterScroll : MonoBehaviour {
    public GameObject btnLeft;
    public GameObject btnRight;
    public GameObject Grid;
	// Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(btnLeft).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(btnRight).onClick += ButtonOnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ButtonOnClick(GameObject btn)
    {

        if (btn==btnLeft)
        {
            Grid.transform.localPosition += new Vector3(10, 0,0);
        }
        if (btn==btnRight)
        {
            Grid.transform.localPosition -= new Vector3(10, 0, 0);
        }
    }
}
