using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XmobiTea.MiniPopup;
using XmobiTea.MiniPopup.Core;

public class UISplashSceneView : UIViewBase
{
    public override void OnCustomShow(params object[] instantiateData)
    {
        base.OnCustomShow(instantiateData);
    }

    public void PressLoginGame()
    {
        UIManager.HideAllView();
        UIManager.ShowView(UIViewConstanceId.UIMainView);
    }
}
