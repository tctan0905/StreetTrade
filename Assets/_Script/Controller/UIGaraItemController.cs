using StreetTrade;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGaraItemController : UIItemController<TruckConfigItem>
{
    [SerializeField] private TMP_Text nameTMP;

    [SerializeField] private Image avatarImg;

    [SerializeField] private Transform useTrans;
    [SerializeField] private Transform inUseTrans;

    protected override void OnChangeValue()
    {
        base.OnChangeValue();

        if (!GameManager.IsExists) return;

        if (Item == null)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);

            var configGame = GameManager.Instance.ConfigGame;

            var truckConfigItem = configGame.GetTrouserConfigItem(Item.Id);

            if (truckConfigItem == null) return;

            avatarImg.sprite = truckConfigItem.Sprite;

        }
    }
}
