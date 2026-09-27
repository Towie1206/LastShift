using UnityEngine;

public static class MobileDeviceOptimizer
{
    // [RuntimeInitializeOnLoadMethod] giúp hàm này TỰ ĐỘNG CHẠY trước khi bất kỳ Scene nào load!
    // Không cần tạo GameObject, không cần kéo thả vào Scene!
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        // 1. ÉP XOAY NGANG MÀN HÌNH (Chỉ cho phép xoay ngang trái / phải)
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.AutoRotation;

        // 2. MỞ KHÓA 60 FPS (Bỏ giới hạn 30 FPS mặc định của Unity)
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0; // Tắt VSync để targetFrameRate có hiệu lực

        // 3. ĐIỀU CHỈNH ĐỘ PHÂN GIẢI TRÊN MOBILE (Tăng mượt mà 30-40%)
#if UNITY_ANDROID && !UNITY_EDITOR
        // Giữ tỉ lệ màn hình nhưng giới hạn chiều cao tối đa khoảng 720p - 1080p chuẩn
        // Tránh tình trạng màn hình 2K/4K làm sập GPU
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
        if (screenHeight > 1080)
        {
            float scale = 1080f / screenHeight;
            Screen.SetResolution((int)(screenWidth * scale), 1080, true);
        }
#endif
    }
}