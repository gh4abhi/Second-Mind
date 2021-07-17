using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//To control graph.

public class GraphController : MonoBehaviour
{
    public float WaitTime;

    [SerializeField]
    API api;

    [SerializeField]
    TextMeshPro title;

    void Start()
    {
        api.GetTimeData(onDataReceived);
    }

    void onDataReceived(List<TimeData> dataList)
    {
        StartCoroutine(CycleDataRoutine(dataList));
    }

    IEnumerator CycleDataRoutine(List<TimeData> dataList)
    {
        while (true)
        {
            foreach (TimeData data in dataList)
            {
                title.text = data.confirmed.ToString();
                yield return new WaitForSeconds(WaitTime);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
