using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    Touch touch;

    bool isMove;
    int S = 1920;
    int V = 900;
    int T;
    // Start is called before the first frame update
    void Start()
    {
        isMove = false;
        T = S / V;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                RaycastHit hit;
                if (Physics.Raycast(touch.position, transform.TransformDirection(Vector3.forward),out hit,100))
                {
                    if (hit.transform.CompareTag("Walk"))
                    {
                        if (!isMove)
                        {
                            Move();
                        }
                        Debug.Log("AAAAAAAAAa");
                    }
                    
                }
                else
                {
                    Debug.Log("BBBBBBBBBBBB");
                }
            }
        }
    }

    void Move()
    {
        var tempPos = Camera.main.ScreenToWorldPoint(touch.position);
        tempPos.z = 0f;
        Debug.Log(touch.position);
        this.transform.DOMove(tempPos, T).SetEase(Ease.Linear)
            .OnStart(() => { isMove = true; })
            .OnComplete(() => { isMove = false; });
    }
}
