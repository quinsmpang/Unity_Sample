using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class RaycastReflection : MonoBehaviour
{
    //本地的Transform;
    private Transform goTransfor;
    //添加的line renderer 组件
    private LineRenderer lineRenderer;
    //一条射线
    private Ray ray;
    //一个RaycastHit类型的变量,可以得到射线碰撞点的信息;
    private RaycastHit hit;
    //折射的方向
    private Vector3 inDirection;
    //折射次数
    public int nReflections;
    //lint renderer组件上点的数量
    private int nPoints;

    void Awake()
    {
        //初始化组件
        goTransfor = this.GetComponent<Transform>();
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //在当前物体的正前方发射一条射线
        ray = new Ray(goTransfor.position, goTransfor.forward);
        //只有在编辑器的Scene窗口才会看到的射线,用于调试
        //Debug.DrawRay(goTransfor.position, goTransfor.forward * 100, Color.magenta);

        //讲lineRenderer的点数设置成和折叠次数相等
        if (nReflections >= 1 && nReflections != null)
        {
            nPoints = nReflections;
            //使lineRenderer有nPoints个点
            lineRenderer.SetVertexCount(nPoints);
            //讲lineRenderer的第一个点设置为当前的位置
            lineRenderer.SetPosition(0, goTransfor.position);

            for (int i = 0; i < nReflections && Physics.Raycast(ray.origin, ray.direction, out hit, 100); i++)
            {
                //检查射线是否碰到了墙壁
                // if (Physics.Raycast(ray.origin, ray.direction, out hit, 100)) //发射了一条100长度的射线
                //{
                //折射方向就是当前碰撞点的反射角
                inDirection = Vector3.Reflect(hit.point, hit.normal);
                //新建一条射线,用刚才的碰撞点当做新射线的初始点,用折射方向当做他的发射方向
                ray = new Ray(hit.point, inDirection);
                //调试用信息,绘制法线.射线
                //Debug.DrawRay(hit.point, hit.normal * 3, Color.blue);
                //Debug.DrawRay(hit.point, inDirection * 100, Color.magenta);

                //打印被射线击中物体的名称
                //Debug.Log("被击中物体名字" + hit.transform.name);

                //给lineRenderer上新加一个点
                lineRenderer.SetVertexCount(++nPoints);
                //将lineRenderer的下一个点的位置设置击中的位置
                lineRenderer.SetPosition(i + 1, hit.point);
                //    }
            }
        }
    }
}
