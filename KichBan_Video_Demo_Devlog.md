# KỊCH BẢN CHI TIẾT VIDEO DEMO & DEVLOG (5 - 10 PHÚT)
## ĐỒ ÁN BÀI TẬP LỚN: TRÒ CHƠI KINH DỊ SINH TỒN "LAST SHIFT"
### HỌC PHẦN: LẬP TRÌNH ỨNG DỤNG DI ĐỘNG (MOBILE APPLICATION DEVELOPMENT)
### TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á (EAUT)

---

## 📌 HƯỚNG DẪN DÀNH CHO BẠN TRƯỚC KHI QUAY
- **Thời lượng mục tiêu:** Khoảng 6 đến 8 phút (nằm trọn vẹn trong khung 5–10 phút theo barem chấm điểm của Thầy).
- **Phần mềm quay màn hình:** OBS Studio hoặc phím tắt `Windows + Alt + R` (Xbox Game Bar).
- **Giọng đọc (Voice-over):** Đọc với phong thái tự tin, rõ ràng, chân thành của một lập trình viên sinh viên đam mê công nghệ phần mềm. Bạn có thể đọc trực tiếp khi quay hoặc quay video trước rồi lồng tiếng sau.

---

## ⏱️ PHÂN CẢNH VÀ LỜI THOẠI CHI TIẾT TỪNG PHÚT

### 🎬 PHẦN 1: MỞ ĐẦU & GIỚI THIỆU ĐỒ ÁN (0:00 – 1:00)
- **Hình ảnh trên màn hình (Visual):** 
  - Mở slide đầu tiên hoặc quay màn hình Menu chính của game `Last Shift` với hiệu ứng nhiễu Analog Horror huyền bí.
  - Hiện thông tin: Nhóm sinh viên thực hiện (Nguyễn Công Bằng - Trưởng nhóm, Nguyễn Trung Kiên, Nguyễn Thành Nam), MSSV, Lớp, Giảng viên hướng dẫn, Học phần: Lập trình ứng dụng di động, Trường ĐH Công nghệ Đông Á (EAUT), Kèm link GitHub: `https://github.com/Towie1206/LastShift` & Link Figma: `https://www.figma.com/design/giXJAL6gsB4NRTOpyzeHKq/Last-Shift---UI-UX-Design-System?node-id=0-1&t=LNW2fttUkiR2wFor-1`.
- **Lời thoại mẫu (Voice-over):**
  > *"Em xin kính chào Thầy và các bạn! Em tên là `Nguyễn Công Bằng`, đại diện nhóm sinh viên thực hiện đồ án, thuộc Viện Đào tạo và Hợp tác Quốc tế - Trường Đại học Công nghệ Đông Á.*
  > 
  > *Hôm nay, em xin phép được trình bày báo cáo và demo sản phẩm Bài tập lớn học phần **Lập trình ứng dụng di động** với đề tài: **Nghiên cứu, thiết kế và phát triển trò chơi kinh dị sinh tồn 'Last Shift' trên nền tảng Unity với kiến trúc hướng đối tượng (OOP), máy trạng thái hữu hạn (FSM) và khả năng tương thích đa nền tảng (PC & Android)**.*
  > 
  > *Dự án được nhóm em nghiên cứu và phát triển nghiêm túc với toàn bộ mã nguồn được quản trị công khai trên GitHub và hệ thống thiết kế giao diện UI/UX được phác thảo bài bản trên Figma. Trong video ngày hôm nay, em sẽ chia sẻ về hành trình phát triển (Devlog), trải nghiệm gameplay thực tế, các Case Studies kỹ thuật trong Unity Editor và quy trình xuất bản đa nền tảng của sản phẩm."*

---

### 🛠️ PHẦN 2: DEVLOG HÀNH TRÌNH PHÁT TRIỂN, FIGMA UI/UX & MINH CHỨNG GITHUB (1:00 – 3:00)
- **Hình ảnh trên màn hình (Visual):**
  - Mở trình duyệt vào trang GitHub: `https://github.com/Towie1206/LastShift` (mục **Insights -> Contributors** cho thấy gần 60 commits của 3 thành viên `Towie1206`, `KDotBlack`, `LuoihaiDakin`).
  - Chuyển sang tab Figma Design System: `https://www.figma.com/design/giXJAL6gsB4NRTOpyzeHKq/Last-Shift---UI-UX-Design-System?node-id=0-1&t=LNW2fttUkiR2wFor-1` lướt qua cụm 4 màn hình Wireframe/Mockup (Menu, CCTV, Báo cáo dị thường, Trạm bảo trì).
  - Mở Unity Editor: Lướt qua cấu trúc thư mục dự án (`Assets/Script`, `Scenes`, `Prefabs`, `Art`).
  - Mở một vài file script tiêu biểu trên Visual Studio Code như `ShiftGameManager.cs`, `WatcherBrain.cs`, `GeneratorSystem.cs`, `IPowerConsumer.cs`.
