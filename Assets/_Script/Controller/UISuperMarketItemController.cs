using StreetTrade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ConfigGame;

public class UISuperMarketItemController : UIItemController<GoodsStatsConfigItem>
{
    [SerializeField] Image goodsImg;
    protected override void OnChangeValue()
    {
        base.OnChangeValue();

        if (Item == null)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);

            if (!GameManager.IsExists) return;

            var configGame = GameManager.Instance.ConfigGame;

            var goodConfigItem = configGame.GetGoodsConfigItem(Item.Id);

            if (goodConfigItem != null)
            {
                goodsImg.sprite = goodConfigItem.GoodSpr;
            }
        }
    }
}
