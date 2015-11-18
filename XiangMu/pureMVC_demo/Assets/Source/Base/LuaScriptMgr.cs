using UnityEngine;
using System.Collections;

public class LuaScriptMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public object[] CallLuaFunction(string funcName, params object[] args)
    {
        object[] o=new object[1];
        return o;
    }
}
