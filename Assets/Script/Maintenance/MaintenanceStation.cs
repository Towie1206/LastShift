using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class MaintenanceStation : MonoBehaviour, IInteractable
{
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private float cameraBlendDuration;
    [SerializeField] private int monitorPriority = 20;
    [SerializeField] private MaintenanceView maintenanceView;

    // 👈 Bắn tín hiệu ra ngoài khi máy tính bị đóng
    public event Action OnStationClosed;

    private void OnEnable() => maintenanceView.ExitRequested += Close;
    private void OnDisable() => maintenanceView.ExitRequested -= Close;

    // Khi người chơi bấm vào máy:
    public void Interact(Player player)
    {
        // Nhờ Player tự đưa mình vào trạng thái dùng máy tính
        player.UseMaintenanceComputer(this);
    }

    public void Open()
    {
        cinemachineCamera.Priority = monitorPriority;
        StartCoroutine(OpenMaintenanceAfterBlend());
    }

    public void Close()
    {
        maintenanceView.Hide();
        cinemachineCamera.Priority = 0;

        // Báo cho ai đang theo dõi biết: "Tôi đã đóng xong!"
        OnStationClosed?.Invoke();
    }

    private IEnumerator OpenMaintenanceAfterBlend()
    {
        yield return new WaitForSeconds(cameraBlendDuration);
        maintenanceView.Show();
    }
}