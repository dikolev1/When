using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody _rb;

    public Transform feetOrigin;

    [SerializeField] private LayerMask jumpableMask;
    [SerializeField] private float sphereRadius;
    [SerializeField] private float sphereCastDistance;
    [SerializeField] private float maxAngle;

    private bool _jumpPressed = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _jumpPressed = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if (_jumpPressed && CheckIsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        Debug.Log("I jumped!");
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    private bool CheckIsGrounded()
    {
        if (Physics.SphereCast(feetOrigin.position, sphereRadius, Vector3.down, out RaycastHit hit, sphereCastDistance, jumpableMask))
        {
            float angle = Vector3.Angle(hit.normal, Vector3.up);
            Debug.Log("”гол: " + angle);
            return angle <= maxAngle;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(feetOrigin.position, sphereRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(feetOrigin.position, feetOrigin.position + Vector3.down * sphereCastDistance);
    }

}
