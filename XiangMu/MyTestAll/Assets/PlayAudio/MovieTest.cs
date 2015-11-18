using UnityEngine;
using System.Collections;

public class MovieTest : MonoBehaviour
{

    void Start()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,150,80),"播放"))
        {
  //          Handheld.PlayFullScreenMovie("test.mp4", Color.black, FullScreenMovieControlMode.Full);
        }
        if(GUI.Button(new Rect(0,80,150,80),"游戏场景"))
        {
            Application.LoadLevel("Game");
        }
    }

}
