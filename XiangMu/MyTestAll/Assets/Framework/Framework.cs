using UnityEngine;
using System.Collections;

public class Framework : MonoBehaviour {
    private static Framework _instance;
    public static Framework Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = GameObject.Find("Main Camera").GetComponent<Framework>();
            }
            return _instance;
        }
    }
	// Use this for initialization
	void Start () {
        GreetingDelegate delegate1, delegate2;
        delegate1 = EnglishGreeting;
        delegate2 = ChineseGreeting;
        delegate2 += EnglishGreeting;
        GreetPeople("Liker", delegate1);
        GreetPeople("徐光亮", delegate2);
        delegate1("liker");
        //----------
        GreetingDelegate de1 = new GreetingDelegate(EnglishGreeting);
        de1 += ChineseGreeting;//给此魏国变量再绑定一个方法
        GreetPeople("徐光亮", de1);
        de1 -= EnglishGreeting;//取消对EnglishGreeting的绑定
        //仅调用ChineseGreeting
        de1 += EnglishGreeting;
        GreetPeople("徐光亮", ChineseGreeting);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public delegate void GreetingDelegate(string name);
    public void GreetPeople(string name, GreetingDelegate MakeGreeting)
    {
        MakeGreeting(name);
    }
    private void EnglishGreeting(string name)
    {
        Debug.Log("Good Morning, " + name);
    }
    public void ChineseGreeting(string name)
    {
        Debug.Log("早上好, " + name);
    }
}
