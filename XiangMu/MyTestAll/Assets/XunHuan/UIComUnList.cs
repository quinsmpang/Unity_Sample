using UnityEngine;
using System.Collections;


/// <summary>
/// 创建代理
/// </summary>
/// <param name="item"></param>
/// <param name="index"></param>
public delegate void UpdateListItem(Transform item,int index);
public class UIComUnList : MonoBehaviour {

    //UI对象
    public Transform m_itemParent;
    public GameObject m_item;
    public UIScrollBar m_sb;

    //外部参数设置
    public int m_itemWidth;//单元格宽
    public int m_itemHeight;//单元格高

    public int m_fixedColumnCount;//固定列数
    public int m_fixedColCount;     //固定行数

    //内部私有遍历
    private Vector2 m_allItemArea = Vector2.zero;//当前所有内容高度
    private Vector2 m_showArea = Vector2.zero;//当前显示局域

    //前后的单元格位置
    private Vector2 m_firstItemPos = Vector2.zero;
    private Vector2 m_lastItemPos = Vector2.zero;

    //数据处理
    private int m_listMaxLength = 0;
    private int m_curShowStartIndex = 0;
    private int m_curShowEndIndex = 0;

    //更新item内容
    private UpdateListItem m_updateItem;

    /// <summary>
    /// 记录当前值用于获取滑动方向
    /// </summary>
    private float m_curSbVal = 0;

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="maxLength"></param>
    /// <param name="updateItem"></param>
    public void Init(int maxLength, UpdateListItem updateItem)
    {
        m_showArea = GetComponent<RectTransform>().sizeDelta;
        m_item.SetActive(false);
        m_firstItemPos.y += m_itemHeight;
        m_curSbVal = m_sb.value;
        m_curShowEndIndex = m_fixedColCount;

        m_listMaxLength = maxLength;
        m_updateItem = updateItem;
        for (int i = 0; i < m_fixedColCount+1; i++)
        {
            Transform item = CreateItem(i);
            m_updateItem(item, i);
        }
    }

    /// <summary>
    /// 创建item
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private Transform CreateItem(int index)
    {
        Transform item = (GameObject.Instantiate(m_item) as GameObject).transform;
        item.gameObject.SetActive(true);
        item.SetParent(m_itemParent);//---------------------------m嘛意思啊
        item.name = index.ToString();
        //1.行
        int row = index / m_fixedColCount;
        //2.列
        int col = index % m_fixedColCount;
        item.localPosition = new Vector3(col * m_itemWidth, -1 * row * m_itemHeight, 0f);

        m_allItemArea.y = (row + 1) * m_itemHeight;
        m_lastItemPos.y = -1 * (int)m_allItemArea.y;
        return item;
    }
    /// <summary>
    /// 滑动条改变时调用
    /// </summary>
    /// <param name="val"></param>
    public void OnDragSlider(float val)
    {
        UpDateListByFloat(m_sb.value * (m_listMaxLength - m_fixedColCount));
    }
    /// <summary>
    /// 通过一个浮点值滑动列表
    /// </summary>
    /// <param name="val"></param>
    public void UpDateListByFloat(float val)
    {
        UpdateListPos(val);
        if (val>m_curSbVal)
        {
            if (m_curShowEndIndex>=m_listMaxLength-1)
            {
                return;
            }
            UpdateItemPos(false);
        }
        else
        {
            if (m_curShowStartIndex<=0)
            {
                return;
            }
            m_curSbVal = val;
        }
    }
    /// <summary>
    /// 更新item父节点位置
    /// </summary>
    /// <param name="val"></param>
    private void UpdateListPos(float val)
    {
        //获取多出来的高度
        float excess = 0f;
        if (m_allItemArea.y>m_showArea.y)
        {
            excess = m_allItemArea.y - m_showArea.y;
        }
        m_itemParent.localPosition = new Vector2(0, excess * val);
    }
    /// <summary>
    /// 更新item位置
    /// </summary>
    /// <param name="isDown"></param>
    private void UpdateItemPos(bool isDown)
    {
        if (isDown)
        {
            for (int i = 0; i < m_itemParent.childCount; i++)
            {
                Transform item = m_itemParent.GetChild(i);
                float curPos = item.localPosition.y + m_itemParent.localPosition.y;
                if (curPos>m_itemHeight)
                {
                    item.localPosition = new Vector3(0, m_lastItemPos.y, 0);
                    m_lastItemPos.y -= m_itemHeight;
                    m_firstItemPos.y -= m_itemHeight;

                    m_updateItem(item, m_curShowEndIndex + 1);
                    m_curShowStartIndex++;
                    m_curShowEndIndex++;
                }
            }
        }
        else
        {
            for (int i = m_itemParent.childCount - 1; i >= 0; i--)
            {
                Transform item = m_itemParent.GetChild(i);
                float curPos = item.localPosition.y + m_itemParent.localPosition.y;
                if (curPos<-1*m_showArea.y)
                {
                    item.localPosition = new Vector3(0, m_firstItemPos.y, 0);
                    m_firstItemPos.y += m_itemHeight;
                    m_lastItemPos.y += m_itemHeight;

                    m_updateItem(item, m_curShowStartIndex - 1);
                    m_curShowEndIndex--;
                    m_curShowStartIndex--;
                }
            }
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
