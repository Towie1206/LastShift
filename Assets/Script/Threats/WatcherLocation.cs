using UnityEngine;

public class WatcherLocation : MonoBehaviour
{
    [SerializeField] private bool isAttackLocation;
    [SerializeField] private int cameraIndex = -1;

    [Header("Dáng đứng của Bonnie")]
    public string poseAnimationName = "Pose_Idle";

    public bool IsAttackLocation() =>isAttackLocation;
    public int GetCameraIndex() => cameraIndex;

}
