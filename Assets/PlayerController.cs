using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    Touch touch;

    bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                var tempPos = Camera.main.ScreenToWorldPoint(touch.position);

                this.transform.DOMove(tempPos, 0.5f).SetEase(Ease.Linear)
                    .OnStart(()=> { isMove = true; })
                    .OnComplete(() =>{ isMove = false; });
                               
            }
        }
    }
}
