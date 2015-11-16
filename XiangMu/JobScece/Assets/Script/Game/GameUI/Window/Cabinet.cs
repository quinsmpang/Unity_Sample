using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityCillter;

/// <summary>
/// 带抽屉的工具柜
/// </summary>
public class Cabinet : ColliterWindow
{
    /// <summary>
    /// 抽屉的层
    /// </summary>
    public Toggle[] togCTNR;
    /// <summary>
    /// 抽屉
    /// </summary>
    public GameObject DrawerMove;
    public GameObject Out;
    public GameObject In;
    /// <summary>
    /// 当前已经打开的是第几个
    /// </summary>
    private int howDrawer = -1;
    private bool isDrawer = false;
    private GameObject _DrawerMove;
    // Use this for initialization
    void Start()
    {
        FindGame();
        for (int i = 0; i < togCTNR.Length; i++)
        {
            EventTriggerListener.Get(togCTNR[i].gameObject).onClick += ToggleButtonClick;
        }
    }

    void ToggleButtonClick(GameObject btn)
    {
        for (int i = 0; i < togCTNR.Length; i++)
        {
            if (togCTNR[i].gameObject == btn)
            {
                CustDebug.Log("实例化");
                JudgeIsOn(i, "Prefab/UIPrefab/SceneMeasure/CabinetCTNR/" + togCTNR[i].name);
            }
        }

        //GameCillter.GoToChild(DrawerMove, _DrawerMove);
    }
    void JudgeIsOn(int how, string path)
    {
        if (how == howDrawer && !togCTNR[how].GetComponent<Toggle>().isOn)
        {
            howDrawer = -1;
            isDrawer = false;
            iTween.MoveTo(DrawerMove, Out.transform.position, 0.3f);
        }
        else if (how != howDrawer && togCTNR[how].GetComponent<Toggle>().isOn)
        {
            howDrawer = how;
            if (isDrawer)
            {
                isDrawer = false;
                iTween.MoveTo(DrawerMove, Out.transform.position, 0.3f);
            }
            else
            {
                InstantiateDrawer(path);
            }
            StartCoroutine(MoveOutAndIn(path));
        }
    }
    IEnumerator MoveOutAndIn(string path)
    {
        yield return new WaitForSeconds(1.0f);
        InstantiateDrawer(path);
    }
    void InstantiateDrawer(string path)
    {
        GameObject _Drawer = Instantiate(Resources.Load(path)) as GameObject;
        if (_DrawerMove != null)
            Destroy(_DrawerMove.gameObject);
        _DrawerMove = _Drawer;
        _DrawerMove.transform.parent = DrawerMove.transform;
        _DrawerMove.transform.localPosition = Vector3.zero;
        _DrawerMove.transform.localScale = Vector3.one;
        _DrawerMove = _Drawer;
        isDrawer = true;
        iTween.MoveTo(DrawerMove, In.transform.position, 1.0f);
    }
    // Update is called once per frame
    void Update()
    {

    }
}