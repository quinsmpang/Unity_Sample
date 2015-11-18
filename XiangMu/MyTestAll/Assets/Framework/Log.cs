using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {
    public delegate void DoOnething(string str);
    public static event DoOnething doOne;
    public delegate void DoTwothing(string str);
    public static event DoTwothing doTwo;

	// Use this for initialization
	void Start () {
        if (doOne!=null)
        {
            doOne("雨松");
        }
        if (doTwo!=null)
        {
            doTwo("nono");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
