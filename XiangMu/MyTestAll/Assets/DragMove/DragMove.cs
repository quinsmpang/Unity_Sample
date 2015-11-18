using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 继承三个接口,IBeginDragHandler,IDragHandler,IEndDragHandler ，这三个接口可实现触发贴图事件，,IBeginDragHandler是当鼠标按下后第一次拖动就结束的接口,IDragHandler当鼠标在拖动中触发的接口,IEndDragHandler当停止拖动的接口 
/// </summary>

public class DragMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    /// <summary>
    /// 我们声明一个贴图来做拖动用的
    /// </summary>
    private Image image;
    private Vector2 imaPos;
    void Start()
    {
        imaPos = GetComponent<RectTransform>().anchoredPosition;
    }
    /// <summary>
    /// 使用上面的IBeginDragHandler接口就必须包含这个方法public void OnBeginDrag();
    /// </summary>
    /// <param name="data"></param>
    public void OnBeginDrag(PointerEventData data)
    {
        setDragPosition(data);//我们来设置拖动贴图位置的方法
        image = GetComponent<Image>();//获取组建下的Image组建，当然这个组建必须要有的
        image.fillAmount = 1f;//这是设置贴图的属性，当我们拖动贴图的冷却条为1，就是可见的贴图
    }
    /// <summary>
    /// 鼠标在贴图中拖动时会调用此函数
    /// </summary>
    /// <param name="data"></param>
    public void OnDrag(PointerEventData data)
    {
        setDragPosition(data);//我们也在这里设置贴图拖动的位置
    }
    /// <summary>
    /// 当鼠标拖动后弹起时调用这个函数
    /// </summary>
    /// <param name="data"></param>
    public void OnEndDrag(PointerEventData data)//
    {
        GetComponent<RectTransform>().anchoredPosition = imaPos;//Vector2.zero;//我们把贴图的位置归位
        image.fillAmount = 0;//隐藏掉图片
    }
    /// <summary>
    /// 这是我设置的拖动贴图方法，也就是上面三个函数都在调用的函数
    /// </summary>
    /// <param name="data"></param>
    private void setDragPosition(PointerEventData data)
    {
        var rt = GetComponent<RectTransform>();//我们动态声明一个变量来存储拖动贴图的位置
        Vector3 MousePos;//我们设置一个拖动后贴图的位置的ve3变量
        //我们假设移动贴图的位置后得到贴图的位置
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, data.position, data.pressEventCamera, out MousePos))
        {
            rt.position = MousePos;//贴图位置
        }
    }

}