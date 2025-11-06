using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // TODO Make the player speed scalable
    [SerializeField] private float _playerSpeed = 5.0f;
    [SerializeField] private float _jumpHeight = 1.5f;
    [SerializeField] private float _gravityValue = -10.0f;

    private CharacterController _controller;
    private bool _isGrounded;

    private InputManager _inputManager;
    private void Awake() => _controller = GetComponent<CharacterController>();

    private void Start() => _inputManager = InputManager.Instance;

    private void FixedUpdate() => Move();

    private void Update()
    {
        _isGrounded = _controller.isGrounded;
        if (_inputManager.JumpedThisFrame())
        { Jump(); }

    }

    private void Jump()
    {

        Debug.Log("Hola");
    }

    private void Move()
    {
        // TODO Implement movement related with camera
    }
}
