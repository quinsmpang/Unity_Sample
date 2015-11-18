using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPlay : MonoBehaviour {
#if UNITY_EDITOR
	public MovieTexture movTexture;

	public GameObject texture;
	public GameObject btnPlay;
	public GameObject btnStop;
	// Use this for initialization
	void Start () {
		movTexture.loop = true;
		texture.gameObject.GetComponent<RawImage> ().texture = movTexture;
		btnPlay.gameObject.GetComponent<Button> ().onClick.AddListener (delegate() {
			this.PlayOnClick (btnPlay);
		});
		btnStop.gameObject.GetComponent<Button> ().onClick.AddListener (delegate() {
			this.StopOnClick (btnStop);
		});
	}
	void PlayOnClick(GameObject btn){
		if (!movTexture.isPlaying) {
			movTexture.Play ();
			btnPlay.transform.FindChild ("Text").gameObject.GetComponent<Text>().text = "Pause"; 
		} else {
			movTexture.Pause ();
			btnPlay.transform.FindChild("Text").gameObject.GetComponent<Text>().text="Play";
		}
	}
	void StopOnClick(GameObject btn){
		movTexture.Stop();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.KeypadEnter)||Input.GetKeyDown(KeyCode.Return)) {
			if (!movTexture.isPlaying) {
				movTexture.Play ();
				btnPlay.transform.FindChild ("Text").gameObject.GetComponent<Text>().text = "Pause"; 
			} else {
				movTexture.Pause ();
				btnPlay.transform.FindChild("Text").gameObject.GetComponent<Text>().text="Play";
			}
		}
    }
#endif

}
