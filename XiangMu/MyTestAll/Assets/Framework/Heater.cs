using UnityEngine;
using System.Collections;

namespace Delegate
{
    public class Heater 
    {
        private static Heater _instance;
        public static Heater Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new Heater();
                }
                return _instance;
            }
        }
        private int temperature;//水温
        //烧水
        public void BoilWater()
        {
            for (int i = 0; i <=100; i++)
            {
                temperature = i;
                if (temperature>95)
                {
                    MakeAlert(temperature);
                    ShowMsg(temperature);
                }
            }
        }
        //发出语音警报
        private void MakeAlert(int param)
        {
            Debug.Log("Alarm：嘀嘀嘀，水已经 {0} 度了："+ param);
        }
        //显示水温
        private void ShowMsg(int param)
        {
            Debug.Log("Display：水快开了，当前温度：{0}度。" + param);
        }
    }
}