using UnityEngine;
using System.Collections;

public class FollowFirst : MonoBehaviour {
    public GameObject FirstMan;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (FirstMan.activeSelf)
        {
            transform.position = FirstMan.transform.position;
            gameObject.GetComponent<MouseLook>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<MouseLook>().enabled = false;
        }
	}
}
