using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class ReadAndWrite : MonoBehaviour {
    public Text texts;
	// Use this for initialization
	void Start () {
	    //判断文件是否存在,不存在则创建,否则读取值显示到窗体
        if (!File.Exists("C:\\Users\\FH\\Desktop\\FH\\TestTxt.log"))
        {
            Debug.Log("--------文件不存在,需要写入");
            Writer("文件为不存在状态，第一次输入的值");
        }
        else
        {
            Debug.Log("----------文件存在");
            Writer("文件为存在状态，重新输入的值");
        }
	}//----------------------------if和else中的逻辑相同,那么在没有检测的时候可以直接进行第二步么,效果是什么

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ArrayList lf = LoadFile("C:\\Users\\FH\\Desktop\\FH", "TestTxt.log");
            string st = "";
            for (int i = 0; i < lf.Count; i++)
            {
                st = st + lf[i].ToString() + "\n";
            }
            texts.text = st;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AppendLog("C:\\Users\\FH\\Desktop\\FH\\TestTxt.log", "我擦");
        }
	}
    public ArrayList LoadFile(string path,string name)//加载要读取的文件
    {
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + "//" + name);//打开文件的路径;
        }
        catch (Exception ex)
        {
            return null;
        }
        string line;
        ArrayList arrlist =new ArrayList();//定义一个动态数组
        while ((line=sr.ReadLine())!=null)
	    {
            arrlist.Add(line);//读取每行信息并添加到动态数组中;
	    }
        sr.Close();//关闭流
        sr.Dispose();//销毁流
        return arrlist;//返回该动态数组
    }
    public void Writer(string str)//重新写入值
    {
        FileStream fs = new FileStream("C:\\Users\\FH\\Desktop\\FH\\TestTxt.log", FileMode.Open, FileAccess.Write);
        StreamWriter sr = new StreamWriter(fs);
        sr.WriteLine(str);//开始写入值
      //  sr.WriteLine(str);
        sr.WriteLine(16);
        sr.Close();
        fs.Close();
    }
    public void AppendLog(string path,string message)
    {
        try
        {
            if (!File.Exists(path))
                File.CreateText(path);
            File.AppendAllText(path, "[" + DateTime.Now + "]" + message + "\r\n");
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
