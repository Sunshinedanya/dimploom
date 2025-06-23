using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenShower : MonoBehaviour
{
    [SerializeField] private GameObject _screen;
    
    public static LoseScreenShower instance;

    private void Awake()
    {
        instance = this;
    }

    public void Lose()
    {
        _screen.SetActive(true);
        StartCoroutine(LoseCorutine());
    }
    
    private IEnumerator LoseCorutine()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(0);
    }
}
