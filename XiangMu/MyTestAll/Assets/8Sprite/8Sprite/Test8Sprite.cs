using UnityEngine;
using System.Collections;

public class Test8Sprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    float myGameTimer = 5.0f;
    bool gameOver = false;
    //-----
    float speed = 5.0f;
    //-----
    float power = 500.0f;
    public GameObject powerGameObject;
	// Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("正在输入内容");
        }
        //-------------------
        if (myGameTimer > 0)
        {
            myGameTimer -= Time.deltaTime;
        }
        if (myGameTimer <= 0 && !gameOver)
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
        //-------------
        transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
        //-------------
        powerGameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, power));
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube1")
        {
            Debug.Log("碰撞Cube1");
        }
        else if (collision.gameObject.name == "Cube2")
        {
            Debug.Log("碰撞Cube2");
        }
        StartCoroutine(NextScence());
    }
    void DestroyGameOnbject(GameObject name, float timer = 0)
    {
        Destroy(name.gameObject, timer);
    }
    GameObject thePreFab;
    void InstantiateGameObject(Vector3 sonPosition)
    {
        GameObject sonGameObject = Instantiate(thePreFab) as GameObject;
        sonGameObject.transform.position = sonPosition;
    }
    void InstantiateGameObject()
    {
        GameObject sonGameObject = Instantiate(thePreFab) as GameObject;
        sonGameObject.transform.position = Vector3.zero;
    }
    IEnumerator NextScence()
    {
        yield return new WaitForSeconds(2.0f);
        Application.LoadLevel("test2");
    }
}
