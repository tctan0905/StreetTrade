using StreetTrade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XmobiTea.MiniPopup;
using XmobiTea.MiniPopup.Core;

public class UIMapTabPopup : UIPopupBase
{
    [SerializeField] UIMapItemController cellItem;

    [SerializeField] List<UIMapItemController> uiMapItemControllerLst;

    protected override void OnCustomAwake()
    {
        base.OnCustomAwake();
        if(cellItem.gameObject.activeSelf) cellItem.gameObject.SetActive(false);
        if (uiMapItemControllerLst == null) uiMapItemControllerLst = new List<UIMapItemController>();
    }

    public override void OnCustomShow(params object[] instantiateData)
    {
        base.OnCustomShow(instantiateData);

        if (!GameManager.IsExists) return;

        var dataManager = GameManager.Instance.DataManager;

        dataManager.OnUpdateMap -= OnUpdateMap;
        dataManager.OnUpdateMap += OnUpdateMap;

        OnUpdateMap();
    }

    public void PressGo(UIMapItemController uiMapItemController)
    {
        if (uiMapItemController == null) return;

        var item = uiMapItemController.Item;

        UIManager.HideAllView();
        UIManager.HideAllPopup();

        switch (item.mapState)
        {
            case MapConfigItem.MapState.MARKET:
                UIManager.ShowPopup(UIPopupConstanceId.UIMarketTabPopup);
                break;
            case MapConfigItem.MapState.SUPERMARKET:
                UIManager.ShowPopup(UIPopupConstanceId.UISuperMarketTabPopup);
                break;
        }
    }

    public void PressClose()
    {
        this.gameObject.SetActive(false);
    }

    public void OnUpdateMap()
    {
        if (!GameManager.IsExists) return;

        var configGame = GameManager.Instance.ConfigGame;

        var mapConfigItem = configGame.MapConfigItemLst;

        while (uiMapItemControllerLst.Count < mapConfigItem.Count)
        {
            uiMapItemControllerLst.Add(Instantiate(cellItem, cellItem.transform.parent));
        }

        for (int i = 0; i < mapConfigItem.Count; i++)
        {
            uiMapItemControllerLst[i].Item = mapConfigItem[i];
        }
    }
}
