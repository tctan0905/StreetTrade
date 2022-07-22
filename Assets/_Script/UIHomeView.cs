using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XmobiTea.MiniPopup;
using XmobiTea.MiniPopup.Core;

public class UIHomeView : UIViewBase
{
    public void PressHome()
    {
        UIManager.ShowView(UIViewConstanceId.UIHomeView);
    }

    public void PressGara()
    {
        UIManager.ShowPopup(UIPopupConstanceId.UIGaraPopup);
    }
}
