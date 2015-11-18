using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Gamelogic.Examples
{

    public class ClockTest :MonoBehaviour,  IClockListener
    {

        public Text clockText;

        public Text messageText;

        private Clock clock; // 时钟对象

        void Start()
        {

            clock = new Clock();

            clock.AddClockListener(this); // 对时钟监听
        }

        public void OnSecondsChanged(int seconds)
        {
            throw new System.NotImplementedException();
        }

        public void OnTimeOut()
        {
            throw new System.NotImplementedException();
        }
    }
}