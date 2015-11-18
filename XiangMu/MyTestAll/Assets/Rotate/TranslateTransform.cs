using UnityEngine;
using System.Collections;

public class TranslateTransform : MonoBehaviour {
    float posX;
    float posY;
    float posZ;
    public Transform translateX;
    public Transform translateY;
    public Transform translateZ;

	void Update () {
	    //设置移动的范围
        float x = Time.deltaTime * 3;
        float y = Time.deltaTime * 2;
        float z = Time.deltaTime * 1;

        //设置移动
        translateX.Translate(x, 0, 0);
        translateY.Translate(0, y, 0);
        translateZ.Translate(0, 0, z);
	}
}
