using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityCillter;
/// <summary>
/// 设置
/// </summary>
public class Setting : ColliterWindow
{
    /// <summary>
    /// 返回选择项目场景
    /// </summary>
    public GameObject btnBackScene;
    public GameObject tishi;
    /// <summary>
    /// 声音调节
    /// </summary>
    public GameObject SoundValueSlider;
    // Use this for initialization
    void Start()
    {
        FindGame();
        SoundValueSlider.GetComponent<Slider>().value = GameCillter.SoundValue;
        EventTriggerListener.Get(SoundValueSlider).onDrag = SliderDragClick;
        EventTriggerListener.Get(btnBackScene).onClick = ButtonOnClick;
        EventTriggerListener.Get(tishi).onClick = ButtonOnClicks;
    }
    void ButtonOnClicks(GameObject btn)
    {
        NextTIPS.Instance.ClearMakeGreet();
        NextTIPS.Instance.MakeGreet += Greet;
        NextTIPS.Instance.GreetTIPS("你二大爷");
        //NextTIPS.Instance.onDestroy = greet;
        //Apron.Instance.ApronPanel(2.0f);
    }
    public void greet(GameObject go)
    {
        Debug.Log("asdfasdfasd fsaf sad s");
    }
    public void Greet(string names)
    {
        Debug.Log("Greet的打印值: " + names);
    }
    void ButtonOnClick(GameObject btn)
    {
        GameCillter.GotoScene("GameChoice");
    }
    void SliderDragClick(GameObject sli)
    {
        Debug.Log(SoundValueSlider.GetComponent<Slider>().value + "Drag");
        GameCillter.SoundValue = SoundValueSlider.GetComponent<Slider>().value;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
