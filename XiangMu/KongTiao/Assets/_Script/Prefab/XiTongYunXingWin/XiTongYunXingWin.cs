using UnityEngine;
using System.Collections;

public class XiTongYunXingWin : MonoBehaviour {
    public GameObject btnLqtOpen;
    public GameObject btnLqtClose;
    
    public GameObject btnLqsbOpen;
    public GameObject btnLqsbClose;

    public GameObject btnLqsb2Open;
    public GameObject btnLqsh2Close;
    
    public GameObject btnYsjOpen;
    public GameObject btnYsjClose;
    public RectTransform imgXTYXRaw;
    public GameObject XTYX;
    public GameObject _3DCarmer;
    public GameObject btnClose;
	// Use this for initialization
	void Start () {
        UGUIEventTriggerListener.Get(btnLqtOpen).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(btnLqtClose).onClick += ButtonOnClick;
       
        UGUIEventTriggerListener.Get(btnLqsbOpen).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(btnLqsbClose).onClick += ButtonOnClick;
        
        UGUIEventTriggerListener.Get(btnLqsb2Open).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(btnLqsh2Close).onClick += ButtonOnClick;
        
        UGUIEventTriggerListener.Get(btnYsjOpen).onClick += ButtonOnClick;
        UGUIEventTriggerListener.Get(btnYsjClose).onClick += ButtonOnClick;

        UGUIEventTriggerListener.Get(btnClose).onClick = CloseBtnOnClick;
	}
    void ButtonOnClick(GameObject btn)
    {
        if (btn==btnLqtOpen)
        {
            XTYX.GetComponent<XiTongYunXingQieHuan>().DKLengQueTa();
        }
        if (btn == btnLqtClose)
        {
            XTYX.GetComponent<XiTongYunXingQieHuan>().GBLengQueTa();
        }
        if (btn == btnLqsbOpen)
        {
             XTYX.GetComponent<XiTongYunXingQieHuan>().DKLengQueShuiBeng();
        }
        if (btn == btnLqsbClose)
        {
            XTYX.GetComponent<XiTongYunXingQieHuan>().GBLengQueShuiBeng();
        }
        if (btn == btnLqsb2Open)
        {
            XTYX.GetComponent<XiTongYunXingQieHuan>().DKLengQueShui2Beng();
        }
        if (btn == btnLqsh2Close)
        {
            XTYX.GetComponent<XiTongYunXingQieHuan>().GBLengQueShui2Beng();
        }
        if (btn == btnYsjOpen)
        {
            XTYX.GetComponent<XiTongYunXingQieHuan>().DKYaSuoJi();
        }
        if (btn == btnYsjClose)
        {
            XTYX.GetComponent<XiTongYunXingQieHuan>().GBYaSuoJi();
        }
    }
    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");
        //if (Input.GetMouseButton(1))
        //{
        //    if (mouseX != 0)
        //    {
        //        _3DCarmer.transform.RotateAround(XTYX.transform.position, XTYX.transform.up, mouseX * 500f * Time.deltaTime);
        //    }
        //    if (mouseY != 0)
        //    {
        //        _3DCarmer.transform.RotateAround(XTYX.transform.position, XTYX.transform.forward, mouseX * 500f * Time.deltaTime);
        //    }
        //}
        //if ((Input.GetAxis("Mouse ScrollWheel") != 0))
        //{
        //    //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        //    imgXTYXRaw.sizeDelta += imgXTYXRaw.sizeDelta * Input.GetAxis("Mouse ScrollWheel");
        //   // XTYX.transform.localScale += XTYX.transform.localScale * Input.GetAxis("Mouse ScrollWheel");
        //    //dipan.transform.localScale += LunTai.transform.localScale * Input.GetAxis("Mouse ScrollWheel");
        //}
    }
    void CloseBtnOnClick(GameObject btn)
    {
        CloseBtn();
    }
    public void CloseBtn()
    {
        gameObject.SetActive(false);
        transform.parent.parent.gameObject.GetComponent<MenuSheJiWindows>().FalseToggle();
    }
}
