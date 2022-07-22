using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XmobiTea.MiniPopup.Core;

public class UIGaraPopup : UIPopupBase
{
    [SerializeField] UIGaraItemController cellItem;

    [SerializeField] List<UIGaraItemController> uiGaraItemControllerLst;

    protected override void OnCustomAwake()
    {
        base.OnCustomAwake();
        if (cellItem.gameObject.activeSelf) cellItem.gameObject.SetActive(false);
        if (uiGaraItemControllerLst == null) uiGaraItemControllerLst = new List<UIGaraItemController>();
    }

    public override void OnCustomShow(params object[] instantiateData)
    {
        base.OnCustomShow(instantiateData);

        var dataCenter = GameManager.Instance.DataManager;

        dataCenter.UserCharacterItem.OnUpdateTruck -= OnUpdateGara;
        dataCenter.UserCharacterItem.OnUpdateTruck += OnUpdateGara;

        OnUpdateGara();
    }

    public void PressClose()
    {
        this.gameObject.SetActive(false);
    }

    public void OnUpdateGara()
    {
        if (!GameManager.IsExists) return;

        var configGame = GameManager.Instance.ConfigGame;
        var dataCenter = GameManager.Instance.DataManager;

        var truckConfigLst = configGame.TruckConfigItemLst;
        var truckDataItem = dataCenter.TruckDataItemLst;

        while (uiGaraItemControllerLst.Count < truckDataItem.Count)
        {
            uiGaraItemControllerLst.Add(Instantiate(cellItem, cellItem.transform.parent));
        }

        for (int i = 0; i < uiGaraItemControllerLst.Count; i++)
        {
            uiGaraItemControllerLst[i].Item = truckConfigLst[i];
        }
    }

    public void PressUse(UIGaraItemController uiGaraItemController)
    {
        if (uiGaraItemController == null) return;

        var item = uiGaraItemController.Item;

        var dataCenter = GameManager.Instance.DataManager;

        var userCharacterItem = dataCenter.UserCharacterItem;

        userCharacterItem.TruckItemId = item.Id;
    }

    public override void OnCustomHide()
    {
        base.OnCustomHide();

                var dataCenter = GameManager.Instance.DataManager;

        dataCenter.UserCharacterItem.OnUpdateTruck -= OnUpdateGara;
    }
}
