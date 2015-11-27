using UnityEngine;
using System.Collections;

/// <summary>
/// 用于生产实习-机房总体设计-系统运行的3D部分
/// </summary>
public class XiTongYunXingQieHuan : MonoBehaviour
{
    #region 3D的物品
   // public GameObject lengQueTaGame;
    public GameObject lengQueShuiBengGame;
    public GameObject lengQueShuiBeng2Game;
    public GameObject yaSuoJiGame;
    #endregion
    #region 对应的要展示的箭头和灯泡
    public GameObject dengPao;
    public GameObject LQTjt;
    public GameObject LQSBjt;
    public GameObject YSJjt;
    #endregion
    #region 材质球, 原始的和透明的
    public Material matTouMing;
    public Material matYuanShi;
    #endregion
    //private float 
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (Input.GetMouseButtonDown(0))
        {
            
        }
        if (Input.GetMouseButton(0))
        {
            if (mouseX != 0)
            {
                transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * 200f * mouseX, Space.World);
            }
        }
        if (Input.GetMouseButton(1))
        {
            if (mouseY != 0)
            {
                transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 200f * mouseY, Space.World);
            }
        }
    }
    #region 打开
    /// <summary>
    /// 打开冷却塔
    /// </summary>
    public void DKLengQueTa()
    {
        dengPao.SetActive(true);
    }
    /// <summary>
    /// 打开冷却水泵
    /// </summary>
    public void DKLengQueShuiBeng()
    {
        DK(lengQueShuiBengGame, LQTjt);
    }
    /// <summary>
    /// 打开冷却水泵2
    /// </summary>
    public void DKLengQueShui2Beng()
    {
        DK(lengQueShuiBeng2Game, LQSBjt);
    }
    /// <summary>
    /// 打开压缩泵
    /// </summary>
    public void DKYaSuoJi()
    {
        DK(yaSuoJiGame, YSJjt);
    }
    #endregion

    #region 关闭
    /// <summary>
    /// 关闭冷却塔
    /// </summary>
    public void GBLengQueTa()
    {
        dengPao.SetActive(false);
    }
    /// <summary>
    /// 关闭冷却水泵
    /// </summary>
    public void GBLengQueShuiBeng()
    {
        GB(lengQueShuiBengGame, LQTjt);
    }
    /// <summary>
    /// 关闭冷却水泵2
    /// </summary>
    public void GBLengQueShui2Beng()
    {
        GB(lengQueShuiBeng2Game, LQSBjt);
    }
    /// <summary>
    /// 关闭压缩泵
    /// </summary>
    public void GBYaSuoJi()
    {
        GB(yaSuoJiGame, YSJjt);
    }

    void DK(GameObject d3, GameObject jt)
    {
        foreach (Transform item in d3.transform)
        {
            item.gameObject.GetComponent<Renderer>().material = matTouMing;
        }
        foreach (Transform item in jt.transform)
        {
            item.gameObject.GetComponent<Jiantou>().enabled = true;
        }
    }
    void GB(GameObject d3, GameObject jt)
    {
        foreach (Transform item in d3.transform)
        {
            item.gameObject.GetComponent<Renderer>().material = matYuanShi;
        }
        foreach (Transform item in jt.transform)
        {
            item.gameObject.GetComponent<Jiantou>().enabled = false;
        }
    }
    #endregion
}
