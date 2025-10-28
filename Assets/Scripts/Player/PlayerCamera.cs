using UnityEngine;
using System.Collections;
using UnityEngine.PlayerLoop;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField] private float _sensitivityX;
    [SerializeField] private float _sensitivityY;

    [SerializeField] private Transform _orientation;

    [SerializeField] private float _xRotation;
    [SerializeField] private float _yRotation;

    private void Start()
    {
        ChangeCursorState(CursorLockMode.Locked);
        ChangeCursorVisibility(false);
    }

    public void ChangeCursorVisibility(bool toSet) => Cursor.visible = toSet;
    public void ChangeCursorState(CursorLockMode toSet) => Cursor.lockState = toSet;

    private void Update()
    {
        // TODO Input handler
    }
}
