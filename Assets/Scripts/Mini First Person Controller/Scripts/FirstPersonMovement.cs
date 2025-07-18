﻿using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new();

    public GameObject passGame;
    public GameObject passSelectionGame;

    private void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        var targetMovingSpeed = IsRunning ? runSpeed : speed;
        
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
        var targetVelocity = new Vector2(horizontalInput * targetMovingSpeed, verticalInput * targetMovingSpeed);
        
        // Apply movement.
        var newVelocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.linearVelocity.y, targetVelocity.y);
        rigidbody.linearVelocity = new Vector3(newVelocity.x, rigidbody.linearVelocity.y, newVelocity.z);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PasswordTrigger"))
        {
            passGame.SetActive(true);
            Debug.Log("jopa");
        }
        if (other.CompareTag("SelectionTrigger"))
        {
            passSelectionGame.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PasswordTrigger"))
        {
            passGame.SetActive(false);
        }
        if (other.CompareTag("SelectionTrigger"))
        {
            passSelectionGame.SetActive(false);
        }
    }

}