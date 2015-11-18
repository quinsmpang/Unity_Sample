using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    public GameObject cube;
    Rigidbody cubeRigidbody;
    bool jumpjing = false;
    Vector3 jumpVector;
    float timer = 0;
    float jumpTime;
    //bool jumpButtonPressed;
	// Use this for initialization
	void Start () {
        jumpTime = 0.4f;
        jumpVector = new Vector3(10, 20, 10);
        cubeRigidbody = cube.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)&&!jumpjing)
        {
            Debug.Log("跳跃");
            jumpjing = true;
            StartCoroutine(JumpRoutine());
        }
	}

    IEnumerator JumpRoutine()
    {
        cubeRigidbody.velocity = Vector2.zero;
        while (timer < jumpTime)
        {
            float proportionCompleted = timer / jumpTime;
            Vector2 thisFrameJumpVector = Vector2.Lerp(jumpVector, Vector2.zero, proportionCompleted);
            cubeRigidbody.AddForce(thisFrameJumpVector);
            timer += Time.deltaTime;
            yield return null;
        }
        Debug.Log("jump is over");
        timer = 0;
        jumpjing = false;
    }

}
