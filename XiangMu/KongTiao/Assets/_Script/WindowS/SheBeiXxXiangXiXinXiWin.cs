using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/// <summary>
/// 用于打开下拉菜单和上传数据
/// </summary>
public class SheBeiXxXiangXiXinXiWin : MonoBehaviour
{

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
    /// 图纸展示
    /// </summary>
    public Image imgTuZhi;
    /// <summary>
    /// 图纸数组
    /// </summary>
    public Sprite[] sprTuZhi;
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
    /// 设备相关信息
    /// </summary>
    public GameObject btnSheBei;
    /// <summary>
    /// 设备相关信息介绍
    /// </summary>
    public Text texXinXi;
    /// <summary>
    /// 是否已经打开下拉菜单
    /// </summary>
    private bool IsDown = false;


    private string[] strItemJiShao=new string[12];
    // Use this for initialization
    void Start()
    {
        UGUIEventTriggerListener.Get(xiaLaBtn).onClick = XiaLaoButtonOnClick;
        UGUIEventTriggerListener.Get(xiaLaGrid).onExit = xingHaoExitHandle;
        for (int i = 0; i < ItemBtn.Length; i++)
        {
            UGUIEventTriggerListener.Get(ItemBtn[i]).onClick += ItemButtonOnClick;
        }
        UGUIEventTriggerListener.Get(inputFileTex).onSubMit = InputFileOnSubmit;
        UGUIEventTriggerListener.Get(btnSheBei).onClick = SheBeiOnClick;
        //inputFileTex.GetComponent<InputField>().MoveTextEnd
        inputFileTex.GetComponent<InputField>().interactable = false;//禁止输入
        xiaLaGrid.SetActive(false);
        strItemJiShao[0] = "在制冷行业中分为风冷式冷水机组和水冷式冷水机组两种，根据压缩机又分为螺杆式冷水机组和涡旋式冷水机组，在温度控制上分为低温工业冷水机和常温冷水机，常温机组温度一般控制在0度-35度范围内。低温机组温度控制一般在0度至-100度左右。\n冷水机组又称为：冷冻机、制冷机组、冰水机组、冷却设备等，因各行各业的使用比较广泛，所以对冷水机组的要求也不一样。其工作原理是一个多功能的机器，除去了液体蒸气通过压缩或热吸收式制冷循环。";
        strItemJiShao[1] = "水泵是输送液体或使液体增压的机械。它将原动机的机械能或其他外部能量传送给液体，使液体能量增加，主要用来输送液体包括水、油、酸碱液、乳化液、悬乳液和液态金属等，也可输送液体、气体混合物以及含悬浮固体物的液体。水泵性能的技术参数有流量、吸程、扬程、轴功率、水功率、效率等；根据不同的工作原理可分为容积水泵、叶片泵等类型。容积泵是利用其工作室容积的变化来传递能量；叶片泵是利用回转叶片与水的相互作用来传递能量，有离心泵、轴流泵和混流泵等类型。";
        strItemJiShao[2] = "热镀锌钢管：为提高钢管的耐腐蚀性能，对一般钢管进行镀锌。镀锌钢管分热镀锌和电镀锌两种，热镀锌镀锌层厚，电镀锌成本低，表面不是很光滑。\n焊接钢管：焊接钢管是指用钢带或钢板弯曲变形为圆形、方形等形状后再焊接成的、表面有接缝的钢管。 焊接钢管采用的坯料是钢板或带钢。\n无缝钢管：无缝钢管具有中空截面，大量用作输送流体的管道。钢管与圆钢等实心钢材相比，在抗弯抗扭强度相同时，重量较轻，是一种经济截面钢材，广泛用于制造结构件和机械零件，可提高材料利用率，简化制造工序，节约材料和加工工时，已广泛用钢管来制造。";
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
    /// <summary>
    /// 修改图纸的展示
    /// </summary>
    /// <param name="ni"></param>
    void ChangeTuZhi(int ni)
    {
        try
        {
            imgTuZhi.sprite = sprTuZhi[ni];
        }
        catch (Exception e)
        {
            Debugger.LogError("图纸未绑定,或个数不够");   
        }
    }
    /// <summary>
    /// 修改信息描述
    /// </summary>
    /// <param name="ni"></param>
    void ChangeJiShao(int ni)
    {
        try
        {
            texXinXi.text = strItemJiShao[ni];
        }
        catch (Exception e)
        {
            Debugger.LogError("介绍信息不完整");
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
        Debugger.Log(inp.GetComponent<InputField>().text + "------");
    }
    void xingHaoExitHandle(GameObject exi)
    {
        XiaLaoButtonOnClick(xiaLaBtn);
    }
    /// <summary>
    /// 确定选中的设备信息
    /// </summary>
    /// <param name="btn"></param>
    void SheBeiOnClick(GameObject btn)
    {
        ChangeSheBeiImage(numSheBei);
        ChangeTuZhi(numSheBei);
        ChangeJiShao(numSheBei);
    }
}

