using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool timerEnabled = true;

    public static Timer Instance;
    
    // Текущее время прохождения в секундах
    public float currentTime { private set; get; }
    private bool isTimerRunning = false;

    [SerializeField] private Text timerText;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!isTimerRunning || !timerEnabled) return;
        currentTime += Time.deltaTime;
        UpdateTimerDisplay();
    }

    // Запуск таймера
    public void StartTimer()
    {
        isTimerRunning = true;
        currentTime = 0f;
    }

    // Остановка таймера
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // Получение текущего времени в секундах (int)
    private int GetCurrentTime()
    {
        return Mathf.FloorToInt(currentTime);
    }

    // Обновление отображения таймера
    private void UpdateTimerDisplay()
    {
        if (timerText == null) return;
        var minutes = Mathf.FloorToInt(currentTime / 60f);
        var seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }


    public string GetFormattedTime()
    {
        return FormatTime(GetCurrentTime());
    }
    
    // Форматирование времени из int в строку
    private static string FormatTime(int totalSeconds)
    {
        var minutes = totalSeconds / 60;
        var seconds = totalSeconds % 60;
        return $"{minutes:00}:{seconds:00}";
    }
}
