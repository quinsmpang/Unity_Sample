using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        //获取组件
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 point = Vector3.zero;
        //鼠标左键单击
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                //判断是否是地形
               // if (!hit.collider.name.Equals("Terrain"))
                //{
                 //   return;
                //}
                //点击位置坐标
                point = hit.point;
                //转向
                transform.LookAt(new Vector3(point.x, transform.position.y, point.z));
                //设置寻路的目标点
                agent.SetDestination(point);
                
            }
        }
        if (gameObject.transform.position==point)
        {
            //agent.SetDestination(null);
        }
	}
}
