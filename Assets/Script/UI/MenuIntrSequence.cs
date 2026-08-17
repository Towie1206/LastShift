using UnityEngine;
using System.Collections;

/// <summary>
/// MenuIntroSequence.cs
/// ----------------------
/// Chịu trách nhiệm duy nhất: chạy màn hình cảnh báo (Warning) kiểu FNAF lúc vừa mở Menu -
/// mờ dần hiện ra, giữ nguyên vài giây, mờ dần biến mất - sau đó mới "nhường sân khấu"
/// cho Menu chính.
///
/// LƯU Ý QUAN TRỌNG (khác với code gốc bạn có):
/// - KHÔNG tự load scene hay thoát game ở đây - 2 việc đó MainMenuActions.cs đã làm rồi,
///   viết lại sẽ bị trùng chức năng.
/// - KHÔNG tự SetActive() panel nào khác ngoài WarningPanel của chính nó - việc hiện
///   MainPanel được giao lại cho MenuPanelController.ShowMainPanel(), để chỉ có DUY NHẤT
///   1 nơi trong code chịu trách nhiệm bật/tắt panel, tránh 2 script cùng giành quyền
///   điều khiển 1 panel.
/// - storyPanel trong code gốc bạn gửi đang bị comment (chưa dùng tới) nên mình bỏ qua,
///   cần thì làm thêm sau.
/// </summary>
public class MenuIntroSequence : MonoBehaviour
{
    [Header("1. Panel cảnh báo (GameObject này phải có sẵn Canvas Group)")]
    [SerializeField] private CanvasGroup warningPanel;

    [Header("2. Kéo script MenuPanelController (đang gắn ở UIManager) vào đây")]
    // Sau khi Warning mờ dần biến mất, script này gọi ShowMainPanel() của
    // MenuPanelController để hiện Menu chính lên - không tự bật panel ở đây.
    [SerializeField] private MenuPanelController panelController;

    [Header("3. Hiệu ứng phụ khi Menu chính xuất hiện (không bắt buộc, để trống cũng chạy được)")]
    [SerializeField] private GameObject flickerFace;
    [SerializeField] private GameObject staticOverlay;
    [SerializeField] private AudioSource staticNoiseSource;
    [SerializeField] private AudioSource backgroundMusicSource;

    [Header("4. Thời gian cảnh báo (giây)")]
    [SerializeField] private float warningFadeDuration = 1.5f;
    [SerializeField] private float warningDisplayTime = 5f;

    /// <summary>
    /// Start() chạy 1 lần duy nhất khi scene Menu vừa mở lên.
    /// Đảm bảo mấy hiệu ứng phụ đang tắt hết, rồi mới bắt đầu chạy màn cảnh báo.
    /// </summary>
    private void Start()
    {
        if (staticOverlay != null) staticOverlay.SetActive(false);
        if (flickerFace != null) flickerFace.SetActive(false);

        if (warningPanel != null)
        {
            StartCoroutine(RunWarningSequence());
        }
    }

    /// <summary>
    /// Coroutine chạy toàn bộ trình tự: mờ dần hiện ra -> giữ nguyên -> mờ dần biến mất
    /// -> báo cho MenuPanelController hiện Menu chính lên.
    /// </summary>
    private IEnumerator RunWarningSequence()
    {
        // ----- MỜ DẦN HIỆN RA -----
        float t = 0f;
        while (t < warningFadeDuration)
        {
            t += Time.unscaledDeltaTime / warningFadeDuration;
            warningPanel.alpha = t;
            yield return null;
        }
        warningPanel.alpha = 1f;

        // ----- GIỮ NGUYÊN cho người chơi kịp đọc -----
        yield return new WaitForSeconds(warningDisplayTime);

        // ----- MỜ DẦN BIẾN MẤT -----
        t = 0f;
        while (t < warningFadeDuration)
        {
            t += Time.unscaledDeltaTime / warningFadeDuration;
            warningPanel.alpha = 1f - t;
            yield return null;
        }

        warningPanel.gameObject.SetActive(false);

        // ----- Giao việc hiện Menu chính lại cho MenuPanelController -----
        if (panelController != null)
        {
            panelController.ShowMainPanel();
        }

        // ----- Bật các hiệu ứng phụ (nếu có gắn) -----
        if (flickerFace != null) flickerFace.SetActive(true);
        if (staticOverlay != null) staticOverlay.SetActive(true);
        if (staticNoiseSource != null) staticNoiseSource.Play();
        if (backgroundMusicSource != null) backgroundMusicSource.Play();
    }
}