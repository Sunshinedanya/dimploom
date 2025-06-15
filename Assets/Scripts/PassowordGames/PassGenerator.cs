using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PassGenerator : MonoBehaviour
{
    [HideInInspector] public int _code;
    [HideInInspector] public int _a;
    [HideInInspector] public int _b;
    [HideInInspector] public int _c;
    
    void Start()
    {
        GenerateRandomCode();
    }
    public void GenerateRandomCode()
    {
        _code = Random.Range(100, 999);

        _a = int.Parse(_code.ToString()[0].ToString());
        _b = int.Parse(_code.ToString()[1].ToString());
        _c = int.Parse(_code.ToString()[2].ToString());

        Debug.Log($"Code: {_code}; _a = {_a}; _b = {_b}; _c = {_c}");
    }
}