using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private SpriteRenderer _shadowSpriteRenderer;

    [SerializeField]
    private Animator _animator;


    #region Pseudo-physics

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float GroundY;

    [SerializeField]
    private float _jumpAcceleration;

    [SerializeField]
    private float _jumpFriction;


    private float _verticalSpeed;
    private bool _isJumping;

    #endregion


    void Update()
    {
        Vector3 newPosition = transform.position;

        // Walking/Running
        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0f)
        {
            if (!_isJumping)
            {
                _animator.SetBool(IsRunning, true);
            }

            _spriteRenderer.flipX = false;

            newPosition.x += _speed * Time.deltaTime;
        }
        else if (horizontal < 0f)
        {
            if (!_isJumping)
            {
                _animator.SetBool(IsRunning, true);
            }

            _spriteRenderer.flipX = true;

            newPosition.x += -_speed * Time.deltaTime;
        }
        else
        {
            _animator.SetBool(IsRunning, false);
        }

        // Jumping
        var vertical = Input.GetAxis("Vertical");
        if (vertical > 0f && !_isJumping)
        {
            _animator.SetBool(IsJumping, true);

            _shadowSpriteRenderer.enabled = false;

            _isJumping = true;
            _verticalSpeed = _jumpAcceleration;
        }

        // Jumping: air friction
        if (_isJumping)
        {
            _verticalSpeed -= _jumpFriction;
            if (_verticalSpeed < -_jumpAcceleration)
            {
                _verticalSpeed = -_jumpAcceleration;
            }
        }

        newPosition.y += _verticalSpeed * Time.deltaTime;


        // Check for ground without physics
        if (newPosition.y < GroundY)
        {
            _animator.SetBool(IsJumping, false);

            _isJumping = false;

            _shadowSpriteRenderer.enabled = true;

            newPosition.y = GroundY;
        }

        transform.position = newPosition;
    }
}