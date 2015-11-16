using UnityEngine;
using System.Collections;

public class MyStarts : MonoBehaviour
{
    public GameObject gongJuXiang;
    public GameObject gongJuZuHe;
    public GameObject maskGameUI;
    public GameObject targetGameX;
    public GameObject targetGameZH;
    public GameObject targetGameY;
    bool xb;
    bool zhb;

	// Use this for initialization
	void Start () {
        xb = false;
        zhb = false;
        EventTriggerListener.Get(gongJuXiang).onClick = XiangButtonClick;
        EventTriggerListener.Get(gongJuZuHe).onClick = ZuHeButtonClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void XiangButtonClick(GameObject btn)
    {
        xb = !xb;
        zhb = false;
        if (xb)
        {
            iTween.MoveTo(maskGameUI.gameObject, targetGameX.transform.position, 1.0f);
        }
        else
        {
            iTween.MoveTo(maskGameUI.gameObject, targetGameY.transform.position, 1.0f);
        }
    }
    void ZuHeButtonClick(GameObject btn)
    {
        zhb = !zhb;
        xb = false;
        if (zhb)
        {
            iTween.MoveTo(maskGameUI.gameObject, targetGameZH.transform.position, 1.0f);
        }
        else
        {
            iTween.MoveTo(maskGameUI.gameObject, targetGameY.transform.position, 1.0f);
        }
    }
}
