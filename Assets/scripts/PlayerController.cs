using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("SpeedWalk, SpeedJump")]
    [SerializeField]private float speed = 5f;
    [Header("Physic and math")]
    public Rigidbody rb;
    private Vector2 _moveInput;
    [SerializeField] private Transform playerBody;
    private Animator _animPlayer;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        _animPlayer = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _moveInput = new Vector3(
            (Keyboard.current.dKey.isPressed) ? 1 : (Keyboard.current.aKey.isPressed) ? -1 : 0,
            (Keyboard.current.wKey.isPressed) ? 1 : (Keyboard.current.sKey.isPressed) ? -1 : 0
        ).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 move = playerBody.transform.forward * _moveInput.y + playerBody.transform.right * _moveInput.x;
        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);

        _animPlayer.SetFloat("isMovePlayer", _moveInput.magnitude);
    }
}
