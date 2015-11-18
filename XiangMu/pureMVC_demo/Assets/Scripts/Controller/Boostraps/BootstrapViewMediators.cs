using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SimpleFramework;
public class BootstrapViewMediators : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        GameObject gameMgr = GameObject.Find("GlobalGenerator");

        AppView appview = gameMgr.GetComponent<AppView>();
        //Facade.RegisterMediator(new AppMediator(appview));
    }
}
