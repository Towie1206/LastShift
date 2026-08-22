using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private Rigidbody rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    public void SetMoveInput(Vector2 input)
    {
        moveInput = Vector2.ClampMagnitude(input, 1f);
    }

    public void Stop()
    {
        moveInput = Vector2.zero;

        Vector3 currentVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(0f, currentVelocity.y, 0f);
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;

        Vector3 currentVelocity = rb.linearVelocity;

        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, currentVelocity.y, moveDirection.z * moveSpeed);
    }

}
