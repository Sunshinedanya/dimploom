using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // Ссылка на аудиомикшер
    [SerializeField] private Slider volumeSlider; // Ссылка на слайдер громкости
    
    private void Start()
    {
        // Загружаем сохраненное значение громкости (по умолчанию 1)
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        
        // Устанавливаем значение слайдера
        volumeSlider.value = savedVolume;
        
        // Применяем громкость
        SetVolume(savedVolume);
        
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }
    
    // Метод для изменения громкости
    public void SetVolume(float volume)
    {
        // Преобразуем линейное значение (0-1) в логарифмическое (для AudioMixer)
        float volumeDB = Mathf.Log10(volume) * 20;
        
        // Если громкость на минимуме - отключаем звук полностью
        if (volume <= 0.0001f)
        {
            volumeDB = -80f; // Минимальное значение в микшере
        }
        
        // Устанавливаем громкость в микшере
        audioMixer.SetFloat("MasterVolume", volumeDB);
        
        // Сохраняем значение
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }
}
