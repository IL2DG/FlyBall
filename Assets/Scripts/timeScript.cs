using System;
using UnityEngine.UI;
using UnityEngine;

public class timeScript : MonoBehaviour
{
    DateTime startTime;
    DateTime stopTime;
    Text tryTxt;
    public GameObject tryObj;

    private void OnEnable() {
        startTime = DateTime.Now;
    }

    private void OnDisable() {
        stopTime = DateTime.Now;
        tryTxt = tryObj.GetComponent<Text>();
        TimeSpan data = stopTime.Subtract(startTime);
        tryTxt.text = String.Format("Последняя попытка - {0:00}:{1:00}:{2:00.#}", data.TotalHours,data.Minutes,data.Seconds + data.Milliseconds/1000); 
    }
}
