using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 用于打开下拉菜单和上传数据
/// </summary>
public class XingHaoXiaLaCaiDan : MonoBehaviour {
    public bool IsXingHao;
    /// <summary>
    /// 下拉菜单的按钮
    /// </summary>
    public GameObject xiaLaBtn;
    /// <summary>
    /// 可输入的框
    /// </summary>
    public GameObject inputFileTex;
    /// <summary>
    /// 下拉菜单
    /// </summary>
    public GameObject xiaLaGrid;
    /// <summary>
    /// 下拉菜单中的按钮
    /// </summary>
    public GameObject[] ItemBtn;
    /// <summary>
    /// 是否已经打开下拉菜单
    /// </summary>
    private bool IsDown = false;
    void Awake()
    {
        
    }
	// Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(xiaLaBtn).onClick = XiaLaoButtonOnClick;
        for (int i = 0; i < ItemBtn.Length; i++)
        {
            UGUIEventTriggerListener.Get(ItemBtn[i]).onClick += ItemButtonOnClick;
        }
        UGUIEventTriggerListener.Get(inputFileTex).onSubMit = InputFileOnSubmit;
        //inputFileTex.GetComponent<InputField>().MoveTextEnd
        inputFileTex.GetComponent<InputField>().interactable = false;//禁止输入
        xiaLaGrid.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void XiaLaoButtonOnClick(GameObject btn)
    {
        xiaLaGrid.SetActive(!xiaLaGrid.activeSelf);
    }
    void ItemButtonOnClick(GameObject btn)
    {
        XiaLaoButtonOnClick(xiaLaBtn);

        if (btn == ItemBtn[(ItemBtn.Length - 1)])
        {
            inputFileTex.GetComponent<InputField>().interactable = true;
        }
        else
        {
            inputFileTex.GetComponent<InputField>().interactable = false;
            if (IsXingHao)
            {
                transform.parent.GetComponent<SheBeiZu>().SetInputXingHao(btn.GetComponent<XingHaoItem>().names);
            }
            else
            {
                transform.parent.GetComponent<SheBeiZu>().SetInputNum(btn.GetComponent<XingHaoItem>().names);
            }
            inputFileTex.GetComponent<InputField>().text = btn.GetComponent<XingHaoItem>().names;
        }
    }
    void InputFileOnSubmit(GameObject inp)
    {
        Debugger.Log(inp.GetComponent<InputField>().text+"------");
    }
}
