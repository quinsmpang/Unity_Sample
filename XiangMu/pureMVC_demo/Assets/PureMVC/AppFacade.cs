using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class AppFacade : Facade
{
    private static AppFacade _instance;
    public AppFacade()
        : base()
    {

    }
    //设置单例模式
    public static AppFacade Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AppFacade();
            return _instance;
        }
    }
    //注册  
    public void RegisterMultiCommand(SimpleCommand commandClassRef, params string[] notificationName)
    {
        int count = notificationName.Length;
        for (int i = 0; i < count; i++)
        {
            RegisterCommand(notificationName[i], commandClassRef.GetType());
        }
    }
    public void RegisterMultiCommand(System.Type commandType, params string[] notificationName)
    {
        int count = notificationName.Length;
        for (int i = 0; i < count; i++)
        {
            RegisterCommand(notificationName[i], commandType.GetType());
        }
    }
    //移除掉
    public void RemoveMultiCommand(params string[] notificationName)
    {
        int count = notificationName.Length;
        for (int i = 0; i < count; i++)
        {
            RemoveCommand(notificationName[i]);
        }
    }
    override protected void InitializeController()
    {
        base.InitializeController();
        
        RegisterCommand(NotiConst.START_UP, typeof(StartUpCommand));
    }
    /// <summary>
    /// 启动框架
    /// </summary>
    public void StarUp()
    {
        SendNotification(NotiConst.START_UP);
        RemoveMultiCommand(NotiConst.START_UP);
    }
}
