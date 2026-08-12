using UnityEngine;

    /// <summary>
    /// Chịu trách nhiệm duy nhất: quản lý hiển thị MainPanel, SettingsPanel, CreditsPanel.
    /// Tại mọi thời điểm chỉ có một panel active.
    /// </summary>
    public class MenuPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject creditsPanel;

        /// <summary>
        /// Được gọi từ Settings BackButton / Credits BackButton.OnClick.
        /// </summary>
        public void ShowMainPanel()
        {
            ShowOnly(mainPanel);
        }

        /// <summary>
        /// Được gọi từ SettingsButton.OnClick.
        /// </summary>
        public void ShowSettingsPanel()
        {
            ShowOnly(settingsPanel);
        }

        /// <summary>
        /// Được gọi từ CreditsButton.OnClick.
        /// </summary>
        public void ShowCreditsPanel()
        {
            ShowOnly(creditsPanel);
        }

        private void ShowOnly(GameObject selectedPanel)
        {
            mainPanel.SetActive(false);
            settingsPanel.SetActive(false);
            creditsPanel.SetActive(false);

            selectedPanel.SetActive(true);
        }
    }