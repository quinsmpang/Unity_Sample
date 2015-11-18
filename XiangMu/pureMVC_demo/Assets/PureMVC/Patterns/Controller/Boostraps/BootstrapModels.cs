using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SimpleFramework;

public class BootstrapModels : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        //Facade.RegisterProxy(new SocketProxy());
    }
}
