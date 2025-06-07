using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float mouseSensitivity = 100f;
    public float jumpForce;

    void Update()
    {
        // WASD movement
        float rightMove = Input.GetAxis("Horizontal");
        float forvardMove = Input.GetAxis("Vertical");

        Vector3 move = transform.right * rightMove + transform.forward * forvardMove;
        transform.position += movementSpeed * Time.deltaTime * move;

        // Mouse movement
        float moseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        transform.Rotate(Vector3.up * moseX);

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("dfd");
        }

    }
}
