using System.Collections;
using TMPro;

using UnityEngine;
using UnityEngine.Scripting;

public class AnomalyReportFeedback : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject feedbackUI;
    [SerializeField] private TMP_Text anomalyText;
    [SerializeField] private TMP_Text resultText;

    [Header("Timing")]
    private float fadeDuration = 1.5f;
    private float displayDuration = 2f;

    private void Awake()
    {
        feedbackUI.SetActive(false);
        anomalyText.text = "Anomaly";
    }

    public void ShowFeedBack(bool isCorrect)
    {
        resultText.text = isCorrect ? "Detected" : "Not Found";
        Color color = resultText.color;
        color.a = 0f;
        resultText.color = color;
        feedbackUI.SetActive(true);

        Time.timeScale = 0;

        StartCoroutine(FeedbackSequence());

    }

    private IEnumerator FeedbackSequence()
    {
        yield return new WaitForSecondsRealtime(1f);
        float t = 0;
        Color color = resultText.color;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            resultText.color = color;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(displayDuration);
        feedbackUI.SetActive(false);
        Time.timeScale = 1;
    }
}
