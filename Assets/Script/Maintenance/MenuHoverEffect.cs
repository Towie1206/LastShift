using UnityEngine;
using UnityEngine.EventSystems;

public class MenuHoverEffect : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private RectTransform arrowText;
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        arrowText.anchoredPosition = new Vector2 (-290, rectTransform.anchoredPosition.y);
    }

}
