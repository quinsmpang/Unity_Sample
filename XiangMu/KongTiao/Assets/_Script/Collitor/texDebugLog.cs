using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class texDebugLog : MonoBehaviour {

    private static texDebugLog _instance;
    public static texDebugLog Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = GameObject.Find("DebugLog").GetComponent<texDebugLog>();
            }
            return _instance;
        }
    }

    public void SetText(object obj)
    {
        gameObject.GetComponent<Text>().text = obj.ToString();
    }
    public void SetText(object obj, string colo)
    {
        gameObject.GetComponent<Text>().text = "<color=#"+colo+">" + obj.ToString() + "</color>";
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
