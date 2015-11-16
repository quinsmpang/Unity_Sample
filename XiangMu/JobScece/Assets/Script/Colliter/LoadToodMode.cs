using UnityEngine;
using System.Collections;

namespace UnityCillter
{
/// <summary>
/// 用来读取数据的一个类, 输出为二维数组
/// </summary>
    public class LoadToodMode
    {
        private static LoadToodMode _instance;
        protected static string[][] ToolReadArray;
        public static LoadToodMode Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoadToodMode();
                }
                return _instance;
            }
        }
        
        protected string[][] ReadTool(string path)
        {
            if (ToolReadArray == null)
            {
                //读取二进制文本
                TextAsset binAsset = Resources.Load(path, typeof(TextAsset)) as TextAsset;
                //读取每一行的内容
                string[] lineArray = binAsset.text.Split("\r"[0]);
                //创建二维数组
                //string[][] Array = new string[lineArray.Length][];
                ToolReadArray = new string[lineArray.Length][];
                for (int i = 0; i < lineArray.Length; i++)
                {
                    ToolReadArray[i] = lineArray[i].Split(";"[0]);
                }
            }
            return ToolReadArray;
        }
        protected void DataConversion(string[][] array)
        {
            string[][] strArray;
            for (int i = 0; i < array.Length; i++)
            {
                
            }
        }
    }
}
