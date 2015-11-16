using UnityEngine;
using System.Collections;
using UnityCillter;
using UnityEngine.UI;

namespace GameMenu
{
    public class GameChoiceUI : MonoBehaviour
    {
        public GameObject sceneNameToggle1;
        public GameObject sceneNameToggle2;
        public GameObject sceneNameToggle3;
        /// <summary>
        /// 进入场景按钮
        /// </summary>
        public GameObject btnBigen;
        /// <summary>
        /// 返回上一场景按钮
        /// </summary>
        public GameObject back;
        /// <summary>
        /// 选中场景介绍
        /// </summary>
        public Text introductionText;
        /// <summary>
        /// 选中场景的图片介绍
        /// </summary>
        public Image introductionImage;
        /// <summary>
        /// 当前选中的那一个场景
        /// </summary>
        int sceneNum = 1;
        AsyncOperation async;
        float sceneProgress = 0;
        GameObject progressBar;
        // Use this for initialization
        void Start()
        {
            EventTriggerListener.Get(sceneNameToggle1).onClick = Toggle1Click;
            EventTriggerListener.Get(sceneNameToggle2).onClick = Toggle2Click;
            EventTriggerListener.Get(sceneNameToggle3).onClick = Toggle3Click;
            EventTriggerListener.Get(btnBigen).onClick = ButtonClick;
            EventTriggerListener.Get(back).onClick = backOnClick;
            Toggle1Click(sceneNameToggle1);
            progressBar = GameObject.FindGameObjectWithTag("progressbar").gameObject;
            progressBar.gameObject.SetActive(false);
        }

        void backOnClick(GameObject btn)
        {
            GameCillter.GotoScene("GameStart");
        }
        void Toggle1Click(GameObject go)
        {
            bool togg = go.GetComponent<Toggle>().isOn;
            if (togg)
            {
                //CustDebug.Log("toggle1为真");
                sceneNum = 1;
                AssignmentText(SceneIntroduction.SceneIntroductioOne);
            }
        }
        void Toggle2Click(GameObject go)
        {
            bool togg = go.GetComponent<Toggle>().isOn;
            if (togg)
            {
                //CustDebug.Log("toggle2为真");
                sceneNum = 2;
                AssignmentText(SceneIntroduction.SceneIntroductioTwo);
            }
        }
        void Toggle3Click(GameObject go)
        {
            bool togg = go.GetComponent<Toggle>().isOn;
            if (togg)
            {
                //CustDebug.Log("toggle3为真");
                sceneNum = 3;
                AssignmentText(SceneIntroduction.SceneIntroductioThree);
            }
        }
        void ButtonClick(GameObject go)
        {
            switch (sceneNum)
            {
                case 1:
                    //GameCillter.GotoScene("Game" + "Measure");
                    StartCoroutine(StartScene("Game" + "Measure"));
                    break;
                case 2:
                    //GameCillter.GotoScene("Game" + "Change");
                    StartCoroutine(StartScene("Game" + "Change"));
                    break;
                case 3:
                    //GameCillter.GotoScene("Game" + "Repair");
                    StartCoroutine(StartScene("Game" + "Repair"));
                    break;
            }
            //StartCoroutine(StartScene());

        }
        /// <summary>
        /// 关于本项目的介绍
        /// </summary>
        /// <param name="str"></param>
        void AssignmentText(string str)
        {
            introductionText.text = str;
            introductionImage.sprite = Resources.Load("Sprite/Texture/scene" + sceneNum, typeof(Sprite)) as Sprite;
            //Debug.Log(introductionImage.sprit)
        }
        void Update()
        {
            if (async != null)
            {
                progressBar.GetComponent<ProgressBar>().ModifyBar(async.progress);
                CustDebug.Log(async.progress + "场景进度条");
            }
        }
        IEnumerator StartScene(string name)
        {
            CustDebug.Log("异步加载场景");
            btnBigen.SetActive(false);
            back.SetActive(false);
            progressBar.gameObject.SetActive(true);
            async = Application.LoadLevelAsync(name);
            GameCillter.SceneNameDefine(name);
            //async = GameCillter.GotoScene(name) as AsyncOperation;
            //StartCoroutine(LoadScene());
            yield return async;
        }
        //IEnumerator LoadScene()
        //{
        //    yield return new WaitForEndOfFrame();
        //   // progressBar.GetComponent<ProgressBar>().ModifyBar(async.progress);
        //    CustDebug.LogError(async.progress + "场景进度条");
        //}
    }
}