- **Lời thoại mẫu (Voice-over):**
  > *"Ý tưởng của 'Last Shift' bắt nguồn từ niềm đam mê với thể loại tâm lý kinh dị và analog horror. Về mặt tâm lý học người chơi, nhóm em đã nghiên cứu rất kỹ từ tư liệu phân tích chuyên sâu của kênh 'Game Cực Hay' với chủ đề 'Tại sao chúng ta thích chơi game kinh dị'. Dựa vào đó, nhóm đã áp dụng các cơ chế tâm lý cốt lõi: tạo ra nỗi sợ an toàn kích thích Adrenaline, tước đoạt vũ khí sát thương của người chơi, và đặt họ vào trạng thái áp lực đa nhiệm khi quản lý camera và nguồn điện buồng an ninh.*
  > 
  > *Toàn bộ quy trình phối hợp làm việc nhóm được quản lý bài bản qua GitHub với gần 60 commits qua 3 sprint: Em giữ vai trò Trưởng nhóm phụ trách toàn bộ kiến trúc lõi C#, FSM, hệ thống điện động và AI quái vật; bạn Nguyễn Trung Kiên phụ trách mô hình nhân vật 3D và giao diện PausePanel; bạn Nguyễn Thành Nam phụ trách Animation và hệ thống Đa ngôn ngữ Localization.*
  > 
  > *Vì đây là học phần **Lập trình ứng dụng di động**, nên ngay từ đầu kiến trúc của game đã được nhóm thiết kế theo mô hình **Đa nền tảng (Cross-Platform)**. Unity đóng vai trò là một Mobile Engine mạnh mẽ chạy trên nền tảng Android. Nhóm đã tối ưu hóa toàn bộ hệ thống UI Canvas theo chuẩn Safe Area của màn hình điện thoại, cấu hình định danh `com.Towie1012.LastShift`, Min SDK 26 và biên dịch IL2CPP ARM64.*
  > 
  > *Về mặt kỹ thuật, nhóm xin cam đoan **toàn bộ 100% mã nguồn C#, kiến trúc OOP, logic game và thuật toán AI quái vật đều do nhóm tự thiết kế và lập trình hoàn toàn, tuyệt đối không dùng AI viết code**. Công cụ Generative AI duy nhất chỉ được áp dụng làm phương tiện phụ trợ mỹ thuật để sinh một vài kết cấu texture bề mặt môi trường và ảnh bìa minh họa."*

---

### 🎮 PHẦN 3: TRẢI NGHIỆM GAMEPLAY THỰC TẾ (3:00 – 6:30)
*(Đây là phần hấp dẫn nhất của video, bạn mở bản game build ra chạy trực tiếp)*

#### Phân đoạn 3.1: Menu chính & Chế độ Story Mode (3:00 – 4:00)
- **Hình ảnh:** Bấm vào game, giao diện Menu hiện ra. Bấm **Story Mode**.
- **Lời thoại:**
  > *"Bây giờ, em xin mời Thầy cùng trải nghiệm gameplay thực tế của trò chơi. Ở Menu chính, người chơi có hai lựa chọn. Đầu tiên là **Story Mode** - chế độ cốt truyện đầy đủ. Nhân vật của chúng ta sẽ thức dậy trong phòng ngủ tại nhà, nghe chuông điện thoại từ người quản lý nhắc nhở đi làm, sau đó bước ra xe để đến khu xưởng an ninh."*

#### Phân đoạn 3.2: Chế độ Office Mode & Vòng lặp sinh tồn (4:00 – 5:30)
- **Hình ảnh:** Quay lại Menu, bấm nút **Office Mode** (chứng minh tính năng nhảy cóc vào thẳng văn phòng hoạt động trơn tru).
- **Thao tác trong game:**
  - Ngồi trong ghế bảo vệ, bấm `A` và `D` để lia đầu kiểm tra cửa trái, cửa phải.
  - Bật hệ thống Camera CCTV, chuyển qua các kênh Cam 01, Cam 02...
  - Xoay sang trạm máy phát điện, kiểm tra mức pin đang tụt dần, nhấn giữ `[E]` để sạc lại điện.
  - Mở trạm bảo trì (Maintenance System), chỉ cho người xem thấy các hệ thống Camera, Đèn, Quạt thông gió.
