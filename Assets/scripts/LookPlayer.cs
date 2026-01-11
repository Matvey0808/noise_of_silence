using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookPlayer : MonoBehaviour
{
    [Header("LookPlayer")]
    [SerializeField] private float _mouseSens = 50f;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _sRoll = 0.5f;
    private float _roll;
    private float _xRotate = 0f;
    private float _defaultPosCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Mouse.current == null)
        {
            return;
        }

        float mouseX = Mouse.current.delta.value.x * _mouseSens * Time.deltaTime;
        float mouseY = Mouse.current.delta.value.y * _mouseSens * Time.deltaTime;

        _playerBody.Rotate(Vector3.up * mouseX);
        _xRotate -= mouseY;

        _xRotate = Mathf.Clamp(_xRotate, -60, 55);

        float mouserollX = Mouse.current.delta.x.value;
        _roll = -mouserollX * _sRoll;
        _roll = Mathf.Clamp(_roll, -15f, 15f);

        _defaultPosCamera = Mathf.Lerp(_defaultPosCamera, _roll, 5f * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(_xRotate, 0f, _defaultPosCamera);
    }
}
