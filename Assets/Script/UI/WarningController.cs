using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarningController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private CanvasGroup warningPanel;

    [Header("Timing")]
    [SerializeField] private float fadeDuration = 1.5f;
    [SerializeField] private float displayDuration = 5.0f;

    [Header("Scene")]
    [SerializeField] private string menuSceneName = "Menu";

    private void Start()
    {
        StartCoroutine(Co_Warning());
    }

    private IEnumerator Co_Warning()
    {
        // Fade in
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime / fadeDuration;
            warningPanel.alpha = t;
            yield return null;
        }
        warningPanel.alpha = 1f;

        // Giữ hiển thị
        yield return new WaitForSeconds(displayDuration);

        // Fade out
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime / fadeDuration;
            warningPanel.alpha = 1f - t;
            yield return null;
        }
        warningPanel.alpha = 0f;

        // Chuyển sang Scene Menu chính
        SceneManager.LoadScene(menuSceneName);
    }
}

