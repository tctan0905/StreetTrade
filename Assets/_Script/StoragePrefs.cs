using CodeStage.AntiCheat.Storage;
using UnityEngine;

public class StoragePrefs
{
    public static void Save()
    {
        ObscuredPrefs.Save();
    }

    public static T Get<T>(string key, T defaultValue = default(T))
    {
        return ObscuredPrefs.Get(key, defaultValue);
    }

    public static bool HasKey(string key)
    {
        return ObscuredPrefs.HasKey(key);
    }

    public static T GetObject<T>(string key, T defaultValue = default(T))
    {
        var jsonStr = Get<string>(key);
        if (string.IsNullOrEmpty(jsonStr)) return defaultValue;

        return JsonUtility.FromJson<T>(jsonStr);
    }

    public static void Set<T>(string key, T value, bool saveImmediate = true)
    {
        ObscuredPrefs.Set(key, value);

        if (saveImmediate) Save();
    }

    public static void SetObject<T>(string key, object value, bool saveImmediate = true)
    {
        Set(key, JsonUtility.ToJson(value), saveImmediate);
    }

    public static void DeleteKey(string key, bool saveImmediate = true)
    {
        ObscuredPrefs.DeleteKey(key);

        if (saveImmediate) Save();
    }

    public static void DeleteAll(bool saveImmediate = true)
    {
        ObscuredPrefs.DeleteAll();

        if (saveImmediate) Save();
    }
}