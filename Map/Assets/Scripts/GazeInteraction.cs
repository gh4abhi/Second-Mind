using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//To create Gaze Interaction.

[ExecuteInEditMode]
public class GazeInteraction : MonoBehaviour
{
    List<InfoBehaviour> infos = new List<InfoBehaviour>();

    void Start()
    {
        infos = FindObjectsOfType<InfoBehaviour>().ToList();    
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("Player"))
            {
                OpenInfo(go.GetComponent<InfoBehaviour>());
            }
            else
            {
                CloseAll();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
            CloseAll();
        }
    }

    void OpenInfo(InfoBehaviour desiredInfo)
    {
        foreach (InfoBehaviour info in infos)
        {
            if (info == desiredInfo)
            {
                info.OpenInfo();
            }
            else
            {
                info.CloseInfo();
            }
        }
    }
    void CloseAll()
    {
        foreach (InfoBehaviour info in infos)
        {
            info.CloseInfo();
        }
    }
}