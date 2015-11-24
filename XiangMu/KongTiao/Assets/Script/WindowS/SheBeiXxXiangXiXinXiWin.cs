using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/// <summary>
/// 用于打开下拉菜单和上传数据
/// </summary>
public class SheBeiXxXiangXiXinXiWin : MonoBehaviour {

    /// <summary>
    /// 设备展示图片
    /// </summary>
    public Image imgSheBei;
    /// <summary>
    /// 设备图片数组
    /// </summary>
    public Sprite[] sprSheBei;
    /// <summary>
    /// 选中的是第几个
    /// </summary>
    private int numSheBei;

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
    public GameObject xingHaoGrid;
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
        UGUIEventTriggerListener.Get(xingHaoGrid).onExit = xingHaoExitHandle;
        for (int i = 0; i < ItemBtn.Length; i++)
        {
            UGUIEventTriggerListener.Get(ItemBtn[i]).onClick += ItemButtonOnClick;
        }
        UGUIEventTriggerListener.Get(inputFileTex).onSubMit = InputFileOnSubmit;
        //inputFileTex.GetComponent<InputField>().MoveTextEnd
        inputFileTex.GetComponent<InputField>().interactable = false;//禁止输入
        xiaLaGrid.SetActive(false);
	}
    /// <summary>
    /// 关闭下拉框
    /// </summary>
    /// <param name="btn"></param>
    void XiaLaoButtonOnClick(GameObject btn)
    {
        xiaLaGrid.SetActive(!xiaLaGrid.activeSelf);
    }
    /// <summary>
    /// 修改设备的详细信息的展示
    /// </summary>
    /// <param name="ni"></param>
    void ChangeSheBeiImage(int ni)
    {
        try
        {
            imgSheBei.sprite = sprSheBei[ni];
        }
        catch (Exception e)
        {
            Debugger.LogError("图片未绑定或者图片个数不够");

        }
    }
    void ItemButtonOnClick(GameObject btn)
    {
        XiaLaoButtonOnClick(xiaLaBtn);

        // inputFileTex.GetComponent<InputField>().interactable = false;
        for (int i = 0; i < ItemBtn.Length; i++)
        {
            if (btn == ItemBtn[i])
            {
                inputFileTex.GetComponent<InputField>().text = btn.GetComponent<XingHaoItem>().names;
                numSheBei = i;
            }
        }
    }
        void InputFileOnSubmit(GameObject inp)
    {
        Debugger.Log(inp.GetComponent<InputField>().text+"------");
    }
    void xingHaoExitHandle(GameObject exi)
    {
        XiaLaoButtonOnClick(xiaLaBtn);
    }
}

