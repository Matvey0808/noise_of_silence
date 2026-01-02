using System;
using System.IO.Compression;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("SpeedWalk, SpeedJump")]
    [SerializeField] private float _speed = 3f;
    public AudioSource stepAudio;
    public float stepFadeAudio = 2f;
    public float walkAudioVolume = 1f;
    private float _currentVolume = 0f;
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

    private void Start()
    {
        stepAudio = GetComponentInChildren<AudioSource>();
        if (stepAudio == null)
        {
            stepAudio = gameObject.AddComponent<AudioSource>();
        }
        stepAudio.loop = true;
        stepAudio.playOnAwake = false;
        stepAudio.spatialBlend = 1f;
        stepAudio.volume = 0f;
    }

    private void Update()
    {
        _moveInput = new Vector3(
            (Keyboard.current.dKey.isPressed) ? 1 : (Keyboard.current.aKey.isPressed) ? -1 : 0,
            (Keyboard.current.wKey.isPressed) ? 1 : (Keyboard.current.sKey.isPressed) ? -1 : 0
        ).normalized;

        bool isMoving = _moveInput.magnitude >= 0.1f;
        float targetVolume = isMoving ? walkAudioVolume : 0f;

        _currentVolume = Mathf.Lerp(
            _currentVolume,
            targetVolume,
            stepFadeAudio * Time.deltaTime
        );

        stepAudio.volume = _currentVolume;

        if (isMoving && !stepAudio.isPlaying)
        {
            stepAudio.Play();
        }
        else if (!isMoving && stepAudio.volume < 0.01f)
        {
            stepAudio.Stop();
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = playerBody.transform.forward * _moveInput.y + playerBody.transform.right * _moveInput.x;
        rb.linearVelocity = new Vector3(move.x * _speed, rb.linearVelocity.y, move.z * _speed);

        _animPlayer.SetFloat("isMovePlayer", _moveInput.magnitude);
    }
}
