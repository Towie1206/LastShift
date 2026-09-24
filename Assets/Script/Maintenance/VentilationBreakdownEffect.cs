using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VentilationBreakdownEffect : MonoBehaviour
{
    [SerializeField] private MaintenanceSystem maintenanceSystem;

    [Header("Timer UI")]
    [SerializeField] private TMP_Text timerText;


    [SerializeField] private Image blackoutPanel;

    private bool isCountingDown;
    private bool isGameOver;

    private void OnEnable()
    {
        maintenanceSystem.SubSystemChanged += HandleSubSystemChanged;
        maintenanceSystem.VentilationExpired += HandleVentilationExpired;
    }

    private void OnDisable()
    {
        maintenanceSystem.SubSystemChanged -= HandleSubSystemChanged;
        maintenanceSystem.VentilationExpired -= HandleVentilationExpired;
    }

    private void Start()
    {
        if (timerText != null)
            timerText.gameObject.SetActive(false);

        blackoutPanel.gameObject.SetActive(true);
        Color c = blackoutPanel.color;
        c.a = 0;
        blackoutPanel.color = c;
        blackoutPanel.raycastTarget = false;
    }

    private void Update()
    {
        if (!isCountingDown || isGameOver)
            return;

        float timeLeft = maintenanceSystem.GetVentilationTimeLeft();

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
            timerText.text = $"VENTILATION OFFLINE: {minutes:00}:{seconds:00}";
        }
    }

    private void HandleSubSystemChanged(SubSystem system, bool isOnline)
    {
        if (system != SubSystem.Ventilation || isGameOver)
            return;

        if (isOnline)
        {
            isCountingDown = false;
            StopAllCoroutines();

            if (timerText != null)
                timerText.gameObject.SetActive(false);

            // Mở mắt tỉnh táo lại hoàn toàn
            StartCoroutine(FadeAlpha(0f, 0.4f));
        }
        else
        {
            isCountingDown = true;

            StartCoroutine(SuffocationBlinkRoutine());

            if (timerText != null)
                timerText.gameObject.SetActive(true);
        }
    }


    private void HandleVentilationExpired()
    {
        isCountingDown = false;
        isGameOver = true;

        StopAllCoroutines();

        if (timerText != null)
            timerText.gameObject.SetActive(false);

        // Ngất lịm hoàn toàn: Màn hình tối sầm dần trong 0.8s
        StartCoroutine(FadeAlpha(1f, 0.8f));
    }

    private IEnumerator FadeAlpha(float targetAlpha, float duration)
    {
        Color c = blackoutPanel.color;
        float stratAlpha = c.a;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Lerp(stratAlpha, targetAlpha, elapsed / duration);
            blackoutPanel.color = c;
            yield return null;
        }

        c.a = targetAlpha;

        // Chỉ chặn click chuột khi mắt đã nhắm nghiền (> 0.8)
        blackoutPanel.raycastTarget = (targetAlpha > 0.8f);
    }

    private IEnumerator SuffocationBlinkRoutine()
    {
        while (isCountingDown)
        {
            float timeLeft = maintenanceSystem.GetVentilationTimeLeft();

            float interval;       // Khoảng cách giữa 2 lần chớp
            float closeDuration;  // Tốc độ mí mắt sụp xuống
            float holdDuration;   // Thời gian mắt nhắm nghiền
            float openDuration;   // Tốc độ hé mắt mở ra


            if (timeLeft > 30f)
            {
                // Giai đoạn 1 (> 30s): Chớp mắt nhẹ nhàng
                interval = Random.Range(4f, 6f);
                closeDuration = 0.2f;
                holdDuration = 0.25f;
                openDuration = 0.3f;
            }
            else if (timeLeft > 15f)
            {
                // Giai đoạn 2 (15s - 30s): Thiếu oxy, mắt nặng trĩu
                interval = Random.Range(2f, 3.5f);
                closeDuration = 0.35f;
                holdDuration = 0.6f;
                openDuration = 0.4f;
            }
            else
            {
                // Giai đoạn 3 (< 15s): Nguy kịch! Mắt lịm dần, tối sầm lâu
                interval = Random.Range(0.8f, 1.4f);
                closeDuration = 0.5f;  // Từ từ sụp xuống
                holdDuration = 1.0f;   // Tối đen rất lâu
                openDuration = 0.6f;   // Mở mắt một cách mệt mỏi
            }

            yield return new WaitForSeconds(interval);

            if (!isCountingDown || isGameOver) break;

            // 1. NHẮM MẮT (Fade Alpha 0 -> 1)
            yield return FadeAlpha(1f, closeDuration);

            // 2. GIỮ MẮT NHẮM
            yield return new WaitForSeconds(holdDuration);

            if (!isCountingDown || isGameOver) break;

            // 3. HÉ MẮT RA LẠI (Fade Alpha 1 -> 0)
            yield return FadeAlpha(0f, openDuration);
        }
    }
}
