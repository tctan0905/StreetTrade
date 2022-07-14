using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XmobiTea.MiniPopup;

public class MainMenuSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Timing.RunCoroutine(IEStart());
    }

    IEnumerator<float> IEStart()
    {
        yield return Timing.WaitUntilTrue(() => UIManager.IsExists);

        UIManager.ShowView(UIViewConstanceId.UISplashSceneView);

        Destroy(this.gameObject);
    }
}
