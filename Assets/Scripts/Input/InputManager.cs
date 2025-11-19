using UnityEngine;

public class InputManager : MonoBehaviour {
    public static InputManager Instance { get; private set; }
    private PlayerController _playerController;

    private void Awake() {
        if (Instance != null && Instance != this) { Destroy(gameObject); }
        else { Instance = this; }

        _playerController = new();
    }
    private void OnEnable() => _playerController.Enable();
    private void OnDisable() => _playerController.Disable();

    /// <summary>
    /// Gets the player's current movement input as a 2D vector.
    /// </summary>
    /// <returns>
    /// A <see cref="Vector2"/> representing the player's movement input
    /// (X = horizontal, Y = forward/backwards).
    /// </returns>
    public Vector2 GetPlayerMovement() => _playerController.Player.Movement.ReadValue<Vector2>();

    /// <summary>
    /// Gets the mouse movement delta since the last frame.
    /// </summary>
    /// <returns>
    /// A <see cref="Vector2"/> representing the mouse movement delta
    /// (X = horizontal, Y = vertical).
    /// </returns>
    public Vector2 GetMouseDelta() => _playerController.Player.Look.ReadValue<Vector2>();

    /// <summary>
    /// Checks whether the jump action was pressed during the current frame.
    /// </summary>
    /// <returns><c>true</c> if the player pressed jump this frame; otherwise, <c>false</c>.</returns>
    public bool JumpedThisFrame() => _playerController.Player.Jump.WasPressedThisFrame();

    /// <summary>
    /// Checks whether the player is currently holding the run key
    /// </summary>
    /// <returns>
    /// <c>true</c> if the run key is being held down; otherwise, <c>false</c>.
    /// </returns>
    public bool IsRunning() => _playerController.Player.Run.IsPressed();
}