- **Lời thoại:**
  > *"Tiếp theo là **Office Mode** – tính năng giúp người chơi bỏ qua cốt truyện mở đầu để bước thẳng vào thử thách sinh tồn. 
  > 
  > Tại đây, em thiết kế góc nhìn bị giam hãm trong chiếc ghế xoay. Người chơi phải liên tục xử lý đa nhiệm: một mặt phải chuyển qua lại giữa các kênh camera giám sát để tìm dấu vết của quái vật Watcher, mặt khác phải để mắt đến đồng hồ pin của máy phát điện. Nếu không nhấn giữ nút sạc, máy phát sẽ cạn pin và toàn bộ hệ thống sẽ sập nguồn."*

#### Phân đoạn 3.3: Quái vật xuất hiện & Màn jumpscare kịch tính (5:30 – 6:30)
- **Hình ảnh:** Để cho quái vật Watcher tiếp cận hoặc để hết điện, đèn trong phòng phụt tắt, còi báo động hú lên, quái vật lao vào thực hiện cú jumpscare kinh điển, màn hình nhiễu hạt rồi hiện bảng Game Over.
- **Lời thoại:**
  > *"Và đây chính là lúc cao trào! Khi em lơ là không theo dõi hoặc để máy phát điện cạn kiệt, AI của Watcher sẽ đạt ngưỡng đe dọa tối đa và xông thẳng vào phòng an ninh. Một pha jumpscare bất ngờ diễn ra và trò chơi kết thúc. Người chơi có thể bấm 'Restart Shift' để lập tức bắt đầu lại ca trực một cách nhanh chóng."*

---

### 🧪 PHẦN 4: TRÌNH DIỄN NGHIÊN CỨU TÌNH HUỐNG (CASE STUDIES) & THAO TÁC TRONG UNITY (6:30 – 8:00)
- **Hình ảnh trên màn hình (Visual):**
  - Mở trực tiếp Unity Editor, thao tác qua các cửa sổ **Hierarchy**, **Scene View**, **Inspector** và **Project Settings**:
    1. *Thao tác 1 (Ánh sáng & Post-Processing):* Chọn GameObject đèn `Light_DeskArea` trên Hierarchy, chỉ vào Inspector các thông số `Intensity`, `Range`, và mở profile Post-Processing Volume với các override `Vignette`, `Film Grain`.
    2. *Thao tác 2 (Material & Pivot Cửa):* Mở thư mục `Assets/Art`, click vào Material tường/sàn cho thấy thiết lập `Tiling X: 1, Y: 1` chống đốm li ti, và click vào GameObject cánh cửa trượt cho thấy hai mốc tọa độ `Open Position` / `Closed Position` đã được căn chỉnh trục Pivot chuẩn xác.
    3. *Thao tác 3 (Inspector Serialization & Button Wiring):* Mở scene `Menu.unity`, chọn GameObject `MenuManager`, chỉ vào biến `Game Scene Name` đã được gán chuẩn xác là `"Game"` và giải thích ngắn gọn nguyên nhân sự cố click Office Mode load nhầm Home trước đây đã được giải quyết.
    4. *Thao tác 4 (Build Profiles & Player Settings):* Bật cửa sổ `Project Settings -> Player` cho thấy `Company Name: Towie1012`, `Product Name: LastShift` và icon mặt quái vật Freddy tùy biến.
    5. *Thao tác 5 (Cấu hình Android & Unity Device Simulator):* Bật tab Android trong Player Settings (`com.Towie1012.LastShift`, `ARM64`) và mở cửa sổ **Device Simulator** trong Unity chiếu thử giao diện game trên **Samsung Galaxy S10+** và **iPhone 13 Pro Max**.
