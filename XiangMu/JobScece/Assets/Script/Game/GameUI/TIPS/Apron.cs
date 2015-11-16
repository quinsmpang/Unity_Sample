using UnityEngine;
using System.Collections;
using UnityCillter;
using UnityEngine.UI;

/// <summary>
/// 挡板, 此挡板的功能是在点击二保焊, 电阻焊时会有屏幕弹出, 因为itween是以世界坐标为计算的, 所以在运行的时候需要将屏幕进行遮挡, 防止itween运行, 以免造成移位;
/// </summary>
public class Apron : MonoBehaviour
{
    private static Apron _instance;
    public static Apron Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Apron").GetComponent<Apron>();
            }
            return _instance;
        }
    }
    public GameObject PanelApron;
    public void ApronPanel(float timer)
    {
        PanelApron.SetActive(true);
        StartCoroutine(SetActivePanel(timer));
    }
    IEnumerator SetActivePanel(float timer)
    {
        yield return new WaitForSeconds(timer);
        PanelApron.SetActive(false);
    }
}
