using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 机房设备选型的选型窗口
/// </summary>
public class JiFangSheBeiWin : MonoBehaviour {
    /// <summary>
    /// 设备组
    /// </summary>
    public GameObject gamGridItem;
    /// <summary>
    /// 确定
    /// </summary>
    public GameObject btnQueDing;
    /// <summary>
    /// 重置
    /// </summary>
    public GameObject btnChongZhi;
    /// <summary>
    /// 设备组
    /// </summary>
    private List<SheBeiZu> SBZ = new List<SheBeiZu>();
    /// <summary>
    /// 型号的组合
    /// </summary>
    private List<SheBeiZuData> XH = new List<SheBeiZuData>();
	void Start () {
        UGUIEventTriggerListener.Get(btnQueDing).onClick = QueDingOnClikc;
        UGUIEventTriggerListener.Get(btnChongZhi).onClick = CZOnClick;
        foreach (Transform item in gamGridItem.transform)
        {
            SheBeiZu sb = item.GetComponent<SheBeiZu>();
            SBZ.Add(sb);
        }
	}
    /// <summary>
    /// 确定
    /// </summary>
    /// <param name="btn"></param>
    void QueDingOnClikc(GameObject btn)
    {
        for (int i = SBZ.Count-1; i >= 0; i--)
        {
            ///设置方法, 将为选定的部件进行显示红色, 闪动两次,提示未选定
            if (SBZ[i].SBZ.XH!=null&&SBZ[i].SBZ.XH!=""&&SBZ[i].SBZ.NUM!=null&&SBZ[i].SBZ.NUM!=0)
            {
                XH.Add(SBZ[i].SBZ);
            }
            else
            {
                SBZ[i].TIPS();
                return;//如果首个的值不全将不进行下面的
            }
        }
        Debugger.Log("确定");//将值放入一个静态中
    }
    /// <summary>
    /// 重置
    /// </summary>
    /// <param name="btn"></param>
    void CZOnClick(GameObject btn)
    {
        for (int i = 0; i < SBZ.Count; i++)
        {
            SBZ[i].ResetInput();
        }
    }
}
