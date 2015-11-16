using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityCillter;

namespace GameMenu
{
    public class GameStartUI : MonoBehaviour
    {
        /// <summary>
        /// 介绍的Mask
        /// </summary>
        public GameObject scrollRectWin;
        public GameObject MyCarma;
        /// <summary>
        /// 介绍的UI
        /// </summary>
        public GameObject introductionUI;
        /// <summary>
        /// 进入场景的Button;
        /// </summary>
        public GameObject goToSceneBtn;
        public GameObject targetUI;

        // Use this for initialization
        void Start()
        {
            scrollRectWin.GetComponent<ScrollRect>().enabled = false;
            EventTriggerListener.Get(goToSceneBtn).onClick = ButtonClick;
            StartCoroutine(GoUPintroductionUI(3.0f));
        }

        // Update is called once per frame
        void Update()
        {

        }
        void ButtonClick(GameObject btn)
        {
            GameCillter.GotoScene("GameChoice");
        }
        IEnumerator GoUPintroductionUI(float timer)
        {
            iTween.MoveTo(introductionUI.gameObject, targetUI.transform.position, timer);
            yield return new WaitForSeconds(timer);
            scrollRectWin.GetComponent<ScrollRect>().enabled = true;
        }
    }
}