using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WarningTIPS : MonoBehaviour {
    public GameObject Warning;
    /// <summary>
    /// 红色底板
    /// </summary>
    public GameObject warning;
    /// <summary>
    /// 用于显示的警告内容
    /// </summary>
    public Text texWarning;
    private static WarningTIPS _instance;
    public static WarningTIPS Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = GameObject.Find("WarningTIPS").GetComponent<WarningTIPS>();
            }
            return _instance;
        }
    }
	// Use this for initialization
	void Start () {
        Warning.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void WarningText(string warning)
    {
        Warning.SetActive(true);
        texWarning.text = warning;
        StartCoroutine(DestoryWarning());
    }
    IEnumerator DestoryWarning()
    {
        yield return new WaitForSeconds(1.0f);
        Warning.SetActive(false);
    }
    
}
