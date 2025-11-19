using System.Linq;
using UnityEngine;
public class PlayerCamera : MonoBehaviour
{
    private InputManager _inputManager;

    [SerializeField, Tooltip("The speed the camera will move")]
    private float _sensitivity;
    private float _xRotation, _yRotation;

    private Vector2 _axis;

    [SerializeField, Tooltip("Add here the orientation object")]
    private Transform _orientation;

    private void Start()
    {
        _inputManager = InputManager.Instance;
        tag = "MainCamera";
        ChangeCursorState(CursorLockMode.Locked);
        ChangeCursorVisibility(false);
    }

    public void ChangeCursorVisibility(bool toSet) => Cursor.visible = toSet;
    public void ChangeCursorState(CursorLockMode toSet) => Cursor.lockState = toSet;

    private void Update() => MoveCamera();

    public float GetSensivity() => _sensitivity;
    public void SetSensivity(float toSet) => _sensitivity = toSet;

    private void MoveCamera()
    {
        _axis = _inputManager.GetMouseDelta();

        float mouseX = _axis.x * _sensitivity * Time.deltaTime;
        float mouseY = _axis.y * _sensitivity * Time.deltaTime;

        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        _orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}
