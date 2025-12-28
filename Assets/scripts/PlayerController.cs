using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("SpeedWalk, SpeedJump")]
    public float speed = 5f;
    public float jumpSpeed = 5f;
    [Header("Physic and math")]
    private Rigidbody _rb;
    private Vector2 _moveInput;
    public Transform playerBody;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveInput = new Vector3(
            (Keyboard.current.wKey.isPressed) ? 1 : (Keyboard.current.sKey.isPressed) ? -1 : 0,
            (Keyboard.current.aKey.isPressed) ? 1 : (Keyboard.current.dKey.isPressed) ? -1 : 0
        ).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 move = playerBody.transform.forward * _moveInput + playerBody.transform.right * _moveInput;
        _rb.linearVelocity = new Vector3(move.x * speed, _rb.linearVelocity.y, move.z * speed);
    }
}
