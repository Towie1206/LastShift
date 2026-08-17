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

            PlayerPrefs.SetFloat(MasterVolumeKey, value);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Được gọi từ FullscreenToggle.OnValueChanged.
        /// </summary>
        public void SetFullscreen(bool enabled)
        {
            Screen.fullScreen = enabled;

            PlayerPrefs.Save();
        }
    }