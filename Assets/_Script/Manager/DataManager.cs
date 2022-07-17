using CodeStage.AntiCheat.ObscuredTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    [SerializeField]
    private UserCurrent userCurrent;
    public UserCurrent UserCurrent => userCurrent;

    [SerializeField]
    private UserCharacterItem userCharacterItem;
    public UserCharacterItem UserCharacterItem => userCharacterItem;

    public Action OnUpdateMap;

    [SerializeField]
    private ObscuredInt maxShoppingcart;
    public ObscuredInt MaxShoppingCart
    {
        get
        {
            return maxShoppingcart;
        }
        set
        {
            maxShoppingcart = value;
        }
    }

    [SerializeField]
    private List<GoodsDataItem> goodsDataItemLst;
    public List<GoodsDataItem> GoodsDataItemLst => goodsDataItemLst;
}
