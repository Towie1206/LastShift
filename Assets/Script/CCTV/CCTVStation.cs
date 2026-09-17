using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CCTVStation : MonoBehaviour, IInteractable
{

    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private float cameraBlendDuration;
    [SerializeField] private int monitorPriority = 20;
    [SerializeField] private CCTVView cctvView;

    public void Interact(Player player)
    {
        player.EnterCCTV(this);
        cinemachineCamera.Priority = monitorPriority;

        StartCoroutine(OpenMaintenanceAfterBlend());

    }

    private IEnumerator OpenMaintenanceAfterBlend()
    {
        yield return new WaitForSeconds(cameraBlendDuration);

        cctvView.Show();
    }
    public void CloseCCTV()
    {
        if (cctvView != null) cctvView.Hide();
        if (cinemachineCamera != null) cinemachineCamera.Priority = 0; 
    }
}
