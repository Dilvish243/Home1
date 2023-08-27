using System.Collections;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    public Animator animator;

    //Debug
    [Header("Debug")]
    [SerializeField]
    private Vector3 moveDirection;

    [SerializeField]
    private int isMoving;

    [SerializeField]
    private float rotationSpeed;

    public void Move(Vector3 direction)
    {
        this.moveDirection = direction;
        this.isMoving = 1;
    }

    public void Attack()
    {
        this.isMoving = 2;
    }

    public void Die()
    {
        this.isMoving = 3;
    }

    private IEnumerator WaitForAttackAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(2).length);
        Die();
    }

    private void FixedUpdate()
    {
        if (this.isMoving == 1)
        {
            var deltaTime = Time.fixedDeltaTime;
            this.transform.position += moveDirection * this.moveSpeed * deltaTime;

            var targetRotation = Quaternion.LookRotation(this.moveDirection, Vector3.up);
            var nextRotation = Quaternion.Slerp(this.transform.rotation, targetRotation, this.rotationSpeed * deltaTime);
            this.transform.rotation = nextRotation;

            this.animator.SetInteger("State", 1); // MOVE
            this.isMoving = 0;
        }
        else if (this.isMoving == 0)
        {
            this.animator.SetInteger("State", 0); // IDLE
        }
        else if (this.isMoving == 2)
        {
            this.animator.SetInteger("State", 2); // ATTACK
            StartCoroutine(WaitForAttackAnimation());
            this.isMoving = 0;
        }
        else if (this.isMoving == 3)
        {
            this.animator.SetInteger("State", 3); // DEATH
            this.isMoving = 0;
        }
    }
}
