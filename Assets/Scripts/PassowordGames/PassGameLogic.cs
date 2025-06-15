using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

    public class PassGameLogic : MonoBehaviour
    {
        private int _currentPass;
        private int _endValue;
        
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TextMeshPro _textPass;
        [SerializeField] private Toggle _togglePass;
        [SerializeField] private GameObject _door;
        

        private void Awake()
        {
            GenerationPass();
            _togglePass.isOn = false;
        }
        
        private void GenerationPass()
        {
            _currentPass = Random.Range(100000, 999999);
            
            _textPass.text = _currentPass.ToString();
        }
        
        private void Update()
        {
            CheckPass(_door);
        }

        private void CheckPass(GameObject door)
        {
            if (!_togglePass.isOn)
            {
                return;
            }
            
            if (_inputField.text == _currentPass.ToString())
            {
                StartCoroutine(NicePassAnim());
                GenerationPass();
                _togglePass.isOn = false;
                door.SetActive(false);
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(WrongPassAnim());
                _togglePass.isOn = false;
            }
        }

        private IEnumerator WrongPassAnim()
        {
            _inputField.GetComponent<Image>().color = Color.red;
            yield return new WaitForSeconds(0.3f);
            _inputField.GetComponent<Image>().color = Color.white;
            yield return new WaitForSeconds(0.3f);
            _inputField.GetComponent<Image>().color = Color.red;
            yield return new WaitForSeconds(0.3f);
            _inputField.GetComponent<Image>().color = Color.white;
        }
        
        private IEnumerator NicePassAnim()
        {
            _inputField.GetComponent<Image>().color = Color.green;
            yield return new WaitForSeconds(0.3f);
            _inputField.GetComponent<Image>().color = Color.white;
            yield return new WaitForSeconds(0.3f);
            _inputField.GetComponent<Image>().color = Color.green;
            yield return new WaitForSeconds(0.3f);
            _inputField.GetComponent<Image>().color = Color.white;
        }

        
    }