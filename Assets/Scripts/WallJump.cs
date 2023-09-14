using UnityEngine;

public class WallJump : MonoBehaviour
{
    public CollisionCheck collisionCheck;
    public float jumpForce = 5f;
    public float wallJumpForce = 3f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D rb;

    // переменная для проверки направления взгляда лисички
    public bool isFacingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        // если направо то true и наоборот
        if (rb.velocity.x > 0.1f)
        {
            isFacingRight = true;
            
        }
        else if (rb.velocity.x < -0.1f)
        {
            isFacingRight = false;
            
        }

        if (Input.GetButtonDown("Jump") && !collisionCheck.IsGrounded && collisionCheck.IsTouchingWall)
        {
            WallJumpAction();
        }
    }

    void WallJumpAction()
    {
        // Отменить текущую вертикальную скорость
        rb.velocity = new Vector2(rb.velocity.x, 0);

        // Получить направление отталкивания от стены
        float wallJumpDirection = Mathf.Sign(collisionCheck.wallCheckPosition.position.x - transform.position.x);

        // Изменить направление отталкивания в зависимости от значения isFacingRight
        if (isFacingRight)
        {
            wallJumpDirection = -1;
        }
        else
        {
            wallJumpDirection = 1;
        }

        // Применить силу прыжка
        rb.AddForce(new Vector2(wallJumpDirection * wallJumpForce, jumpForce), ForceMode2D.Impulse);
        if (isFacingRight)
        { 
        _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}