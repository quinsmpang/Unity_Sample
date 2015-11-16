using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityCillter;
/// <summary>
/// 定义委托, 定义了可以代表的方法类型
/// </summary>
/// <param name="names"></param>
public delegate void GreetingDelegate(string names);
public class NextTIPS : MonoBehaviour
{

    private static NextTIPS _instance;
    public static NextTIPS Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("NextTIPS").GetComponent<NextTIPS>();
            return _instance;
        }
    }
    /// <summary>
    /// 下一步按钮
    /// </summary>
    public GameObject btnNext;
    /// <summary>
    /// 显示提示的内容的
    /// </summary>
    public Text texNextText;
    /// <summary>
    /// 在TIPS内部声明变量
    /// </summary>
    public event GreetingDelegate MakeGreet;
    #region 代理2

    //public delegate void MakeDelegate(GameObject gameo);
    //public MakeDelegate onDestroy;
    //public MakeDelegate onInstance;
    #endregion
    
    /// <summary>
    /// 显示的屏幕
    /// </summary>
    public GameObject ScreneO;
    /// <summary>
    /// 显示的屏幕弹出的位置
    /// </summary>
    public GameObject ScreneOut;
    /// <summary>
    /// 显示的屏幕弹入的位置
    /// </summary>
    public GameObject ScreneIn;
    /// <summary>
    /// 是否将鼠标放在UI上了
    /// </summary>
    private bool isEnter = true;
    /// <summary>
    /// 当前有多长时间没有碰触到TIPS
    /// </summary>
    private float timerEnter = 0f;
    public GameObject outBtn;
    bool IsOut = false;
    string ads;
    // Use this for initialization
    void Start()
    {
        
        EventTriggerListener.Get(btnNext).onClick = NextButtonOnClick;
        EventTriggerListener.Get(outBtn).onClick = EnterHandlerUI;
    }
    #region 代理
    void NextButtonOnClick(GameObject btn)
    {
        //判断代理的是否为空
        if (MakeGreet != null)
        {
            //如果不为空则执行代理传入的值
            MakeGreet(ads);
            //清空代理, 防止多次执行同一个代理
            ClearMakeGreet();
        }
        //OnDestroy(gameObject);
        //OnInstance(gameObject);
    }

    /// <summary>
    /// 接收代理的传入值
    /// </summary>
    /// <param name="names"></param>
    public void GreetTIPS(string names)
    {
        texNextText.text = names;
        ads = names;
    }
    /// <summary>
    /// 清空代理
    /// </summary>
    public void ClearMakeGreet()
    {
        NextTIPS.Instance.MakeGreet = null;
    }
    #endregion
    #region 代理2// 目前的代理2处于待用阶段, 代理模式1可以胜任工作的部分, 虽然较麻烦
    //public void OnDestroy(GameObject go)
    //{
    //    if (onDestroy!=null)
    //    {
    //        onDestroy(gameObject);
    //    }
    //}
    //public void OnInstance(GameObject go)
    //{
    //    if (onInstance!=null)
    //    {
    //        onInstance(gameObject);
    //    }
    //}
    #endregion
    #region 当鼠标移开时渐隐, 当鼠标放上时显示
    void EnterHandlerUI(GameObject gam)
    {
        IsOut=!IsOut;
        if (IsOut)
        {
            iTween.MoveTo(ScreneO.gameObject, ScreneOut.transform.position, 0.3f);
        }
        else
        {
            iTween.MoveTo(ScreneO.gameObject, ScreneIn.transform.position, 0.1f);
        }
       
        CustDebug.Log("鼠标进入UI上EnterHandlerUI");
    }
    void ExitHandlerUI(GameObject gam)
    {
        CustDebug.Log("鼠标移出UI上ExitHandlerUI");
        
    }
 
    #endregion
    // Update is called once per frame
    void Update()
    {

    }
}