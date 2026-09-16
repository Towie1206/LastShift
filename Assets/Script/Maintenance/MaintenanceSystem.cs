using System;
using System.Collections;
using UnityEngine;

public enum SubSystem { CameraDevices, Lighting, Ventilation }

public class MaintenanceSystem : MonoBehaviour
{
    [Header("Reboot Settings")]
    [SerializeField, Min(1f)] private float rebootDuration = 5f;

    [SerializeField, Min(1f)] private float rebootAllDuration = 10f;

    [Header("Air Cleaner Countdown")]
    [SerializeField, Min(10f)] private float ventilationDeadline = 60f;

    /// Phát khi trạng thái 1 hệ thống thay đổi.
    /// Param 1: loại hệ thống. Param 2: true = online, false = error.
    public event Action<SubSystem, bool> SubSystemChanged;

    /// Phát khi Air Cleaner hết giờ → Bad Ending.
    public event Action VentilationExpired;

    private bool[] isOnline = new bool[3];
    private bool[] isRebooting = new bool[3];
    private float ventilationTimer;
    private bool ventilationCounting;
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
        if (!ventilationCounting)
            return;

        ventilationTimer -= Time.deltaTime;

        if (ventilationTimer <= 0f)
        {
            ventilationCounting = false;
            VentilationExpired?.Invoke();
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

    public float GetVentilationTimeLeft()
    {
        return ventilationCounting ? Mathf.Max(0f, ventilationTimer) : -1f;
    }

    /// Gây hỏng 1 hệ thống. Nếu đang online thì chuyển sang error.
    [ContextMenu("Break Camera")]
    private void BreakCamera() => BreakSubSystem(SubSystem.CameraDevices);

    [ContextMenu("Break Lighting")]
    private void BreakLighting() => BreakSubSystem(SubSystem.Lighting);

    [ContextMenu("Break Electricity")]
    private void BreakVentilation() => BreakSubSystem(SubSystem.Ventilation);

    public void BreakSubSystem(SubSystem system)
    {
        int index = (int)system;

        if (!isOnline[index])
            return;

        isOnline[index] = false;
        isRebooting[index] = false;

        if (system == SubSystem.Ventilation)
        {
            ventilationTimer = ventilationDeadline;
            ventilationCounting = true;
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
            
            if ((SubSystem)i == SubSystem.Ventilation)
            {
                ventilationCounting = false;
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

        if (system == SubSystem.Ventilation)
        {
            ventilationCounting = false;
        }

        SubSystemChanged?.Invoke(system, true);
    }
}
