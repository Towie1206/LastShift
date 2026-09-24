# 🔦 Last Shift: Night Watch

<div align="center">

![Unity](https://img.shields.io/badge/Unity-6000.5.6f1-black?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Android-blue?style=for-the-badge)
![Version](https://img.shields.io/badge/Version-v0.0.2-orange?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**A 3D Psychological Survival Horror Game combining the surveillance tension of Five Nights at Freddy's with the anomaly hunting of Alternate Watch.**

[🎮 Chơi trên Itch.io](https://itch.io/your-game-link-here) • [📺 Xem Video Devlog (YouTube)](https://youtube.com/your-devlog-link-here) • [🎨 Figma UI/UX Design](https://www.figma.com/design/giXJAL6gsB4NRTOpyzeHKq/Last-Shift---UI-UX-Design-System?node-id=0-1&t=LNW2fttUkiR2wFor-1) • [📄 Báo Cáo BTL](BaoCao_BTL_LastShift.md)

</div>

---

## 📖 Giới thiệu tổng quan (About The Game)

**Last Shift** là một trò chơi kinh dị sinh tồn góc nhìn thứ nhất (3D Psychological Survival Horror) được phát triển trên engine **Unity 6**. Người chơi đảm nhận ca trực đêm cô độc từ **00:00 đến 06:00** tại một cơ sở an ninh bí ẩn. 

Game kết hợp hài hòa giữa 3 cơ chế kinh điển:
1. **Quản lý năng lượng & Phòng thủ văn phòng** (*Five Nights at Freddy's 1*): Cửa điện tử, đèn hành lang và nguồn điện hạn chế.
2. **Bảo trì & Sự cố thiết bị** (*Five Nights at Freddy's 3*): Khởi động lại hệ thống Camera, Đèn chiếu sáng và Thông gió (Ventilation). Hết oxy sẽ dẫn đến ngạt thở và ngất lịm!
3. **Theo dõi dị thường (Anomaly Hunting)** (*Alternate Watch by Tesseron*): Soi màn hình camera an ninh (CCTV), phát hiện và báo cáo các biến dạng không gian, vật thể xê dịch hoặc thực thể xâm nhập.

---

## 🕹️ Tính năng nổi bật (Key Features)

### 1. Hệ thống Điện & Quản lý Năng lượng (Power & Generator)
- Sử dụng kiến trúc đa hình `IPowerConsumer` quản lý mức tiêu thụ của Cửa và Đèn.
- Cạn kiệt điện năng sẽ kích hoạt chuỗi **Blackout Outage**: Toàn bộ đèn phụt tắt, cửa tự động mở toang và chuông nhạc tử thần vang lên trong bóng tối.

### 2. Trạm Bảo trì Thiết bị (Maintenance System)
- Quản lý 3 phân hệ cốt lõi: **Camera Devices**, **Lighting**, và **Ventilation (Air Cleaner)**.
- **Cơ chế Ngạt khí (Hypoxia/Suffocation):** Khi hệ thống thông gió hỏng, đồng hồ đếm ngược 60s sẽ kích hoạt. Mức oxy giảm dần khiến mắt người chơi díu lại, chớp đen dồn dập (Fade In/Out qua UI Image) trước khi lịm đi hoàn toàn dẫn đến Game Over.

### 3. Hệ thống Giám sát & Báo cáo Dị thường (CCTV Surveillance)
- Quan sát đa góc camera trong tòa nhà.
- Báo cáo sai lệch và bất thường theo thời gian thực để ngăn chặn các thế lực siêu nhiên xâm nhập.

### 4. Đa nền tảng mượt mà (PC & Mobile Android)
- **PC (Windows):** Điều khiển quay nhìn văn phòng bằng chuột, tương tác trực quan với các công tắc và thiết bị.
- **Android APK:** Hỗ trợ thao tác vuốt cảm ứng đa điểm (`Touchscreen.current`), giao diện co giãn thông minh thích ứng mọi tỉ lệ màn hình từ 16:9 đến 21:9 (`Canvas Scaler: Expand`).

---

## 🎮 Hướng dẫn điều khiển (Controls)

| Thao tác (Action) | PC (Windows) | Android (Mobile) |
| :--- | :--- | :--- |
| **Quan sát văn phòng (Look Around)** | Rê chuột trái / phải hoặc bấm nút A / D | Vuốt ngón tay (Swipe) sang Trái / Phải |
| **Tương tác (Interact)** | Click chuột trái vào Nút cửa, Đèn, Máy tính | Chạm (Tap) trực tiếp vào màn hình |
| **Mở Tablet CCTV** | Click nút mở Camera trên bàn | Chạm vào biểu tượng Camera |
| **Mở Máy tính Bảo trì** | Nhìn sang trái, click vào màn hình máy tính | Chạm vào màn hình máy tính bảo trì |
| **Thoát góc nhìn Camera/PC** | Click nút Exit / Phím `S` | Chạm vào nút Exit góc dưới màn hình |

---

## 🏗️ Kiến trúc Phần mềm & Thiết kế (Architecture & Patterns)

Dự án áp dụng chặt chẽ các nguyên lý **OOP** và triết lý thiết kế **SOLID**:

```
Assets/Script/
├── Core/               # Chu trình game, dịch chuyển góc nhìn, chuỗi mất điện
├── Manager/            # ShiftGameManager (Quản lý Win/Loss, ca trực)
├── Player/             # State Machine góc nhìn văn phòng, Touch Controls
├── Power & Generator/  # GeneratorSystem, IPowerConsumer, PowerOutageController
├── Maintenance/        # MaintenanceSystem, VentilationBreakdownEffect, Station
├── CCTV/               # Hệ thống camera an ninh, chuyển đổi màn hình
├── Anomaly/            # Trình tạo và quản lý sự kiện dị thường
├── Threats/            # Trí thông minh nhân tạo (AI) của Animatronic
├── Time/               # ShiftClock (Đồng hồ ca trực từ 00:00 -> 06:00)
└── UI/                 # Responsive Canvas Scaler, hiệu ứng mờ mắt, âm thanh
```

- **Single Responsibility (SRP):** Tách biệt rạch ròi giữa Logic dữ liệu (`MaintenanceSystem`), Hiệu ứng hiển thị (`VentilationBreakdownEffect`) và Luồng kết thúc ván chơi (`ShiftGameManager`).
- **Dependency Inversion (DIP) & Interface Segregation (ISP):** Cửa (`Door`) và Đèn (`LightControl`) giao tiếp với Trạm phát điện thông qua interface `IPowerConsumer`.
- **Finite State Machine (FSM):** Kiểm soát mượt mà các góc nhìn văn phòng của người chơi (`PlayerOfficeState`).
- **Observer Pattern:** Sử dụng C# Action/Events để truyền tin tức thời khi cúp điện, hỏng máy hoặc người chơi bị bắt.

---

## 📦 Cài đặt & Trải nghiệm (Installation)

### Chơi ngay bản Build:
1. **Bản PC (Windows):** Tải file `.zip` từ [Itch.io](https://itch.io/your-game-link-here), giải nén và chạy `LastShift.exe`.
2. **Bản Mobile (Android):** Tải file `LastShift_v0.0.2.apk` từ [Itch.io](https://itch.io/your-game-link-here), cho phép cài đặt ứng dụng từ nguồn không xác định và mở game.

### Chạy từ Mã nguồn (Unity Editor):
1. Clone kho lưu trữ về máy:
   ```bash
   git clone https://github.com/Towie1206/LastShift.git
   ```
2. Mở **Unity Hub** và chọn `Add project from disk`.
3. Chọn thư mục `LastShift` với phiên bản **Unity 6 (6000.5.6f1)** hoặc mới hơn.
4. Mở Scene chính tại: `Assets/Scenes/Game.unity`.
5. Bấm nút **Play** để bắt đầu trải nghiệm!

---

## 👥 Nhóm phát triển (Development Team)

Đồ án được thực hiện bởi nhóm sinh viên **Trường Đại học Công nghệ Đông Á (EAUT)**:

*   **Nguyễn Công Bằng** ([@Towie1206](https://github.com/Towie1206)) - *Lead Programmer & System Architect*
    - Xây dựng kiến trúc hệ thống, FSM Player, Maintenance System, Generator & Power.
*   **Nguyễn Trung Kiên** ([@KDotBlack](https://github.com/KDotBlack)) - *Gameplay & 3D Assets Programmer*
    - Tích hợp asset 3D môi trường, setup Cinemachine và tương tác văn phòng.
*   **Nguyễn Thành Nam** ([@LuoihaiDakin](https://github.com/LuoihaiDakin)) - *UI/UX & Audio Support*
    - Thiết kế UI Responsive, xử lý âm thanh môi trường và hỗ trợ kịch bản kiểm thử.

---

## 📜 Bản quyền & Lời cảm ơn (Credits & Acknowledgments)

- Trò chơi lấy cảm hứng sâu sắc từ các tác phẩm kinh điển:
  - **Five Nights at Freddy's** của Scott Cawthon.
  - **Alternate Watch** của Tesseron.
- Âm thanh và hiệu ứng tiếng động tham khảo từ kho tài nguyên mã nguồn mở của cộng đồng horror game.
- Mô hình 3D văn phòng và đạo cụ được cấp phép theo tiêu chuẩn Creative Commons từ Sketchfab (Chi tiết xem tại Mục 4.4 của [Báo cáo BTL](BaoCao_BTL_LastShift.md)).

---
<div align="center">
  <sub>Last Shift © 2026. Phát triển cho mục đích học thuật và nghiên cứu công nghệ game.</sub>
</div>
