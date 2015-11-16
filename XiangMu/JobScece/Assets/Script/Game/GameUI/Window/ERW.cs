using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 电阻焊
/// </summary>
public class ERW : ColliterWindow
{
    /// <summary>
    /// 用于选择的窗口
    /// </summary>
    public GameObject Choose;
    /// <summary>
    /// 当前是否选中了电阻焊
    /// </summary>
    public GameObject ToggleButton;
    /// <summary>
    /// 用于显示电阻焊的调节装置的显示
    /// </summary>
    public GameObject ScreenWindow;
    public GameObject btnButtonCloseScreen;
    /// <summary>
    /// 屏幕是否在外面, 这里默认是在里面的
    /// </summary>
    bool IoO = true;
    public GameObject OutScreen;
    public GameObject InScreen;
    // Use this for initialization
    void Start()
    {
        FindGame();
        EventTriggerListener.Get(btnButtonCloseScreen).onClick = ButtonCloseScreenOnClick;
        EventTriggerListener.Get(ToggleButton).onClick = ToggleOnClick;
        //FindTwoGameObject();
        ToggleOnClick(ToggleButton);
    }

    void ButtonCloseScreenOnClick(GameObject btn)
    {
        float timer = 2.0f;
        if (IoO)
        {
            IoO = false;
            btnButtonCloseScreen.transform.localScale = new Vector3(1, 1, 1);
            iTween.MoveTo(ScreenWindow, OutScreen.transform.position, timer);
        }
        else
        {
            IoO = true;
            btnButtonCloseScreen.transform.localScale = new Vector3(-1, 1, 1);
            iTween.MoveTo(ScreenWindow, InScreen.transform.position, timer);
        }
        Apron.Instance.ApronPanel(timer);  
        //GameObject.Find("Apron").GetComponent<Apron>().ApronPanel(timer);
    }
    void ToggleOnClick(GameObject tog)
    {
        bool isOn = ToggleButton.GetComponent<Toggle>().isOn;
        ScreenWindow.SetActive(isOn);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
