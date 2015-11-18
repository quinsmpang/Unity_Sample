using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
public class _Player : MonoBehaviour
{
    //private static Animator anim;//动画
    public float Move_Speed;
    private CharacterController chacoll;//角色控制器
    Vector3 moveDirection = Vector3.zero;//移动使用的三维
    public Transform camera_roto;//我们声明个平移组建来控制角色的移动方向，当然也可以不设置，3D的必须设置

    public RectTransform rt;//摇杆移动，关键的一个畸形位置，这里就是存放上面脚本拖动到Image组建的RectTransform组建， 圆心贴图属性的矩形位置

    // Use this for initialization
    void Start()
    {
       // anim = GetComponent<Animator>();//得到动画组建
        
        chacoll = GetComponent<CharacterController>();//得到角色控制器
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("x:"+rt.anchoredPosition.x+"y:" + rt.anchoredPosition.y);
        //地面移动
        //if (chacoll.isGrounded)
        //{
           // Debug.Log(rt.anchoredPosition.x + rt.anchoredPosition.y);
            AnimEventDrag(rt.anchoredPosition.x, rt.anchoredPosition.y); //移动方法,这是我写的移动方法，方法在下面
        //}
        //移动
        chacoll.Move(moveDirection * Time.deltaTime);
    }
    
    /// <summary>
    /// 角色移动动画方法
    /// 此方法有两个参数，分别获得X和Y方向来设置移动的方向
    /// </summary>
    /// <param name="Horizontal"></param>
    /// <param name="Vertical"></param>
    private void AnimEventDrag(float Horizontal, float Vertical)
    {
        //统一动画run
        if (Vertical != 0 || Horizontal != 0)
        {
            //设置速度
            //anim.speed = Move_Speed;
            //anim.Play("Run");
            //始终对准相机的前方移动
            moveDirection = new Vector3(transform.forward.x * 5f, moveDirection.y, transform.forward.z * 5f);
            if (Vertical > 30f)//前进
            {
                if (Horizontal > 30f)//右前斜进
                    transform.rotation = Quaternion.Euler(0, camera_roto.eulerAngles.y + 60, 0);
                else if (Horizontal < -30f)//左前斜进
                    transform.rotation = Quaternion.Euler(0, camera_roto.eulerAngles.y - 60, 0);
                else
                    transform.rotation = Quaternion.Euler(0, camera_roto.eulerAngles.y, 0);

            }
            else if (Vertical < -30f)//后进
            {
                if (Horizontal > 30f)//后右斜进
                    transform.rotation = Quaternion.Euler(0, camera_roto.eulerAngles.y + 120, 0);
                else if (Horizontal < -30f)//后左斜进
                    transform.rotation = Quaternion.Euler(0, camera_roto.eulerAngles.y - 120, 0);
                else
                    transform.rotation = Quaternion.Euler(0, camera_roto.eulerAngles.y - 180, 0);
            }
            else if (Horizontal < -30f)//左进
                transform.rotation = Quaternion.Euler(0, camera_roto.eulerAngles.y - 90, 0);
            else if (Horizontal > 30f)//右进
                transform.rotation = Quaternion.Euler(0, camera_roto.eulerAngles.y + 90, 0);
        }
        else
        {
            //anim.Play("Idle");
            moveDirection = new Vector3(0, moveDirection.y, 0);
        }

    }
}