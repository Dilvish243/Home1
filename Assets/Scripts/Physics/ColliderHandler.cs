using UnityEngine;

namespace Physics
{
    public class ColliderHandler : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log($"ColliderHandler.OnCollisionEnter2D: {gameObject.name} start colliding with {collision.gameObject.name}");
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            Debug.Log($"ColliderHandler.OnCollisionStay2D: {gameObject.name} continue colliding with {collision.gameObject.name}");
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            Debug.Log($"ColliderHandler.OnCollisionExit2D: {gameObject.name} finish colliding with {collision.gameObject.name}");
        }
    }
}