using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test1: MonoBehaviour{
	//电影纹理
//#if UNITY_EDITOR
	public MovieTexture movTexture;

    public GameObject btnPlay;
	public GameObject btnPause;
	public GameObject btnStop;
	void Start(){
		btnPlay.gameObject.GetComponent<Button> ().onClick.AddListener (delegate() {
			this.PlayOnClick (btnPlay);
		});
		btnPause.gameObject.GetComponent<Button> ().onClick.AddListener (delegate() {
			this.PausOnClick (btnPause);
		});
		btnStop.gameObject.GetComponent<Button> ().onClick.AddListener (delegate() {
			this.StopOnClick (btnStop);
		});
		//设置当前对象的主纹理为电影纹理
		GetComponent<Renderer>().material.mainTexture = movTexture;
		//设置电影纹理播放模式为循环
		movTexture.loop = true;
	}
	void PlayOnClick(GameObject btn){
		if(!movTexture.isPlaying)
			movTexture.Play();
	}
	void PausOnClick(GameObject btn){
		movTexture.Pause();
	}
	void StopOnClick(GameObject btn){
		movTexture.Stop();
	}
	void OnGUI(){
		//Debug.Log("d")
		if(GUILayout.Button("播放/继续"))
			//播放/继续播放视频
			if(!movTexture.isPlaying)
				movTexture.Play();
		if(GUILayout.Button("暂停播放"))
			//暂停播放
			movTexture.Pause();		
		if(GUILayout.Button("停止播放"))
			//停止播放
			movTexture.Stop();
    }
//#endif
}