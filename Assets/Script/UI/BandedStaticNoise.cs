using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// BandedStaticNoise.cs
/// -----------------------
/// Tạo hiệu ứng "nhiễu sọc" (banded noise) - từng dải ngang có độ dày ngẫu nhiên, mỗi
/// dải 1 màu xám riêng, y hệt tivi analog bị mất đồng bộ tín hiệu dọc (vertical sync).
///
/// KHÁC với RandomStaticNoise.cs (nhiễu hạt mịn, từng điểm ảnh random riêng lẻ nhìn như
/// hạt cát) - ở đây GOM NHIỀU HÀNG PIXEL LIỀN NHAU LẠI THÀNH 1 DẢI rồi mới tô chung 1
/// màu, tạo ra từng vệt sọc ngang rõ rệt thay vì hạt mịn.
///
/// Không cần ảnh có sẵn - script tự vẽ toàn bộ bằng code, giống cách RandomStaticNoise.cs
/// đã làm.
///
/// CÁCH DÙNG: gắn vào GameObject StaticOverlay (dùng Raw Image, giống RandomStaticNoise.cs)
/// - CHỈ DÙNG 1 SCRIPT NHIỄU tại 1 thời điểm trên object đó. Nếu đang có
/// RandomStaticNoise.cs hoặc StaticNoisePlayer.cs gắn sẵn, gỡ ra trước (3 chấm góc
/// component > Remove Component) rồi mới gắn script này vào.
/// </summary>
[RequireComponent(typeof(RawImage))]
public class BandedStaticNoise : MonoBehaviour
{
    [Header("Kéo chính component Raw Image của GameObject này vào đây")]
    [SerializeField] private RawImage noiseDisplay;

    [Header("Chiều rộng tấm nhiễu (để nhỏ vì mỗi dải là 1 màu đồng nhất theo chiều ngang)")]
    [SerializeField] private int textureWidth = 4;

    [Header("Chiều cao tấm nhiễu (số hàng pixel - càng cao càng chia được nhiều dải chi tiết)")]
    [SerializeField] private int textureHeight = 128;

    [Header("Độ dày mỗi dải sọc (số hàng pixel, chọn ngẫu nhiên trong khoảng này)")]
    [SerializeField] private int minBandHeight = 2;
    [SerializeField] private int maxBandHeight = 12;

    [Header("Bao lâu vẽ lại toàn bộ dải sọc mới (giây)")]
    [SerializeField] private float updateInterval = 0.06f;

    [Header("Độ sáng tối thiểu / tối đa của mỗi dải (0 = đen, 1 = trắng)")]
    [SerializeField] [Range(0f, 1f)] private float minBrightness = 0f;
    [SerializeField] [Range(0f, 1f)] private float maxBrightness = 1f;

    // Tấm texture được tạo ra ngay trong code lúc chạy, không cần ảnh có sẵn nào.
    private Texture2D noiseTexture;

    // Mảng chứa màu từng điểm ảnh, tái sử dụng lại mỗi lần để đỡ tốn bộ nhớ.
    private Color32[] pixelBuffer;

    private void Awake()
    {
        if (noiseDisplay == null)
        {
            noiseDisplay = GetComponent<RawImage>();
        }

        noiseTexture = new Texture2D(textureWidth, textureHeight);

        // FilterMode.Point: giữ cạnh sọc sắc nét, vuông vức, không bị làm mờ nhoè.
        noiseTexture.filterMode = FilterMode.Point;

        noiseDisplay.texture = noiseTexture;

        pixelBuffer = new Color32[textureWidth * textureHeight];
    }

    private void OnEnable()
    {
        StartCoroutine(BandLoop());
    }

    private IEnumerator BandLoop()
    {
        while (true)
        {
            RedrawBands();
            yield return new WaitForSeconds(updateInterval);
        }
    }

    /// <summary>
    /// Vẽ lại toàn bộ tấm nhiễu THEO TỪNG DẢI: đi từ hàng pixel trên cùng xuống dưới,
    /// mỗi lần "cắt" ra 1 dải dày ngẫu nhiên (từ minBandHeight tới maxBandHeight hàng),
    /// tô NGUYÊN dải đó cùng 1 màu xám ngẫu nhiên, rồi tiếp tục với dải kế tiếp bên dưới.
    /// Đây chính là điểm khác biệt tạo ra "sọc" thay vì "hạt nhiễu mịn" như trước.
    /// </summary>
    private void RedrawBands()
    {
        int row = 0;
        while (row < textureHeight)
        {
            // Chọn độ dày ngẫu nhiên cho dải này, không để tràn quá phần còn lại.
            int bandHeight = Random.Range(minBandHeight, maxBandHeight + 1);
            bandHeight = Mathf.Min(bandHeight, textureHeight - row);

            // Chọn 1 màu xám DUY NHẤT dùng chung cho cả dải này.
            float gray = Random.Range(minBrightness, maxBrightness);
            byte grayByte = (byte)(gray * 255f);
            Color32 bandColor = new Color32(grayByte, grayByte, grayByte, 255);

            // Tô toàn bộ các hàng pixel thuộc dải này bằng đúng 1 màu vừa chọn.
            for (int r = 0; r < bandHeight; r++)
            {
                int actualRow = row + r;
                int rowStartIndex = actualRow * textureWidth;
                for (int col = 0; col < textureWidth; col++)
                {
                    pixelBuffer[rowStartIndex + col] = bandColor;
                }
            }

            row += bandHeight;
        }

        // Đẩy toàn bộ mảng màu vừa vẽ vào texture, Apply() để Unity cập nhật hình hiển thị.
        noiseTexture.SetPixels32(pixelBuffer);
        noiseTexture.Apply();
    }
}
