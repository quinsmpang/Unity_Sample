using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIFirst : MonoBehaviour {

    public UIComUnList m_list;

    /// <summary>
    /// 测试数据
    /// </summary>
    public List<string> m_listData = new List<string>();
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 1000; i++)
        {
            m_listData.Add("光亮" + i.ToString());
        }
        m_list.Init(m_listData.Count, UpdateItem);
	}
    /// <summary>
    /// 列表内部刷新界面时回调
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    private void UpdateItem(Transform item, int index)
    {
        item.FindChild("text").GetComponent<Text>().text = "真实item: " + item.name + "数据: "
            + m_listData[index];
        UGUIEventTriggerListener.Get(item.gameObject).onClick = OnClickBtn;
        //UGUIEventTriggerListener.Get(item.gameObject).parameter
    }
    private void OnClickBtn(GameObject go)
    {
        int index = (int)2;
        Debug.Log("您单击的索引为: " + index);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
