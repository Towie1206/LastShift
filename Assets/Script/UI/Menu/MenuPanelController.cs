using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPanelController : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject playModePanel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject anomalyListPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [SerializeField] private GameObject startButton;      // nút Start trong Main
    [SerializeField] private GameObject firstPlayModeButton; // nút đầu tiên trong PlayMode
    [SerializeField] private GameObject backButtonControls; // nút Back trong Controls
    [SerializeField] private GameObject backButtonAnomalyList; // nút Back trong AnomalyList
    [SerializeField] private GameObject firstSettingsControl; // slider đầu tiên trong Settings
    [SerializeField] private GameObject backButtonCredits; // nút Back trong Credits

    // Nhớ lại nút đang được chọn ở Main, để khi Back từ Settings/Credits về thì chọn lại đúng chỗ
    private GameObject lastMainSelection;

    public void ShowMainPanel()
    {
        if (mainPanel != null) mainPanel.SetActive(true);
        if (playModePanel != null) playModePanel.SetActive(false);
        if (controlsPanel != null) controlsPanel.SetActive(false);
        if (anomalyListPanel != null) anomalyListPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (creditsPanel != null) creditsPanel.SetActive(false);

        GameObject target = lastMainSelection != null ? lastMainSelection : startButton;
        if (target != null) SetSelected(target);
    }

    public void ShowPlayModePanel()
    {
        lastMainSelection = EventSystem.current != null ? EventSystem.current.currentSelectedGameObject : null;

        if (mainPanel != null) mainPanel.SetActive(false);
        if (playModePanel != null) playModePanel.SetActive(true);
        if (controlsPanel != null) controlsPanel.SetActive(false);
        if (anomalyListPanel != null) anomalyListPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (creditsPanel != null) creditsPanel.SetActive(false);

        if (firstPlayModeButton != null) SetSelected(firstPlayModeButton);
    }

    public void ShowControlsPanel()
    {
        lastMainSelection = EventSystem.current != null ? EventSystem.current.currentSelectedGameObject : null;

        if (mainPanel != null) mainPanel.SetActive(false);
        if (playModePanel != null) playModePanel.SetActive(false);
        if (controlsPanel != null) controlsPanel.SetActive(true);
        if (anomalyListPanel != null) anomalyListPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (creditsPanel != null) creditsPanel.SetActive(false);

        if (backButtonControls != null) SetSelected(backButtonControls);
    }

    public void ShowAnomalyListPanel()
    {
        lastMainSelection = EventSystem.current != null ? EventSystem.current.currentSelectedGameObject : null;

        if (mainPanel != null) mainPanel.SetActive(false);
        if (playModePanel != null) playModePanel.SetActive(false);
        if (controlsPanel != null) controlsPanel.SetActive(false);
        if (anomalyListPanel != null) anomalyListPanel.SetActive(true);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (creditsPanel != null) creditsPanel.SetActive(false);

        if (backButtonAnomalyList != null) SetSelected(backButtonAnomalyList);
    }

    public void ShowSettingsPanel()
    {
        lastMainSelection = EventSystem.current != null ? EventSystem.current.currentSelectedGameObject : null;

        if (mainPanel != null) mainPanel.SetActive(false);
        if (playModePanel != null) playModePanel.SetActive(false);
        if (controlsPanel != null) controlsPanel.SetActive(false);
        if (anomalyListPanel != null) anomalyListPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(true);
        if (creditsPanel != null) creditsPanel.SetActive(false);

        if (firstSettingsControl != null) SetSelected(firstSettingsControl);
    }

    public void ShowCreditsPanel()
    {
        lastMainSelection = EventSystem.current != null ? EventSystem.current.currentSelectedGameObject : null;

        if (mainPanel != null) mainPanel.SetActive(false);
        if (playModePanel != null) playModePanel.SetActive(false);
        if (controlsPanel != null) controlsPanel.SetActive(false);
        if (anomalyListPanel != null) anomalyListPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (creditsPanel != null) creditsPanel.SetActive(true);

        if (backButtonCredits != null) SetSelected(backButtonCredits);
    }

    // Gọi hàm này ngay sau khi màn Warning kết thúc
    public void OnWarningFinished()
    {
        ShowMainPanel();
    }

    private void SetSelected(GameObject target)
    {
        if (EventSystem.current == null || target == null) return;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(target);
    }
}