using UnityEngine;
using System;

public static class LanguageManager
{
    // Sự kiện được gọi mỗi khi ngôn ngữ thay đổi (để UI tự động cập nhật)
    public static event Action OnLanguageChanged;

    private static bool _isEnglish = false;
    
    public static bool IsEnglish 
    {
        get => _isEnglish;
        set 
        {
            if (_isEnglish != value) 
            {
                _isEnglish = value;
                // Lưu vào hệ thống để lần sau mở game vẫn nhớ
                PlayerPrefs.SetInt("IsEnglish", value ? 1 : 0); 
                PlayerPrefs.Save();
                
                // Báo cho các UI đang mở biết để tự update chữ
                OnLanguageChanged?.Invoke();
            }
        }
    }

    // Tự động load ngôn ngữ lúc game vừa khởi động
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadLanguage()
    {
        _isEnglish = PlayerPrefs.GetInt("IsEnglish", 0) == 1;
    }
}
