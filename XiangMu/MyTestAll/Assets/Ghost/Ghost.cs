using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{
    /// <summary>
    /// 残影个数
    /// </summary>
    public int ghostNum;
    public float timer;
    int num;
    public float targetTimer;
    IList ghostList = new ArrayList();
    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left *5* Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > targetTimer)
        {
            timer = 0;
            num++;
            if (ghostList.Count < ghostNum)
            {
                GameObject gho = Instantiate(Resources.Load("Cube")) as GameObject;
                Destroy(gho.GetComponent<BoxCollider>());
                //gho.GetComponent<Material>().color = new Color(200, 200, 200, 200);
                //iTween.ColorTo(gho, new Color32(2, 2, 2, 2), 2.0f);
                gho.name = num.ToString();
                gho.transform.position = transform.position;
                ghostList.Add(gho);
            }
            else
            {
                GameObject go = ghostList[0] as GameObject;
                //go.GetComponent<Material>().color = Color.white;
                go.transform.position = transform.position;
                //iTween.ColorTo(go, Color.red, 2.0f);
                ghostList.RemoveAt(0);
                ghostList.Add(go);
            }
        }
    }
}
