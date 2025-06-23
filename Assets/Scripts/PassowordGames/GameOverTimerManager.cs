using System;
using TMPro;
using UnityEngine;

public class GameOverTimerManager : MonoBehaviour
{
    [SerializeField] private float currentTime;

    [SerializeField] private TextMeshProUGUI timerText;

    private void Update()
    {
        currentTime -= Time.deltaTime;
        UpdateTimerDisplay();

        if (currentTime <= 0)
        {
            currentTime = 0;
            LoseScreenShower.instance.Lose();
        }
    }

    private void UpdateTimerDisplay()
    {
        if (timerText == null) return;
        var minutes = Mathf.FloorToInt(currentTime / 60f);
        var seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}