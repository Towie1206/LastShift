using UnityEngine;

public class LightingBreakdownEffect : MonoBehaviour
{
    [SerializeField] private MaintenanceSystem maintenanceSystem;

    [Header("Kéo tất cả Spot Light / Point Light trong scene vào đây")]
    [SerializeField] private Light[] controllableLights;

    private void OnEnable()
    {
        maintenanceSystem.SubSystemChanged += HandleSubSystemChanged;
    }

    private void OnDisable()
    {
        maintenanceSystem.SubSystemChanged -= HandleSubSystemChanged;
    }

    private void HandleSubSystemChanged(SubSystem system, bool isOnline)
    {
        if (system != SubSystem.Lighting)
            return;

        SetLightsActive(isOnline);
    }

    private void SetLightsActive(bool active)
    {
        if (controllableLights == null)
            return;

        for (int i = 0; i < controllableLights.Length; i++)
        {
            if (controllableLights[i] == null)
                continue;

            controllableLights[i].enabled = active;
        }
    }
}
