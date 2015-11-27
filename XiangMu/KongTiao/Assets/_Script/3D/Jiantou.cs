using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 是系统运行的控制
/// </summary>
public class Jiantou : MonoBehaviour
{
    // public GameObject Jiantou;
    public Transform Starts;
    public Transform Target;
    public Transform GoParent;
    private bool IsMove = false;
    private List<Transform> go=new List<Transform>();
    // Use this for initialization
    void Start()
    {
        foreach (Transform item in GoParent)
        {
            //item.LookAt(Target);
            go.Add(item);
        }
      
    }
    void Update()
    {
        for (int i = 0; i < go.Count; i++)
        {
            if (go[i].transform.position != Target.position)
            {
                go[i].transform.position = Vector3.MoveTowards(go[i].transform.position, Target.transform.position, 1.5f * Time.deltaTime);
            }
            else
            {
                go[i].transform.position = Starts.position;
            }
        }
    }
}
