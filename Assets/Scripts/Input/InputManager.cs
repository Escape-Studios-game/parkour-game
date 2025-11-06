using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private PlayerController _playerController;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        { Destroy(gameObject); }
        else
        { Instance = this; }

        _playerController = new();
    }
    private void OnEnable() => _playerController.Enable();
    private void OnDisable() => _playerController.Disable();

    public Vector2 GetPlayerMovement() => _playerController.Player.Movement.ReadValue<Vector2>();
    public Vector2 GetMouseDelta() => _playerController.Player.Look.ReadValue<Vector2>();
    public bool JumpedThisFrame() => _playerController.Player.Jump.WasPressedThisFrame();
}
