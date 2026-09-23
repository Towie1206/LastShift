using UnityEngine;
using UnityEngine.UI;

public class UsageUI : MonoBehaviour
{
    [SerializeField] private GeneratorSystem generatorSystem;
    [SerializeField] private Image[] usageBars;

    [Header("Màu sắc theo cấp độ nguy hiểm")]
    [SerializeField] private Color normalColor = new Color(0.2f, 1f, 0.2f);   // Xanh lá (Mức 1-2)
    [SerializeField] private Color warningColor = new Color(1f, 0.8f, 0.1f);  // Vàng/Cam (Mức 3)
    [SerializeField] private Color dangerColor = new Color(1f, 0.2f, 0.2f);   // Đỏ (Mức 4)

    private void OnEnable()
    {
        if (generatorSystem != null)
            generatorSystem.OnUsageLevelChanged += UpdateUsageDisplay;
    }
    private void OnDisable()
    {
        if (generatorSystem != null)
            generatorSystem.OnUsageLevelChanged -= UpdateUsageDisplay;
    }
    private void Start()
    {
        UpdateUsageDisplay(1); // Mặc định vào game là mức 1 (Base Drain)
    }

    private void UpdateUsageDisplay(int level)
    {
        // Chọn màu chung cho toàn bộ dải vạch
        Color currentColor = normalColor;
        if (level == 3) currentColor = warningColor;
        else if (level >= 4) currentColor = dangerColor;
        for (int i = 0; i < usageBars.Length; i++)
        {
            if (i < level)
            {
                // Bật vạch sáng lên và gán màu
                usageBars[i].color = currentColor;
            }
            else
            {
                // Vạch tắt: Màu xám tối trong suốt (mờ đi)
                usageBars[i].color = new Color(0.2f, 0.2f, 0.2f, 0f);
            }
        }
    }


}
