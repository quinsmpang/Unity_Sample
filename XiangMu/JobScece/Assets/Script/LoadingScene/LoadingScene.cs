using UnityEngine;
using System.Collections;

public class LoadingScene : MonoBehaviour {
    private float fps = 10.0f;
    private float timer;
    //一组动画的贴图,在编辑器中赋值
    public Texture2D[] animations;
    private int nowFram;
    //异步对象
    AsyncOperation async;
    //读取场景的进度, 他的取值范围在0-1之间
    int progress = 0;
	// Use this for initialization
	void Start () {
        //这里开启一个异步任务
        //进入LoadScene方法
        StartCoroutine(LoadScene());
	}
    IEnumerator LoadScene()
    {
        //异步读取场景
        async = Application.LoadLevelAsync(3);
        yield return async;
    }
	// Update is called once per frame
	void Update () {
        //在这里计算读取值的进度.
        //progress的取值在0.1-1之间,但是他不会等于1
        //也就是说progress可能是0.9的时候就直接进入新场景了
        //所以在写进度条的时候需要注意一下.
        //为了计算百分比,所以直接乘以100即可
        progress = (int)(async.progress * 100);
        //有了读取进入的数值,大家可以自行制作进度条啦
        Debug.Log("光亮进度条---" + progress);
	}
    void OnGUI()
    {
        //因为在异步读取场景
        //所以这里我们可以刷新UI
        DrawAnimation(animations);
    }
    /// <summary>
    /// 简单的绘制的2D的动画
    /// </summary>
    /// <param name="tex"></param>
    void DrawAnimation(Texture2D[] tex)
    {
        timer += Time.deltaTime;
        if (timer>=1.0/fps)
        {
            nowFram++;
            timer = 0;
            if (nowFram>=tex.Length)
            {
                nowFram = 0;
            }
        }
        GUI.DrawTexture(new Rect(100, 100, 40, 60), tex[nowFram]);

        //这里显示读取进度
        GUI.Label(new Rect(100, 180, 300, 60), "Loading!!!" + progress);
    }
}
