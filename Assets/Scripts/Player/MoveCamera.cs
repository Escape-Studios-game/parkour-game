using UnityEngine;

public class MoveCamera : MonoBehaviour {

    [SerializeField, Tooltip("Add the player camera position")]
    private Transform _cameraPosition;

    private void Update() => transform.position = _cameraPosition.position;
}
