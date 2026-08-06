using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Clock UI")]
    [SerializeField] private TMP_Text clockText;
    private float elapsedTime;

    [Header("Storm activity")]
    public bool stormActive;
    private float stormStartTime = 2f;
    private float stormEndTime = 19.5f;
   
    void Update()
    {
        elapsedTime += Time.deltaTime * 600;
        

        if (elapsedTime >= 86400)
        {
            elapsedTime = 0;
        }

        UpdateClockUI();
        CheckStormSchedule();
    }

    private void UpdateClockUI()
    {
        float hours = Mathf.FloorToInt(elapsedTime / 3600f);
        float minutes = Mathf.FloorToInt((elapsedTime - hours * 3600f) / 60f);
        float seconds = Mathf.FloorToInt((elapsedTime - hours * 3600f) - (minutes * 60f));

        string clockString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        clockText.text = clockString;
    }

    private void CheckStormSchedule()
    {
        float currentHour = elapsedTime / 3600f;

        bool shouldStormBeActive = currentHour >= stormStartTime && currentHour < stormEndTime;

        if (shouldStormBeActive && !stormActive)
        {
            StormEnabled();
        }

        if (!shouldStormBeActive && stormActive)
        {
            StormDisabled();
        }
    }

    private void StormEnabled()
    {
        stormActive = true;
        Debug.Log("Storm is active!");

        // Activate full particles later
    }

    private void StormDisabled()
    {
        stormActive = false;
        Debug.Log("Storm has calmed.");

        // Switch to softer particles
    }
}
