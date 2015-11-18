using UnityEngine;
using System.Collections;

public class RayFire : MonoBehaviour
{
    public GameObject Cube2;
    void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(1))
        {
            if ("添加判断条件"!=null)
            {
                Cube2.SetActive(true);
                Cube2.transform.localPosition = hit.point;
                Cube2.transform.rotation = Quaternion.LookRotation(hit.normal, transform.up);
            }
        }
        else
        {
            Cube2.SetActive(false);
        }
    }
}
