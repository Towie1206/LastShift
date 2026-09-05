using UnityEngine;
using UnityEngine.EventSystems;

// Gắn script này vào từng nút chọn ngôn ngữ (nút Tiếng Việt, nút Tiếng Anh).
// Trách nhiệm duy nhất: báo cho LanguageSettingsUI hiện/ẩn tooltip khi chuột rê vào/ra.
public class LanguageOptionHoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private LanguageSettingsUI settingsUI;

    [TextArea]
    [SerializeField] private string tooltipMessage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        settingsUI.ShowTooltip(tooltipMessage);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        settingsUI.HideTooltip();
    }
}
