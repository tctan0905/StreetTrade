using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XmobiTea.MiniPopup;
using XmobiTea.MiniPopup.Core;

namespace StreetTrade
{
    public class UIMainView : UIViewBase
    {
        public override void OnCustomShow(params object[] instantiateData)
        {
            base.OnCustomShow(instantiateData);
        }

        public void PressMap()
        {
            UIManager.ShowPopup(UIPopupConstanceId.UIMapTabPopup);
        }

        public void PressTruck()
        {
            UIManager.ShowPopup(UIPopupConstanceId.UIInventoryTabPopup);
        }
    }
}
