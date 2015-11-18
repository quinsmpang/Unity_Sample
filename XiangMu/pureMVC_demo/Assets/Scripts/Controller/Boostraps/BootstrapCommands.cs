using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SimpleFramework;
/// <summary>
/// 注册Command,简历Command与Notification之间的映射
/// </summary>
public class BootstrapCommands : SimpleCommand
{
    /// <summary>
    /// 执行启动命令
    /// </summary>
    /// <param name="notification"></param>
    public override void Execute(INotification notification)
    {
        Facade.RegisterCommand(NotiConst.DISPATCH_MESSAGE, typeof(SocketCommand)); ;

        //Facade.AddManager(ManagerName.Lua, new LuaScriptMgr());

        //Facade.AddManager<PanelManager>(ManagerName.Panel);
        //Facade.AddManager<MusicManager>(ManagerName.Music);
        //Facade.AddManager<TimerManager>(ManagerName.Timer);
        //Facade.AddManager<NetWorkManager>(ManagerName.NetWork);
        //Facade.AddManager<ResourManager>(ManagerName.Resource);
        //Facade.AddManager<ThreadManager>(ManagerName.Thread);
        //Facade.AddManager<GameManager>(ManagerName.Game);
    }
}
