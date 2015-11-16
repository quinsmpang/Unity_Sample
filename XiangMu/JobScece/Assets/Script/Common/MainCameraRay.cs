using UnityEngine;
using System.Collections;
using UnityCillter;

public class MainCameraRay : MonoBehaviour {
    private static MainCameraRay _instance;
    public static MainCameraRay Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<MainCameraRay>();
            return _instance;
        }
    }
    public RaycastHit mainCameraHit;
    public Ray mainCameraRay;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        mainCameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mainCameraRay,out mainCameraHit))
        {

        }
        else
        {
            //mainCameraHit ;
        }
        //hit在有输出的时候有值, 在没有输出的时候是没有值的, 值受Physics.Raycast(mainCameraRay,out mainCameraHit)控制,
        //当Physics.Raycast(mainCameraRay,out mainCameraHit)为真则hit有值, 否则为空
        //CustDebug.Log(mainCameraHit.transform.name + Time.time);
	}
}
