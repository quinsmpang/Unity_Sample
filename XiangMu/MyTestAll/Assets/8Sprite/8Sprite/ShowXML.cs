using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;

public class ShowXML : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //public string showXml(string temp)
    //{
        //UnityEditor.AssetDatabase.Refresh();
        //string filepath = Application.dataPath + "/my.xml";
        //string tempText = "";
        //Debug.Log("a");
        //if (File.Exists(filepath))
        //{
        //    Debug.Log("b");
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load(filepath);//若要读网络,前面改成IEnum线程这里改网络xml地址即可
        //    XmlNodeList nodeList = xmlDoc.SelectSingleNode("main").ChildNodes;
        //    foreach (XmlElement xe in nodeList)
        //    {
        //        foreach (XmlElement x1 in xe.ChildNodes)
        //        {
        //            if (x1.Name==temp)
        //            {
        //                tempText = x1.InnerText;
        //            } 
        //        }
        //    }
        //    return tempText;
        //}
        //else
        //{
        //    return "fill not exists!";
        //}
    //}
}
