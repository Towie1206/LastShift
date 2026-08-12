using UnityEngine;
using UnityEngine.SceneManagement;

    /// <summary>
    /// Chịu trách nhiệm duy nhất: bắt đầu game và thoát game.
    /// </summary>
public class MainMenuActions : MonoBehaviour
{
        [SerializeField] private string gameSceneName = "Game";

        /// <summary>
        /// Được gọi từ StartButton.OnClick.
        /// </summary>
        public void StartShift()
        {
            SceneManager.LoadScene(gameSceneName);
        }

        /// <summary>
        /// Được gọi từ QuitButton.OnClick.
        /// Lưu ý: Application.Quit() không thoát Play Mode trong Unity Editor,
        /// cần test hành vi thực tế trong Build.
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
}