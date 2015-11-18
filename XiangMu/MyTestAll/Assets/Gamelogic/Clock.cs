using System.Collections.Generic;
namespace Gamelogic
{
    public class Clock
    {
        private float time;
        private int timeInSeconds;
        private readonly List<IClockListener> listeners; // 监听列表
        #region
        public bool IsPaused
        {
            get;
            private set;
        }
        public bool IsDone
        {
            get;
            private set;
        }
        public float Time
        {
            get
            {
                return time;
            }
        }
        public int TimeInSeconds
        {
            get
            {
                return timeInSeconds;
            }
        }
        #endregion
        // 构造函数
        public Clock()
        {
            listeners = new List<IClockListener>();
            IsPaused = true;
            Reset(0);
        }
        public void AddClockListener(IClockListener listener)
        {
            listeners.Add(listener);
        }
        public void RemoveClockListener(IClockListener listener)
        {
            listeners.Remove(listener);
        }
        public void Reset(float startTime)
        {
            time = startTime;
            IsDone = false;
            CheckIfTimeInSecondsChanged();
        }
        public void Unpause()
        {
            IsPaused = false;
        }
        public void Pause()
        {
            IsPaused = true;
        }
        // 时间每帧更新
        public void Update()
        {
            if (IsPaused) return;
            if (IsDone) return;
            time -= UnityEngine.Time.deltaTime;
            CheckIfTimeInSecondsChanged();
            if (time <= 0)
            {
                time = 0;
                IsDone = true;
                for (int i = 0; i < listeners.Count; i++)
                {
                    listeners[i].OnTimeOut();
                }
            }
        }
        // 判断是否发生秒的改变
        private void CheckIfTimeInSecondsChanged()
        {
            var newTimeInSeonds = (int)time;
            if (newTimeInSeonds == timeInSeconds) return;
            timeInSeconds = newTimeInSeonds;
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].OnSecondsChanged(timeInSeconds);
            }
        }
    }
    // 时钟监听者类型接口
    public interface IClockListener
    {
        void OnSecondsChanged(int seconds);
        void OnTimeOut();
    }
}