using UnityEngine;
using System.Collections;

public class rotateray : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * 15f,Space.World);
	}
}
