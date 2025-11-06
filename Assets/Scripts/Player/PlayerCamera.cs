using UnityEngine;
using System.Collections;
using UnityEngine.PlayerLoop;
// TODO Refactor this, because we are not using the old unity's input system
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _sensitivityX;
    [SerializeField] private float _sensitivityY;
    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        ChangeCursorState(CursorLockMode.Locked);
        ChangeCursorVisibility(false);
    }

    public void ChangeCursorVisibility(bool toSet) => Cursor.visible = toSet;
    public void ChangeCursorState(CursorLockMode toSet) => Cursor.lockState = toSet;

    private void Update() => MoveCamera();

    private void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _sensitivityY;

        _yRotation += mouseX;
        _xRotation -= mouseY;

        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }
}
