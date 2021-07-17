using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UiZoomManager : MonoBehaviour
{
    // Start is called before the first frame update

    private GraphicRaycaster _rayCaster;
    private EventSystem eventSystem;
    public Transform selectionPoint;
    private PointerEventData pData;
    public static UiZoomManager instance;

    public static UiZoomManager Instance
    {
        get
            {
            if(instance == null)
            {
                instance = FindObjectOfType<UiZoomManager>();
            }
            return instance;
        }
    }


    void Start()
    {
        _rayCaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        pData = new PointerEventData(eventSystem);
        pData.position = selectionPoint.position;
    }

  public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        _rayCaster.Raycast(pData, results);

        foreach(RaycastResult result in results)
        {
            if(result.gameObject == button)
            {
                return true;
            }
        }
        return false;
    }
}
