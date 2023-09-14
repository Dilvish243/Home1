using UnityEngine;

namespace Physics
{
    public class MovePhysicsDynamic : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private float _forceMagnitude;


        private void FixedUpdate()
        {
            _rigidbody2D.AddForce(new Vector2(_forceMagnitude, 0f));
        }
    }
}