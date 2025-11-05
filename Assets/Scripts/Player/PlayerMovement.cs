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

    [SerializeField] private PlayerInput _playerInput;
    private bool _isGrounded;
    private Rigidbody _rb;
    [SerializeField] private float _mass;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
}
