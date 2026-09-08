using System.Collections;
using UnityEngine;

public class MaintenanceBreakdownScheduler : MonoBehaviour
{
    [SerializeField] private MaintenanceSystem maintenanceSystem;
    
    [Header("Thời gian chờ giữa 2 lần kiểm tra (giây)")]
    [SerializeField] private float minCheckInterval = 15f;
    [SerializeField] private float maxCheckInterval = 45f;

    [Header("Tỉ lệ hỏng hóc (0-1) mỗi lần kiểm tra")]
    [SerializeField, Range(0f, 1f)] private float breakdownChance = 0.3f;

    private void Start()
    {
        StartCoroutine(BreakdownRoutine());
    }

    private IEnumerator BreakdownRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minCheckInterval, maxCheckInterval);
            yield return new WaitForSeconds(waitTime);

            // Tung xúc xắc, nếu trúng thì hỏng 1 hệ thống ngẫu nhiên đang online
            if (Random.value <= breakdownChance)
            {
                BreakRandomOnlineSystem();
            }
        }
    }

    private void BreakRandomOnlineSystem()
    {
        // Thu thập các hệ thống đang online
        System.Collections.Generic.List<SubSystem> onlineSystems = new System.Collections.Generic.List<SubSystem>();
        
        if (maintenanceSystem.IsOnline(SubSystem.CameraDevices)) onlineSystems.Add(SubSystem.CameraDevices);
        if (maintenanceSystem.IsOnline(SubSystem.Lighting)) onlineSystems.Add(SubSystem.Lighting);
        if (maintenanceSystem.IsOnline(SubSystem.Electricity)) onlineSystems.Add(SubSystem.Electricity);

        if (onlineSystems.Count > 0)
        {
            // Chọn ngẫu nhiên 1 cái để làm hỏng
            SubSystem target = onlineSystems[Random.Range(0, onlineSystems.Count)];
            maintenanceSystem.BreakSubSystem(target);
        }
    }
}
