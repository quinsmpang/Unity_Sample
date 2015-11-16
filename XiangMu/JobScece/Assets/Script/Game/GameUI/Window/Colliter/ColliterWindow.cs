using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ColliterWindow : MonoBehaviour
{
    private GameObject OutPosition;
    private GameObject InPosition;
    private GameObject OriginalPosition;
    float timer = 2.0f;
    /// <summary>
    /// 背景按钮
    /// </summary>
    private GameObject btnBgButton;
    //public void FindGame()
    //{
    //}
    // Use this for initialization
    public void FindGame()
    {
        OutPosition = GameObject.Find("OutPositionWindow").gameObject;
        //InPosition = GameObject.Find("InPosition").gameObject;
        OriginalPosition = GameObject.Find("OriginalPosition").gameObject;
        btnBgButton = transform.FindChild("BgButton").gameObject;
        EventTriggerListener.Get(btnBgButton).onClick = ButtonClose;
    }
    public void FindTwoGameObject()
    {
        OutPosition = GameObject.Find("OutPosition").gameObject;
    }
    public void InWindow()
    {
        Apron.Instance.ApronPanel(timer);
       // gameObject.transform.position = InPosition.transform.position;
        iTween.MoveTo(gameObject, OriginalPosition.transform.position, timer);
        InWindowWay();
    }
    void ButtonClose(GameObject btn)
    {
        iTween.MoveTo(gameObject, OutPosition.transform.position, timer);
        CloseWay();
    }
    public virtual void InWindowWay()
    {
        ///实现方法为下面, 在子类中写入下属, 就可以调用子类方法了
    //    public override void InWindowWay()
    //{
    }
    public virtual void CloseWay()
    {

    }
}
