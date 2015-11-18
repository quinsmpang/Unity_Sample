using UnityEngine;
using System.Collections;

public class ColliterInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            InputMouseButtonDown();
        }

	}
    public virtual void InputMouseButtonDown()
    {

    }
}
