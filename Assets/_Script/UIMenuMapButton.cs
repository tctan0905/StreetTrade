using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XmobiTea.MiniPopup;

public class UIMenuMapButton : MonoBehaviour
{
    public void PressMap()
    {
        UIManager.ShowPopup(UIPopupConstanceId.UIMapTabPopup);
    }
}
