using UnityEngine;
using System.Collections;
 
public class Global :MonoBehaviour
{
    //public static Global instance;
    //public int i = 1;
 
    //static Global()
    //{
    //    GameObject go = new GameObject("Globa");
    //    DontDestroyOnLoad(go);
    //    instance = go.AddComponent<Global>();
    //}
 
    //public void DoSomeThings()
    //{
    //    i++;
    //    Debug.Log("DoSomeThings");
    //    Debug.Log(i);
    //}
 
    //void Start () 
    //{
    //    Debug.Log("Start");
    //}

    public GameObject GameUI;
    public static bool isUI = false;
    void Start()
    {
        //Debug.Log("Global");
        if (!isUI)
        {
            DontDestroyOnLoad(GameUI);
            isUI = true;
        }
       
    }
}