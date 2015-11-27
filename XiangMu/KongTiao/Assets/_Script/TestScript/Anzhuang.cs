using UnityEngine;
using System.Collections;

public class Anzhuang : MonoBehaviour {
    public GameObject Zhilengji;
    public GameObject Lengdongshuibeng;
    public GameObject Lengqueshuibeng;
    public GameObject Lengdongshuizhuguan;
    public GameObject Lengqueshuizhuguan;
    public GameObject Fenjishuiqi;
    public GameObject Zhilengjizufamen;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            Zhilengji.SetActive(true);
        }
        if (Input.GetKey(KeyCode.B))
        {
            Lengdongshuibeng.SetActive(true);
        }
        if (Input.GetKey(KeyCode.C))
        {
            Lengqueshuibeng.SetActive(true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Lengdongshuizhuguan.SetActive(true);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Lengqueshuizhuguan.SetActive(true);
        }
        if (Input.GetKey(KeyCode.F))
        {
            Fenjishuiqi.SetActive(true);
        }
        if (Input.GetKey(KeyCode.G))
        {
            Zhilengjizufamen.SetActive(true);
        }
	}
}
