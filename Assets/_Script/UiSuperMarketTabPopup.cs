using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XmobiTea.MiniPopup;
using XmobiTea.MiniPopup.Core;

public class UiSuperMarketTabPopup : UIPopupBase
{
    [SerializeField] UISuperMarketItemController cellItem;

    [SerializeField] List<UISuperMarketItemController> uiSuperMarketItemLst;

    protected override void OnCustomAwake()
    {
        base.OnCustomAwake();

        if (cellItem.gameObject.activeSelf) cellItem.gameObject.SetActive(false);
        if (uiSuperMarketItemLst == null) uiSuperMarketItemLst = new List<UISuperMarketItemController>();
    }

    public override void OnCustomShow(params object[] instantiateData)
    {
        base.OnCustomShow(instantiateData);

        if (!GameManager.IsExists) return;

        var configGame = GameManager.Instance.ConfigGame;

        var goodsStatsConfig = configGame.GoodsStatsConfigLst.Items;

        while (uiSuperMarketItemLst.Count < goodsStatsConfig.Count)
        {
            uiSuperMarketItemLst.Add(Instantiate(cellItem, cellItem.transform.parent));
        }

        for (int i = 0; i < goodsStatsConfig.Count; i++)
        {
            uiSuperMarketItemLst[i].Item = goodsStatsConfig[i];
        }
    }

    public void PressShowInfo(UISuperMarketItemController uiSuperMarketItemController)
    {
        if (!GameManager.IsExists) return;

        if (uiSuperMarketItemController == null) return;

        var item = uiSuperMarketItemController.Item;

        UIManager.ShowPopup(UIPopupConstanceId.UIShowInfoGoodsPopup);
    }
}
