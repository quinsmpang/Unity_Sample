using UnityEngine;
using System.Collections;

public class IsMoveCube : MonoBehaviour
{

    public GameObject UpCubeBtn;
    public GameObject DownCubeBtn;
    public GameObject GameUpOrDown;
    public float speed;
    Ray ray;
    RaycastHit hit;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Hello Word");
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == UpCubeBtn)
            {
                MoveGame(Vector3.up);
            }
            if (hit.transform.gameObject == DownCubeBtn)
            {
                MoveGame(Vector3.down);
            }
        }
    }
    void MoveGame(Vector3 move)
    {
        Debug.Log(GameUpOrDown.transform.localPosition);
        bool IsMove = true;
        if (IsMove)
        {
            GameUpOrDown.transform.Translate(move * Time.deltaTime * speed);
        }
        Debug.Log(GameUpOrDown.transform.localPosition.y);
        if (GameUpOrDown.transform.localPosition.y >= 1)//在一帧之内y值还是有微小变化，但不会显示在inspectors里，因为这里显示的是从一帧到下一帧的变化值。
        {
            GameUpOrDown.transform.localPosition = new Vector3(GameUpOrDown.transform.localPosition.x, 1, GameUpOrDown.transform.localPosition.z);
            IsMove = false;
        }
        else if (GameUpOrDown.transform.localPosition.y <= -0.1f)
        {
            GameUpOrDown.transform.localPosition = new Vector3(GameUpOrDown.transform.localPosition.x, -0.1f, GameUpOrDown.transform.localPosition.z);
            IsMove = false;
        }
        else
        {
            IsMove = true;
        }
    }
}
