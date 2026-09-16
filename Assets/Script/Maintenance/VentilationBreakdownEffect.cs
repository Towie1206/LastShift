using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class VentilationBreakdownEffect : MonoBehaviour
{
    [SerializeField] private MaintenanceSystem maintenanceSystem;

    [Header("Timer UI")]
    [SerializeField] private TMP_Text timerText;


    [SerializeField] private GameObject blackoutPanel;

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
            timerText.text = $"VENTILATION  OFFLINE: {minutes:00}:{seconds:00}";
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
            if (blackoutPanel != null) blackoutPanel.SetActive(false);

            if (timerText != null)
                timerText.gameObject.SetActive(false);
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

        if (timerText != null)
            timerText.gameObject.SetActive(false);

        // Khóa player
        if (maintenanceSystem.TryGetComponent<MaintenanceStation>(out var station))
        {
            // Station sẽ tự xử lý
        }

    }


    private IEnumerator SuffocationBlinkRoutine()
    {
        while (isCountingDown)
        {
            // Cứ sau 3 đến 5 giây thì bị "nhắm mắt" 1 lần
            yield return new WaitForSeconds(Random.Range(3f, 5f));

            if (!isCountingDown) break;

            // 1. Màn hình tối đen (nhắm mắt)
            if (blackoutPanel != null) blackoutPanel.SetActive(true);

            // 2. Tối trong khoảng 0.8 đến 1.2 giây
            yield return new WaitForSeconds(1f);

            // 3. Mở mắt ra lại
            if (blackoutPanel != null) blackoutPanel.SetActive(false);
        }
    }
}
