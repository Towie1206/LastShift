using UnityEngine;
using TMPro;

public class LanguageSettingsUI : MonoBehaviour
{
    [Header("Dropdown tham chiếu (Nấu có)")]
    [SerializeField] private TMP_Dropdown languageDropdown;

    private void Start()
    {
        if (languageDropdown != null)
        {
            // Cập nhật giá trị hiển thị lúc mới mở Menu: 0 = Tiếng Việt, 1 = English
            languageDropdown.value = LanguageManager.IsEnglish ? 1 : 0;
            
            // Lắng nghe sự kiện người dùng đổi Dropdown
            languageDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }
    }

    // Gắn hàm này vào OnClick của nút "Tiếng Việt" (Nếu dùng 2 Buttons riêng)
    public void SetVietnamese()
    {
        LanguageManager.IsEnglish = false;
    }

    // Gắn hàm này vào OnClick của nút "English" (Nếu dùng 2 Buttons riêng)
    public void SetEnglish()
    {
        LanguageManager.IsEnglish = true;
    }

    // Tự động gọi nếu dùng Dropdown
    private void OnDropdownValueChanged(int index)
    {
        // Giả định: Index 0 là Tiếng Việt, Index 1 là English
        LanguageManager.IsEnglish = (index == 1);
    }
}
