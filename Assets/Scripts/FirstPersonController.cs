using UnityEngine;

public class FirstPersonController : MonoBehaviour  // контроллер персонажа от первого лица
{
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public Transform playerCamera;

    private float xAxisClamp = 0.0f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotateCamera();
        MovePlayer();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
        }

        playerCamera.Rotate(Vector3.left * mouseY);
        transform.Rotate(Vector3.up * mouseX);
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement = transform.TransformDirection(movement);
        transform.position += movement;
    }
}