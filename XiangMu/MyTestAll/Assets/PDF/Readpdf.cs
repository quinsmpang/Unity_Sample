using UnityEngine;
using System.Collections;
using System.IO;

public class Readpdf : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public Texture2D img = null;
    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 20), "选择文件"))
        {

            //OpenFileDialog od = new OpenFileDialog();
            //od.Title = "请选择头像图片";
            //od.Multiselect = false;
            //od.Filter = "图片文件(*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp";
            //if (od.ShowDialog() == DialogResult.OK)
            //{
                if (File.Exists(UnityEngine.Application.streamingAssetsPath + "/Temp/temp.png"))
                {
                    File.Delete(UnityEngine.Application.streamingAssetsPath + "/Temp/temp.png");
                    //File.Copy(od.FileName, UnityEngine.Application.streamingAssetsPath + "/Temp/temp.png");
                }
                else
                {
                    //File.Copy(od.FileName, UnityEngine.Application.streamingAssetsPath + "/Temp/temp.png");
                }
                StartCoroutine(GetTexture("file://" + UnityEngine.Application.streamingAssetsPath + "/Temp/temp.png"));
            }
        //}
        if (img != null)
        {
            GUI.DrawTexture(new Rect(0, 20, img.width, img.height), img);
        }
    }

    IEnumerator GetTexture(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.isDone && www.error == null)
        {
            img = www.texture;
            Debug.Log(img.width + "  " + img.height);
            byte[] data = img.EncodeToPNG();
            File.WriteAllBytes(UnityEngine.Application.streamingAssetsPath + "/Temp/temp.png", data);
        }
    }
}
