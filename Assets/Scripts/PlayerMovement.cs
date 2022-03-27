using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller = default;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _playerSpeed = 6f;
    [SerializeField] private float _runningSpeed = 10f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundCheck = default;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask = default;
    [SerializeField] private float _jumpHeight = 3f;
    private bool _isGrounded = default;
    Vector3 _velocity = default;

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && _isGrounded)
        {
            _speed = _runningSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = _playerSpeed;
        }

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xAxis + transform.forward * zAxis;
        _controller.Move(move * _speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}