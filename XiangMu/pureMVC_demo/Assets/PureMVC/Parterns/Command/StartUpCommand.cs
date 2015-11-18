using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using UnityEditor;
using SimpleFramework;

public class StartUpCommand : MacroCommand{

    protected override void InitializeMacroCommand()
    {
        base.InitializeMacroCommand();
#if UNITY_ENITOR
        int resultId=Util.CheckRuntimeFile();
        if(resultId == -1){
            Debug.LogError("No Find Resoure");
            EditorApplication.isPlaying=false;
            return;
        }
        else if (resultId == -2)
        {
            Debug.LogError("No Find Wrap Fire");
            EditorApplication.isPlaying = false;
            return;
        }
#endif
        AddSubCommand(typeof(BootstrapViewMediators));
        AddSubCommand(typeof(BootstrapCommands));
        AddSubCommand(typeof(BootstrapModels));
    }
}
