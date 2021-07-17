using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UiZoomManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 1.5f, 0.3f);
           // transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.DOScale(Vector3.one , 0.3f);
            //transform.localScale = Vector3.one;
        }
        
    }
}
