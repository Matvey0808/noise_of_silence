using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("SpeedWalk, SpeedJump")]
    [SerializeField]private float speed = 5f;
    [SerializeField]private float jumpSpeed = 5f;
    [Header("Physic and math")]
    private Rigidbody _rb;
    private Vector2 _moveInput;
    [SerializeField] private Transform playerBody;
    private bool _isGround = true;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = false;
        }
    }

    private void Update()
    {
        _moveInput = new Vector3(
            (Keyboard.current.dKey.isPressed) ? 1 : (Keyboard.current.aKey.isPressed) ? -1 : 0,
            (Keyboard.current.wKey.isPressed) ? 1 : (Keyboard.current.sKey.isPressed) ? -1 : 0
        ).normalized;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && _isGround)
        {
            _rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = playerBody.transform.forward * _moveInput.y + playerBody.transform.right * _moveInput.x;
        _rb.linearVelocity = new Vector3(move.x * speed, _rb.linearVelocity.y, move.z * speed);
    }
}
