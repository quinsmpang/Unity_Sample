using UnityEngine;
using System.Collections;
using Delegate;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Heater.Instance.BoilWater();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
