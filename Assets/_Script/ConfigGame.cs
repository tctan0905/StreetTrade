using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using XmobiTea.MiniJson;
using CodeStage.AntiCheat.ObscuredTypes;
using System.Linq;

[CreateAssetMenu(fileName = "ConfigGame", menuName = "Scriptable/ConfigGame", order = 1)]
public class ConfigGame : ScriptableObject
{
    [SerializeField] private string defaultGoodsStatsConfig = "{}";
    [SerializeField] private string defaultMapStatsConfig = "{}";
    [SerializeField] private string defaultTruckStatsConfig = "{}";

    [SerializeField]
    private List<BodyPartConfigItem> hatConfigItemLst;
    public List<BodyPartConfigItem> HatConfigItemLst => hatConfigItemLst;
    public BodyPartConfigItem GetHatConfigItem(int id)
    {
        return hatConfigItemLst.Find(x => x.Id == id);
    }

    [SerializeField]
    private List<BodyPartConfigItem> shirtConfigItemLst;
    public List<BodyPartConfigItem> ShirtConfigItemLst => shirtConfigItemLst;
    public BodyPartConfigItem GetShirtConfigItem(int id)
    {
        return shirtConfigItemLst.Find(x => x.Id == id);
    }

    [SerializeField]
    private List<BodyPartConfigItem> trouserConfigItemLst;
    public List<BodyPartConfigItem> TrouserConfigItemLst => trouserConfigItemLst;
    public BodyPartConfigItem GetTrouserConfigItem(int id)
    {
        return trouserConfigItemLst.Find(x => x.Id == id);
    }

    [SerializeField]
    private List<GoodsConfigItem> goodsConfigItemLst;
    public List<GoodsConfigItem> GoodsConfigItemLst => goodsConfigItemLst;
    public GoodsConfigItem GetGoodsConfigItem(int id)
    {
        return goodsConfigItemLst.Find(x => x.Id == id);
    }

    [SerializeField]
    private List<MapConfigItem> mapConfigItemLst;
    public List<MapConfigItem> MapConfigItemLst => mapConfigItemLst;
    public MapConfigItem GetMapConfigItem (int id)
    {
        return mapConfigItemLst.Find(x => x.Id == id);
    }

    [SerializeField]
    private List<TruckConfigItem> truckConfigItemLst;
    public List<TruckConfigItem> TruckConfigItemLst => truckConfigItemLst;
    public TruckConfigItem GetTruckConfigItem(int id)
    {
        return truckConfigItemLst.Find(x => x.Id == id);
    }

    [SerializeField]
    private Config<BodyPartStatsConfigItem> hatStatsConfig;
    public Config<BodyPartStatsConfigItem> HattStatsConfig => hatStatsConfig;

    [SerializeField]
    private Config<BodyPartStatsConfigItem> trouserStatsConfig;
    public Config<BodyPartStatsConfigItem> TrouserStatsConfig => trouserStatsConfig;

    [SerializeField]
    private Config<BodyPartStatsConfigItem> shirtStatsConfig;
    public Config<BodyPartStatsConfigItem> ShirttStatsConfig => shirtStatsConfig;

    [SerializeField]
    private Config<GoodsStatsConfigItem> goodsStatsConfig;
    public Config<GoodsStatsConfigItem> GoodsStatsConfig => goodsStatsConfig;

    [SerializeField]
    private Config<MapStatsConfigItem> mapStatsConfig;
    public Config<MapStatsConfigItem> MapStatsConfig => mapStatsConfig;

    [SerializeField]
    private Config<TruckStatsConfigItem> truckStatsConfig;
    public Config<TruckStatsConfigItem> TruckStatsConfig => truckStatsConfig;

    public void LoadData()
    {
        goodsStatsConfig = new Config<GoodsStatsConfigItem>("GoodsStatsConfig", defaultGoodsStatsConfig);
        truckStatsConfig = new Config<TruckStatsConfigItem>("TruckStatsConfig", defaultTruckStatsConfig);
    }

