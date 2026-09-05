using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettingsUI : MonoBehaviour
{
    [Header("Nút chọn ngôn ngữ")]
    [SerializeField] private Image imgBtnVietnamese;
    [SerializeField] private Image imgBtnEnglish;

    [Header("Ô tick đánh dấu ngôn ngữ đang chọn")]
    [SerializeField] private GameObject checkVietnamese;
    [SerializeField] private GameObject checkEnglish;

    [Header("Box thông báo (tooltip) khi rê chuột")]
    [SerializeField] private GameObject tooltipBox;
    [SerializeField] private TMP_Text tooltipText; 
    private void Start()
    {
        UpdateVisuals();
        HideTooltip();
    }

    public void SetVietnamese()
    {
        LanguageManager.IsEnglish = false;
        UpdateVisuals();
    }

    public void SetEnglish()
    {
        LanguageManager.IsEnglish = true;
        UpdateVisuals();
    }

    // Bật/tắt ô tick theo ngôn ngữ đang được chọn (thay cho việc đổi màu sáng/tối trước đây)
    private void UpdateVisuals()
    {
        bool isEnglish = LanguageManager.IsEnglish;

        checkVietnamese.SetActive(!isEnglish);
        checkEnglish.SetActive(isEnglish);
    }

    // Được LanguageOptionHoverTooltip gọi khi chuột rê vào một lựa chọn
    public void ShowTooltip(string message)
    {
        tooltipText.text = message;
        tooltipBox.SetActive(true);
    }

    // Được gọi khi chuột rời khỏi lựa chọn
    public void HideTooltip()
    {
        tooltipBox.SetActive(false);
    }
}