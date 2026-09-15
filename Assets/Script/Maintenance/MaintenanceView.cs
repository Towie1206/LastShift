using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaintenanceView : MonoBehaviour
{
    [SerializeField] private MaintenanceSystem maintenanceSystem;
    [SerializeField] private GameObject maintenancePanel;

    [Header("Buttons")]
    [SerializeField] private Button cameraBtn;
    [SerializeField] private Button lightingBtn;
    [SerializeField] private Button airCleanerBtn;
    [SerializeField] private Button rebootAllBtn;
    [SerializeField] private Button exitBtn;

    [Header("Status Texts")]
    [SerializeField] private TMP_Text cameraStatusText;
    [SerializeField] private TMP_Text lightingStatusText;
    [SerializeField] private TMP_Text airCleanerStatusText;
    [SerializeField] private TMP_Text rebootAllStatusText;

    [Header("Text Colors")]
    [SerializeField] private Color errorColor = new Color(1f, 0.2f, 0.2f); // Red
    [SerializeField] private Color normalColor = new Color(0.2f, 1f, 0.2f); // Green

    public event Action ExitRequested;

    private void OnEnable()
    {
        cameraBtn.onClick.AddListener(() => StartReboot(SubSystem.CameraDevices, cameraStatusText));
        lightingBtn.onClick.AddListener(() => StartReboot(SubSystem.Lighting, lightingStatusText));
        airCleanerBtn.onClick.AddListener(() => StartReboot(SubSystem.Electricity, airCleanerStatusText));
        
        rebootAllBtn.onClick.AddListener(StartRebootAll);
        exitBtn.onClick.AddListener(() => ExitRequested?.Invoke());

        maintenanceSystem.SubSystemChanged += HandleSubSystemChanged;
    }

    private void OnDisable()
    {
        cameraBtn.onClick.RemoveAllListeners();
        lightingBtn.onClick.RemoveAllListeners();
        airCleanerBtn.onClick.RemoveAllListeners();
        rebootAllBtn.onClick.RemoveAllListeners();
        exitBtn.onClick.RemoveAllListeners();

        maintenanceSystem.SubSystemChanged -= HandleSubSystemChanged;
    }

    public void Show()
    {
        maintenancePanel.SetActive(true);
        RefreshUI(SubSystem.CameraDevices, cameraStatusText);
        RefreshUI(SubSystem.Lighting, lightingStatusText);
        RefreshUI(SubSystem.Electricity, airCleanerStatusText);
        
        if (rebootAllStatusText != null)
        {
            rebootAllStatusText.text = ""; // Trống khi chưa làm gì
        }
    }

    public void Hide()
    {
        maintenancePanel.SetActive(false);
    }

    private void StartReboot(SubSystem system, TMP_Text statusText)
    {
        if (maintenanceSystem.IsRebooting(system))
            return;

        maintenanceSystem.RebootSubSystem(system);
        StartCoroutine(LoadingAnimationRoutine(system, statusText));

        UnpdateExitButtonState();
    }

    private void StartRebootAll()
    {
        maintenanceSystem.RebootAll();
        
        StartCoroutine(LoadingAnimationRoutine(SubSystem.CameraDevices, cameraStatusText));
        StartCoroutine(LoadingAnimationRoutine(SubSystem.Lighting, lightingStatusText));
        StartCoroutine(LoadingAnimationRoutine(SubSystem.Electricity, airCleanerStatusText));

        if (rebootAllStatusText != null)
        {
            StartCoroutine(RebootAllTextAnimation());
        }

        UnpdateExitButtonState();
    }

    // Hiệu ứng chữ loading . .. ... vòng lặp
    private IEnumerator LoadingAnimationRoutine(SubSystem system, TMP_Text statusText)
    {
        if (statusText == null) yield break;
        
        statusText.color = normalColor; // Đổi màu xanh
        int dotCount = 0;
        
        while (maintenanceSystem.IsRebooting(system))
        {
            dotCount++;
            if (dotCount > 4) dotCount = 1;
            
            string dots = new string('.', dotCount);
            statusText.text = $"loading{dots}";
            
            yield return new WaitForSeconds(0.3f);
        }
        
        UnpdateExitButtonState(); // Mở khóa nút Exit khi animation kết thúc
    }

    private IEnumerator RebootAllTextAnimation()
    {
        rebootAllStatusText.color = normalColor;
        int dotCount = 0;
        
        while (maintenanceSystem.IsRebooting(SubSystem.CameraDevices) || 
               maintenanceSystem.IsRebooting(SubSystem.Lighting) || 
               maintenanceSystem.IsRebooting(SubSystem.Electricity))
        {
            dotCount++;
            if (dotCount > 4) dotCount = 1;
            
            string dots = new string('.', dotCount);
            rebootAllStatusText.text = $"loading{dots}";
            
            yield return new WaitForSeconds(0.3f);
        }
        rebootAllStatusText.text = ""; // Xong thì ẩn đi
        
        UnpdateExitButtonState(); // Mở khóa nút Exit khi animation kết thúc
    }

    private void HandleSubSystemChanged(SubSystem system, bool isOnline)
    {
        if (system == SubSystem.CameraDevices) RefreshUI(system, cameraStatusText);
        if (system == SubSystem.Lighting) RefreshUI(system, lightingStatusText);
        if (system == SubSystem.Electricity) RefreshUI(system, airCleanerStatusText);

        UnpdateExitButtonState();
    }

    private void RefreshUI(SubSystem system, TMP_Text statusText)
    {
        if (statusText == null) return;

        if (maintenanceSystem.IsOnline(system))
        {
            statusText.text = "online";
            statusText.color = normalColor;
        }
        else if (!maintenanceSystem.IsRebooting(system))
        {
            statusText.text = "error";
            statusText.color = errorColor;
        }
    }

    private void UnpdateExitButtonState()
    {
        bool isAnyRebooting = maintenanceSystem.IsRebooting(SubSystem.CameraDevices) ||
                              maintenanceSystem.IsRebooting(SubSystem.Lighting) ||
                              maintenanceSystem.IsRebooting(SubSystem.Electricity);

        exitBtn.interactable = !isAnyRebooting;
    }
        
}
