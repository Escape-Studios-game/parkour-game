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
    private float _speedMultiplier;
    [SerializeField, Tooltip("The amount of speed the player will loose when stopping in place")]
    private float _speedDecreaser;
    [SerializeField, Tooltip("The amount of speed the player will have when starts moving")]
    private float _initialSpeed;

    private InputManager _inputManager;
    private Rigidbody _rigidbody;

    [SerializeField, Tooltip("Add here the orientation object from the player")]
    private Transform _orientation;

    private bool _isGrounded;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Start() => _inputManager = InputManager.Instance;

    private void FixedUpdate() => Move();

    private void Update()
    {
        Move();
        ApplyGravity();

        if (_inputManager.JumpedThisFrame() && _isGrounded)
        { Jump(); }
    }

    /// <summary>
    /// Gets the player's current movement speed.
    /// </summary>
    /// <returns>The player's current speed in units per second.</returns>
    public float GetCurrentSpeed() => _currentSpeed;

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
        var axis = _inputManager.GetPlayerMovement();

        var moveDirection = _orientation.forward * axis.x + _orientation.right * axis.y;

        // Get what direction is the camera looking at, and normalize it so it doesn't tilt
        var forwardDirection = Camera.main.transform.forward;
    }

    private void IncreaseSpeed()
    {

    }

    private void DecreaseSpeed()
    {

    }
}
