using UnityEngine;

namespace Physics
{
    public class Platform : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private Transform _point1;

        [SerializeField]
        private Transform _point2;


        private Transform _currentTarget;


        private void Start()
        {
            _currentTarget = _point1;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var distance = _currentTarget.position - transform.position;

            TryChangeTarget(distance);

            var direction = distance.normalized;

            _rigidbody.velocity = _speed * direction;
        }

        private void TryChangeTarget(Vector3 distance)
        {
            var magnitude = distance.magnitude;
            if (magnitude <= 0.1f)
            {
                _currentTarget = (_currentTarget == _point1) ? _point2 : _point1;
            }
        }
    }
}