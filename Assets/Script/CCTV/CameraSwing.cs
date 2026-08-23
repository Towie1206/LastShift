using UnityEngine;

public class CameraSwing : MonoBehaviour
{
    [SerializeField] private Transform[] cameraPivots;
    [SerializeField] private float speedRotate, clampValue;
    private bool movingLeft, movingRight;
    private CameraSystem cameraSystem;
    private Quaternion[] initialLocalRotation;

    private void Awake()
    {
        cameraSystem = GetComponent<CameraSystem>();
        
        initialLocalRotation = new Quaternion[cameraPivots.Length];

        for (int i = 0; i < cameraPivots.Length; i++)
        {
            initialLocalRotation[i] = cameraPivots[i].transform.localRotation;

        }
    }

    private void Update()
    {
        if (movingLeft) HandleRotateLeft();
        if (movingRight) HandleRotateRight();
    }

    private void HandleRotateRight()
    {
        if (cameraPivots[cameraSystem.currentCamIndex].localRotation == Quaternion.Euler(0, clampValue, 0) * initialLocalRotation[cameraSystem.currentCamIndex])
        {

        }
        else
        {
            cameraPivots[cameraSystem.currentCamIndex].Rotate(0, speedRotate * Time.deltaTime, 0);
        }
    }
    private void HandleRotateLeft()
    {
        if (cameraPivots[cameraSystem.currentCamIndex].localRotation == Quaternion.Euler(0, -clampValue, 0) * initialLocalRotation[cameraSystem.currentCamIndex])
        {

        }
        else
        {
            cameraPivots[cameraSystem.currentCamIndex].Rotate(0, -speedRotate * Time.deltaTime, 0);
        }
    }
    public void rotateLeft()
    {
        movingLeft = true;
    }
    public void rotateRight()
    {
        movingRight = true;
    }
    public void stopRotateLeft()
    {
        movingLeft = false;
    }
    public void stopRotateRight()
    {
        movingRight = false;
    }
}
