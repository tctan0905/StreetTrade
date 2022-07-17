using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ConfigGame;

namespace StreetTrade
{
    public class UIMapItemController : UIItemController<MapConfigItem>
    {
        [SerializeField] private TMP_Text nameTMP;
        [SerializeField] private Image avaterImg;

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

                var mapConfig = configGame.GetMapConfigItem(Item.Id);

                if (mapConfig != null)
                {
                    avaterImg.sprite = mapConfig.Spr;
                }
            }
        }
    }
}

