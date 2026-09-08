using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class MaintenanceStation : MonoBehaviour, IInteractable
{
    [SerializeField] private Player player;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private float cameraBlendDuration = 1.5f;
    [SerializeField] private int monitorPriority = 20;
    [SerializeField] private MaintenanceView maintenanceView;

    private bool isRunning;

    private void OnEnable()
    {
        maintenanceView.ExitRequested += HandleExit;
    }

    private void OnDisable()
    {
        maintenanceView.ExitRequested -= HandleExit;
    }

    public void Interact()
    {
        if (isRunning)
            return;

        isRunning = true;

        player.EnterComputer();
        cinemachineCamera.Priority = monitorPriority;

        StartCoroutine(OpenMaintenanceAfterBlend());
    }

    private IEnumerator OpenMaintenanceAfterBlend()
    {
        yield return new WaitForSeconds(cameraBlendDuration);

        maintenanceView.Show();
    }

    private void HandleExit()
    {
        maintenanceView.Hide();
        cinemachineCamera.Priority = 0;
        player.ExitComputer();
        isRunning = false;
    }
}
