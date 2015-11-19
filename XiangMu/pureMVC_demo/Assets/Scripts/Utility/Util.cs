using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using UnityEditor;

namespace SimpleFramework
{
    public class Util
    {
       
        /// <summary>
        /// 转化为int
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int Int(object o)
        {
            return Convert.ToInt32(o);
        }
        /// <summary>
        /// 转化为floate
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static float Floate(object o)
        {
            return (float)Math.Round(Convert.ToSingle(o), 2);
        }
        /// <summary>
        /// 转化为long
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static long Long(object o)
        {
            return Convert.ToInt64(o);
        }
        /// <summary>
        /// 取整数型随机数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Random(int min, int max)
        {
            return UnityEngine.Random.Range(min, max);
        }
        /// <summary>
        /// 取floate类型随机数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Random(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }
        /// <summary>
        /// 取字符串前的下划线的个数
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string Uid(string uid)
        {
            int position = uid.LastIndexOf("_");
            return uid.Remove(0, position + 1);
        }
        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static long GetTime()
        {
            TimeSpan ts = new TimeSpan(DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0, 0, 0).Ticks);
            return (long)ts.TotalMilliseconds;
        }
        /// <summary>
        /// 通过GameObject获取子物体组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <param name="subnode"></param>
        /// <returns></returns>
        public static T Get<T>(GameObject go, string subnode) where T : Component
        {
            if (go != null)
            {
                Transform sub = go.transform.FindChild(subnode);

                if (subnode != null)
                {
                    return sub.GetComponent<T>();
                }
            }
            return null;
        }
        /// <summary>
        /// 通过Transform获取子物体组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <param name="subnode"></param>
        /// <returns></returns>
        public static T Get<T>(Transform go, string subnode) where T : Component
        {
            if (go != null)
            {
                Transform sub = go.FindChild(subnode);
                if (sub != null)
                {
                    return sub.GetComponent<T>();
                }
            }
            return null;
        }
        /// <summary>
        /// 通过组件获取子物体组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <param name="subnode"></param>
        /// <returns></returns>
        public static T Get<T>(Component go, string subnode) where T : Component
        {
            return go.transform.FindChild(subnode).GetComponent<T>();
        }
        /// <summary>
        /// 通过GameObject添加组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <returns></returns>
        public static T Add<T>(GameObject go) where T : Component
        {
            if (go != null)
            {
                T[] ts = go.GetComponents<T>();
                for (int i = 0; i < ts.Length; i++)
                {
                    if (ts[i] != null)
                    {
                        GameObject.Destroy(ts[i]);
                    }
                }
                return go.gameObject.AddComponent<T>();
            }
            return null;
        }
        public static T Add<T>(Transform go) where T : Component
        {
            if (go != null)
            {
                T[] ts = go.GetComponents<T>();
                for (int i = 0; i < ts.Length; i++)
                {
                    if (ts[i] != null)
                    {
                        GameObject.Destroy(ts[i]);
                    }
                }
                return go.gameObject.AddComponent<T>();
            }
            return null;
        }
        /// <summary>
        /// 通过名字查找子对象
        /// </summary>
        /// <param name="go"></param>
        /// <param name="subnode"></param>
        /// <returns></returns>
        public static GameObject Child(GameObject go, string subnode)
        {
            return Child(go.transform, subnode);
        }
        public static GameObject Child(Transform go, string subnode)
        {
            Transform tran = go.FindChild(subnode);
            if (tran == null)
            {
                return null;
            }
            return tran.gameObject;
        }
        /// <summary>
        /// 查找同级对象
        /// </summary>
        /// <param name="go"></param>
        /// <param name="subnode"></param>
        /// <returns></returns>
        public static GameObject Peer(GameObject go, string subnode)
        {
            return Peer(go.transform, subnode);
        }
        public static GameObject Peer(Transform go, string subnode)
        {
            Transform tran = go.parent.FindChild(subnode);
            if (tran == null)
            {
                return null;
            }
            return tran.gameObject;
        }
        /// <summary>
        /// 转换成64为编码
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Encode(string message)
        {
            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(message);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// 64位解码
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Decode(string message)
        {
            byte[] bytes = Convert.FromBase64String(message);
            return Encoding.GetEncoding("utf-8").GetString(bytes);
        }
        /// <summary>
        /// 判断字符串是不是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool InNumeric(string str)
        {
            if (str == null || str.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsNumber(str[i]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="surecStr"></param>
        /// <returns></returns>
        public static string HashToMD5Hex(string surecStr)
        {
            byte[] Bytes = Encoding.UTF8.GetBytes(surecStr);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] result = md5.ComputeHash(Bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    builder.Append(result[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        /// <summary>
        ///计算字符串的md5值 
        /// </summary>
        /// <returns></returns>
        public static string md5(string soruce)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(soruce);
            byte[] md5Data = md5.ComputeHash(data, 0, data.Length);

            md5.Clear();

            string destString = "";
            for (int i = 0; i < md5Data.Length; i++)
            {
                destString += System.Convert.ToString(md5Data[i], 16).PadLeft(2, '0');
            }
            destString = destString.PadLeft(32, '0');
            return destString;
        }
        /// <summary>
        /// 计算文件的md5
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string md5fils(string file)
        {
            try
            {
                FileStream fs = new FileStream(file, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(fs);
                fs.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("md5file(),fail,error: " + ex.Message);
            }
        }
        /// <summary>
        /// 删除所有的子元素
        /// </summary>
        /// <param name="go"></param>
        public static void ClearChild(Transform go)
        {
            if (go == null) return;
            for (int i = go.childCount - 1; i >= 0; i--)
            {
                GameObject.Destroy(go.GetChild(i).gameObject);
            }
        }
        public static string GetKey(string key)
        {
            return AppConst.AppPrefix + AppConst.UserId + "_" + key;
        }
        public static int GetInt(string key)
        {
            string name = GetKey(key);
            return PlayerPrefs.GetInt(name);
        }
        public static bool HasKey(string key)
        {
            string name = GetKey(key);
            return PlayerPrefs.HasKey(name);
        }
        public static void SetInt(string key, int value)
        {
            string name = GetKey(key);
            PlayerPrefs.DeleteKey(name);
            PlayerPrefs.SetInt(name, value);
        }
        public static string GetString(string key)
        {
            string name = GetKey(key);
            return PlayerPrefs.GetString(name);
        }
        public static void SetString(string key, string value)
        {
            string name = GetKey(key);
            PlayerPrefs.DeleteKey(name);
            PlayerPrefs.SetString(name, value);
        }
        public static void RemoveData(string key)
        {
            string name = GetKey(key);
            PlayerPrefs.DeleteKey(name);
        }
        //清理内存
        public static void ClearMemory()
        {
            GC.Collect();
            Resources.UnloadUnusedAssets();
            LuaScriptMgr mgr = AppFacade.Instance.GetManager<LuaScriptMgr>(ManagerName.Lua);
            if (mgr != null)
            {
                //mgr.LuaGC();
            }
        }
        public static bool IsNumber(string strNumber)
        {
            Regex regex = new Regex("[0-9]");
            return !regex.IsMatch(strNumber);
        }
        public static string DataPath
        {
            get
            {
                string game = AppConst.AppName.ToLower();
                if (Application.isMobilePlatform)
                {
                    return Application.persistentDataPath + "/" + game + "/";
                }
                if (Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    return Application.streamingAssetsPath + "/";
                }
                if (AppConst.DebugMode)
                {
                    if (Application.isEditor)
                    {
                        return Application.dataPath + "/StreamingAssets/";
                    }
                }
                return "c:/" + game + "/";
            }
        }
        public static string GetFileText(string path)
        {
            return File.ReadAllText(path);
        }
        /// <summary>
        /// 网络是否可用
        /// </summary>
        public static bool NetAvailable
        {
            get
            {
                return Application.internetReachability != NetworkReachability.NotReachable;
            }
        }
        /// <summary>
        /// 是否使用WiFi
        /// </summary>
        public static bool IsWiFi
        {
            get
            {
                return Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork;
            }
        }
        /// <summary>
        /// 返回程序文件路径
        /// </summary>
        /// <returns></returns>
        public static string AppContentPath()
        {
            string path = string.Empty;
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    path = "jar:file://" + Application.dataPath + "!/assets/";
                    break;
                case RuntimePlatform.BlackBerryPlayer:
                    break;
                case RuntimePlatform.IPhonePlayer:
                    path = Application.dataPath + "/Ray/";
                    break;
                case RuntimePlatform.LinuxPlayer:
                    break;
                case RuntimePlatform.WSAPlayerARM:
                    break;
                case RuntimePlatform.WSAPlayerX64:
                    break;
                case RuntimePlatform.WSAPlayerX86:
                    break;
                case RuntimePlatform.OSXDashboardPlayer:
                    break;
                case RuntimePlatform.OSXEditor:
                    break;
                case RuntimePlatform.OSXPlayer:
                    break;
                case RuntimePlatform.OSXWebPlayer:
                    break;
                case RuntimePlatform.PS3:
                    break;
                case RuntimePlatform.PS4:
                    break;
                case RuntimePlatform.PSM:
                    break;
                case RuntimePlatform.PSP2:
                    break;
                case RuntimePlatform.SamsungTVPlayer:
                    break;
                case RuntimePlatform.TizenPlayer:
                    break;
                case RuntimePlatform.WP8Player:
                    break;
                case RuntimePlatform.WebGLPlayer:
                    break;
                case RuntimePlatform.WindowsEditor:
                    break;
                case RuntimePlatform.WindowsPlayer:
                    break;
                case RuntimePlatform.WindowsWebPlayer:
                    break;
                case RuntimePlatform.XBOX360:
                    break;
                case RuntimePlatform.XboxOne:
                    break;
                default:
                    path = Application.dataPath + "/StreamingAssets/";
                    break;
            }
            return path;
        }
        /// <summary>
        /// lua中的单击事件 需要引入NGUI
        /// </summary>
        /// <param name="go"></param>
        /// <param name="luafuct"></param>
        public static void AddClick(GameObject go, System.Object luafuct)
        {
            //UIEventListener.Get(go).onClick+=delegate(GameObject o){
            //    LuaInterface.LuaFunction func=(LuaInterface.LuaFunction)luafuct;
            //    func.Call();
            //};
        }
        /// <summary>
        /// 是否是登录场景
        /// </summary>
        public static bool isLogin
        {
            get
            {
                return Application.loadedLevelName.CompareTo("login") == 0;
            }
        }
        /// <summary>
        /// 判断是否是主城场景
        /// </summary>
        public static bool isMain
        {
            get
            {
                return Application.loadedLevelName.CompareTo("main") == 0;
            }
        }
        /// <summary>
        /// 是否是战斗场景
        /// </summary>
        public static bool isFight
        {
            get
            {
                return Application.loadedLevelName.CompareTo("fight") == 0;
            }
        }
        /// <summary>
        /// 返回lua路径
        /// </summary>
        /// <returns></returns>
        public static string LuaPath()
        {
            if (AppConst.DebugMode)
            {
                return Application.dataPath + "/lua/";
            }
            return DataPath + "lua/";
        }
        /// <summary>
        /// lua脚本路径
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string LuaPath(string name)
        {
            string path = AppConst.DebugMode ? Application.dataPath + "/" : DataPath;
            string loverName = name.ToLower();
            if (loverName.EndsWith(".lua"))
            {
                int index = name.LastIndexOf('.');
                name = name.Substring(0, index);
            }
            name = name.Replace(".", "/");
            
            return path+"lua/"+name+".lua";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject LoadAsset(AssetBundle bundle, string name)
        {
#if UNITY_5
            return bundle.LoadAsset(name,typeof(GameObject))as GameObject;
#else
            return bundle.Load(name,typeof(GameObject))as GameObject;
#endif
        }
        /// <summary>
        /// 增加组件
        /// </summary>
        /// <param name="go"></param>
        /// <param name="assembly"></param>
        /// <param name="classename"></param>
        /// <returns></returns>
        public static Component AddComponent(GameObject go, string assembly, string classename)
        {
            Assembly asmb = Assembly.Load(assembly);
            Type t = asmb.GetType(assembly + "." + classename);
            return go.AddComponent(t);
        }
        /// <summary>
        /// 加载预设体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject LoadPrefab(string name)
        {
            return Resources.Load(name, typeof(GameObject)) as GameObject;
        }
        /// <summary>
        /// 执行lua方法
        /// </summary>
        /// <param name="module"></param>
        /// <param name="func"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object[] CallMethod(string module, string func, params object[] args)
        {
            LuaScriptMgr luaMgr = AppFacade.Instance.GetManager<LuaScriptMgr>(ManagerName.Lua);
            if (luaMgr==null)
            {
                return null;
            }
            string funcName = module + "." + func;
            funcName = funcName.Replace("(Clone)", "");
            return luaMgr.CallLuaFunction(funcName, args);
        }
        /// <summary>
        /// 为了防止不按步骤进行操作,
        /// </summary>
        /// <returns></returns>
        public static int CheckRuntimeFile()
        {
            if (!Application.isEditor)
            {
                return 0;
            }
            string streamDir = Application.dataPath + "/StreamingAssets/";
            if (!Directory.Exists(streamDir))
            {
                return -1;
            }
            else
            {
                string[] files = Directory.GetFiles(streamDir);
                if (files.Length==0)
                {
                    return -1;
                }
                if (!File.Exists(streamDir+"files.txt"))
                {
                    return -1;
                }
            }
            string sourceDir = Application.dataPath + "/Source/LuaWrap";
            if (!Directory.Exists(sourceDir))
            {
                return -2;
            }
            else
            {
                string[] files = Directory.GetFiles(sourceDir);
                if (files.Length==0)
                {
                    return -2;
                }
            }
            return 0;
        }
        public static bool CheckEnviroment()
        {
#if UNITY_ENITOR
            int resulId = Util.CheckRuntimeFile();
            if (resulId==-1)
            {
                CustDebug.LogError("没有找到框架所需要资源, 单击Game菜单下的Build xxx Resoure");
                EditorApplication.isPlaying = false;
                return false;
            }
            else if (resulId==-2)
            {
                CustDebug.LogError("没有找到Wrap脚本缓存,单击Lua菜单Gen Lua Wrap");
                EditorApplication.isPlaying = false;
                return false;
            }
#endif
            if (Application.loadedLevelName=="Test"&&!AppConst.DebugMode)
            {
                CustDebug.LogError("测试场景,必须打开调试模式,AppConst.DebugMode=true!!!");
                EditorApplication.isPlaying = false;
                return false;
            }
            return true;
        }
    }
}