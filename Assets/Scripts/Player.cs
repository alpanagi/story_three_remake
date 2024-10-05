using UnityEngine;

public class Character : MonoBehaviour
{
    private const float MOVEMENT_SPEED = 4f;
    private const float MOUSE_SENSITIVITY = 50f;

    private CharacterController characterController;
    private Transform cameraTransform;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();
        cameraTransform = transform.GetChild(0);
    }

    void Update()
    {
        Vector3 forward = Input.GetAxis("Vertical") * transform.forward;
        Vector3 strafe = Input.GetAxis("Horizontal") * transform.right;
        Vector3 movement = forward + strafe;

        transform.Rotate(0, Input.GetAxis("Mouse X") * MOUSE_SENSITIVITY * Time.deltaTime, 0);

        float rotation_x = cameraTransform.rotation.eulerAngles.x - Input.GetAxis("Mouse Y") * MOUSE_SENSITIVITY * Time.deltaTime;
        if (rotation_x > 180)
        {
            rotation_x -= 360;
        }
        rotation_x = Mathf.Clamp(rotation_x, -80f, 80f);

        cameraTransform.rotation = Quaternion.Euler(
                rotation_x,
                cameraTransform.rotation.eulerAngles.y,
                0);

        if (movement.magnitude > 0.001)
        {
            characterController.Move(movement * MOVEMENT_SPEED * Time.deltaTime);
        }
    }
}
