using System.Collections;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public GameObject greenBeamPrefab; // ������ �� ������ �������� ����
    public float fireDelay = 1.0f; // �������� ����� ���������� � ��������
    public float beamSpeed = 10.0f; // �������� �������� ����
    public Transform muzzlePoint; // ����� ������ ����
    public AudioClip shootSound; // ���� ��������
    private bool canShoot = true; // ����, ������������, ����� �� ��� ��������

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
            StartCoroutine(FireDelayCoroutine());
        }
    }

    void Shoot()
    {
        GameObject greenBeam = Instantiate(greenBeamPrefab, muzzlePoint.position, Quaternion.identity);
        greenBeam.transform.forward = muzzlePoint.forward;
        Rigidbody rb = greenBeam.GetComponent<Rigidbody>();
        rb.velocity = muzzlePoint.forward * beamSpeed;
        PlayShootSound(); 
    }

    IEnumerator FireDelayCoroutine()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }

    private void PlayShootSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(shootSound);
    }
}