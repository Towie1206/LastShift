using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    [SerializeField] private string storySceneName = "Home";
    [SerializeField] private string gameSceneName = "Game";

    /// <summary>
    /// Chơi cốt truyện: Thức dậy ở nhà (Home), nghe điện thoại và đến xưởng gặp Quản lý
    /// </summary>
    public void StartStoryMode()
    {
        ShiftGameManager.startDirectlyInOffice = false;
        SceneManager.LoadScene(storySceneName);
    }

    /// <summary>
    /// Vào thẳng văn phòng (Office Mode): Bỏ qua cốt truyện, vào ca trực bảo vệ ngay
    /// </summary>
    public void StartOfficeMode()
    {
        ShiftGameManager.startDirectlyInOffice = true;
        SceneManager.LoadScene(gameSceneName);
    }

    /// <summary>
    /// Tiếp tục sau đoạn chat ở nhà: Đến xưởng để nói chuyện với Quản lý
    /// </summary>
    public void ContinueToWork()
    {
        ShiftGameManager.startDirectlyInOffice = false;
        SceneManager.LoadScene(gameSceneName);
    }

    /// <summary>
    /// Tương thích ngược với nút Start cũ
    /// </summary>
    public void StartShift()
    {
        StartStoryMode();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}