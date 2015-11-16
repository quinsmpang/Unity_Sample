using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

    public static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = new Player();
            }
            return _instance;
        }
    }
    /// <summary>
    /// 角色所在的项目
    /// </summary>
    public int project = 1;
    //普通帽子   :1; 
    //安全帽     :1; 
    //透明面罩   :2;
    //电焊面罩   :2;
    //耳罩       :3
    //口罩       :4;
    //手套(全指) :8;
    //手套(电焊) :8;
    //防护衣     :9;
    //护膝       :10;
  
}
