using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoXingNameData : MonoBehaviour
{

    private Text moxingName;
    public string names;
    public string JiShao;
    // Use this for initialization
    void Start()
    {
        moxingName = transform.FindChild("Text").GetComponent<Text>();
    }
}