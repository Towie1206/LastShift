using UnityEngine;

public class CameraBreakdownEffect : MonoBehaviour
{
    [SerializeField] private MaintenanceSystem maintenanceSystem;
    
    [Header("Cameras")]
    [SerializeField] private GameObject[] cctvCameras;

    [Header("Noise")]
    [SerializeField] private GameObject staticNoiseOverlay;
    [SerializeField] private AudioSource staticNoiseAudio;

    private void Start()
    {
        // Mặc định tắt 2 cái noise đi khi game bắt đầu
        if (staticNoiseOverlay != null) staticNoiseOverlay.SetActive(false);
        if (staticNoiseAudio != null) staticNoiseAudio.Stop();
    }

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
        if (system != SubSystem.CameraDevices)
            return;

        if (isOnline)
        {
            RestoreCameras();
        }
        else
        {
            DisruptCameras();
        }
    }

    private void DisruptCameras()
    {
        // Bật màn hình nhiễu và tiếng rè
        if (staticNoiseOverlay != null) staticNoiseOverlay.SetActive(true);
        if (staticNoiseAudio != null)
        {
            staticNoiseAudio.loop = true;
            staticNoiseAudio.Play();
        }

        // Tắt hết các Camera đi
        foreach (GameObject cam in cctvCameras)
        {
            if (cam != null) cam.SetActive(false);
        }
    }

    private void RestoreCameras()
    {
        // Tắt màn hình nhiễu và tiếng rè
        if (staticNoiseOverlay != null) staticNoiseOverlay.SetActive(false);
        if (staticNoiseAudio != null) staticNoiseAudio.Stop();

        // Bật lại các Camera
        foreach (GameObject cam in cctvCameras)
        {
            if (cam != null) cam.SetActive(true);
        }
    }
}
