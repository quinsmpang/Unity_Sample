using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityCillter;

public class Title_UI : MonoBehaviour {

    public Text texTitleName;
	// Use this for initialization
	void Start () {
        //CustDebug.Log(ScencModel.titleNmae);
        texTitleName.text = GameCillter.SceneName;
        //CustDebug.Log(EditorApplication.currentScene);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
