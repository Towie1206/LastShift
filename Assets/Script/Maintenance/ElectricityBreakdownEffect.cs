using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ElectricityBreakdownEffect : MonoBehaviour
{
    [SerializeField] private MaintenanceSystem maintenanceSystem;

    [Header("Timer UI (hiện đếm ngược khi Điện hỏng)")]
    [SerializeField] private TMP_Text timerText;

    [Header("Đèn phòng bảo vệ (tắt khi mất điện)")]
    [SerializeField] private Light[] securityRoomLights;

    [Header("Jumpscare")]
    [SerializeField] private GameObject jumpscareUI; // Ảnh/Animation jumpscare
    [SerializeField] private AudioSource jumpscareAudio; // Tiếng hét
    [SerializeField] private float jumpscareDelay = 3f; // Chờ bao lâu trong bóng tối trước khi jumpscare
    [SerializeField] private float jumpscareDisplayTime = 2f; // Jumpscare hiện bao lâu
    [SerializeField] private string homeSceneName = "Home";

    private bool isCountingDown;
    private bool isGameOver;

    private void OnEnable()
    {
        maintenanceSystem.SubSystemChanged += HandleSubSystemChanged;
        maintenanceSystem.ElectricityExpired += HandleElectricityExpired;
    }

    private void OnDisable()
    {
        maintenanceSystem.SubSystemChanged -= HandleSubSystemChanged;
        maintenanceSystem.ElectricityExpired -= HandleElectricityExpired;
    }

    private void Start()
    {
        if (timerText != null)
            timerText.gameObject.SetActive(false);

        if (jumpscareUI != null)
            jumpscareUI.SetActive(false);
    }

    private void Update()
    {
        if (!isCountingDown || isGameOver)
            return;

        float timeLeft = maintenanceSystem.GetElectricityTimeLeft();

        if (timeLeft < 0f)
        {
            isCountingDown = false;
            if (timerText != null)
                timerText.gameObject.SetActive(false);
            return;
        }

        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeLeft / 60f);
            int seconds = Mathf.FloorToInt(timeLeft % 60f);
            timerText.text = $"ELECTRICITY OFFLINE: {minutes:00}:{seconds:00}";
        }
    }

    private void HandleSubSystemChanged(SubSystem system, bool isOnline)
    {
        if (system != SubSystem.Electricity || isGameOver)
            return;

        if (isOnline)
        {
            isCountingDown = false;
            SetSecurityLights(true);

            if (timerText != null)
                timerText.gameObject.SetActive(false);
        }
        else
        {
            isCountingDown = true;
            SetSecurityLights(false);

            if (timerText != null)
                timerText.gameObject.SetActive(true);
        }
    }

    private void SetSecurityLights(bool active)
    {
        if (securityRoomLights == null) return;

        foreach (Light light in securityRoomLights)
        {
            if (light != null)
                light.enabled = active;
        }
    }

    private void HandleElectricityExpired()
    {
        isCountingDown = false;
        isGameOver = true;

        if (timerText != null)
            timerText.gameObject.SetActive(false);

        // Khóa player
        if (maintenanceSystem.TryGetComponent<MaintenanceStation>(out var station))
        {
            // Station sẽ tự xử lý
        }

        StartCoroutine(JumpscareSequence());
    }

    private IEnumerator JumpscareSequence()
    {
        // 1. Ngồi trong bóng tối chờ chết
        yield return new WaitForSeconds(jumpscareDelay);

        // 2. JUMPSCARE!
        if (jumpscareUI != null)
            jumpscareUI.SetActive(true);

        if (jumpscareAudio != null)
            jumpscareAudio.Play();

        // 3. Giữ jumpscare trên màn hình
        yield return new WaitForSeconds(jumpscareDisplayTime);

        // 4. Đẩy ra Home
        SceneManager.LoadScene(homeSceneName);
    }
}
