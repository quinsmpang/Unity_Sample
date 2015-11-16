using UnityEngine;
using System.Collections;
using UnityCillter;
using System;

/// <summary>
/// 用于大梁校正仪的滑竿
/// </summary>
public class HuaGan : MonoBehaviour
{
    public GameObject HuaGanUp;
    public GameObject HuaGanDown;
    public GameObject HuaGanLeft;
    public GameObject HuaGanRight;
    private Sub_Objects huaGanUp;
    private Sub_Objects huaGanDown;
    private Sub_Objects huaGanLeft;
    private Sub_Objects huaGanRight;
    public bool IsWorkHuaGang = true ;
    // Use this for initialization
    void Start()
    {
        huaGanUp = HuaGanUp.GetComponent<Sub_Objects>();
        huaGanDown = HuaGanDown.GetComponent<Sub_Objects>();
        huaGanLeft = HuaGanLeft.GetComponent<Sub_Objects>();
        huaGanRight = HuaGanRight.GetComponent<Sub_Objects>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
           // CustDebug.Log(MainCameraRay.Instance.mainCameraHit.transform.name + Time.time);
            if (Input.GetMouseButtonDown(0))
            {
                huaGanRight.tiesuokou(MainCameraRay.Instance.mainCameraHit);
            }
            //
        }
        catch (Exception ex)
        {
            //CustDebug.Log("未检测到物体:------" + ex.Message);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            //huaGanUp.HuaGanTouUpOrDown(true);
            //huaGanDown.HuaGanTouUpOrDown(true);
            //huaGanLeft.HuaGanTouUpOrDown(true);
            //huaGanRight.HuaGanTouUpOrDown(true);
            huaGanUp.TieSuoKouUpOrDown(true);
            huaGanDown.TieSuoKouUpOrDown(true);
            huaGanLeft.TieSuoKouUpOrDown(true);
            huaGanRight.TieSuoKouUpOrDown(true);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            //huaGanUp.HuaGanTouUpOrDown(false);
            //huaGanDown.HuaGanTouUpOrDown(false);
            //huaGanLeft.HuaGanTouUpOrDown(false);
            //huaGanRight.HuaGanTouUpOrDown(false);
            huaGanUp.TieSuoKouUpOrDown(false);
            huaGanDown.TieSuoKouUpOrDown(false);
            huaGanLeft.TieSuoKouUpOrDown(false);
            huaGanRight.TieSuoKouUpOrDown(false);
        }
    }
}
