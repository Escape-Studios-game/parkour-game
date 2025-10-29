using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float _MAX_SPEED = 100.00f;
    private const float _MAX_MOMENTUM = 100.00f;
    [SerializeField] private float _speed;
    [SerializeField] private float _momentum;

    private bool _isGrounded;
    private Rigidbody rb;
}