    [Serializable]
    public class Config<T> where T : ConfigItem, new()
    {
        private const string DEFAULT_DATA = "{}";

        public ObscuredString ConfigName { get; private set; }
        public ObscuredInt Version { get; private set; }
        public List<T> Items { get; private set; }
        void SaveConfig(CXData cxData)
        {
            StoragePrefs.Set(ConfigName, cxData.JSON);
        }

        CXData GetConfig(string defaultConfigData = DEFAULT_DATA)
        {
            return CXObject.FromJson(StoragePrefs.Get(ConfigName, defaultConfigData));
        }

        public void UpdateConfig(CXData cxData)
        {
            try
            {
                var version = cxData.GetInt("Version").GetValueOrDefault();
                Version = version;

                OnUpdateConfig(cxData);
                SaveConfig(cxData);
            }
            catch (Exception ex)
            {
                Debug.LogError("Config " + ConfigName + " error!");
                Debug.LogException(ex);

                ReUpdateConfig(GetConfig());
            }
        }

        void ReUpdateConfig(CXData cxData)
        {
            var version = cxData.GetInt("Version").GetValueOrDefault();
            Version = version;

            OnUpdateConfig(cxData);
        }

        void OnUpdateConfig(CXData cxData)
        {
            Items.Clear();
            if (cxData.ContainsKey("Items"))
            {
                var cxItems = cxData.GetCXDataList("Items");

                for (var i = 0; i < cxItems.Count; i++)
                {
                    var t = new T();
                    t.SetData(cxItems[i]);

                    Items.Add(t);
                }
            }
        }

        public T GetItemById(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public Config(string configName, string defaultConfigData = DEFAULT_DATA)
        {
            ConfigName = configName;
            Version = -1;
            Items = new List<T>();

            ReUpdateConfig(GetConfig(defaultConfigData));
        }
    }

    [Serializable]
    public class ConfigItem
    {
        ///public CXData cxData { get; private set; }

        public ObscuredInt Id { get; private set; }

        public virtual void SetData(CXData cxData)
        {
            //this.cxData = cxData;

            Id = cxData.GetInt("Id").GetValueOrDefault();
        }
    }

    [Serializable]
    public class MapStatsConfigItem : ConfigItem
    {
        public override void SetData(CXData cxData)
        {
            base.SetData(cxData);
        }
    }

    [Serializable]
    public class GoodsStatsConfigItem: ConfigItem
    {
        public ObscuredString Name { get; private set; }
        public ObscuredInt MoneyBuy { get; private set; }
        public ObscuredLong TimeDone { get; private set; }
        public ObscuredInt Profit { get; private set; }
        public ObscuredInt Experience { get; private set; }

        public override void SetData(CXData cxData)
        {
            base.SetData(cxData);

            Name = cxData.GetString("Name");
            MoneyBuy = cxData.GetInt("MoneyBuy").GetValueOrDefault();
            TimeDone = cxData.GetLong("TimeDone").GetValueOrDefault();
            Profit = cxData.GetInt("Profit").GetValueOrDefault();
            Experience = cxData.GetInt("Experience").GetValueOrDefault();
        }
    }

    public class BodyPartStatsConfigItem: ConfigItem
    {
        public ObscuredInt Strong { get; private set; }
        public ObscuredInt Heart { get; private set; }

        public override void SetData(CXData cxData)
        {
            base.SetData(cxData);

            Strong = cxData.GetInt("Strong").GetValueOrDefault();
            Heart = cxData.GetInt("Heart").GetValueOrDefault();
        }
    }

    public class TruckStatsConfigItem: ConfigItem
    {
        public ObscuredInt AmountEmpty { get; private set; }

        public override void SetData(CXData cxData)
        {
            base.SetData(cxData);
            AmountEmpty = cxData.GetInt("AmountEmpty").GetValueOrDefault();
        }
    }
}
