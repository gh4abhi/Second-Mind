using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

//To draw data from an online website.

[ExecuteInEditMode]
public class API : MonoBehaviour
{
    const string ENDPOINT =  "https://coronavirusapi.com/time_series.csv";

   
    public void GetTimeData(UnityAction<List<TimeData>> callback)
    {
        StartCoroutine(GetTimeDataRoutine(callback));
    }
    IEnumerator GetTimeDataRoutine(UnityAction<List<TimeData>> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(ENDPOINT);
        yield return request.SendWebRequest();
        if(request.isNetworkError)
        {
            Debug.Log("Network Error");
        }
        else
        {
            callback(ParseData(request.downloadHandler.text));
        }
    }
   List<TimeData> ParseData(string Data)
    {
        List<string> lines = Data.Split('\n').ToList();
        lines.RemoveAt(0);
        List<TimeData> dataList = new List<TimeData>();
        foreach (string line in lines)
        {
            List<string> lineData = line.Split(',').ToList();
            if (lineData[3] != null  )
            {
                TimeData timeData = new TimeData
                {

                    confirmed = long.Parse(lineData[3]),


                };
                dataList.Add(timeData);
            }
           
             
            
        }
        return dataList;
    }
}
