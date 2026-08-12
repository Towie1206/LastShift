using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform cameraPivot;

    [Header("Look Details")]
    [SerializeField] private float lookSensitivity = 1f;
    [SerializeField] private float maxLookAngle = 80f;
    [SerializeField] private float minLookAngle = -80f;

    private float pitch;    

    public void Look(Vector2 lookInput)
    {
        HandleHorizontalLook(lookInput.x);
        HandleVerticalLook(lookInput.y);
    }    

    private void HandleHorizontalLook(float horizontalInput)
    {
        transform.Rotate(Vector3.up * horizontalInput * lookSensitivity);
    }

    private void HandleVerticalLook(float verticalInput)
    {
        pitch -= verticalInput * lookSensitivity;
        pitch = Mathf.Clamp(pitch, minLookAngle, maxLookAngle);

        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
