using UnityEngine;

public class NoUnderMap : MonoBehaviour
{
    public float minVerticalPosition;

    private Rigidbody _rb;

    private void Awake()
    {
        TryGetComponent<Rigidbody>(out _rb);
    }

    private void FixedUpdate()
    {
        if (transform.position.y < minVerticalPosition)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
            if (_rb != null)
            {
                _rb.linearVelocity.Set(0, 0, 0);
            }
        }
    }
}
