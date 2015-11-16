using UnityEngine;
using System.Collections;

namespace UnityCillter
{
    public class GameCillter : MonoBehaviour
    {
        private static GameCillter _instance;
        public static GameCillter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameCillter();
                }
                return _instance;
            }
        }
        public static string SceneName = ScencModel.SceneNameStart;
        public static float SoundValue = 0;
        public static void SceneNameDefine(string SceneName)
        {
            switch (SceneName)
            {
                case "GameStart":
                    SceneName = ScencModel.SceneNameStart;
                    break;
                case "GameChoice":
                    SceneName = ScencModel.SceneNameChoice;
                    break;
                case "GameMeasure":
                    SceneName = ScencModel.SceneNameMeasure;
                    break;
                case "GameRepair":
                    SceneName = ScencModel.SceneNameRepair;
                    break;
                case "GameChange":
                    SceneName = ScencModel.SceneNameChange;
                    break;
            }
        }
        /// <summary>
        /// 跳转场景
        /// </summary>
        /// <param name="sceneName"></param>
        public static void GotoScene(string sceneName)
        {
            switch (sceneName)
            {
                case "GameStart":
                    SceneName = ScencModel.SceneNameStart;
                    break;
                case "GameChoice":
                    SceneName = ScencModel.SceneNameChoice;
                    break;
                case "GameMeasure":
                    SceneName = ScencModel.SceneNameMeasure;
                    break;
                case "GameRepair":
                    SceneName = ScencModel.SceneNameRepair;
                    break;
                case "GameChange":
                    SceneName = ScencModel.SceneNameChange;
                    break;
            }
            Application.LoadLevel(sceneName);
        }
        /// <summary>
        /// 跳转场景
        /// </summary>
        /// <param name="sceneNum"></param>
        public static void GotoScene(int sceneNum)
        {
            Application.LoadLevel(sceneNum);
        }
        /// <summary>
        /// 更换坐标的单个值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="flo"></param>
        /// <returns></returns>
        public static Vector2 ChangeVector2(Vector2 vec, string str, float flo)
        {
            Vector2 ve = vec;
            switch (str)
            {
                case "x":
                    ve = new Vector2(vec.x, flo);
                    break;
                case "y":
                    ve = new Vector2(flo, vec.y);
                    break;
            }
            //Vector2 ve=new Vector2(vec.x)
            return ve;
        }
        /// <summary>
        /// 更换坐标的单个值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="flo"></param>
        /// <returns></returns>
        public static Vector3 ChangeVector3(Vector3 vec, string str, float flo)
        {
            Vector3 ve = vec;
            switch (str)
            {
                case "x":
                    ve = new Vector3(flo, vec.y, vec.z);
                    break;
                case "y":
                    ve = new Vector3(vec.x, flo, vec.z);
                    break;
                case "z":
                    ve = new Vector3(vec.x, vec.y, flo);
                    break;
            }
            return ve;
        }
        /// <summary>
        /// 实例化子物体
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static GameObject InstanitiatePrefab(GameObject go)
        {
            return InstanitiatePrefab(go, Vector3.zero);
        }
        public static GameObject InstanitiatePrefab(Transform go)
        {
            return InstanitiatePrefab(go.gameObject);
        }
        public static GameObject InstanitiatePrefab(GameObject go, Vector3 pos)
        {
            GameObject son = Instantiate(go) as GameObject;
            son.transform.position = pos;
            son.transform.rotation = go.transform.rotation;
            return son;
        }
        public static void GoToChild(GameObject parent, GameObject son)
        {
            GoToChild(parent.transform, son.transform, Vector3.zero, Vector3.one);
        }
        public static void GoToChild(GameObject parent, GameObject son,Vector3 pos,Vector3 scale)
        {
            GoToChild(parent.transform, son.transform, pos, scale);
        }
        public static void GoToChild(Transform parent, Transform son)
        {
            GoToChild(parent, son, Vector3.zero, Vector3.one);
        }
        public static void GoToChild(Transform parent, Transform son, Vector3 pos,Vector3 scale)
        {
            son.transform.parent = parent.transform;
            son.transform.localPosition = pos;
            son.transform.localScale = scale;
        }


    }
}
