using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// MenuHoverArrow.cs
/// -------------------
/// Chịu trách nhiệm duy nhất: khi chuột rê vào 1 nút trong Menu, di chuyển mũi tên chỉ dẫn
/// (Arrow) tới ngang hàng với nút đó - tạo cảm giác "đang được chọn" giống game console cũ.
///
/// CÁCH DÙNG: gắn script này riêng vào TỪNG nút (StartButton, SettingsButton, CreditsButton,
/// QuitButton...) - mỗi bản đều kéo CÙNG 1 object Arrow duy nhất vào ô "Arrow" bên dưới.
///
/// Vì sao dùng IPointerEnterHandler thay vì Update()? Đây là 1 interface (giao diện) có sẵn
/// của chính Unity, dùng để Unity tự gọi hàm OnPointerEnter() đúng lúc chuột chạm vào -
/// không phải interface tự bịa ra, và giúp mình không phải kiểm tra vị trí chuột liên tục
/// trong Update() mỗi khung hình.
/// </summary>
public class MenuHoverArrow : MonoBehaviour, IPointerEnterHandler
{
    [Header("Kéo object mũi tên chỉ dẫn (dùng chung cho mọi nút) vào đây")]
    [SerializeField] private RectTransform arrow;

    // Vị trí X gốc của mũi tên, ghi nhớ lại lúc Menu vừa mở lên, để mỗi lần di chuyển
    // chỉ đổi vị trí Y (lên/xuống) mà vẫn giữ nguyên cột X ban đầu.
    private Vector2 arrowStartPosition;

    private void Start()
    {
        if (arrow != null)
        {
            arrowStartPosition = arrow.position;
        }
    }

    /// <summary>
    /// Unity tự động gọi hàm này khi chuột vừa di vào vùng của nút đang gắn script này.
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (arrow == null) return;

        Vector2 targetPosition = (transform as RectTransform).position;
        arrow.position = new Vector2(arrowStartPosition.x, targetPosition.y);
    }
}