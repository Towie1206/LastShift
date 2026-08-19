using UnityEngine;

public class WatcherLocation : MonoBehaviour
{
    [SerializeField] private bool isAttackLocation;
    [SerializeField] private int cameraIndex = -1;

    public bool IsAttackLocation()
    {
        return isAttackLocation;
    }

    public int GetCameraIndex()
    {
        return cameraIndex;
    }

}
