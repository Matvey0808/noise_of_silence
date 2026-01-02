using UnityEngine;
using UnityEngine.InputSystem;

public class LookPlayer : MonoBehaviour
{
    [Header("LookPlayer")]
    [SerializeField] private float mouseSens = 50f;
    [SerializeField] private Transform playerBody;
    private float _xRotate = 0f;

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

        float mouseX = Mouse.current.delta.value.x * mouseSens * Time.deltaTime;
        float mouseY = Mouse.current.delta.value.y * mouseSens * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);
        _xRotate -= mouseY;

        _xRotate = Mathf.Clamp(_xRotate, -60, 75);
        transform.localRotation = Quaternion.Euler(_xRotate, 0, 0);
    }
}
