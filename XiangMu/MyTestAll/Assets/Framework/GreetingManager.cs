using UnityEngine;
using System.Collections;
namespace Delegate
{
    /// <summary>
    /// 定义委托,它定义了可以代表的方法的类型
    /// </summary>
    /// <param name="name"></param>
    public delegate void GreetingDelegate(string name);
    /// <summary>
    /// 新建的GreetingManager类
    /// </summary>
    public class GreetingManager : MonoBehaviour
    {
        /// <summary>
        /// 在GreetingManager类的内部声明变量
        /// </summary>
        public event GreetingDelegate MakeGreet;
        public void GreetPeople(string name)
        {
                MakeGreet(name);
        }
    }
    class Program
    {
        private static void EnglishGreeting(string name)
        {
            Debug.Log("Good Morning, " + name);
        }
        private static void ChineseGreeting(string name)
        {
            Debug.Log("早上好, " + name);
        }
        void main()
        {
            GreetingManager gm = new GreetingManager();
            //gm.MakeGreet = EnglishGreeting;
            gm.MakeGreet += ChineseGreeting;
            gm.GreetPeople("liker");
        }

    }
}