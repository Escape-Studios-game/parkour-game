using UnityEngine;

public class PlayerMovement : Player
{
    private PlayerInput _playerInput;
    private Rigidbody _rigidBody;
    private bool _isGrounded;
    private Vector2 _moveInput;

    private void Awake() => _playerInput = new PlayerInput();
    private void OnEnable() => _playerInput.Gameplay.Enable();
    private void OnDisable() => _playerInput.Gameplay.Disable();
    private void Update()
    {
        _moveInput = _playerInput.Gameplay.Move.ReadValue<Vector2>();
    }
}
