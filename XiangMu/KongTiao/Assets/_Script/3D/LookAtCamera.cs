using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {

    private static LookAtCamera _instance;
    public static LookAtCamera Instance
    {
        get
        {
            if (_instance!=null)
            {
                _instance = GameObject.Find("LookAtCamera").GetComponent<LookAtCamera>();
            }
            return _instance;
        }
    }
    public GameObject JianTou;
    public float speed = 60f;
    private bool IsRota = true;
    Ray ray;
    RaycastHit hit;
	// Use this for initialization
	void Start () {
        //JianTou.SetActive(false);
    }
    void Update()
    {
        JianTou.transform.Rotate(Vector3.up * speed * Time.deltaTime);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == JianTou && Input.GetMouseButtonDown(0))
            {
                Debugger.Log("点击到了箭头");
            }
        }
    }
}
