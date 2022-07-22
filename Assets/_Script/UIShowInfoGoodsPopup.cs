using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using XmobiTea.MiniPopup.Core;
using static ConfigGame;

public class UIShowInfoGoodsPopup : UIPopupBase
{
    [SerializeField] TMP_Text titleTmp;
    [SerializeField] TMP_Text priceTmp;
    [SerializeField] TMP_Text profitTmp;
    [SerializeField] TMP_Text expTmp;
    [SerializeField] TMP_Text timeDoneTmp;
    [SerializeField] TMP_Text amountTMP;

    int amount;

    private GoodsStatsConfigItem item;

    public override void OnCustomShow(params object[] instantiateData)
    {
        base.OnCustomShow(instantiateData);

        item = (GoodsStatsConfigItem)instantiateData[0];

        if (!GameManager.IsExists) return;

        if (item == null) return;

        Init(item.Id);

        amount = 1;

        amountTMP.text = amount.ToString();
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

    public void PressLeft()
    {
        if (amount > 1)
        {
            amount--;
            amountTMP.text = amount.ToString();

        }
    }

    public void PressRight()
    {
        amount++;
        amountTMP.text = amount.ToString();
    }

    public void Init(int id)
    {
        if (!GameManager.IsExists) return;

        var configGame = GameManager.Instance.ConfigGame;

        var goodsStatsConfig = configGame.GoodsStatsConfig.GetItemById(id);

        if (goodsStatsConfig != null)
        {
            titleTmp.text = goodsStatsConfig.Name;
            priceTmp.text = goodsStatsConfig.MoneyBuy.ToString("N0");
            profitTmp.text = goodsStatsConfig.Profit.ToString("N0");

            var changeMiliToMinu = (goodsStatsConfig.TimeDone / 1000) / 60;

            timeDoneTmp.text = changeMiliToMinu.ToString("N0") + " minutes";
            expTmp.text = goodsStatsConfig.Experience.ToString("N0");
        }
    }
}
