using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static PauseMenuController Instance { get; private set; }

    [SerializeField] private GameObject pauseMenuPanel; // Gắn UI Pause chính
    [SerializeField] private GameObject settingsPanel;  // Gắn UI Settings (mang từ Main Menu qua)

    public bool isPaused { get; private set; } = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Dừng mọi hoạt động trong game

        pauseMenuPanel.SetActive(true);
        settingsPanel.SetActive(false); // Ẩn settings lúc mới mở Pause

        // Mở khóa chuột để người chơi có thể bấm nút
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Tiếp tục game

        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);

        // Khóa lại chuột khi chơi (như trong PlayerFreeState của bạn)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenSettings()
    {
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // Nhớ đặt lại timeScale trước khi load menu
        SceneManager.LoadScene("Menu"); // Đổi tên scene cho đúng với Menu của bạn nhé
    }
}
