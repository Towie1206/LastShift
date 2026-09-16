using System.Collections;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private RectTransform timeText5;
    [SerializeField] private RectTransform timeText6;
    [SerializeField] private float rollDistance = 120f;
    [SerializeField] private float rollDuration = 1.2f;

    [Header("Audio")]
    [SerializeField] private AudioSource cheerAudio;
    [SerializeField] private AudioSource bellAudio;

    [ContextMenu("🎉 TEST 6 AM WIN SEQUENCE 🎉")]
    public void StartWinSequence()
    {
        gameObject.SetActive(true);
        StartCoroutine(WinRoutine());
    }

    private IEnumerator WinRoutine()
    {
        timeText5.anchoredPosition = new Vector2(timeText5.anchoredPosition.x, 0);
        timeText6.anchoredPosition = new Vector2(timeText6.anchoredPosition.x, -rollDistance);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        yield return new WaitForSecondsRealtime(2f);

        Vector2 startPos5  = timeText5.anchoredPosition;
        Vector2 targetPos5 = new Vector2(timeText5.anchoredPosition.x, rollDistance);

        Vector2 startPos6 = timeText6.anchoredPosition;
        Vector2 targetPos6 = new Vector2(timeText6.anchoredPosition.x, 0);

        float timer = 0f;

        while (timer < rollDuration)
        {
            timer += Time.unscaledDeltaTime;

            float t = Mathf.Clamp01(timer / rollDuration);

            float smoothT = Mathf.SmoothStep(0f, 1f, t);

            timeText5.anchoredPosition = Vector2.Lerp(startPos5, targetPos5, smoothT);
            timeText6.anchoredPosition = Vector2.Lerp(startPos6, targetPos6, smoothT);

            yield return null;
        }

        timeText5.anchoredPosition = targetPos5;
        timeText6.anchoredPosition = targetPos6;
       
        if (cheerAudio != null) cheerAudio.Play();
        if (bellAudio != null) bellAudio.Play();

        yield return new WaitForSecondsRealtime(4f);

    }
}
