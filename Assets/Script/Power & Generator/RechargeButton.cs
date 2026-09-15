using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Thêm thư viện này để tương tác với màu của Image

// Thêm 2 cái Interface Enter và Exit vào đuôi
public class RechargeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GeneratorSystem generatorSystem;

    [Header("Hover Settings")]
    [SerializeField] private Image buttonImage; // Kéo component Image của nút vào đây
    [SerializeField] private Color normalColor;
    [SerializeField] private Color hoverColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.color = normalColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        generatorSystem.SetReCharging(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        generatorSystem.SetReCharging(false);
    }
}