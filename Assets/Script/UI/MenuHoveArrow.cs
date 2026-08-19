using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// MenuHoverArrow.cs
/// -------------------
/// Chịu trách nhiệm duy nhất: khi chuột hoặc gamepad/bàn phím chọn 1 nút trong Menu,
/// di chuyển mũi tên chỉ dẫn (Arrow) tới ngang hàng với nút đó.
/// </summary>
public class MenuHoverArrow : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler,
    ISelectHandler, IDeselectHandler
{
    [Header("Kéo object mũi tên chỉ dẫn (dùng chung cho mọi nút) vào đây")]
    [SerializeField] private RectTransform arrow;

    // Vị trí X gốc của mũi tên, ghi nhớ lại lúc Menu vừa mở lên
    private Vector2 arrowStartPosition;

    private void Start()
    {
        if (arrow != null)
        {
            arrowStartPosition = arrow.position;
        }
    }

    // Khi chuột rê vào nút
    public void OnPointerEnter(PointerEventData eventData) => MoveArrow(true);

    // Khi chuột rời khỏi nút
    public void OnPointerExit(PointerEventData eventData) => SetHighlighted(false);

    // Khi nút được chọn bằng gamepad/bàn phím
    public void OnSelect(BaseEventData eventData) => MoveArrow(true);

    // Khi nút bị bỏ chọn
    public void OnDeselect(BaseEventData eventData) => SetHighlighted(false);

    private void MoveArrow(bool on)
    {
        if (arrow == null) return;

        Vector2 targetPosition = (transform as RectTransform).position;
        arrow.position = new Vector2(arrowStartPosition.x, targetPosition.y);

        SetHighlighted(on);
    }

    private void SetHighlighted(bool on)
    {
        if (arrow == null) return;

        var image = arrow.GetComponent<UnityEngine.UI.Image>();
        if (image != null)
        {
            var color = image.color;
            color.a = on ? 1f : 0.3f; // sáng khi được chọn, mờ khi không
            image.color = color;
        }
    }
}
