using UnityEngine;

public class BeamCollision : MonoBehaviour // ����������� ���� ��� ��������� � �����
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}