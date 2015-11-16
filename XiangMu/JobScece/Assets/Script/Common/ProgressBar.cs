using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
    
	// Use this for initialization
    public Image scrollBar;
	
    public void ModifyBar(float barNum)
    {
        scrollBar.fillAmount = barNum;
    }
}
