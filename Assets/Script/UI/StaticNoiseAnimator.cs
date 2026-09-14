using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class StaticNoiseAnimator : MonoBehaviour
{
    private RawImage rawImage;
    [SerializeField] private float fps = 30f; // Tốc độ chớp nhiễu (30 frame/s)
    private float timer;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    private void Update()
    {
        // Dùng unscaledDeltaTime để nhiễu hạt vẫn chạy ngay cả khi game đang bị pause (Time.timeScale = 0)
        timer += Time.unscaledDeltaTime;

        if (timer >= 1f / fps)
        {
            timer = 0f;

            // Random tọa độ X, Y để trượt ảnh
            float randomX = Random.Range(0f, 1f);
            float randomY = Random.Range(0f, 1f);

            // Random lật ngược ảnh (gương) để tạo cảm giác các khung hình khác nhau hoàn toàn
            float scaleX = Random.value > 0.5f ? 1f : -1f;
            float scaleY = Random.value > 0.5f ? 1f : -1f;

            // Áp dụng độ lệch vào UI
            rawImage.uvRect = new Rect(randomX, randomY, scaleX, scaleY);
        }
    }
}