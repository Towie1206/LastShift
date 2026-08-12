using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Menu
{
    /// <summary>
    /// Chịu trách nhiệm duy nhất: quản lý Master Volume và Fullscreen,
    /// đọc/lưu PlayerPrefs và áp dụng settings.
    /// </summary>
    public class MenuSettings : MonoBehaviour
    {
        private const string MasterVolumeKey = "MasterVolume";
        private const string FullscreenKey = "Fullscreen";

        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Toggle fullscreenToggle;

        private void Awake()
        {
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            float savedVolume = PlayerPrefs.GetFloat(MasterVolumeKey, 1f);
            bool savedFullscreen = PlayerPrefs.GetInt(FullscreenKey, Screen.fullScreen ? 1 : 0) == 1;

            AudioListener.volume = savedVolume;
            Screen.fullScreen = savedFullscreen;

            masterVolumeSlider.SetValueWithoutNotify(savedVolume);
            fullscreenToggle.SetIsOnWithoutNotify(savedFullscreen);
        }

        /// <summary>
        /// Được gọi từ MasterVolumeSlider.OnValueChanged.
        /// </summary>
        public void SetMasterVolume(float value)
        {
            AudioListener.volume = value;

            PlayerPrefs.SetFloat(MasterVolumeKey, value);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Được gọi từ FullscreenToggle.OnValueChanged.
        /// </summary>
        public void SetFullscreen(bool enabled)
        {
            Screen.fullScreen = enabled;

            PlayerPrefs.SetInt(FullscreenKey, enabled ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}