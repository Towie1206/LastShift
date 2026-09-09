using System;
using System.Collections;
using UnityEngine;

public enum SubSystem { CameraDevices, Lighting, Electricity }

public class MaintenanceSystem : MonoBehaviour
{
    [Header("Reboot Settings")]
    [SerializeField, Min(1f)] private float rebootDuration = 5f;

    [SerializeField, Min(1f)] private float rebootAllDuration = 10f;

    [Header("Air Cleaner Countdown")]
    [SerializeField, Min(10f)] private float electricityDeadline = 60f;

    /// Phát khi trạng thái 1 hệ thống thay đổi.
    /// Param 1: loại hệ thống. Param 2: true = online, false = error.
    public event Action<SubSystem, bool> SubSystemChanged;

    /// Phát khi Air Cleaner hết giờ → Bad Ending.
    public event Action ElectricityExpired;

    private bool[] isOnline = new bool[3];
    private bool[] isRebooting = new bool[3];
    private float electricityTimer;
    private bool electricityCounting;
    private bool isRebootingAll = false;

    private void Awake()
    {
        for (int i = 0; i < isOnline.Length; i++)
        {
            isOnline[i] = true;
            isRebooting[i] = false;
        }
    }

    private void Update()
    {
        if (!electricityCounting)
            return;

        electricityTimer -= Time.deltaTime;

        if (electricityTimer <= 0f)
        {
            electricityCounting = false;
            ElectricityExpired?.Invoke();
        }
    }

    public bool IsOnline(SubSystem system)
    {
        return isOnline[(int)system];
    }

    public bool IsRebooting(SubSystem system)
    {
        return isRebooting[(int)system] || isRebootingAll;
    }

    public float GetElectricityTimeLeft()
    {
        return electricityCounting ? Mathf.Max(0f, electricityTimer) : -1f;
    }

    public float GetElectricityDeadline()
    {
        return electricityDeadline;
    }

    /// Gây hỏng 1 hệ thống. Nếu đang online thì chuyển sang error.
    [ContextMenu("Break Camera")]
    private void BreakCamera() => BreakSubSystem(SubSystem.CameraDevices);

    [ContextMenu("Break Lighting")]
    private void BreakLighting() => BreakSubSystem(SubSystem.Lighting);

    [ContextMenu("Break Electricity")]
    private void BreakElectricity() => BreakSubSystem(SubSystem.Electricity);

    public void BreakSubSystem(SubSystem system)
    {
        int index = (int)system;

        if (!isOnline[index])
            return;

        isOnline[index] = false;
        isRebooting[index] = false;

        if (system == SubSystem.Electricity)
        {
            electricityTimer = electricityDeadline;
            electricityCounting = true;
        }

        SubSystemChanged?.Invoke(system, false);
    }

    /// Bắt đầu reboot 1 hệ thống. Chờ rebootDuration giây rồi online.
    public void RebootSubSystem(SubSystem system)
    {
        int index = (int)system;

        if (isRebooting[index] || isRebootingAll)
            return;

        StartCoroutine(RebootRoutine(system, rebootDuration));
    }

    /// Reboot tất cả hệ thống đang error, mất 10s.
    public void RebootAll()
    {
        if (isRebootingAll) return;
        StartCoroutine(RebootAllRoutine());
    }

    private IEnumerator RebootAllRoutine()
    {
        isRebootingAll = true;

        for (int i = 0; i < isOnline.Length; i++)
        {
            isRebooting[i] = true;
        }

        yield return new WaitForSeconds(rebootAllDuration);

        isRebootingAll = false;

        for (int i = 0; i < isOnline.Length; i++)
        {
            isRebooting[i] = false;
            isOnline[i] = true;
            
            if ((SubSystem)i == SubSystem.Electricity)
            {
                electricityCounting = false;
            }
            
            SubSystemChanged?.Invoke((SubSystem)i, true);
        }
    }

    private IEnumerator RebootRoutine(SubSystem system, float duration)
    {
        int index = (int)system;
        isRebooting[index] = true;

        yield return new WaitForSeconds(rebootDuration);

        isRebooting[index] = false;
        isOnline[index] = true;

        if (system == SubSystem.Electricity)
        {
            electricityCounting = false;
        }

        SubSystemChanged?.Invoke(system, true);
    }
}
