using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class CameraTest : MonoBehaviour
{
    public WebCamTexture cameraTexture;
    public string cameraName = "";
    private bool isPlay = false;
    // Use this for initialization
    void Start()
    {
        //StartCoroutine(OpenCamera());
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 获取权限打开摄像头
    /// </summary>
    /// <returns></returns>
    IEnumerator OpenCamera()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            cameraName = devices[0].name;
            cameraTexture = new WebCamTexture(cameraName, 320, 240, 15);
            cameraTexture.Play();
            isPlay = true;
        }
    }

    void OnGUI()
    {
        if (isPlay)
        {
            GUI.DrawTexture(new Rect(0, 0, 320, 240), cameraTexture, ScaleMode.ScaleAndCrop);
        }

        if (GUI.Button(new Rect(0, 0, 100, 35), "OpenDialog"))
        {
            OpenFileName ofn = new OpenFileName();

            ofn.structSize = Marshal.SizeOf(ofn);

            ofn.filter = "All Files\0*.*\0\0";

            ofn.file = new string(new char[256]);

            ofn.maxFile = ofn.file.Length;

            ofn.fileTitle = new string(new char[64]);

            ofn.maxFileTitle = ofn.fileTitle.Length;

            ofn.initialDir = UnityEngine.Application.dataPath;//默认路径

            ofn.title = "Open Project";

            ofn.defExt = "JPG";//显示文件的类型
            //注意 一下项目不一定要全选 但是0x00000008项不要缺少
            ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR

            if (WindowDll.GetOpenFileName(ofn))
            {
                Debug.Log("Selected file with full path: {0}" + ofn.file);
            }

        }
    }
}
