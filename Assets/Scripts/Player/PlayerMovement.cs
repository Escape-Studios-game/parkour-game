using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private readonly float _maxForwardSpeed = 5f;
    private readonly float _maxMovementSpeed = 4f;

    private readonly float _jumpForce = 2f;
    private readonly float _gravityValue = -9.81f; // * This is actually the gravity we have on earth

    private float _currentSpeed = 0f;

    [SerializeField, Tooltip("The amount to multiply the speed every frame, to get a smooth speed movement")]
    private float _speedMultiplier = 6f;
    [SerializeField, Tooltip("The amount of speed the player will loose when stopping in place")]
    private float _speedDecreaser = 16f;
    [SerializeField, Tooltip("The amount of speed the player will have when starts moving")]
    private float _initialSpeed = 2f;

    private InputManager _inputManager;
    private Rigidbody _rigidbody;
    private bool _isGrounded;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Start() => _inputManager = InputManager.Instance;

    private void FixedUpdate() => Move();

    private void Update()
    {
        Move();
        ApplyGravity();

        // Debug.Log("Is on ground: " + _isGrounded);
        if (_inputManager.JumpedThisFrame() && _isGrounded)
        { Jump(); }
    }

    private void CheckGrounded()
    {
        // TODO check when the player is touching the ground (Because characterController sucks)
    }

    private void ApplyGravity()
    {
        if (!_isGrounded)
        {
            // TODO Apply gravity to the character
        }
    }

    private void Jump()
    {
        // TODO implement logic to make the player jump
        Debug.Log("Jumping");
    }

    private void Move()
    {
        // TODO Implement movement related with camera and make it move smoothly, make it still moving even when stopped until speed reaches 0
        // Get the player inputs into a vector
        Vector2 axis = new(_inputManager.GetPlayerMovement().y, _inputManager.GetPlayerMovement().x);

        // Detect where is forward detecting where is the camera looking
        Vector3 forwardDirection = new(-Camera.main.transform.right.z, 0.0f, Camera.main.transform.right.x);

        // Make the player move
        var moveDirection = (forwardDirection * axis.x) + (Camera.main.transform.right * axis.y) + (Vector3.up * _rigidbody.linearVelocity.y);
        _rigidbody.linearVelocity = moveDirection;

    }
}
