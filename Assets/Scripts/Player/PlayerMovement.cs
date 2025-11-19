using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    private readonly float _maxForwardSpeed = 5f;
    private readonly float _maxMovementSpeed = 4f;
    private readonly float _jumpForce = 20f;

    // ! WON'T BE SERIALIZED
    [SerializeField]
    private float _gravityForce = -9.81f; // * This is actually the gravity we have on earth

    [SerializeField, Tooltip("The amount to multiply the speed every frame, to get a smooth speed movement")]
    private float _speedMultiplier;
    [SerializeField, Tooltip("The amount of speed the player will loose when stopping in place")]
    private float _speedDecreaser;
    [SerializeField, Tooltip("The amount of speed the player will have when starts moving")]
    private float _initialSpeed;
    private float _currentSpeed = 0f;
    private float _verticalVelocity = 2f;

    private InputManager _inputManager;
    private CharacterController _characterController;

    [SerializeField, Tooltip("Add here the orientation object from the player")]
    private Transform _orientation;

    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void Start() => _inputManager = InputManager.Instance;

    private void FixedUpdate() => Move();

    private void Update() {
        Debug.Log(_characterController.isGrounded);
    }

    /// <summary>
    /// Gets the player's current movement speed.
    /// </summary>
    /// <returns>The player's current speed in units per second.</returns>
    public float GetCurrentSpeed() => _currentSpeed;

    private float ApplyGravity() {
        return 2f;
    }

    private void Move() {
        // TODO Implement movement related with camera and make it move smoothly, make it still moving even when stopped until speed reaches 0

        // Get the player inputs into a vector
        var axis = _inputManager.GetPlayerMovement();

        // Get where the camera is looking at horizontally (So if the player looks vertically, it won't stop moving)
        var moveDirection = (_orientation.forward * axis.y) + (_orientation.right * axis.x);

        // TODO Add gravity to the current moveDirection var
        moveDirection = moveDirection.normalized;

        // Move the player
        _characterController.Move(_initialSpeed * Time.deltaTime * moveDirection);
    }

    private void IncreaseSpeed() {

    }

    private void DecreaseSpeed() {

    }
}
