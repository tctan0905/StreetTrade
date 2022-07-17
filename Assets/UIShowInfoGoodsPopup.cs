using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using XmobiTea.MiniPopup.Core;

public class UIShowInfoGoodsPopup : UIPopupBase
{
    [SerializeField] TMP_Text titleTmp;
    [SerializeField] TMP_Text priceTmp;
    [SerializeField] TMP_Text profitTmp;
    [SerializeField] TMP_Text expTmp;
    [SerializeField] TMP_Text timeTradeTmp;

    public override void OnCustomShow(params object[] instantiateData)
    {
        base.OnCustomShow(instantiateData);

        if (!GameManager.IsExists) return;

        var configGame = GameManager.Instance.ConfigGame;

        var goodsStatsConfig = configGame.GoodsStatsConfigLst;
    }

    public void PressBuy()
    {
        if (!GameManager.IsExists) return;

        var dataCenter = GameManager.Instance.DataManager;

        var tempAmount = 0;
        foreach (var item in dataCenter.GoodsDataItemLst)
        {
            tempAmount += item.Amount;
        }

        if (tempAmount < dataCenter.MaxShoppingCart)
        {

        }
        else
        {

        }
    }
}
