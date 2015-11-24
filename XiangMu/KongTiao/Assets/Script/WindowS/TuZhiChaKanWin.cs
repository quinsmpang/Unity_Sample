using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 用于查看图纸的内容
/// </summary>
public class TuZhiChaKanWin : MonoBehaviour
{
    /// <summary>
    /// 远洋大厦相关信息的介绍
    /// </summary>
    public Text texXinXi;
    /// <summary>
    /// 向左翻图纸
    /// </summary>
    public GameObject btnLeftTuZhi;
    /// <summary>
    /// 向右翻图纸
    /// </summary>
    public GameObject btnRightTuZhi;
    /// <summary>
    /// 要查看的图纸
    /// </summary>
    public Sprite[] sprTuZhi;
    public GameObject sprTuZhiImage;
    private int sprNum;
    /// <summary>
    /// 远洋大厦机房平面图
    /// </summary>
    public GameObject btnPingMianTu;
    /// <summary>
    /// 图纸信息
    /// </summary>
    public GameObject btnTuZhiXinXi;
    public GameObject TIPS;
    /// <summary>
    /// 关闭按钮
    /// </summary>
    public GameObject btnCloseBtn;
   
	// Use this for initialization
	void Start () {
        texXinXi.text = GameSceneUI.YuanYangDaShaXiangGuanXinXi;
        UGUIEventTriggerListener.Get(btnLeftTuZhi).onClick += TuZhiOnClick;
        UGUIEventTriggerListener.Get(btnRightTuZhi).onClick += TuZhiOnClick;
        UGUIEventTriggerListener.Get(btnPingMianTu).onClick += BtnOnClick;
        UGUIEventTriggerListener.Get(btnTuZhiXinXi).onClick += BtnOnClick;
        UGUIEventTriggerListener.Get(btnCloseBtn).onClick = CloseBtnOnClick;
        if (sprTuZhi.Length>0)
        {
            SetChangeTuZhi(0);//初始化第一张图纸;    
        }
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetAxis("Mouse ScrollWheel") != 0))
        {
            //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
            sprTuZhiImage.GetComponent<RectTransform>().sizeDelta += sprTuZhiImage.GetComponent<RectTransform>().sizeDelta * Input.GetAxis("Mouse ScrollWheel");
            //LunTai.transform.localScale += LunTai.transform.localScale * Input.GetAxis("Mouse ScrollWheel");
            //dipan.transform.localScale += LunTai.transform.localScale * Input.GetAxis("Mouse ScrollWheel");
        }
	}
    void TuZhiOnClick(GameObject btn)
    {
        if (btn==btnLeftTuZhi)
        {
            sprNum--;       
        }
        if (btn==btnRightTuZhi)
        {
            sprNum++;
        }
        if (sprNum>(sprTuZhi.Length-1))
        {
            sprNum = (sprTuZhi.Length - 1);
        }
        if (sprNum <0)
        {
            sprNum = 0;
        }
        SetChangeTuZhi(sprNum);
    }
    void BtnOnClick(GameObject btn)
    {
        if (btn==btnTuZhiXinXi)
        {
            TIPS.SetActive(true);
        }
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
    /// <summary>
    /// 用于更换图纸
    /// </summary>
    /// <param name="i"></param>
    public void SetChangeTuZhi(int i)
    {
        sprTuZhiImage.GetComponent<Image>().sprite = sprTuZhi[i];
        sprTuZhiImage.GetComponent<Image>().SetNativeSize();
    }
    /// <summary>
    /// 更换远洋大厦相关信息
    /// </summary>
    /// <param name="str"></param>
    public void SetStringXinXi(string str)
    {
        texXinXi.text = str;
    }
}
