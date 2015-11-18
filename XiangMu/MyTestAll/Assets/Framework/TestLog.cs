using UnityEngine;
using System.Collections;

public class TestLog : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //OnEnable();
	}
    void OnEnable()
    {
        Log.doOne += DOnething;
        Log.doTwo += DoTwething;
    }
    void OnDisable()
    {
        Log.doOne -= DOnething;
        Log.doTwo -= DoTwething;
    }
    public void DOnething(string str)
    {
        Debug.Log("DoOnething " + str);
    }
    public void DoTwething(string str)
    {
        Debug.Log("DoTwething " + str);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
