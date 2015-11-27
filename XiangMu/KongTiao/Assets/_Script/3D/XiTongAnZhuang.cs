using UnityEngine;
using System.Collections;

/// <summary>
/// 系统安装
/// </summary>
public class XiTongAnZhuang : MonoBehaviour {
    /// <summary>
    /// 主摄像机
    /// </summary>
    public GameObject mainCameras;
    #region 安装点的箭头
    public GameObject LDB;
    public GameObject LQSB;
    public GameObject LQSZG;
    public GameObject LDSZG;
    public GameObject ZLZJ;
    public GameObject FJSQ;
    public GameObject FM;
    private GameObject temppos;
    #endregion
    #region 摄像机的点
    public GameObject LDBC;
    public GameObject LQSBC;
    public GameObject LQSZGC;
    public GameObject LDSZGC;
    public GameObject ZLZJC;
    public GameObject FJSQC;
    public GameObject FMC;
    #endregion
    #region 要安装的东西
    public GameObject LDBG;
    public GameObject LQSBG;
    public GameObject LQSZGG;
    public GameObject LDSZGG;
    public GameObject ZLZJG;
    public GameObject FJSQG;
    public GameObject FMG;
    private GameObject tempGame;
    #endregion
    // Use this for initialization
    void Start()
    {
        #region 将所有的对象进行隐藏
        LDB.SetActive(false);
        LQSB.SetActive(false);
        LQSZG.SetActive(false);
        LDSZG.SetActive(false);
        ZLZJ.SetActive(false);
        FJSQ.SetActive(false);
        FM.SetActive(false);
        LDBC.SetActive(false);
        LQSBC.SetActive(false);
        LQSZGC.SetActive(false);
        LDSZGC.SetActive(false);
        ZLZJC.SetActive(false);
        FJSQC.SetActive(false);
        FMC.SetActive(false);
        LDBG.SetActive(false);
        LQSBG.SetActive(false);
        LQSZGG.SetActive(false);
        LDSZGG.SetActive(false);
        ZLZJG.SetActive(false);
        FJSQG.SetActive(false);
        FMG.SetActive(false);
        #endregion
    }
    /// <summary>
    /// 设置摄像机位置
    /// </summary>
    /// <param name="str"></param>
    public GameObject CameraPostion(string str, bool set)
    {
        if (temppos != null)
        {
            temppos.SetActive(false);
        }
        //LDB.SetActive(str == "LDBC");
        //LQSB.SetActive(str == "LQSBC");
        //LQSZG.SetActive(str == "LQSZGC");
        //LDSZG.SetActive(str == "LDSZGC");
        //ZLZJ.SetActive(str == "ZLZJC");
        //FJSQ.SetActive(str == "FJSQC");
        //FM.SetActive(str == "FMC");
        switch (str)
        {
            case "LDBC":
                mainCameras.transform.position = LDBC.transform.position;
                mainCameras.transform.localRotation = LDBC.transform.localRotation;
                //mainCameras.transform
                temppos = LDB;
                tempGame = LDBG;
                break;
            case "LQSBC":
                mainCameras.transform.position = LQSBC.transform.position;
                mainCameras.transform.localRotation = LQSBC.transform.localRotation;
                temppos = LQSB;
                tempGame = LQSBG;
                break;
            case "LQSZGC":
                mainCameras.transform.position = LQSZGC.transform.position;
                mainCameras.transform.localRotation = LQSZGC.transform.localRotation;
                temppos = LQSZG;
                tempGame = LQSZGG;
                break;
            case "LDSZGC":
                mainCameras.transform.position = LDSZGC.transform.position;
                mainCameras.transform.localRotation = LDSZGC.transform.localRotation;
                temppos = LDSZG;
                tempGame = LDSZGG;
                break;
            case "ZLZJC":
                mainCameras.transform.position = ZLZJC.transform.position;
                mainCameras.transform.localRotation = ZLZJC.transform.localRotation;
                temppos = ZLZJ;
                tempGame = ZLZJG;
                break;
            case "FJSQC":
                mainCameras.transform.position = FJSQC.transform.position;
                mainCameras.transform.localRotation = FJSQC.transform.localRotation;
                temppos = FJSQ;
                tempGame = FJSQG;
                break;
            case "FMC":
                mainCameras.transform.position = FMC.transform.position;
                mainCameras.transform.localRotation = FMC.transform.localRotation;
                temppos = FM;
                tempGame = FMG;
                break;
        }
        if (temppos != null && tempGame != null)
        {
            temppos.SetActive(set);
            return tempGame;
        }
        return null;
    }
    /// <summary>
    /// 摄像机对准冷冻泵
    /// </summary>
    public void LDBz()
    {
        mainCameras.transform.position = ZLZJC.transform.position;
        mainCameras.transform.localRotation = ZLZJC.transform.localRotation;
    }
    /// <summary>
    /// 上面的方法将临时的变量进行返回,这里将其进行显示
    /// </summary>
    /// <param name="go"></param>
    public string AnZhuangGame(GameObject go)
    {
        go.SetActive(true);
        if (LDBG == go)
        {
            return "LDB";
        }
        if (LQSBG == go)
        {
            return "LQSB";
        }
        if (LQSZGG == go)
        {
            return "LQSZG";
        }
        if (LDSZGG == go)
        {
            return "LDSZG";
        }
        if (ZLZJG == go)
        {
            return "ZLZJ";
        }
        if (FJSQG == go)
        {
            return "FJSQ";
        }
        if (FMG == go)
        {
            return "FM";
        }
        return null;
    }
    public void SetActiveJT()
    {
        if (temppos != null)
        {
            temppos.SetActive(false);
        }
    }
}
