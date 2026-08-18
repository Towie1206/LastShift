using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPanelController : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [SerializeField] private GameObject startButton;      // nút Start trong Main
    [SerializeField] private GameObject firstSettingsControl; // slider đầu tiên trong Settings
    [SerializeField] private GameObject backButtonCredits; // nút Back trong Credits

    // Nhớ lại nút đang được chọn ở Main, để khi Back từ Settings/Credits về thì chọn lại đúng chỗ
    private GameObject lastMainSelection;

    public void ShowMainPanel()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);

        // Đây là dòng quan trọng đang bị THIẾU trong code gốc:
        GameObject target = lastMainSelection != null ? lastMainSelection : startButton;
        SetSelected(target);
    }

    public void ShowSettingsPanel()
    {
        lastMainSelection = EventSystem.current.currentSelectedGameObject;

        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);

        SetSelected(firstSettingsControl);
    }

    public void ShowCreditsPanel()
    {
        lastMainSelection = EventSystem.current.currentSelectedGameObject;

        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);

        SetSelected(backButtonCredits);
    }

    // Gọi hàm này ngay sau khi màn Warning kết thúc
    public void OnWarningFinished()
    {
        ShowMainPanel(); // sẽ tự chọn startButton vì lastMainSelection còn null lúc này
    }

    private void SetSelected(GameObject target)
    {
        // Clear trước rồi set lại - đây là "trick" bắt buộc của Unity UI,
        // nếu không clear trước, nhiều trường hợp Unity sẽ không chọn lại được
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(target);
    }
}