- **Lời thoại mẫu (Voice-over):**
  > *"Để làm rõ hơn về quá trình phát triển sản phẩm, em xin phép trình bày **các Case Studies thực nghiệm và các thao tác kỹ thuật quan trọng nhất trong Unity Editor**:
  > 
  > *Đầu tiên là **Case Study về Ánh sáng buồng an ninh**: Trước đây, khi chỉ dùng một đèn lớn, phòng hoặc là bị lóa sáng hắt ra ngoài hành lang làm mất chất kinh dị, hoặc là quá tối khiến 4 góc nhìn của nhân viên trực không thấy gì. Em đã xử lý bằng cách phân rã thành cụm 3 đèn Point Light công suất nhỏ tại các vị trí bàn làm việc, máy phát và cửa trượt; kết hợp với hiệu ứng hậu kỳ Volume Post-Processing như Vignette làm tối 4 góc và Film Grain tạo hạt nhiễu analog.*
  > 
  > *Thứ hai là **Case Study về xử lý Material và Pivot cánh cửa**: Khi đưa texture môi trường vào, em đã tinh chỉnh lại thông số Tiling trên Inspector về đúng tỷ lệ 1x1 để triệt tiêu hiện tượng đốm li ti; đồng thời căn chỉnh lại điểm gốc tọa độ Pivot của cửa an ninh để cánh cửa trượt lên/xuống dứt khoát đúng hướng vật lý.*
  > 
  > *Đặc biệt, ở **Case Study chuyển cảnh Menu**: Nút bấm Office Mode từng bị lỗi nạp nhầm vào cảnh Home. Qua kiểm tra sâu vào cơ chế Serialization của Unity, em phát hiện biến `gameSceneName` trong file scene YAML bị lưu cứng giá trị cũ. Sau khi cập nhật lại trường này trong Inspector thành 'Game' và kết hợp với cờ tĩnh `startDirectlyInOffice`, hệ thống đã hoạt động hoàn hảo 100%.*
  > 
  > *Về mặt hiển thị đa màn hình: Do điều kiện nhóm chưa có sẵn máy thật Android để test thực tế, nhóm đã tận dụng công cụ **Unity Device Simulator** để giả lập kiểm thử trực tiếp trên **Samsung Galaxy S10+** và **iPhone 13 Pro Max**. Bằng cách chuyển đổi Canvas Scaler từ 'Match Width Or Height' sang chế độ **'Expand'**, toàn bộ giao diện UI từ đồng hồ, menu dị thường, thanh USAGE cho đến nút Recharge đều hiển thị đầy đủ 100%, không bị lẹm góc dù tỷ lệ điện thoại và PC hoàn toàn khác nhau.*
  > 
  > *Toàn bộ 24 kịch bản chức năng cốt lõi của trò chơi đều đã được nhóm em nghiệm thu đạt kết quả PASS tuyệt đối, đảm bảo tính ổn định cao nhất trước khi xuất xưởng."*

---

### 🚀 PHẦN 5: XUẤT BẢN THỰC TẾ TRÊN ITCH.IO & TỔNG KẾT (8:00 – 9:30)
- **Hình ảnh trên màn hình (Visual):**
  - Mở trình duyệt web truy cập thẳng vào trang game **Last Shift** trên Itch.io của bạn.
  - Kéo chuột cho thấy ảnh bìa, khẩu hiệu, mô tả chi tiết, link tải bản zip Windows x64.
  - Bấm vào tab **Devlogs** cho thấy bài viết cập nhật từ phiên bản `v0.0.1` lên `v0.0.2`.
- **Lời thoại mẫu (Voice-over):**
  > *"Cuối cùng, em xin tự hào giới thiệu sản phẩm đã được **đóng gói hoàn chỉnh và phát hành thực tế trên nền tảng Itch.io**. 
  > 
  > Trang game được thiết kế đầy đủ thông tin giới thiệu, hướng dẫn phím bấm, cảnh báo nhấp nháy đèn và lời nhắn chân thành dành cho cộng đồng người chơi ủng hộ đồ án sinh viên. Dự án cũng đã trải qua chu trình cập nhật từ phiên bản thử nghiệm `v0.0.1` lên bản hoàn thiện `v0.0.2`, sửa triệt để các lỗi logic chuyển cảnh và tối ưu hóa trải nghiệm ánh sáng.
  > 
  > Qua đồ án môn Lập trình ứng dụng di động lần này, em đã thu hoạch được những kinh nghiệm thực chiến vô cùng quý báu về tư duy lập trình kiến trúc hướng đối tượng trong Unity, kỹ năng quản lý dự án độc lập, tối ưu hóa phần cứng di động và quy trình phát hành một sản phẩm phần mềm thương mại từ đầu đến cuối.
  > 
  > Em xin chân thành cảm ơn Thầy đã luôn theo sát, định hướng và tạo điều kiện cho em hoàn thành đồ án này! Em rất mong nhận được những lời nhận xét, góp ý quý báu của Thầy để hoàn thiện hơn nữa trong tương lai. Em xin chân thành cảm ơn!"*

---

## 💡 MẸO GHI ĐIỂM TUYỆT ĐỐI (10/10) TRONG VIDEO:
1. **Âm lượng cân bằng:** Để tiếng game (tiếng máy phát điện, tiếng quái vật) nhỏ hơn tiếng giọng nói của bạn một chút để Thầy nghe rõ bạn thuyết minh.
2. **Hình ảnh sắc nét:** Xuất video ở độ phân giải tối thiểu 1080p (Full HD) để Thầy đọc rõ từng dòng code và giao diện Unity.
3. **Upload video:** Đăng video lên YouTube (chế độ Không công khai - *Unlisted* hoặc Công khai) hoặc Google Drive (nhớ bật quyền *"Bất kỳ ai có đường liên kết đều có thể xem"*), sau đó chèn đường link này vào trang bìa hoặc đầu trang Báo cáo nộp bài!
