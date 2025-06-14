using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    public float currentMovementSpeed;
    public float standardMovementSpeed;
    public float sprintSpeedBoost;

    public float mouseSensitivity;
    public float maxCamVerticalAngle;

    private float _verticalCamRotation = 0;
    public Transform playerCamTransform;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        WASDMovement();

        Crouching();

        MouseMovent();
    }

    private void WASDMovement()
    {
        float rightMove = Input.GetAxis("Horizontal");
        float forvardMove = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMovementSpeed += sprintSpeedBoost;
        }

        Vector3 move = transform.right * rightMove + transform.forward * forvardMove;
        transform.position += currentMovementSpeed * Time.deltaTime * move;

        currentMovementSpeed = standardMovementSpeed;
    }

    private void Crouching()
    {

    }

    private void MouseMovent()
    {
        float moseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        transform.Rotate(Vector3.up * moseX);

        float moseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        _verticalCamRotation -= moseY;
        _verticalCamRotation = Mathf.Clamp(_verticalCamRotation, -maxCamVerticalAngle, maxCamVerticalAngle);

        playerCamTransform.localRotation = Quaternion.Euler(_verticalCamRotation, 0f, 0f);
    }

}
