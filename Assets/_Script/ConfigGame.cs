using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ConfigGame", menuName = "Scriptable/ConfigGame", order = 1)]
public class ConfigGame : ScriptableObject
{
    [SerializeField] private string defaultGoods = "{}";

    [SerializeField]
    private List<GoodsConfigItem> goodsConfigItemLst;
    public List<GoodsConfigItem> GoodsConfigItemLst => goodsConfigItemLst;
    public GoodsConfigItem GetGoodsConfigItem(int id)
    {
        return goodsConfigItemLst.Find(x => x.Id == id);
    }

    [SerializeField]
    private List<GoodsStatsConfig> goodsStatsConfigLst;
    public List<GoodsStatsConfig> GoodsStatsConfigLst => goodsStatsConfigLst;

    [SerializeField]
    private List<BodyPartConfigItem> hatConfigItemLst;
    public List<BodyPartConfigItem> HatConfigItemLst => hatConfigItemLst;
    public BodyPartConfigItem GetHatConfigItem(int id)
    {
        return hatConfigItemLst.Find(x => x.Id == id);
    }

    [SerializeField]
    private List<BodyPartStatsConfig> hatStatsConfig;
    public List<BodyPartStatsConfig> HattStatsConfig => hatStatsConfig;

    [SerializeField]
    private List<BodyPartConfigItem> shirtConfigItemLst;
    public List<BodyPartConfigItem> ShirtConfigItemLst => shirtConfigItemLst;
    public BodyPartConfigItem GetShirtConfigItem(int id)
    {
        return shirtConfigItemLst.Find(x => x.Id == id);
    }

    [SerializeField]
    private List<BodyPartStatsConfig> shirtStatsConfig;
    public List<BodyPartStatsConfig> ShirttStatsConfig => shirtStatsConfig;

    [SerializeField]
    private List<BodyPartConfigItem> trouserConfigItemLst;
    public List<BodyPartConfigItem> TrouserConfigItemLst => trouserConfigItemLst;
    public BodyPartConfigItem GetTrouserConfigItem(int id)
    {
        return trouserConfigItemLst.Find(x => x.Id == id);
    }

    [SerializeField]
    private List<BodyPartStatsConfig> trouserStatsConfig;
    public List<BodyPartStatsConfig> TrouserStatsConfig => trouserStatsConfig;

}
