using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float _jumpPower = 12f;
    [SerializeField] private float _poundPower = 10f;
    [SerializeField] private float _speed = 8f;

    [Header("Objects")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _floorCheck;
    [SerializeField] private Transform _rightWallCheck;
    [SerializeField] private Transform _leftWallCheck;
    [SerializeField] private LayerMask _floorLayer;
    [SerializeField] private LayerMask _jumpWallLayer;

    private float _horizontal;
    private bool _canJump = true;
    private bool _isFacingRight = true;

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        HandleJump();
        FlipPlayer();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
    }

    // Jump
    private void HandleJump()
    {

        if (Input.GetButtonDown("Jump") && IsGrounded() && _canJump)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _jumpPower);
        }

        if (Input.GetButtonUp("Jump") && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }


    // Is the player on the ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_floorCheck.position, 0.2f, _floorLayer);
    }

    private bool IsAgainstWall()
    {
        return Physics2D.OverlapBox(_rightWallCheck.position, new Vector2(.1f, 1f), 360) ||
            Physics2D.OverlapBox(_leftWallCheck.position, new Vector2(.1f, 1f), 360);
    }

    // Flip the Direction
    private void FlipPlayer()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_floorCheck.position, .2f);
        Gizmos.DrawCube(_rightWallCheck.position, new Vector3(.1f, 1f));
        Gizmos.DrawCube(_leftWallCheck.position, new Vector3(.1f, 1f));
    }
}
