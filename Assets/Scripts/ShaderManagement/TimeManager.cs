using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private float _timer;
    [SerializeField] private float _timeToShowButton = 600;
    
    [SerializeField] private Button _helpButton;

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if(_timer >= _timeToShowButton)
            _helpButton.gameObject.SetActive(true);
    }
}
