using UnityEngine;

namespace Physics
{
    public class TriggerHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log($"TriggerHandler.OnTriggerEnter2D: {gameObject.name} was triggered by {col.gameObject.name}");
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            Debug.Log($"TriggerHandler.OnTriggerEnter2D: {gameObject.name} continues to be triggered by {col.gameObject.name}");
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log($"TriggerHandler.OnTriggerEnter2D: {gameObject.name} finished triggering by {col.gameObject.name}");
        }
    }
}