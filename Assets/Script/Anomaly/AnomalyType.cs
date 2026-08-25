using UnityEngine;

public enum AnomalyType 
{
    Electric, // Đèn/TV/radio nhiễu, máy bán nước mất đèn hoặc sáng bất thường
    Displacement, // Bàn, ghế, vật phẩm sai lệch vị trí; máy bán nước bị đổ
    Corpse, // Xuất hiện xác chết
    Mimic, // Sự xuất hiện vật thể, thừa hoặc thiếu
    Tulpa, // Những thứ chỉ xuất hiện trong gương
    Unknown, // Cửa/lối đi mở bất thường, hiện tượng kiến trúc khó giải thích
    Imagery, // Tranh/Poster thay đổi hình
    Flawed // Thực thể bất thường giả dạng Watcher
}
