using UnityEngine;
using System.Collections;

public class RightChange : MonoBehaviour {
    public GameObject inBtn;
    public GameObject outBtn;
    public GameObject BG;
	// Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(inBtn).onClick += ButtononClick;
        UGUIEventTriggerListener.Get(outBtn).onClick += ButtononClick;
	}
    void ButtononClick(GameObject btn)
    {
        if (btn==inBtn)
        {
            BG.SetActive(false);
        }
        if (btn==outBtn)
        {
            BG.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
