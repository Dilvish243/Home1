using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public float groundCheckRadius = 0.2f;
    public float wallCheckRadius = 0.2f;
    public Transform groundCheckPosition;
    public Transform wallCheckPosition;

    public bool IsGrounded { get; private set; }
    public bool IsTouchingWall { get; private set; }

    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundLayer);
        IsTouchingWall = Physics2D.OverlapCircle(wallCheckPosition.position, wallCheckRadius, wallLayer);

        if (IsGrounded)
        {
            Debug.Log("Персонаж находится на полу");
        }
        else
        {
            Debug.Log("Персонаж не находится на полу");
        }

        if (IsTouchingWall)
        {
            Debug.Log("Персонаж касается стены");
        }
        else
        {
            Debug.Log("Персонаж не касается стены");
        }
    }
}