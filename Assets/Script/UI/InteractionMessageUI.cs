using System.Collections;
using TMPro;
using UnityEngine;

public class InteractionMessageUI : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private CanvasGroup messageCanvasGroup;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float moveDistance = 50f;
    [SerializeField] private float speed = 100f;
    private RectTransform messageRect;
    private Vector2 startPosition;

    private Coroutine hideCoroutine;

    private void Awake()
    {
        messageRect = messageText.rectTransform;
        startPosition = messageRect.anchoredPosition;

        messageCanvasGroup.alpha = 0f;
        messageText.gameObject.SetActive(false);

    }

    public void Show(string message)
    {
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        messageText.text = message;
        hideCoroutine = StartCoroutine(PlayMessageAnimation());
    }

    private IEnumerator PlayMessageAnimation()
    {
        messageText.gameObject.SetActive(true); 
        messageRect.anchoredPosition = startPosition;
        messageCanvasGroup.alpha = 1f;


        Vector2 targetPos = startPosition + new Vector2(0, moveDistance);
        
        float Timer = 0f; //thời gian đã trôi qua
        while(Timer < fadeDuration)
        {
            Timer += Time.deltaTime;

            float process = Timer / fadeDuration;

            messageRect.anchoredPosition = Vector2.MoveTowards(messageRect.anchoredPosition, targetPos, speed * Time.deltaTime);

            messageCanvasGroup.alpha = 1f - process;

            yield return null;
        }

        messageRect.anchoredPosition = startPosition;
        messageCanvasGroup.alpha = 0f;
        messageText.gameObject.SetActive(false);

        hideCoroutine = null;
    }
}
