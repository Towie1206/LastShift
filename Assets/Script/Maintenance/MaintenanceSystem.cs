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
    [SerializeField, Min(10f)] private float airCleanerDeadline = 60f;

    /// Phát khi trạng thái 1 hệ thống thay đổi.
    /// Param 1: loại hệ thống. Param 2: true = online, false = error.
    public event Action<SubSystem, bool> SubSystemChanged;

    /// Phát khi bắt đầu reboot (để UI hiện progress bar).
    /// Param 1: loại hệ thống. Param 2: thời gian reboot (giây).
    public event Action<SubSystem, float> RebootStarted;

    /// Phát khi Air Cleaner hết giờ → Bad Ending.
    public event Action ElectricityExpired;

    private bool[] isOnline = new bool[3];
    private bool[] isRebooting = new bool[3];
    private float airCleanerTimer;
    private bool airCleanerCounting;
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
        if (!airCleanerCounting)
            return;

        airCleanerTimer -= Time.deltaTime;

        if (airCleanerTimer <= 0f)
        {
            airCleanerCounting = false;
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
        return airCleanerCounting ? Mathf.Max(0f, airCleanerTimer) : -1f;
    }

    public float GetElectricityDeadline()
    {
        return airCleanerDeadline;
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
            airCleanerTimer = airCleanerDeadline;
            airCleanerCounting = true;
        }

        SubSystemChanged?.Invoke(system, false);
    }

    /// Bắt đầu reboot 1 hệ thống. Chờ rebootDuration giây rồi online.
    public void RebootSubSystem(SubSystem system)
    {
        int index = (int)system;

        if (isOnline[index] || isRebooting[index] || isRebootingAll)
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
            if (!isOnline[i])
            {
                isRebooting[i] = true;
                RebootStarted?.Invoke((SubSystem)i, rebootAllDuration);
            }
        }

        yield return new WaitForSeconds(rebootAllDuration);

        isRebootingAll = false;

        for (int i = 0; i < isOnline.Length; i++)
        {
            if (!isOnline[i])
            {
                isRebooting[i] = false;
                isOnline[i] = true;
                
                if ((SubSystem)i == SubSystem.Electricity)
                {
                    airCleanerCounting = false;
                }
                
                SubSystemChanged?.Invoke((SubSystem)i, true);
            }
        }
    }

    private IEnumerator RebootRoutine(SubSystem system, float duration)
    {
        int index = (int)system;
        isRebooting[index] = true;

        RebootStarted?.Invoke(system, rebootDuration);

        yield return new WaitForSeconds(rebootDuration);

        isRebooting[index] = false;
        isOnline[index] = true;

        if (system == SubSystem.Electricity)
        {
            airCleanerCounting = false;
        }

        SubSystemChanged?.Invoke(system, true);
    }
}
