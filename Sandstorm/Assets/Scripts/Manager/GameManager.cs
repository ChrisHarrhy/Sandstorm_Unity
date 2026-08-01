using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Clock UI")]
    [SerializeField] private TMP_Text clockText;
    private float elapsedTime;
   
    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateClockUI();
    }

    private void UpdateClockUI()
    {
        float hours = Mathf.FloorToInt(elapsedTime / 3600f);
        float minutes = Mathf.FloorToInt((elapsedTime - hours * 3600f) / 60f);
        float seconds = Mathf.FloorToInt((elapsedTime - hours * 3600f) - (minutes * 60f));

        string clockString = string.Format("{0:00}.{1:00}.{2:00}", hours, minutes, seconds);
        clockText.text = clockString;
    }
}
