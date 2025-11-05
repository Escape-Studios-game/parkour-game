using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private const float _MAX_SPEED = 100.00f;
    private const float _MAX_MOMENTUM = 100.00f;
    private const float _MAX_UNCAPED_MOMENTUM = 150.00f;
    [SerializeField] private float _speed;
    [SerializeField] private float _momentum;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _moveDirection;

    private bool _isGrounded;
    private Rigidbody rb;
    [SerializeField] private float _mass;


    private void Start()
    {
    }

}
