using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;

    [SerializeField] private PlayerInput _playerInput;

    private InputAction _moveAction;

    private Rigidbody2D _rb;

    private Vector2 _moveInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _moveAction = _playerInput.actions["Move"];
    }

    private void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
        _moveInput = Vector2.ClampMagnitude(_moveInput, _moveSpeed);
    }

    private void FixedUpdate()
    {
        Move(_moveInput);
    }

    private void Move(Vector2 moveInput)
    {
        _rb.MovePosition(_rb.position +  moveInput * _moveSpeed * Time.fixedDeltaTime);
    }
}
