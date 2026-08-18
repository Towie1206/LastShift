using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Chịu trách nhiệm duy nhất: quản lý Master Volume và Fullscreen,
/// đọc/lưu PlayerPrefs và áp dụng settings.
/// </summary>
public class MenuSettings : MonoBehaviour
{
    private const string MasterVolumeKey = "MasterVolume";

    [SerializeField] private Slider masterVolumeSlider;

    private void Awake()
    {
        InitializeSettings();
    }

    private void InitializeSettings()
    {
        float savedVolume = PlayerPrefs.GetFloat(MasterVolumeKey, 1f);
        AudioListener.volume = savedVolume;
        masterVolumeSlider.SetValueWithoutNotify(savedVolume);
    }

    /// <summary>
    /// Được gọi từ MasterVolumeSlider.OnValueChanged.
    /// </summary>
    public void SetMasterVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(MasterVolumeKey, value); // KHÔNG gọi Save() ở đây
    }

    /// <summary>
    /// Gọi khi bấm nút Back hoặc lúc thoát game.
    /// </summary>
    public void SaveSettings()
    {
        PlayerPrefs.Save(); // Chỉ ghi ổ đĩa 1 lần ở đây
    }

    /// <summary>
    /// Được gọi từ FullscreenToggle.OnValueChanged.
    /// </summary>

    private void OnApplicationQuit()
    {
        SaveSettings(); // đảm bảo lưu khi thoát game
    }
}
