using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XmobiTea.MiniSingleton;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private DataManager dataManager;
    public DataManager DataManager => dataManager;

    [SerializeField]
    private ConfigGame configGame;
    public ConfigGame ConfigGame => configGame;

    protected override void OnInit()
    {
        base.OnInit();
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Application.targetFrameRate = 60;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

}
