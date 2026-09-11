using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AnomalyReportUI : MonoBehaviour
{
    [SerializeField] private AnomalyManager anomalyManager;
    [SerializeField] private AnomalyReportFeedback feedback;
    [SerializeField] private CameraSystem cameraSystem;
    [SerializeField] private GameObject reportPanel;

    [SerializeField] private TMP_Text[] textColor;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color selectedColor = Color.green;
    [SerializeField] private TMP_Text reportBtn;
    private string orgText;

    // Biến này để "nhớ" xem người chơi đang chọn loại lỗi nào (-1 là chưa chọn gì)
    private int selectedTypeIndex = -1;

    private void Start()
    {
        reportPanel.SetActive(false);
        orgText = reportBtn.text;
    }
    public void ToggleReportPanel()
    {
        reportPanel.SetActive(!reportPanel.activeSelf);
        selectedTypeIndex = -1; // Mở lại bảng thì reset lựa chọn 
    }

    public void SelectAnomalyType(int typeIndex)
    {
        selectedTypeIndex = typeIndex;

        for (int i = 0; i < textColor.Length; i++)
        {
            
            if (i == typeIndex)
                textColor[i].color = selectedColor;
            else
                textColor[i].color = normalColor;
        }
    }
    public void SubmitReport()
    {
        if (selectedTypeIndex == -1)
        {
            return;
        }
        StartCoroutine(Reporting());
    }

    private IEnumerator Reporting()
    {
        int dotCount = 0;
        float timer = 0;
        while (timer < 2f)
        {
            dotCount++;
            if (dotCount > 4) dotCount = 1;
            string dots = new string('.', dotCount);
            reportBtn.text = $"Reporting{dots}";

            timer += 0.3f;
            yield return new WaitForSeconds(0.3f);
        }
        reportBtn.text = orgText;

        AnomalyType anomalyType = (AnomalyType)selectedTypeIndex;
        AnomalyLocation location = cameraSystem.GetCurrentLocation();

        bool result = anomalyManager.ReceiveReport(location, anomalyType);

        reportPanel.SetActive(false);
        selectedTypeIndex = -1;

        feedback.ShowFeedBack(result);

        for (int i = 0; i < textColor.Length; i++)
        {
            if (textColor[i] != null) textColor[i].color = normalColor;
        }

    }
}
