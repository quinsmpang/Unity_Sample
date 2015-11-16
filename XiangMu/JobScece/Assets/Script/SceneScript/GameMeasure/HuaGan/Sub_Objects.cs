using UnityEngine;
using System.Collections;
using UnityCillter;

public class Sub_Objects : MonoBehaviour
{
    /// <summary>
    /// 铁索扣,可上下移动
    /// </summary>
    public GameObject tieSuoKou;
    /// <summary>
    /// 螺丝, 用于拧紧铁索扣
    /// </summary>
    public GameObject LuoSi;
    /// <summary>
    /// 螺丝是否拧紧, 如果false则滑竿头部不可动, true则铁索扣不可移动, 并提示
    /// </summary>
    private bool IsLuoSi=true ;
    /// <summary>
    /// 滑竿的头部, 可上下滑动
    /// </summary>
    public GameObject huaGanTou;
    /// <summary>
    /// 扳手A
    /// </summary>
    public GameObject banShouA;
    /// <summary>
    /// 扳手B
    /// </summary>
    public GameObject banShouB;

    /// <summary>
    /// 控制铁索扣上升和下降, 真为上升, 假为下降
    /// </summary>
    /// <param name="DOU"></param>
    public void TieSuoKouUpOrDown(bool DOU)
    {
        //if (!IsLuoSi)
        //{
            //if (DOU && tieSuoKou.transform.localPosition.z < 1.0f)
            //{

            //    tieSuoKou.transform.Translate(Vector3.forward * Time.deltaTime);
            //}
            //else if (!DOU && tieSuoKou.transform.localPosition.z > -0.5f)
            //{
            //    tieSuoKou.transform.Translate(Vector3.back * Time.deltaTime);
            //}
            //CustDebug.Log(tieSuoKou.transform.localPosition);
        //}
        //else
        //{
        //    WarningTIPS.Instance.WarningText("未将螺丝松开, 请先打开螺丝"); 
        //    CustDebug.Log("未将螺丝松开, 请先打开螺丝");
        //}
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name=="ZhuZi")
                {
                    StartCoroutine(TieSuoKouMove(hit.point));
                }
            }
    }
    public void tiesuokou(RaycastHit hit)
    {
        
        StartCoroutine(TieSuoKouMove(hit.point));
    }
    /// <summary>
    /// 使用携程移动铁索扣
    /// </summary>
    /// <param name="hitPos"></param>
    /// <returns></returns>
    IEnumerator TieSuoKouMove(Vector3 hitPos)
    {
        CustDebug.Log("Hit:---" + hitPos);
        yield return null;
        bool IsMove = true;
        while (IsMove)
        {
            if (IsMove)
            {
                if (tieSuoKou.transform.position.y > hitPos.y)
                {
                    tieSuoKou.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
                }
                else
                {
                    tieSuoKou.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
                }
            }
            if (tieSuoKou.transform.localPosition.y >= 0.9f)
            {
                tieSuoKou.transform.localPosition = new Vector3(tieSuoKou.transform.localPosition.x, 0.9f, tieSuoKou.transform.localPosition.z);
                IsMove = false;
            }
            else if (tieSuoKou.transform.localPosition.y < -0.3f)
            {
                tieSuoKou.transform.localPosition = new Vector3(tieSuoKou.transform.localPosition.x, -0.3f, tieSuoKou.transform.localPosition.z);
                IsMove = false;
            }
            else if (Vector3.Distance(tieSuoKou.transform.position, hitPos)<0.01f)
            {
                //tieSuoKou.transform.position=
            } else
            {
                IsMove = true;
            }
            CustDebug.Log(tieSuoKou.transform.localPosition);
            yield return null;
        }
    }
    /// <summary>
    /// 控制头部柱子上升和下降, 真为上升, 假为下降
    /// </summary>
    /// <param name="DOU"></param>
    public void HuaGanTouUpOrDown(bool DOU)
    {
        //if (IsLuoSi)
        //{
            if (DOU && huaGanTou.transform.localPosition.z < 1.5f)
            {
                huaGanTou.transform.Translate(Vector3.forward * Time.deltaTime);
            }
            else
            {
                if (huaGanTou.transform.localPosition.z > 0f)
                {
                    huaGanTou.transform.Translate(Vector3.back * Time.deltaTime);
                }
            }
            CustDebug.Log(huaGanTou.transform.localPosition.ToString() + DOU);
        //}
        //else
        //{
        //    WarningTIPS.Instance.WarningText("未将螺丝拧紧, 请先拧紧螺丝");
        //    CustDebug.Log("未将螺丝拧紧, 请先拧紧螺丝");
        //}
    }
    public void BanShouUpOrDown(bool DOU)
    {
        bool b = true;
        if (b)//预留一个判断, 判断滑竿是否在工作状态
        {
            
        }
        else
        {
            WarningTIPS.Instance.WarningText("滑竿为工作状态, 不可以打开扳手");
        }
    }
    /// <summary>
    /// 使用携程, 将扳手拧紧,或卸开
    /// </summary>
    /// <returns></returns>
    IEnumerator BanShouUpOrDownIE()
    {
        yield return new WaitForSeconds(0);
    }
}
