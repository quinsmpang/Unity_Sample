using UnityEngine;
using System.Collections;

public class RotateTransform : MonoBehaviour {
    /// <summary>
    /// 旋转的范围
    /// </summary>
    float rotate;
    public Transform rotateTransformRightWorld;
    public Transform rotateTransformUpWorld;
    public Transform rotateTransformLeftWorld;
    public Transform rotateTransformRightSelf;
    public Transform rotateTransformUpSelf;
    public Transform rotateTransformLeftSelf;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        rotate = Time.deltaTime * 100;
        rotateTransformRightWorld.Rotate(Vector3.right, Space.World);
        rotateTransformUpWorld.Rotate(Vector3.up, Space.World);
        rotateTransformLeftWorld.Rotate(Vector3.left, Space.World);
        rotateTransformRightSelf.Rotate(Vector3.right, Space.Self);
        rotateTransformUpSelf.Rotate(Vector3.up, Space.Self);
        rotateTransformLeftSelf.Rotate(Vector3.left, Space.Self);
	}
}
