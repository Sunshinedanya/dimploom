using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button resumeGameButton;
    [SerializeField] private Button exitGameButton;

    private void Awake()
    {

        resumeGameButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1; 
            pauseMenu.SetActive(false);
        });
        
        exitGameButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        });
}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeInHierarchy)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                pauseMenu.SetActive(false);
            }
        }
    }
}