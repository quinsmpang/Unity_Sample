using UnityEngine;
using System.Collections;

namespace GameMenu
{


    public class GameMenu : MonoBehaviour
    {
        public GameObject MaskMenuColliter;
        /// <summary>
        /// 护具
        /// </summary>
        public GameObject btnExposureSuit;
        /// <summary>
        /// 工具架 -- 测量项目
        /// </summary>
        public GameObject btnShelfMeasure;
        /// <summary>
        /// 二保焊
        /// </summary>
        public GameObject btnMIGWelder;
        /// <summary>
        /// 电阻焊
        /// </summary>
        public GameObject btnERW;
        /// <summary>
        /// 工具柜
        /// </summary>
        public GameObject btnCabinet;
        /// <summary>
        /// 电脑
        /// </summary>
        public GameObject btnComputer;
        /// <summary>
        /// 控制器---测量项目
        /// </summary>
        public GameObject btnControl;
        /// <summary>
        /// 工具架 -- 修复项目
        /// </summary>
        public GameObject btnShelfRepair;
        /// <summary>
        /// 打磨工具
        /// </summary>
        public GameObject btnPolish;
        /// <summary>
        /// 整形机 --  修复项目
        /// </summary>
        public GameObject btnShaper;
        /// <summary>
        /// 工具台
        /// </summary>
        public GameObject btnDesk;
        /// <summary>
        /// 设置
        /// </summary>
        public GameObject btnSetting;
        /// <summary>
        /// 菜单缩进按钮
        /// </summary>
        public GameObject btnMenu;
        /// <summary>
        /// 测试的电脑屏幕
        /// </summary>
        public GameObject ComputerScene;

        public GameObject menuOut;
        public GameObject menuIn;
        bool menuOOI = true;
        // Use this for initialization
        void Start()
        {
            //CustDebug.Log("GameMenu");
            EventTriggerListener.Get(btnMenu).onClick += MenuOnClick;
            EventTriggerListener.Get(btnExposureSuit).onClick = ExposureSuitOnClick;
            EventTriggerListener.Get(btnShelfMeasure).onClick = ShelfMeasureOnClick;
            EventTriggerListener.Get(btnMIGWelder).onClick = MIGWelderOnClick;
            EventTriggerListener.Get(btnERW).onClick = ERWOnClick;
            EventTriggerListener.Get(btnCabinet).onClick = CabinetOnClick;
            EventTriggerListener.Get(btnComputer).onClick = ComputerOnClick;
            EventTriggerListener.Get(btnControl).onClick = ControlOnClick;
            EventTriggerListener.Get(btnShelfRepair).onClick = ShelfRepairOnClick;
            EventTriggerListener.Get(btnPolish).onClick = PolishOnClick;
            EventTriggerListener.Get(btnShaper).onClick = ShaperOnClick;
            EventTriggerListener.Get(btnDesk).onClick = DeskOnClick;
            EventTriggerListener.Get(btnSetting).onClick = SettingOnClick;
        }

        void MenuOnClick(GameObject btn)
        {
            //CustDebug.Log("缩进按钮");
            if (menuOOI)
            {
                btnMenu.transform.localScale = new Vector3(-1, 1, 1);
                iTween.MoveTo(MaskMenuColliter, menuOut.transform.position, 1.5f);
            }
            else
            {
                btnMenu.transform.localScale = new Vector3(1, 1, 1);
                iTween.MoveTo(MaskMenuColliter, menuIn.transform.position, 1.5f);
            }
            menuOOI = !menuOOI;
        }
        void ExposureSuitOnClick(GameObject btn)
        {
            GameObject Ex = GameObject.Find("ExposureSuit").gameObject;
            Ex.GetComponent<ExposureSuit>().InWindow();
        }
        void ShelfMeasureOnClick(GameObject btn)
        {
            GameObject go = GameObject.Find("ShelfMeasure").gameObject;
            go.GetComponent<ShelfMeasure>().InWindow();
        }
        void MIGWelderOnClick(GameObject btn)
        {
            GameObject go = GameObject.Find("MIGWelder").gameObject;
            go.GetComponent<MIGWelder>().InWindow();
        }
        void ERWOnClick(GameObject btn)
        {
            GameObject go = GameObject.Find("ERW").gameObject;
            go.GetComponent<ERW>().InWindow();
        }
        void CabinetOnClick(GameObject btn)
        {
            GameObject go = GameObject.Find("Cabinet").gameObject;
            go.GetComponent<Cabinet>().InWindow();
        }
        void ComputerOnClick(GameObject btn)
        {
            ComputerScene.SetActive(!ComputerScene.activeSelf);
        }
        void ControlOnClick(GameObject btn)
        {
            GameObject go = GameObject.Find("Control").gameObject;
            go.GetComponent<Control>().SetActives();
        }
        void ShelfRepairOnClick(GameObject btn)
        {
            GameObject go = GameObject.Find("ShelfRepair").gameObject;
            go.GetComponent<ShelfRepair>().InWindow();
        }
        void PolishOnClick(GameObject btn)
        {
            GameObject go = GameObject.Find("Polish").gameObject;
            go.GetComponent<Polish>().InWindow();
        }
        void ShaperOnClick(GameObject btn)
        {
            GameObject go = GameObject.Find("Shaper").gameObject;
            go.GetComponent<Shaper>().InWindow();
        }
        void DeskOnClick(GameObject btn)
        {
            GameObject go = GameObject.Find("Desk").gameObject;
            go.GetComponent<Desk>().InWindow();
        }
        void SettingOnClick(GameObject btn)
        {
            GameObject go = GameObject.Find("Setting").gameObject;
            go.GetComponent<Setting>().InWindow();
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}