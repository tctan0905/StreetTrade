using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Data Item
[Serializable]
public class UserCurrent
{
    public Action OnUpdateUserCurrent;

    [SerializeField]
    private int money;
    public int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }
    }

    [SerializeField]
    private int exp;
    public int Exp
    {
        get
        {
            return exp;
        }
        set
        {
            exp = value;
        }
    }

    [SerializeField]
    private int level;
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
}

[Serializable]
public class UserCharacterItem
{
    public Action OnUpdateHatItem;
    [SerializeField]
    private int hatItemId = -1;
    public int HatItemId
    {
        get
        {
            return hatItemId;
        }
        set
        {
            hatItemId = value;
            OnUpdateHatItem?.Invoke();
        }
    }

    public Action OnUpdateShirtItem;
    [SerializeField]
    private int shirtItemId = -1;
    public int ShirtItemId
    {
        get
        {
            return shirtItemId;
        }
        set
        {
            shirtItemId = value;
            OnUpdateShirtItem?.Invoke();
        }
    }

    public Action OnUpdateTrouserItem;
    [SerializeField]
    private int trouserItemId = -1;
    public int TrouserItemId
    {
        get
        {
            return trouserItemId;
        }
        set
        {
            trouserItemId = value;
            OnUpdateTrouserItem?.Invoke();
        }
    }

    public Action OnUpdateTruck;
    [SerializeField]
    private int truckItemId = 0;
    public int TruckItemId
    {
        get
        {
            return truckItemId;
        }
        set
        {
            truckItemId = value;
            OnUpdateTruck?.Invoke();
        }
    }
}

[Serializable]
public class MapConfigItem
{
    public enum MapState
    {
        MARKET = 0,
        SUPERMARKET = 1,
        HOME = 2,
        TOWN = 3,
    }

    public MapState mapState;
    public int Id;
    public Sprite Spr;
}

// CONFIG ITEM
[Serializable]
public class GoodsConfigItem
{
    public int Id;
    public Sprite GoodSpr;
}

[Serializable]
public class BodyPartConfigItem
{
    public int Id;
    public Sprite Sprite;
}


[Serializable]
public class TruckConfigItem
{
    public int Id;
    public Sprite Amount;
}

//DATA ITEM

[Serializable]
public class GoodsDataItem
{
    public int Id;
    public int Amount;
}

[Serializable]
public class TruckDataItem
{
    public int Id;
}


