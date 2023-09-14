using UnityEngine;

namespace Physics
{
    public class MovePhysicsKinematic : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private float _speed;


        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + new Vector2(_speed * Time.fixedDeltaTime, 0f));
        }
    }
}