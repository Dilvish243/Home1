using UnityEngine;

public class BeamCollision : MonoBehaviour // уничтожение пули при попадании в стену
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}