using UnityEngine;
using System.Collections;

public class CheJia : MonoBehaviour {

    public GameObject ChuaGanQia;
    public GameObject ChuaGanQia01;
    public GameObject ChuaGanQib;
    public GameObject ChuaGanQib01;
    public GameObject ChuaGanQic;
    public GameObject ChuaGanQic01;
    public GameObject ChuaGanQie;
    public GameObject ChuaGanQie01;
    public GameObject ChuaGanQig;
    public GameObject ChuaGanQig01;
    public GameObject ChuaGanQim;
    public GameObject ChuaGanQim01;

    public void SetActiveChuanGanQi(string names)
    {
        switch (names)
        {
            case "a":
                ChuaGanQia.SetActive(!ChuaGanQia.activeSelf);
                break;
            case "a01":
                ChuaGanQia01.SetActive(!ChuaGanQia01.activeSelf);
                break;
            case "b":
                ChuaGanQib.SetActive(!ChuaGanQib.activeSelf);
                break;
            case "b01":
                ChuaGanQib01.SetActive(!ChuaGanQib01.activeSelf);
                break;
            case "c":
                ChuaGanQic.SetActive(!ChuaGanQic.activeSelf);
                break;
            case "c01":
                ChuaGanQic01.SetActive(!ChuaGanQic01.activeSelf);
                break;
            case "e":
                ChuaGanQie.SetActive(!ChuaGanQie.activeSelf);
                break;
            case "e01":
                ChuaGanQie01.SetActive(!ChuaGanQie01.activeSelf);
                break;
            case "g":
                ChuaGanQig.SetActive(!ChuaGanQig.activeSelf);
                break;
            case "g01":
                ChuaGanQig01.SetActive(!ChuaGanQig01.activeSelf);
                break;
            case "m":
                ChuaGanQim.SetActive(!ChuaGanQim.activeSelf);
                break;
            case "m01":
                ChuaGanQim01.SetActive(!ChuaGanQim01.activeSelf);
                break;
        }
    }
}
