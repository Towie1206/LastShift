using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UILocalizedText : MonoBehaviour
{
    [Header("Bản dịch")]
    [TextArea(2,5)]
    [SerializeField] private string vietnameseText;
    
    [TextArea(2,5)]
    [SerializeField] private string englishText;

    private TextMeshProUGUI _textComponent;

    private void Awake()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
        
        // Nếu bạn chưa nhập tiếng việt thì lấy text mặc định của TMPro làm tiếng việt
        if (string.IsNullOrEmpty(vietnameseText))
        {
            vietnameseText = _textComponent.text;
        }
    }

    private void OnEnable()
    {
        UpdateText();
        LanguageManager.OnLanguageChanged += UpdateText;
    }

    private void OnDisable()
    {
        LanguageManager.OnLanguageChanged -= UpdateText;
    }

    private void UpdateText()
    {
        if (_textComponent == null) return;
        
        _textComponent.text = LanguageManager.IsEnglish && !string.IsNullOrEmpty(englishText) 
            ? englishText 
            : vietnameseText;
    }
}
