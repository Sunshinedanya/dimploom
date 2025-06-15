using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassSelection : MonoBehaviour
{
    [SerializeField] private TMP_InputField _firstInput;
    [SerializeField] private TMP_InputField _secondInput;
    [SerializeField] private TMP_InputField _thirdInput;
    [SerializeField] private PassGenerator _passGenerator;
    [SerializeField] private GameObject _door;

    private void Start()
    {
        _firstInput.characterLimit = 1;
        _secondInput.characterLimit = 1;
        _thirdInput.characterLimit = 1;
    }
    void Update()
    {
        if(_firstInput.text != "" && _secondInput.text != "" && _thirdInput.text != "")
        {
            if (_firstInput.text == _passGenerator._a.ToString())
                _firstInput.interactable = false;
            else
                _firstInput.text = "";

            if (_secondInput.text == _passGenerator._b.ToString())
                _secondInput.interactable = false;
            else
                _secondInput.text = "";

            if (_thirdInput.text == _passGenerator._c.ToString())
                _thirdInput.interactable = false;
            else
                _thirdInput.text = "";

        }

        if (_firstInput.text == _passGenerator._a.ToString() &&
            _secondInput.text == _passGenerator._b.ToString() &&
            _thirdInput.text == _passGenerator._c.ToString())
        {
            _door.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}