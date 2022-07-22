using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XmobiTea.MiniPopup;
using XmobiTea.MiniPopup.Core;

public class UISplashSceneView : UIViewBase
{
    [SerializeField] Slider silderLoading;
    [SerializeField] Button btnPlay;

    public override void OnCustomShow(params object[] instantiateData)
    {
        base.OnCustomShow(instantiateData);
    }

    public void PressLoginGame()
    {
        UIManager.HideAllView();
        UIManager.ShowView(UIViewConstanceId.UIHomeView);

        var configGame = GameManager.Instance.ConfigGame;

        //silderLoading.gameObject.SetActive(true);
        //btnPlay.gameObject.SetActive(false);
        //Timing.RunCoroutine(IELoadingView());

        configGame.LoadData();

    }

    IEnumerator<float> IELoadingView()
    {
        yield return Timing.WaitForSeconds(2f);
    }
}
