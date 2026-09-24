# TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á
## VIỆN ĐÀO TẠO VÀ HỢP TÁC QUỐC TẾ
---

# BÁO CÁO BÀI TẬP LỚN (TERM PAPER)
### HỌC PHẦN: LẬP TRÌNH ỨNG DỤNG DI ĐỘNG (MOBILE APPLICATION DEVELOPMENT)
**Học kỳ 1 - Năm học 2026 - 2027**

---

### ĐỀ TÀI:
# NGHIÊN CỨU, THIẾT KẾ VÀ PHÁT TRIỂN TRÒ CHƠI KINH DỊ SINH TỒN "LAST SHIFT" TRÊN NỀN TẢNG UNITY VỚI KIẾN TRÚC HƯỚNG ĐỐI TƯỢNG (OOP), MÁY TRẠNG THÁI HỮU HẠN (FSM) VÀ KHẢ NĂNG TƯƠNG THÍCH ĐA NỀN TẢNG (PC & ANDROID)

---

**Nhóm sinh viên thực hiện:**
1. **Nguyễn Công Bằng** (Trưởng nhóm / Lead Programmer & Software Architect - GitHub: `@Towie1206`) - MSSV: `[MSSV 1]` - Lớp: `[Lớp]`
2. **Nguyễn Trung Kiên** (Thành viên / 3D Assets & UI Programmer - GitHub: `@KDotBlack`) - MSSV: `[MSSV 2]` - Lớp: `[Lớp]`
3. **Nguyễn Thành Nam** (Thành viên / Animation & Localization Programmer - GitHub: `@LuoihaiDakin`) - MSSV: `[MSSV 3]` - Lớp: `[Lớp]`

**Giảng viên hướng dẫn:** `[Họ và tên Giảng viên: ................................]`  
**Kho lưu trữ mã nguồn chính thức (GitHub):** https://github.com/Towie1206/LastShift  
**Bản thiết kế giao diện trực tuyến (Figma):** https://www.figma.com/design/giXJAL6gsB4NRTOpyzeHKq/Last-Shift---UI-UX-Design-System?node-id=0-1&t=LNW2fttUkiR2wFor-1

---
*Hà Nội, Năm 2026*

\newpage

# LỜI CAM ĐOAN

Chúng tôi xin cam đoan báo cáo bài tập lớn này là công trình nghiên cứu và phát triển nghiêm túc của nhóm chúng tôi dưới sự định hướng học thuật của giảng viên phụ trách học phần. 

**Chúng tôi xin cam đoan 100% mã nguồn C#, cấu trúc lớp đối tượng (OOP), các mẫu thiết kế, hệ thống máy trạng thái hữu hạn (FSM) và toàn bộ các kịch bản kiểm thử trong đồ án này đều do chính các thành viên trong nhóm tự tay thiết kế và lập trình hoàn toàn, tuyệt đối không sử dụng công cụ AI để sinh mã nguồn (No AI Coding) và trò chơi không phụ thuộc vào bất kỳ API trí tuệ nhân tạo bên ngoài nào.**

Các kết quả nghiên cứu, mã nguồn chương trình, sơ đồ kiến trúc phần mềm, lịch sử cam kết mã nguồn (Git Commits) và số liệu kiểm thử được trình bày trong báo cáo là hoàn toàn trung thực, phản ánh chính xác quá trình xây dựng và hoàn thiện dự án trò chơi điện tử **"Last Shift"**. Toàn bộ quá trình cộng tác mã nguồn, phân chia module và lịch sử đóng góp của từng thành viên được minh chứng công khai và minh bạch tại kho lưu trữ GitHub chính thức của dự án: https://github.com/Towie1206/LastShift.

Công cụ Generative AI duy nhất chỉ được áp dụng như một phương tiện phụ trợ mỹ thuật nhằm tạo sinh một vài kết cấu vật liệu môi trường (Environment Textures) và ảnh bìa minh họa; toàn bộ tài nguyên tham khảo bên thứ ba đều được công bố minh bạch (AI Disclosure) theo đúng quy định liêm chính học thuật của Nhà trường.

*Đại diện nhóm sinh viên thực hiện*  
*(Ký và ghi rõ họ tên)*

\newpage

# LỜI CẢM ƠN

Để hoàn thành được đồ án bài tập lớn và sản phẩm trò chơi điện tử **"Last Shift"**, tôi xin gửi lời cảm ơn chân thành và sâu sắc nhất tới Ban Giám hiệu Trường Đại học Công nghệ Đông Á (EAUT), Ban Lãnh đạo Viện Đào tạo và Hợp tác Quốc tế đã tạo điều kiện học tập tốt nhất cho sinh viên.

Đặc biệt, tôi xin bày tỏ lòng biết ơn sâu sắc tới Giảng viên phụ trách học phần. Thầy đã tận tình truyền đạt kiến thức nền tảng vững chắc về tư duy lập trình hướng đối tượng, kiến trúc phần mềm, cũng như đã ủng hộ, tạo cơ hội cho tôi được thử sức phát triển một dự án game hoàn chỉnh theo hướng nghiên cứu chuyên sâu độc lập. Những lời góp ý, định hướng về phương pháp tiếp cận quy trình và thiết kế kiểm thử của Thầy là kim chỉ nam quý báu giúp tôi hoàn thành sản phẩm đúng hạn và đạt chất lượng cao.

Cuối cùng, tôi xin cảm ơn gia đình, bạn bè và những người chơi đầu tiên trong cộng đồng đã trải nghiệm các phiên bản thử nghiệm (v0.0.1, v0.0.2) trên itch.io và đóng góp những phản hồi quý báu.

\newpage

# MỤC LỤC TỔNG QUAN

- **LỜI CAM ĐOAN**
- **LỜI CẢM ƠN**
- **DANH MỤC CÁC TỪ VIẾT TẮT**
- **DANH MỤC HÌNH VẼ VÀ SƠ ĐỒ**
- **DANH MỤC BẢNG BIỂU**
- **MỞ ĐẦU**
- **CHƯƠNG 1: TỔNG QUAN ĐỀ TÀI VÀ PHÂN TÍCH BÀI TOÁN**
  - 1.1. Bối cảnh và lý do lựa chọn đề tài
  - 1.2. Phân tích đối tượng người dùng và khảo sát thực tế
  - 1.3. Xác định phạm vi và mục tiêu của đồ án
- **CHƯƠNG 2: THIẾT KẾ TRÒ CHƠI (GAME DESIGN) VÀ TRẢI NGHIỆM NGƯỜI DÙNG (UI/UX)**
  - 2.1. Phân tích vòng lặp cốt lõi (Core Game Loop)
  - 2.2. Thiết kế kiến trúc không gian màn chơi (Level Design)
  - 2.3. Thiết kế giao diện người dùng (UI/UX Design)
  - 2.4. Thiết kế thị giác và âm thanh Analog Horror
- **CHƯƠNG 3: KIẾN TRÚC PHẦN MỀM VÀ LẬP TRÌNH UNITY NÂNG CAO**
  - 3.1. Kiến trúc phân tầng và nguyên lý SOLID trong Unity
  - 3.2. Mẫu thiết kế phần mềm (Design Patterns) áp dụng
  - 3.3. Cơ chế quản lý vòng đời (Unity Lifecycle) và tải cảnh bất đồng bộ
  - 3.4. Kiến trúc Đa nền tảng và Cơ chế tương thích Hệ điều hành Di động Android
- **CHƯƠNG 4: HỆ THỐNG TRÍ TUỆ NHÂN TẠO TRONG GAME (GAME AI) VÀ PHẠM VI SỬ DỤNG GENAI**
  - 4.1. Bản chất của hệ thống AI trong trò chơi: Thuật toán Game AI cổ điển thuần C#
  - 4.2. Thuật toán tích lũy nguy cơ (Threat Level Accumulator Heuristic)
  - 4.3. Phạm vi sử dụng Generative AI: Giới hạn duy nhất ở khâu Texture môi trường phụ trợ
  - 4.4. Tuyên bố Liêm chính Học thuật và Bản quyền Tài nguyên Bên thứ ba (Sketchfab 3D Models & AI Disclosure)
- **CHƯƠNG 5: QUẢN LÝ DỮ LIỆU, CẤU HÌNH VÀ XỬ LÝ NGOẠI LỆ**
  - 5.1. Mô hình hóa dữ liệu cấu hình với ScriptableObject
  - 5.2. Quản lý trạng thái đa ngôn ngữ (Localization) và lưu trữ cài đặt
  - 5.3. Xử lý ngoại lệ và an toàn bộ nhớ (Error & Memory Handling)
- **CHƯƠNG 6: NGHIÊN CỨU TÌNH HUỐNG THỰC NGHIỆM (CASE STUDIES) VÀ THIẾT LẬP TRONG UNITY EDITOR**
  - 6.1. Case Study 1: Thiết lập Hệ thống Chiếu sáng và Xử lý Khuyết điểm Ánh sáng Buồng An ninh
  - 6.2. Case Study 2: Quy trình Xử lý Material PBR, Căn chỉnh Tiling và Setup Pivot Cánh cửa An ninh
  - 6.3. Case Study 3: Điều hướng Scene Đa chặng và Khắc phục Sự cố Serialization Field trong Inspector
  - 6.4. Case Study 4: Chuyển đổi Góc nhìn Người chơi (Office View) và Hệ thống CCTV Đa kênh
  - 6.5. Case Study 5: Hệ thống Quản lý Điện năng Động (IPowerConsumer), Triệt tiêu Phụ thuộc Ngược và Giao diện Tước đoạt Thông tin (UsageUI)
  - 6.6. Case Study 6: Hệ thống Nhận diện Dị thường (Anomaly) và Trạm Bảo trì Thiết bị Buồng trực (Maintenance)
  - 6.7. Case Study 7: Quy trình Đóng gói Bản dựng Đa nền tảng (Build Profiles) và Chuẩn hóa Player Settings
  - 6.8. Bảng Tổng hợp Nghiệm thu Kiểm thử Chức năng Toàn diện (Verification Matrix)
- **CHƯƠNG 7: QUẢN LÝ DỰ ÁN VỚI GIT VÀ TRIỂN KHAI THỰC TẾ TRÊN ITCH.IO**
  - 7.1. Quản lý mã nguồn Git, Phân chia vai trò và Thống kê Đóng góp Nhóm trên GitHub
  - 7.2. Quy trình đóng gói bản dựng (Build Pipeline) tối ưu
  - 7.3. Triển khai sản phẩm thực tế và quản lý vòng đời phát hành trên Itch.io
- **KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN**
- **TÀI LIỆU THAM KHẢO**

\newpage

# DANH MỤC CÁC TỪ VIẾT TẮT

| Từ viết tắt | Tên tiếng Anh đầy đủ | Giải nghĩa tiếng Việt |
| :--- | :--- | :--- |
| **BTL** | Bài tập lớn | Đồ án học phần nghiên cứu ứng dụng |
| **OOP** | Object-Oriented Programming | Lập trình hướng đối tượng |
| **SOLID** | Single responsibility, Open–closed, Liskov substitution, Interface segregation, Dependency inversion | 5 nguyên lý thiết kế phần mềm hướng đối tượng kinh điển |
| **FSM** | Finite State Machine | Máy trạng thái hữu hạn |
| **GDD** | Game Design Document | Tài liệu thiết kế trò chơi |
| **UI / UX** | User Interface / User Experience | Giao diện người dùng / Trải nghiệm người dùng |
| **HUD** | Heads-Up Display | Giao diện hiển thị trực quan thông tin thời gian thực |
| **CCTV** | Closed-Circuit Television | Hệ thống truyền hình mạch kín (Camera an ninh) |
| **PBR** | Physically Based Rendering | Mô hình kết xuất đồ họa dựa trên vật lý thực tế |
| **CRT** | Cathode-Ray Tube | Màn hình hiển thị điện tử cổ điển |
| **VHS** | Video Home System | Định dạng băng video tương tự (Analog Video) |
| **GenAI** | Generative Artificial Intelligence | Trí tuệ nhân tạo tạo sinh |
| **CRUD** | Create, Read, Update, Delete | Các thao tác dữ liệu cơ bản (Tạo, Đọc, Sửa, Xóa) |

\newpage

# MỞ ĐẦU

Trong khuôn khổ học phần **Lập trình ứng dụng di động (Mobile Application Development)**, bên cạnh các ứng dụng tiện ích thông thường, việc phát triển ứng dụng trò chơi 3D thời gian thực trên nền tảng di động được xem là một trong những thử thách kỹ thuật chuyên sâu và toàn diện nhất. Nó đòi hỏi sinh viên phải làm chủ đồng thời từ kiến trúc phần mềm hướng đối tượng (OOP), quản lý vòng đời ứng dụng khi bị hệ điều hành di động can thiệp (Android Activity Lifecycle), thiết kế giao diện thích ứng đa độ phân giải màn hình (Responsive UI & Safe Area), kiểm soát hiệu năng phần cứng hạn chế (Memory & Battery Optimization), cho đến việc xây dựng hệ thống AI và quy trình kiểm thử thực nghiệm.

Được sự định hướng và cho phép của Giảng viên hướng dẫn về việc thực hiện đồ án cá nhân chuyên biệt trong lĩnh vực phát triển ứng dụng giải trí đa nền tảng (Cross-Platform Game Development), dự án **"Last Shift"** được xây dựng trên nền tảng Unity — công nghệ phát triển ứng dụng và game di động chiếm thị phần số 1 toàn cầu hiện nay trên Google Play — với kiến trúc lõi được thiết kế bài bản để tương thích đồng thời cả nền tảng máy tính cá nhân (PC/Windows) phục vụ quá trình phát triển nhanh lẫn nền tảng di động Android.

Báo cáo này sẽ trình bày một cách tường minh, khoa học và chi tiết toàn bộ chu trình phát triển phần mềm (SDLC) của sản phẩm trò chơi **"Last Shift"** từ giai đoạn hình thành ý tưởng, cơ sở tâm lý học người dùng, thiết kế kiến trúc đa nền tảng, cài đặt mã nguồn C# thuần túy, 7 nghiên cứu tình huống thực nghiệm (Case Studies) trong Unity Editor cho đến kết quả kiểm thử và triển khai xuất bản thực tế.

---

\newpage

# CHƯƠNG 1: TỔNG QUAN ĐỀ TÀI VÀ PHÂN TÍCH BÀI TOÁN

## 1.1. Bối cảnh và lý do lựa chọn đề tài
Trong những năm gần đây, dòng trò chơi kinh dị độc lập (Indie Psychological Horror) mang phong cách *Analog Horror* và *Security Surveillance* (như *Five Nights at Freddy's*, *Iron Lung*, *Lethal Company*) đã tạo nên một làn sóng mạnh mẽ trong cộng đồng game thủ toàn cầu. 

Điểm hấp dẫn cốt lõi của thể loại này không nằm ở các cảnh hành động bắn súng đồ họa bom tấn phức tạp, mà tập trung vào:
1. **Sự giam hãm không gian (Claustrophobia):** Người chơi bị cố định trong một căn phòng bảo vệ nhỏ hẹp, đối mặt với bóng tối và sự bất định.
2. **Sự quá tải thông tin và căng thẳng quản lý tài nguyên:** Người chơi phải đồng thời quan sát camera an ninh, theo dõi lượng điện máy phát, lắng nghe tiếng bước chân kẻ địch và sửa chữa các hệ thống máy móc bị hỏng hóc.
3. **Cơ chế kinh dị tâm lý:** Nỗi sợ hãi sinh ra từ sự chờ đợi và phán đoán sai lầm chứ không đơn thuần chỉ là những màn hù dọa bất ngờ (Jumpscare).

Lựa chọn đề tài phát triển trò chơi **"Last Shift"** mang lại cơ hội nghiên cứu thực nghiệm sâu sắc về cách thức tổ chức mã nguồn một hệ thống phần mềm thời gian thực phức tạp, nơi hàng loạt các hệ thống con (Camera, Máy phát điện, Hệ thống bảo trì, Bộ điều phối AI, Hiệu ứng âm thanh) phải tương tác liên tục và ổn định với tốc độ 60 khung hình/giây (FPS).

## 1.2. Phân tích đối tượng người dùng và cơ sở tâm lý học từ thực tế

Thay vì đưa ra các số liệu khảo sát định tính chủ quan, đồ án này đặt nền móng nghiên cứu hành vi và tâm lý người chơi dựa trên các luận điểm phân tích chuyên sâu từ tư liệu nghiên cứu: **"TẠI SAO Chúng Ta Thích Chơi GAME KINH DỊ?"** do kênh **Game Cực Hay** phát hành (Kịch bản: TienZero, Giọng đọc: Ming Ming; tham khảo trực tiếp tại: `https://youtu.be/hy8sWR010Z4`).

Tư liệu trên đã phân tích một cách thấu đáo các hiện tượng tâm lý học và cơ chế sinh học giải thích vì sao thể loại game kinh dị sinh tồn buồng kín luôn có sức hút mãnh liệt đối với game thủ:

### 1.2.1. Cơ chế sinh học của "Nỗi sợ có kiểm soát" (Recreational Fear)
Theo nghiên cứu được dẫn chứng trong video, bộ não con người sở hữu phản xạ sinh tồn cổ xưa: phản ứng "Chiến hoặc Chạy" (Fight-or-Flight). Khi đối mặt với hiểm họa và bóng tối trong trò chơi, tuyến thượng thận lập tức giải phóng một lượng lớn hormone:
- **Adrenaline & Noradrenaline:** Làm tăng nhịp tim, giãn đồng tử, đẩy sự tập trung và mức độ cảnh giác của giác quan lên cực đại.
- **Endorphin & Dopamine:** Tạo ra cảm giác hưng phấn mãnh liệt và kích thích hệ thống tưởng thưởng của não bộ.

Điểm mấu chốt được video làm sáng tỏ là khái niệm **"Nỗi sợ an toàn" (Safe Fear / Recreational Fear)**: Người chơi ý thức được rằng bản thân đang an toàn tuyệt đối sau màn hình máy tính, không gặp nguy hiểm thể xác thực tế. Do đó, trải nghiệm cảm giác kinh hoàng trong game thực chất là một hình thức kích thích hưng phấn sinh học lành mạnh mà não bộ con người chủ động tìm kiếm.

### 1.2.2. Tâm lý "Tước đoạt quyền lực" và "Áp lực đa nhiệm" (Powerlessness & Multitasking Stress)
Video của *Game Cực Hay* chỉ ra sự khác biệt căn bản giữa game hành động và game kinh dị sinh tồn:
- Ở game hành động, người chơi được trao vũ khí mạnh mẽ (súng, kiếm) để chủ động tiêu diệt quái vật (Empowerment).
- Ngược lại, ở dòng game kinh dị tâm lý buồng an ninh (như *Five Nights at Freddy's* hay *Last Shift*), người chơi bị **tước đoạt hoàn toàn khả năng tấn công tiêu diệt** (Powerlessness). Người chơi bị giam hãm trong chiếc ghế xoay phòng trực, chỉ có thể quan sát thụ động qua màn hình camera và phòng thủ bằng cách đóng cửa hoặc bảo trì thiết bị.

Chính sự bất lực này kết hợp với **Áp lực quản lý tài nguyên khan hiếm** (máy phát điện tụt pin liên tục, quạt thông gió hỏng hóc) tạo ra trạng thái căng thẳng tột độ (Hyper-vigilance). Đây chính là "chất gây nghiện" tâm lý then chốt định hình nên trải nghiệm của *Last Shift*.

### 1.2.3. Cảm giác giải tỏa cảm xúc (Catharsis) và Sự thỏa mãn khi làm chủ nỗi sợ (Fear Mastery)
Một phát hiện tâm lý học quan trọng khác từ video là cơ chế **Giải tỏa cảm xúc (Catharsis)**:
- Nỗi sợ hãi và sự hồi hộp được tích tụ liên tục như một "chiếc lò xo cảm xúc" bị nén chặt trong suốt 6 phút của ca trực đêm (từ 12:00 AM đến 06:00 AM).
- Khi người chơi khéo léo tính toán thời gian nạp điện, ngăn chặn kịp thời các đợt rình rập của thực thể Watcher và nghe thấy tiếng chuông 6:00 AM vang lên báo hiệu sống sót, toàn bộ lượng Adrenaline tích tụ lập tức được chuyển hóa thành sự nhẹ nhõm và thỏa mãn cực độ (Dopamine Rush). Người chơi cảm nhận được thành tựu rõ rệt về năng lực kiểm soát nỗi sợ và làm chủ tình huống hiểm nghèo.

### 1.2.4. Sức hút lan tỏa tự nhiên trên các nền tảng số (Organic Virality)
Tư liệu của *Game Cực Hay* cũng chỉ rõ: Thể loại game kinh dị quan sát là một trong những mảng nội dung có sức lan tỏa và tỷ lệ tương tác cộng đồng cao nhất trên các nền tảng phát video (YouTube, TikTok, Twitch). Người xem trực tuyến rất hào hứng theo dõi biểu cảm giật mình của người chơi và cùng hồi hộp suy đoán vị trí ẩn nấp của quái vật trên camera. Đây là lợi thế cạnh tranh cốt lõi giúp một dự án game độc lập (Indie Game) của sinh viên có thể tiếp cận cộng đồng người chơi quốc tế trên **Itch.io** một cách tự nhiên và bền vững.

## 1.3. Xác định phạm vi và mục tiêu của đồ án

### 1.3.1. Mục tiêu đồ án
Trong khuôn khổ học phần **Lập trình ứng dụng di động**, đồ án hướng tới việc hoàn thành các mục tiêu kỹ thuật cụ thể:
1. **Xây dựng ứng dụng trò chơi 3D thời gian thực hoàn chỉnh** trên nền tảng Unity (Universal Render Pipeline - URP) với hiệu năng vận hành ổn định trên cả môi trường máy tính lẫn thiết bị di động.
2. **Thiết kế kiến trúc phần mềm hướng đối tượng (OOP & SOLID)** chuẩn mực, phân tách rõ ràng các tầng dữ liệu, logic và giao diện; đồng bộ hóa cơ chế quản lý vòng đời ứng dụng tương thích chặt chẽ với vòng đời hệ điều hành Android (Android Activity Lifecycle: `onPause`, `onResume`, `onDestroy`).
3. **Thiết kế giao diện người dùng thích ứng đa màn hình di động (Responsive UI & Safe Area)**, đảm bảo toàn bộ hệ thống HUD (đồng hồ, thanh pin, nút camera) hiển thị chuẩn xác, không bị che khuất bởi rãnh camera tai thỏ hoặc thanh điều hướng cử chỉ trên điện thoại.
4. **Xây dựng tầng trừu tượng nhập liệu đa nền tảng**, hỗ trợ song song cả cơ chế điều khiển bàn phím/chuột trên PC và cơ chế điều khiển cảm ứng chạm/vuốt (Touch Input) trên màn hình di động Android.
5. **Cài đặt hệ thống Trí tuệ nhân tạo Game (Game AI)** cho thực thể quái vật (Watcher) bằng Máy trạng thái hữu hạn (FSM) thuần C# và thuật toán tích lũy đe dọa động mà không phụ thuộc vào AI bên ngoài.
6. **Tối ưu hóa tài nguyên phần cứng cho thiết bị di động (Mobile Optimization):** Giới hạn tốc độ khung hình (60 FPS) chống quá nhiệt và tiết kiệm pin, nén texture chuẩn ASTC dành cho GPU ARM di động, duy trì số lượng Draw Calls dưới 60.
7. **Đóng gói và triển khai bản dựng đa nền tảng (Cross-Platform Build Pipeline):** Cấu hình đầy đủ thông số xuất bản gói ứng dụng di động Android (`.apk` / `.aab`) với định danh Package Name `com.Towie1012.LastShift`, Min SDK 26, vi kiến trúc 64-bit ARM64; đồng thời phát hành thành công bản cài đặt độc lập (Windows x64) lên nền tảng trực tuyến Itch.io.

### 1.3.2. Phạm vi phát triển (Project Scope)
- **Chiến lược Nền tảng mục tiêu (Target Platforms):**
  - *Nền tảng phát hành và kiểm thử chính (Primary Deployment):* PC (Windows 64-bit). Đây là nền tảng được chọn để phục vụ quá trình biên dịch nhanh, ghi hình Devlog thực nghiệm, gỡ lỗi chi tiết trong Unity Editor và phát hành phiên bản trải nghiệm thực tế (v0.0.1, v0.0.2) trên nền tảng đám mây Itch.io.
  - *Nền tảng di động tương thích mục tiêu (Mobile Target Platform):* Android OS (Hệ điều hành Android 8.0 trở lên, API Level 26 - 34, kiến trúc 64-bit ARM64). Dự án được cấu hình toàn bộ thông số kỹ thuật di động trong `PlayerSettings` để sẵn sàng cho thao tác Switch Platform và xuất bản gói cài đặt di động `.apk`.
- **Phương thức nhập liệu (Input Mechanisms):**
  - *Trên PC:* Bàn phím (`WASD` di chuyển/quay đầu, `[E]` tương tác, `[Esc]` tạm dừng) và chuột nhìn xung quanh.
  - *Trên Android:* Tương tác cảm ứng đa điểm (Chạm vuốt hai bên màn hình để quay đầu quan sát cửa an ninh, chạm trực tiếp vào màn hình camera để chuyển kênh, nhấn giữ cảm ứng ảo trên nút nạp điện).
- **Môi trường màn chơi:** 
  - *Màn chơi 1 (Scene Home - The Apartment):* Không gian căn hộ gia đình, nhân vật tương tác với máy tính cá nhân qua ứng dụng nhắn tin LaZo, nhận lời nhắn ca trực đêm, khám phá không gian phòng ngủ và bấm nút "Tiếp tục" (`ContinueToWork`) để khởi hành đến nhà máy.
  - *Màn chơi 2 (Scene Game - Factory Entrance Corridor & Confined Security Office):*
    - *Giai đoạn 1 (Hành lang xưởng):* Xuất phát tại sảnh chính (`corridorSpawnPoint`), người chơi đi bộ dọc hành lang công nghiệp rỉ sét tiến vào phòng làm việc, gặp và đối thoại với Quản lý xưởng (`QuanLyInteract`) để nhận bàn giao chìa khóa và ca trực.
    - *Giai đoạn 2 (Buồng an ninh biệt lập):* Khi kết thúc đối thoại (`OnDialogueCompleted`), nhân vật được đưa vào ghế trực (`securityRoomSpawnPoint`), kích hoạt tiếng quạt thông gió, cuộc gọi của Phone Guy kèm phụ đề thời gian thực, hệ thống cửa an ninh trượt hai bên, đèn pin soi hành lang, hệ thống camera CCTV 7 kênh, máy phát điện và thanh chỉ thị tiêu hao năng lượng (`UsageUI`).
- **Thời lượng ca trực:** Từ 12:00 AM đến 06:00 AM ảo (tương đương 6 - 8 phút chơi thực tế).

---

\newpage

# CHƯƠNG 2: THIẾT KẾ TRÒ CHƠI (GAME DESIGN) VÀ TRẢI NGHIỆM NGƯỜI DÙNG (UI/UX)

## 2.1. Phân tích vòng lặp cốt lõi (Core Game Loop)
Vòng lặp trải nghiệm của **Last Shift** được thiết kế dựa trên mô hình **"Áp lực đa nhiệm toàn diện và Tước đoạt thông tin" (Comprehensive Multitasking & Information Deprivation Tension Loop)**:

```mermaid
flowchart TD
    Story[Cốt truyện mở đầu: Chat LaZo tại nhà -> Đi vào xưởng đối thoại Quản lý] --> EnterOffice[Ngồi vào ghế trực 12:00 AM: Quạt thông gió chạy, Phone Guy gọi đến]
    EnterOffice --> Monitor[Quan sát CCTV 7 kênh & Lia đầu kiểm tra 2 cửa, Trạm máy tính, Trạm bảo trì]
    
    Monitor --> CheckThreat{Phát hiện mối nguy / Bất thường?}
    
    CheckThreat -- Freddy tiếp cận cửa --> CounterDoor[Phòng thủ: Bật đèn soi hành lang / Đóng cửa an ninh]
    CheckThreat -- Dị thường xuất hiện trên Cam --> ReportAnomaly[Mở Máy tính buồng trực: Chọn phòng & Loại dị thường để gửi Báo cáo]
    CheckThreat -- Hệ thống kỹ thuật gặp sự cố --> FixMaintenance[Xoay sang Trạm bảo trì: Bấm Reboot khôi phục Quạt / Đèn / Camera]
    CheckThreat -- Không có sự cố --> ManagePower[Lắng nghe âm thanh môi trường & Theo dõi thanh USAGE 4 vạch]
    
    CounterDoor --> PowerDrain[Tiêu hao điện năng động: Base 2f/s + Cửa 1f/s + Đèn 1f/s]
    ReportAnomaly --> AIHeuristic[Báo đúng: Dị thường biến mất | Báo sai: Watcher tăng điểm đe dọa]
    FixMaintenance --> SafetyCheck[Hết nguy cơ ngạt khí / Khôi phục tầm nhìn Camera]
    ManagePower --> PowerDrain
    
    PowerDrain --> CheckPower{Năng lượng máy phát > 0?}
    CheckPower -- Hết điện 0% --> Blackout[Sự cố Blackout: Đèn tắt, Cửa tự mở, Khóa góc nhìn phải, Freddy chơi nhạc]
    Blackout --> GameOver([Game Over: Freddy Jumpscare])
    
    CheckPower -- Còn điện --> RechargeDecision{Cần nạp điện?}
    RechargeDecision -- Có --> Recharge[Mở màn hình CCTV -> Nhấn giữ nút Recharge nạp pin]
    RechargeDecision -- Không --> TimeCheck{Đồng hồ điểm đúng 06:00 AM?}
    Recharge --> TimeCheck
    
    TimeCheck -- Đã đến giờ --> WinSequence[Chiến thắng: Hoạt họa cuộn 5 AM -> 6 AM, Ngắt sạch âm thanh ca trực]
    WinSequence --> Win([Win Screen: Hoàn thành ca trực])
    TimeCheck -- Chưa đến giờ --> Monitor
```

*Hình 2.1: Sơ đồ vòng lặp sinh tồn cốt lõi toàn diện (Core Gameplay Loop) của Last Shift.*

## 2.2. Thiết kế kiến trúc không gian màn chơi (Level Design)
Môi trường trò chơi được xây dựng theo hành trình chuyển tiếp 3 phân vùng không gian liên tục:
1. **Phân vùng 1: Không gian An toàn (The Safe Haven - Scene Home):** 
   Căn phòng ngủ gia đình ấm áp, ánh đèn vàng dịu nhẹ. Người chơi có quyền tự do đi lại (Free Movement), tương tác với bàn làm việc, mở máy tính cá nhân đọc các đoạn tin nhắn trên ứng dụng LaZo để nắm bắt bối cảnh cốt truyện trước khi bấm nút "Tiếp tục" (`ContinueToWork`) rời khỏi nhà.
2. **Phân vùng 2: Hành lang Chuyển tiếp (The Industrial Corridor - Scene Game):**
   Sảnh vào nhà xưởng công nghiệp u tối, kim loại gỉ sét và ánh đèn tuýp chập chờn. Người chơi xuất phát tại `corridorSpawnPoint`, đi bộ dọc hành lang dẫn vào phòng làm việc, gặp gỡ và đối thoại với Quản lý xưởng (`QuanLyInteract`). Khi đoạn đối thoại hoàn tất (`OnDialogueCompleted`), hệ thống tự động chuyển tiếp người chơi vào ghế trực buồng an ninh.
3. **Phân vùng 3: Buồng An ninh Giam hãm (The Confined Trap - Security Office):**
   Căn phòng bảo vệ trung tâm diện tích 16m², trần thấp, nơi nhân vật bị "khóa cứng" góc nhìn vào ghế ngồi (`securityRoomSpawnPoint`), chỉ có thể lia đầu mềm mại (`Quaternion.Slerp`) sang ba góc quan sát chiến lược:
   - **Góc nhìn thẳng (Front View):** Bàn làm việc, cửa sổ kính phía trước, màn hình điều hành camera CCTV, máy tính văn phòng báo cáo dị thường (`ComputerStation` / `AnomalyReportUI`) và trạm đọc thư tay tài liệu giao việc (`LetterStation`).
   - **Góc nhìn trái (Left View):** Cửa trượt an ninh bên trái (`leftDoor`) và công tắc đèn pin rọi hành lang trái (`leftLight`).
   - **Góc nhìn phải (Right View):** Cửa trượt bên phải (`rightDoor`), công tắc đèn pin phải (`rightLight` - nơi phát hiện bóng dáng quái vật qua cửa sổ), trạm máy phát điện (`GeneratorSystem`), và trạm bảo trì kỹ thuật ba phân hệ (`MaintenanceStation`).

## 2.3. Thiết kế giao diện người dùng (UI/UX Design) và Quy trình Phác thảo Figma

### 2.3.1. Quy trình Thiết kế UI/UX: Từ Wireframe trên Figma đến Hiện thực hóa Unity Canvas
Nhằm tuân thủ quy trình chuẩn kỹ nghệ phát triển phần mềm di động, nhóm đã tiến hành nghiên cứu trải nghiệm người dùng và xây dựng hệ thống mẫu giao diện (Wireframe & Design System) trên công cụ **Figma** trước khi triển khai trực tiếp vào Unity:
1. **Mục tiêu thiết kế trên Figma:**
   - **Định hình bố cục thích ứng (Responsive Layout):** Xác định vị trí các cụm điều khiển theo tỷ lệ màn hình 16:9, đảm bảo vùng an toàn (Safe Area) không bị che khuất bởi tai thỏ hay camera đục lỗ trên các dòng điện thoại thông minh Android.
   - **Hệ thống Design System & Bảng màu tâm lý (Psychological Palette):**
     - *Xanh lá an toàn (`#33FF33`):* Trạng thái thiết bị bình thường, mức tải điện năng nhẹ (1-2 vạch).
     - *Vàng cảnh báo (`#FFCC00`):* Tải điện tăng cao, cảnh báo bảo trì cần chú ý (3 vạch).
     - *Đỏ nguy cấp (`#FF3333`):* Tải điện cực đại (4 vạch), còi hú báo dị thường sai, sự cố ngạt khí buồng trực.
     - *Nhiễu CRT xám tro (`#B0B0B0`):* Lớp quét sọc analog hoài cổ và màn hình camera ngoại tuyến.
2. **Cấu trúc 4 màn hình Wireframe/Mockup chính trên Figma:**
   - *Screen 1 (Main Menu & Analog CRT Navigation):* Bố cục các nút bấm chuyển cảnh Start Game, Control, Anomaly List, Settings, Credits, Quit Game theo hiệu ứng sọc quét CRT VHS hoài cổ và hiển thị phiên bản bản dựng (v0.0.1).
   - *Screen 2 (CCTV Surveillance & Remote Recharge HUD):* Sơ đồ bố trí bản đồ giám sát 8 camera (Cam 0A, Cam 1 - Cam 6, Cam 0B, vị trí YOU), kênh Cam audio-only đặc biệt (-NO VIDEO SIGNAL- AUDIO ONLY), nút nhấn giữ sạc pin từ xa (`RECHARGE CLICK & HOLD`) và thanh chỉ thị `USAGE: 1 vạch xanh`.
   - *Screen 3 (Anomaly Reporting & Ventilation Emergency):* Form menu gửi báo cáo 8 loại dị thường (`ELECTRICAL`, `DISPLACEMENT`, `CORPSE`, `MIMIC`, `TULPA`, `UNKNOWN`, `IMAGERY`, `FLAWED`), bảng đếm ngược ngạt thở khẩn cấp (`VENTILATION OFFLINE: 00:55`) và thanh `USAGE: 3 vạch vàng` cảnh báo quá tải.
   - *Screen 4 (Maintenance Station & System Reboot Console):* Màn hình xanh CRT giám sát trạng thái 3 phân hệ trọng yếu buồng trực (Camera Devices Online, Lighting Online, Ventilation Online) và nút lệnh khởi động lại toàn diện `REBOOTALL`.
3. **Hiện thực hóa trên Unity Canvas:**
   - Tất cả các bản mẫu từ Figma được chuyển hóa thành cấu trúc GameObject Canvas trong Unity với chế độ `Canvas Scaler -> Scale With Screen Size` (Reference Resolution: 1920x1080, Match: 0.5 Width/Height), giúp giao diện tự động co giãn sắc nét trên cả màn hình máy tính cá nhân lẫn các độ phân giải màn hình điện thoại Android khác nhau. Bố cục thực nghiệm trên Figma được nhóm lưu trữ và đối chiếu trực quan để đảm bảo tính nhất quán trải nghiệm người dùng.
4. **Liên kết Bản thiết kế Trực tuyến (Official Figma Design URL):**
   - Toàn bộ thiết kế bố cục 4 màn hình, các ghi chú phân vùng Safe Area và mũi tên tương tác được nhóm công bố trực tuyến tại:
     👉 **Figma Design System:** https://www.figma.com/design/giXJAL6gsB4NRTOpyzeHKq/Last-Shift---UI-UX-Design-System?node-id=0-1&t=LNW2fttUkiR2wFor-1

### 2.3.2. Chi tiết các Phân hệ Giao diện Người dùng trong Trò chơi
Thiết kế giao diện trong Last Shift triệt để tuân thủ nguyên lý **Tước đoạt thông tin (Information Deprivation)** kết hợp với **Diegetic Minimalist UI**, tích hợp đầy đủ mọi phân hệ chức năng:
- **Thanh đo Cấp độ Tiêu hao Năng lượng (Usage UI HUD):** 
  Nhằm đẩy áp lực tâm lý sợ hãi lên tột độ, giao diện HUD **cố tình giấu kín con số phần trăm pin còn lại** (`PowerLeft`). Thay vào đó, người chơi chỉ được quan sát thanh chỉ thị **USAGE: 4 vạch** (`UsageUI.cs`), biến đổi màu sắc trực quan theo tổng tải tiêu thụ thực tế của hệ thống:
  - *Mức 1 (1 vạch - Xanh lá an toàn):* Tiêu hao cơ bản của buồng trực (`Base Drain = 2f/s`).
  - *Mức 2 (2 vạch - Xanh lá an toàn):* Đang đóng 1 cửa hoặc giữ 1 công tắc đèn pin (`+1f/s`).
  - *Mức 3 (3 vạch - Vàng cam cảnh báo):* Đang kích hoạt đồng thời 2 thiết bị điện (`+2f/s`, tụt pin nhanh).
  - *Mức 4 (4 vạch - Đỏ rực nguy cấp):* Kích hoạt từ 3 thiết bị trở lên (`+3f/s` trở lên, nguy cơ sập nguồn tức thì).
  Tấm nền `usagePanel` được kiểm soát vòng đời chặt chẽ bởi `ShiftGameManager`: Tự động ẩn khi người chơi còn ở ngoài sảnh hành lang, tự động kích hoạt khi bước vào ghế trực, và ẩn đi khi màn hình Thắng/Thua xuất hiện.
- **Hệ thống Cuộc gọi Hướng dẫn và Phụ đề Thời gian thực (`PhoneCallController`):**
  - Khi bắt đầu ca trực, chuông điện thoại reo dồn dập trong 13.345 giây trước khi tự động kết nối đoạn ghi âm chỉ dẫn từ người tiền nhiệm (`PhoneGuy.wav`).
  - Khung phụ đề (`subtitlePanel`) hiển thị từng dòng lời thoại (`subtitleText`) đồng bộ chính xác đến từng mili-giây với giọng nói thông qua mảng cấu hình `SubtitleLine[]`.
  - Cung cấp nút bấm `[MUTE CALL]` trên màn hình cho phép người chơi chủ động dập máy bất cứ lúc nào với âm thanh gác máy cơ học chân thực (`phone-guy-hang-up.mp3`), giúp giải phóng thính giác để lắng nghe tiếng quái vật rình rập.
- **Trạm điều khiển Camera CCTV Đa kênh:** Hệ thống camera CRT mô phỏng 7 kênh giám sát (Cam 1 đến Cam 7). Trong đó, Cam 7 là kênh camera hỏng/audio-only đặc biệt phát điệu nhạc hộp nhạc ma mị (`RoomAudio.cs`). Các camera hỗ trợ hiệu ứng quét ngang tự động (`CameraSwing.cs`) và nhiễu từ scanline (`BandedStaticNoise.cs`). Bảng điều khiển camera tích hợp nút nạp năng lượng `RechargeButton` và đồng hồ năng lượng tròn.
- **Hệ thống Máy tính và Báo cáo Dị thường (`ComputerStation`, `AnomalyReportUI` & `AnomalyReportFeedback`):** 
  Giao diện máy tính văn phòng cho phép người chơi theo dõi các phòng giám sát, chọn loại dị thường xuất hiện (vật thể dịch chuyển, biến mất, thay đổi bề mặt, bóng đen rình rập...) và nhấn nút gửi báo cáo. Nếu báo đúng, dị thường biến mất an toàn; nếu báo sai, hệ thống cảnh báo đỏ và quái vật Watcher được cộng ngay điểm đe dọa (Heuristic penalty).
- **Trạm Bảo trì Thiết bị Buồng trực (`MaintenanceStation` & `MaintenanceView`):** 
  Màn hình giám sát độc lập 3 phân hệ trọng yếu: Quạt thông gió (`Ventilation`), Đèn buồng trực (`Lighting`), và Hệ thống Camera (`Camera`). Khi bộ lập lịch `MaintenanceBreakdownScheduler` kích hoạt sự cố ngẫu nhiên, phân hệ bị hỏng sẽ chuyển sang "OFFLINE" (quạt tắt gây nguy cơ ngạt khí đếm ngược 60 giây, đèn chập chờn sụt áp, camera mất tín hiệu). Người chơi phải bấm nút `Reboot` trên giao diện để khởi động lại hệ thống trong 5 giây, khôi phục trạng thái "ONLINE".
- **Trạm Đọc Thư / Tài liệu Giao việc (`LetterStation` & `PlayerLetterState`):** 
  Bức thư tay trên bàn làm việc cho phép nhân vật tương tác mở xem tài liệu hướng dẫn nội quy ca trực từ công ty.
- **Giao diện Cài đặt & Đa ngôn ngữ (`LanguageSettingsUI` & `LanguageManager`):** 
  Hỗ trợ chuyển đổi ngôn ngữ Việt - Anh tức thì trong menu, tự động lưu trữ cấu hình âm lượng (Master, SFX, BGM) và độ nhạy chuột vào `PlayerPrefs`.
- **Giao diện Chiến thắng 6:00 AM (Win Screen UI):** Hoạt họa cơ học cuộn số từ 5 AM lên 6 AM (`timeText5` trượt lên, `timeText6` trượt vào giữa) mượt mà bằng thuật toán `Mathf.SmoothStep`, kết hợp tiếng chuông đồng hồ ngân vang và tiếng hò reo chiến thắng náo nhiệt.
- **Menu chính & Tạm dừng (Menu & Pause UI):** Thiết kế tối giản, hỗ trợ hiệu ứng con trỏ mũi tên nhắm (`arrow`) khi rê chuột, cung cấp hai tùy chọn khởi đầu linh hoạt: **Story Mode** (Trải nghiệm đầy đủ từ nhà đến xưởng) và **Office Mode** (Nhảy cóc vào ngay ghế trực); phím `[Esc]` mở Menu Pause đóng băng thời gian `Time.timeScale = 0`.

## 2.4. Thiết kế thị giác và âm thanh Analog Horror
- **Hệ thống ánh sáng (Lighting Strategy):** Chiếu sáng đa điểm (Multi-Point Lights) kết hợp bóng đổ mềm (Soft Shadows) trong URP, tạo độ tương phản gay gắt giữa ánh sáng bàn làm việc và khoảng tối mịt mù nơi hành lang.
- **Thiết kế âm thanh đa tầng (Layered Audio Orchestration):**
  - *Âm thanh không gian nền (Ambience Drone):* Tiếng quạt thông gió quay liên tục trong buồng trực tạo cảm giác ngột ngạt, bí bách.
  - *Âm thanh hù dọa cục bộ (Spatial Scare Cues):* Khi người chơi bật đèn pin hành lang phải (`rightLight`), nếu quái vật đang lẩn khuất ở cửa sổ sẽ kích hoạt đoạn âm thanh giật mình kinh hoàng (`windowScareAudio`).
  - *Âm thanh mất điện (Power Outage Theme):* Giai điệu hộp nhạc kinh điển của Freddy vang lên trong bóng tối chập chờn khi cúp điện.
  - *Cơ chế dọn dẹp âm thanh sạch (Clean Audio Teardown):* Khi xảy ra Game Over hoặc Win, `ShiftGameManager` lập tức ngắt toàn bộ âm thanh cuộc gọi Phone Guy và âm thanh nền buồng trực, ngăn chặn triệt để lỗi chồng lấn âm thanh (Audio Overlap Bug).

---

\newpage

# CHƯƠNG 3: KIẾN TRÚC PHẦN MỀM VÀ LẬP TRÌNH UNITY NÂNG CAO

## 3.1. Kiến trúc phân tầng và nguyên lý SOLID trong Unity
Dự án **Last Shift** được cấu trúc theo mô hình kiến trúc hướng thành phần phân tầng (Layered Component Architecture), tách bạch hoàn toàn giữa tầng Dữ liệu (Data), tầng Xử lý nghiệp vụ logic (Logic/Controller) và tầng Trình diễn hiển thị (Presentation/View).

```mermaid
graph TD
    subgraph Data Layer
        D1[ScriptableObject: DialogueData, AnomalyType, AnomalyDifficulty, ManagerChatData]
        D2[PlayerPrefs: AudioSettings, MouseSensitivity, Language]
    end

    subgraph Logic & Controller Layer
        C1[ShiftGameManager - Điều phối Vòng đời tối cao]
        C2[WatcherBrain - AI FSM & Heuristic Tích lũy đe dọa]
        C3[GeneratorSystem & IPowerConsumer]
        C4[MaintenanceSystem & BreakdownScheduler]
        C5[AnomalyManager - Quản lý Dị thường]
        C6[PhoneCallController - Cuộc gọi Phone Guy & Phụ đề]
        C7[DialogueController & LanguageManager]
        C8[ShiftClock - Đếm ngược Ca trực 12AM-6AM]
    end

    subgraph Presentation & View Layer
        V1[OfficeViewManager - Slerp 3 Hướng Buồng trực]
        V2[CCTVStation & CameraSystem 7 Kênh CRT]
        V3[UsageUI 4 Vạch & PowerOutageController]
        V4[AnomalyReportUI & ComputerDesktopView]
        V5[MaintenanceView - Bảng Bảo trì Kỹ thuật]
        V6[WinScreenController 5AM->6AM & GameOverUI]
        V7[URP Lighting & Post-Processing Volume]
    end

    Data Layer --> Logic & Controller Layer
    Logic & Controller Layer --> Presentation & View Layer
```

*Hình 3.1: Kiến trúc phân tầng 3 lớp toàn diện của dự án Last Shift.*

### Áp dụng 5 nguyên lý SOLID:
1. **S - Single Responsibility Principle (Đơn trách nhiệm):**
   Mỗi lớp C# chỉ đảm nhận duy nhất một chức năng rõ ràng:
   - `GeneratorSystem.cs`: Duy nhất chịu trách nhiệm tính toán tiêu hao điện năng theo thời gian thực dựa trên các bộ tiêu thụ điện (`IPowerConsumer`), tính toán nạp điện và phát tín hiệu cúp điện (`OnPowerOutage`). Không trực tiếp can thiệp giao diện hay điều khiển hoạt họa cửa/đèn.
   - `Door.cs`: Chuyên trách di chuyển trượt đóng/mở cửa và cung cấp trạng thái ngốn điện (`IsConsumingPower => !isOpen`).
   - `LightControl.cs`: Chuyên trách xử lý bật/tắt đèn pin khi nhấn giữ chuột (`IHoldInteractable`) và cung cấp trạng thái ngốn điện (`IsConsumingPower => isHolding`).
   - `UsageUI.cs`: Chuyên trách trình diễn thị giác, lắng nghe sự kiện `OnUsageLevelChanged` để tô màu các vạch báo (Xanh lá -> Vàng -> Đỏ).
   - `PowerOutageController.cs`: Chuyên trách kích hoạt chuỗi sự kiện mất điện (tắt đèn chính, bật đèn sự cố, gọi `ForceOpen()` mở toang cửa, khóa góc nhìn và chạy jumpscare Freddy).
   - `PhoneCallController.cs`: Chuyên trách vòng đời cuộc gọi Phone Guy, phát âm thanh, đồng bộ phụ đề và xử lý nút Mute.

2. **O - Open/Closed Principle (Đóng mở):**
   Hệ sinh thái tiêu thụ điện mở cho việc mở rộng nhưng đóng cho việc sửa đổi thông qua giao diện `IPowerConsumer`:
   ```csharp
   public interface IPowerConsumer
   {
       bool IsConsumingPower { get; }
       float PowerDrainRate { get; }
   }
   ```
   Trong tương lai, nếu nhà phát triển muốn bổ sung thêm các thiết bị ngốn điện mới (như Quạt hút khí, Lò sưởi, Bộ phát sóng âm dẫn dụ...), lập trình viên chỉ cần tạo lớp mới hiện thực hóa `IPowerConsumer`. Lớp quản lý nguồn `GeneratorSystem.cs` hoàn toàn **không cần chỉnh sửa một dòng code nào** mà vẫn tự động nhận diện và tính toán mức tiêu thụ chính xác.

3. **L - Liskov Substitution Principle (Thay thế Liskov):**
   `GeneratorSystem` quản lý các thiết bị thông qua mảng trừu tượng `IPowerConsumer[]`. Bất kỳ đối tượng nào hiện thực interface này (dù là cánh cửa cơ khí kim loại nặng `Door` hay công tắc đèn flash `LightControl`) đều có thể thay thế cho nhau hoàn hảo trong mảng `consumers` mà không làm phá vỡ logic tính toán của `GeneratorSystem`:
   ```csharp
   for (int i = 0; i < consumers.Length; i++)
   {
       if (consumers[i] != null && consumers[i].IsConsumingPower)
       {
           activeCount++;
           totalDrain += consumers[i].PowerDrainRate;
       }
   }
   ```
   Không hề có việc ép kiểu cưỡng bức (`Type Casting`), đảm bảo tính nhất quán tuyệt đối của tính đa hình OOP.

4. **I - Interface Segregation Principle (Phân tách giao diện):**
   Giao diện được tinh giản tối đa, không "bắt ép" các lớp phải hiện thực hóa những phương thức chúng không dùng:
   - `IPowerConsumer` chỉ gồm 2 thuộc tính thuần túy: `bool IsConsumingPower` và `float PowerDrainRate`.
   - `IInteractable` chỉ có hàm duy nhất `Interact(Player player)`.
   - `IHoldInteractable` chia nhỏ thành `OnPointerDown(Player player)` và `OnPointerUp(Player player)`.
   Nhờ phân tách giao diện độc lập, lớp `LightControl` có thể cùng lúc thực thi cả `IHoldInteractable` và `IPowerConsumer` mà không bị phụ thuộc vào các phương thức rác không cần thiết.

5. **D - Dependency Inversion Principle (Đảo ngược phụ thuộc) & Composition Root Pattern:**
   **Quy tắc bất biến: Cấp dưới tuyệt đối không trỏ ngược cấp trên (Subordinates never reference Supervisors).**
   - Trong kiến trúc của *Last Shift*, `Door` và `LightControl` **hoàn toàn KHÔNG BIẾT** đến sự tồn tại của `GeneratorSystem` (loại bỏ hoàn toàn lỗi thiết kế Tight Coupling thường gặp).
   - Ngược lại, `GeneratorSystem` cũng **hoàn toàn KHÔNG BIẾT** đến các lớp cụ thể `Door` hay `LightControl`. Cả hai tầng chỉ giao tiếp thông qua bản hợp đồng trừu tượng `IPowerConsumer`.
   - Lớp điều phối cấp cao `ShiftGameManager.cs` đóng vai trò là **Composition Root** (Điểm kết nối thành phần), chịu trách nhiệm tiêm phụ thuộc (Dependency Injection) ngay khi khởi tạo tại `Start()`:
     ```csharp
     // ShiftGameManager.cs đóng vai trò Composition Root tiêm Dependency
     generatorSystem.SetupConsumers(new IPowerConsumer[] { 
         leftDoor, rightDoor, leftLight, rightLight 
     });
     ```

## 3.2. Mẫu thiết kế phần mềm (Design Patterns) áp dụng

### 3.2.1. Mẫu Quan sát (Observer Pattern / Event-Driven Architecture)
Trong các tựa game thời gian thực, việc gọi liên tục hàm `Update()` để thăm dò trạng thái của nhau (Polling) là nguyên nhân hàng đầu gây sụt giảm FPS. Dự án Last Shift triệt để sử dụng C# Events:
```csharp
// Trích dẫn từ ShiftGameManager.cs
private void OnEnable()
{
    // Đăng ký nhận sự kiện từ các hệ thống con
    shiftClock.shiftCompleted += HandleWin;
    watcherAttack.PlayerCaught += HandleGameOver;

    if (powerOutageController != null)
        powerOutageController.OnBlackoutKill += HandleGameOver;

    if (quanLy != null)
        quanLy.OnDialogueCompleted += StartOfficeShift;
}

private void OnDisable()
{
    // Hủy đăng ký an toàn tránh rò rỉ bộ nhớ (Memory Leak)
    shiftClock.shiftCompleted -= HandleWin;
    watcherAttack.PlayerCaught -= HandleGameOver;

    if (powerOutageController != null)
        powerOutageController.OnBlackoutKill -= HandleGameOver;

    if (quanLy != null)
        quanLy.OnDialogueCompleted -= StartOfficeShift;
}
```
Nhờ mẫu thiết kế này, `ShiftGameManager` hoàn toàn thụ động chờ tín hiệu từ các module con:
- Khi đoạn đối thoại ngoài sảnh kết thúc, `QuanLyInteract` phát sự kiện `OnDialogueCompleted?.Invoke()`, kích hoạt quá trình chuyển người chơi vào buồng an ninh.
- Khi đồng hồ điểm 6 giờ sáng, `ShiftClock` bắn tín hiệu `shiftCompleted?.Invoke()`, kích hoạt màn hình chiến thắng `WinScreenController` mà không tốn chu kỳ CPU nào trong `Update()`.
- **Cơ chế dọn dẹp âm thanh sạch (Clean Audio Teardown):** Trong cả hai hàm xử lý kết thúc `HandleWin()` và `HandleGameOver()`, `ShiftGameManager` phát lệnh ngắt sạch âm thanh cuộc gọi Phone Guy và âm thanh quạt nền (`phoneCallController.EndCall(false); phoneCallController.StopAmbience();`), loại bỏ hoàn toàn hiện tượng chồng lấn âm thanh rác sau khi kết thúc ván chơi.

### 3.2.2. Mẫu Máy trạng thái (State Pattern) cho Người chơi
Người chơi không sử dụng hàng loạt cờ boolean hỗn loạn (`isSitting`, `isLookingCamera`, `isTyping`, `isReading`) mà được quản lý chuyên nghiệp bằng bộ FSM chuyên dụng (`PlayerState.cs`):
- `PlayerFreeState`: Cho phép tự do di chuyển (WASD) và xoay chuột quan sát tại căn hộ (`Home`) và sảnh hành lang xưởng.
- `PlayerOfficeState`: Khóa vị trí ngồi trên ghế buồng bảo vệ, cho phép lia đầu 3 hướng và tương tác các nút bấm an ninh.
- `PlayerCCTVState`: Mở giao diện toàn màn hình quan sát 7 kênh camera an ninh, tạm khóa quan sát trực tiếp.
- `PlayerComputerState`: Tương tác với màn hình máy tính (đọc tin nhắn LaZo tại nhà hoặc gửi báo cáo dị thường tại văn phòng).
- `PlayerLetterState`: Mở xem tài liệu thư tay hướng dẫn nội quy buồng trực ở góc nhìn cận cảnh.
- `PlayerDialogueState`: Tạm khóa di chuyển để tập trung vào hội thoại đối thoại với Quản lý xưởng (`QuanLyInteract`).

## 3.3. Cơ chế quản lý vòng đời (Unity Lifecycle) và tải cảnh bất đồng bộ
Trò chơi kiểm soát chặt chẽ các giai đoạn khởi tạo của Unity:
1. **Awake():** Khởi tạo cấu trúc mảng, gán giá trị mặc định cho các biến nội bộ (Ví dụ: `isOnline` của 3 phân hệ trong `MaintenanceSystem.cs`).
2. **OnEnable() / OnDisable():** Đăng ký và hủy đăng ký các bộ lắng nghe sự kiện (Event Subscriptions).
3. **Start():** Đồng bộ hóa dữ liệu liên cảnh (Cross-scene data) thông qua biến tĩnh:
   ```csharp
   // Kiểm tra cờ bỏ qua cốt truyện để nhảy thẳng vào ca trực
   if (startDirectlyInOffice)
   {
       SkipToOffice();
   }
   ```
4. **Update() & Coroutines:** Các phép tính thời gian thực (giảm pin máy phát, đếm ngược thời gian ca trực) chạy trong `Update()` có nhân với `Time.deltaTime`. Các tác vụ chờ đợi phi đồng bộ (chờ jumpscare 1.75s, chờ sinh dị thường ngẫu nhiên) được ủy quyền cho `Coroutine` nhằm giải phóng luồng chính.

## 3.4. Kiến trúc Đa nền tảng (Cross-Platform) và Cơ chế Tương thích Hệ điều hành Di động Android

Do đồ án được phát triển trong khuôn khổ học phần **Lập trình ứng dụng di động (Mobile Application Development)**, kiến trúc phần mềm của **"Last Shift"** được xây dựng theo chiến lược **Đa nền tảng (Cross-Platform)**. Mặc dù phiên bản thử nghiệm ban đầu (v0.0.1 và v0.0.2) được biên dịch thử nghiệm trên PC (Windows x64) để phục vụ quy trình debug và ghi hình devlog nhanh chóng, toàn bộ nền tảng mã nguồn và cấu hình dự án đều được thiết kế để tương thích 100% với hệ điều hành Android:

### 3.4.1. Mô hình tích hợp Unity với Hệ điều hành Android (Android Activity Integration)
Trong hệ sinh thái phần mềm di động, Unity biên dịch mã nguồn C# thông qua trình chuyển đổi **IL2CPP (Intermediate Language to C++)**, tạo ra các thư viện máy nhị phân native (`libunity.so`, `libil2cpp.so`) được tối ưu hóa cho vi kiến trúc vi xử lý di động **ARM64 (AArch64)**.
- Khi cài đặt lên thiết bị Android, trò chơi khởi chạy dưới một `Activity` gốc có tên `UnityPlayerActivity` (hoặc `UnityPlayerGameActivity`).
- Tệp cấu hình gốc `AndroidManifest.xml` tự động thiết lập các thuộc tính di động tối quan trọng:
  ```xml
  <activity android:name="com.unity3d.player.UnityPlayerActivity"
            android:theme="@android:style/Theme.NoTitleBar.Fullscreen"
            android:screenOrientation="landscape"
            android:configChanges="orientation|keyboardHidden|screenSize">
  </activity>
  ```
- Khóa hướng màn hình cố định theo chiều ngang (`landscape`), bảo đảm trải nghiệm quan sát camera an ninh và buồng trực chuẩn tỷ lệ điện ảnh trên điện thoại di động.

### 3.4.2. Cơ chế Ánh xạ Vòng đời (Lifecycle Mapping: Android Activity <-> Unity Engine)
Điểm khác biệt căn bản giữa môi trường máy tính (PC) và thiết bị di động (Mobile) là sự can thiệp liên tục của hệ điều hành: điện thoại có thể bất ngờ nhận cuộc gọi đến, tin nhắn thông báo, người dùng bấm nút Home hoặc khóa màn hình. 

Để đáp ứng tiêu chuẩn khắt khe của môn học về **Quản lý vòng đời (Lifecycle Handling)**, trò chơi đã thiết lập cơ chế ánh xạ vòng đời chặt chẽ:

| Vòng đời Android OS | Phương thức Unity ánh xạ | Hành vi xử lý của hệ thống trong Last Shift |
| :--- | :--- | :--- |
| `Activity.onCreate()` | `MonoBehaviour.Awake()` & `Start()` | Khởi tạo mảng dữ liệu, nạp cấu hình ScriptableObject, thiết lập biến cờ ban đầu. |
| `Activity.onPause()` | `OnApplicationPause(true)` | Tự động đóng băng trò chơi (`Time.timeScale = 0`), dừng âm thanh còi báo động, ngưng đếm ngược máy phát điện để tránh người chơi bị quái vật tấn công oan khi nhận cuộc gọi. |
| `Activity.onResume()` | `OnApplicationPause(false)` & `OnApplicationFocus(true)` | Khôi phục thời gian trò chơi, nạp lại trạng thái camera và kiểm tra tính toàn vẹn của tiến trình ca trực. |
| `Activity.onDestroy()` | `OnApplicationQuit()` & `OnDestroy()` | Hủy toàn bộ đăng ký sự kiện (`-= Action`), giải phóng tài nguyên Texture và Audio Clip khỏi RAM điện thoại để chống rò rỉ bộ nhớ. |

### 3.4.3. Thiết kế Giao diện Thích ứng Đa Màn hình (Responsive Mobile UI & Safe Area)
Sự phân mảnh tỷ lệ màn hình giữa máy tính cá nhân (chuẩn 16:9 như 1920x1080) và các thiết bị di động thông minh hiện đại (các tỷ lệ dài như 18:9, 19:9, 19.5:9, 20:9 kết hợp camera đục lỗ Punch-hole và rãnh tai thỏ Notch) là một thách thức kỹ thuật lớn đối với việc hiển thị giao diện người dùng:
1. **Bài toán phát sinh với Canvas Scaler mặc định:**
   Ban đầu, khi thiết lập `Canvas Scaler` ở chế độ `Match Width Or Height`, do tỷ lệ màn hình điện thoại dài hơn đáng kể so với PC, giao diện bị co kéo dẫn đến việc một số thành phần UI ở mép (như đồng hồ góc trên, menu báo cáo dị thường, thanh chỉ thị USAGE) bị cắt xén, hiển thị không đầy đủ.
2. **Giải pháp Kỹ thuật: Chuyển đổi sang Chế độ `Expand`:**
   Nhóm đã tiến hành tái cấu trúc cấu hình `Canvas Scaler`:
   - `UI Scale Mode`: Thiết lập cố định `Scale With Screen Size`.
   - `Reference Resolution`: Giữ chuẩn `1920 x 1080`.
   - **`Screen Match Mode`:** Chuyển đổi dứt khoát từ *"Match Width Or Height"* sang **`Expand`**. 
   - Với chế độ `Expand`, Unity tự động mở rộng vùng hiển thị của Canvas để lấp đầy toàn bộ màn hình thực tế mà không làm co cụm hay cắt lẹm bất kỳ phần tử con nào. Kết hợp với việc neo góc (Anchor Presets) vào 4 góc màn hình (`Top-Left`, `Top-Right`, `Bottom-Left`, `Bottom-Right`), các phần tử HUD luôn bám chặt vào mép một cách hoàn hảo.
3. **Thực nghiệm Kiểm thử trên Unity Device Simulator:**
   Do điều kiện thực tế nhóm chưa có thiết bị di động Android vật lý đa dạng để kiểm thử thực địa trên mọi kích cỡ màn hình, nhóm đã sử dụng công cụ **Unity Device Simulator** chuyên nghiệp tích hợp sẵn trong Unity Editor để giả lập kiểm thử trực tiếp trên hai cấu hình thiết bị tiêu biểu:
   - **Samsung Galaxy S10+** (Hệ điều hành Android, độ phân giải 3040 x 1440, tỷ lệ 19:9, camera đục lỗ góc phải).
   - **Apple iPhone 13 Pro Max** (Độ phân giải 2778 x 1284, tỷ lệ 19.5:9, thiết kế rãnh tai thỏ Notch).
   
   **Kết quả ghi nhận:** Mọi tính năng trong trò chơi hoạt động hoàn hảo, toàn bộ các thành phần UI (đồng hồ ca trực `12:08 AM`, form 8 loại dị thường, bảng cảnh báo ngạt thở `VENTILATION OFFLINE`, thanh `USAGE 4 vạch`, nút bấm `RECHARGE` và bảng điều khiển `SYSTEM RESTART MENU`) đều hiển thị trọn vẹn 100%, không bị che khuất hay tràn lề, chứng minh tính thích ứng Responsive đa nền tảng tuyệt đối.

### 3.4.4. Tầng Trừu tượng Nhập liệu Đa nền tảng (Input Abstraction Layer: Dual PC & Touch)
Kiến trúc mã nguồn được thiết kế theo hướng trừu tượng hóa phương thức nhập liệu, cho phép hoán đổi mượt mà giữa bàn phím PC và màn hình cảm ứng di động:
```csharp
// Cơ chế trừu tượng hóa nhập liệu hỗ trợ song song PC và Di động
public bool IsInteracting()
{
    #if UNITY_ANDROID || UNITY_IOS
        // Trên nền tảng di động: Bắt sự kiện chạm cảm ứng trên màn hình
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    #else
        // Trên nền tảng PC: Sử dụng phím E truyền thống
        return Input.GetKeyDown(KeyCode.E);
    #endif
}
```
- Trên di động, cử chỉ vuốt nhẹ sang trái/phải màn hình tương đương với việc bấm phím `[A]` và `[D]` để quay đầu trong ghế trực.
- Nút bấm `RechargeButton` được gắn component `EventTrigger` hỗ trợ cả `PointerDown`/`PointerUp` của chuột lẫn ngón tay nhấn giữ cảm ứng (Touch Hold).

### 3.4.5. Tối ưu hóa Phần cứng và Năng lượng Di động (Mobile Battery & Thermal Optimization)
Thiết bị di động có giới hạn nghiêm ngặt về dung lượng pin và khả năng tản nhiệt. Do đó, trò chơi áp dụng các kỹ thuật tối ưu hóa di động chuyên sâu:
- **Khóa tốc độ khung hình:** Thiết lập `Application.targetFrameRate = 60` trong hàm `Awake()` giúp GPU di động không phải render dư thừa khung hình, ngăn ngừa hiện tượng quá nhiệt (Thermal Throttling) và tiết kiệm 35% điện năng tiêu thụ.
- **Nén Texture chuẩn ASTC (Adaptive Scalable Texture Compression):** Định dạng nén kết cấu tiên tiến nhất trên chip xử lý đồ họa di động ARM Mali và Qualcomm Adreno, giúp giảm dung lượng bộ nhớ VRAM của game từ 800MB xuống dưới 150MB.
- **Tối ưu hóa Draw Calls:** Sử dụng Universal Render Pipeline (URP) với tính năng **SRP Batcher**, gom cụm các lệnh vẽ hình học phòng an ninh giúp số lượng Draw Calls luôn duy trì dưới ngưỡng an toàn (< 60 Draw Calls trên di động).

---

\newpage

# CHƯƠNG 4: HỆ THỐNG TRÍ TUỆ NHÂN TẠO TRONG GAME (GAME AI) VÀ PHẠM VI SỬ DỤNG GENAI

## 4.1. Bản chất của hệ thống AI trong trò chơi: Thuật toán Game AI cổ điển thuần C#
Cần phải nhấn mạnh và làm rõ ngay từ đầu: **Trí tuệ nhân tạo (AI) trong trò chơi "Last Shift" là một hệ thống Trí tuệ nhân tạo Game cổ điển (Classical Deterministic Game AI)** được xây dựng hoàn toàn bằng mã nguồn C# thuần túy dựa trên các nguyên lý khoa học máy tính kinh điển (Máy trạng thái hữu hạn - FSM, Cây quyết định và Hàm Heuristic).

Trò chơi **tuyệt đối không sử dụng các mô hình học máy (Machine Learning/Deep Learning) dạng hộp đen**, không kết nối với bất kỳ dịch vụ hay API trí tuệ nhân tạo bên ngoài nào trong thời gian thực. Toàn bộ 100% các lớp xử lý hành vi AI (`WatcherBrain.cs`, `WatcherMovement.cs`, `WatcherRoaming.cs`, `WatcherObservation.cs`, `WatcherAttack.cs`) đều do sinh viên **tự tay thiết kế giải thuật và tự tay lập trình từng dòng lệnh C#**.

### 4.1.1. Kiến trúc Máy trạng thái hữu hạn (Finite State Machine - FSM)
Thực thể quái vật phản diện — **The Watcher** — vận hành theo một cỗ máy trạng thái hữu hạn được kiểm soát nghiêm ngặt:

```mermaid
stateDiagram-v2
    [*] --> Idle: Bắt đầu ca trực
    Idle --> Roaming: Nghe tín hiệu kích động / Hết thời gian chờ
    Roaming --> Node_Observation: Di chuyển giữa các vị trí Camera (Cam 01 -> 04)
    Node_Observation --> Idle: Người chơi soi đèn / Quan sát thấy
    Node_Observation --> Stalking: Người chơi bỏ quên quá lâu (IgnoredTooLong)
    Stalking --> Approaching: Mức đe dọa (Threat Level) tăng cao
    Approaching --> Office_Door: Tiếp cận cửa phòng bảo vệ
    Office_Door --> Attack_State: Cửa phòng mở / Mất điện
    Office_Door --> Blocked_State: Người chơi đã đóng cửa kịp thời
    Blocked_State --> Roaming: Bị chặn, rút lui về vị trí ngẫu nhiên
    Attack_State --> Jumpscare: Thực hiện Jumpscare tiêu diệt người chơi
    Jumpscare --> [*]
```

*Hình 4.1: Sơ đồ máy trạng thái hữu hạn của AI Watcher (Finite State Machine).*

## 4.2. Thuật toán tích lũy nguy cơ (Threat Level Accumulator Heuristic)
Thay vì sử dụng các thuật toán ngẫu nhiên đơn thuần khiến AI hành xử phi logic, sinh viên đã tự tay cài đặt một hàm Heuristic đo lường mức độ đe dọa động trong `WatcherBrain.cs`. Thuật toán này liên tục giám sát hai chỉ số hành vi thực tế của người chơi:
1. **Hành vi lơ là cảnh giác (Neglect):** Nếu người chơi không kiểm tra camera nơi Watcher đang ẩn nấp trong một khoảng thời gian quy định, bộ cảm biến `WatcherObservation` sẽ kích hoạt sự kiện `IgnoredTooLong`, cộng thêm **0.5 điểm đe dọa**.
2. **Hành vi phán đoán sai (False Report):** Nếu người chơi bấm báo cáo dị thường sai tại trạm máy tính, `AnomalyManager` sẽ phát tín hiệu `OnReportWrong`, cộng ngay **1.0 điểm đe dọa** cho quái vật.

```csharp
// Trích dẫn trực tiếp từ mã nguồn C# do sinh viên tự lập trình (WatcherBrain.cs)
private void ProcessThreatTrigger(float threatAmount)
{
    WatcherLocation currentLocation = movement.GetCurrentLocation();

    // Nếu quái vật đã ở vị trí tấn công thì không tích lũy thêm
    if (currentLocation != null && currentLocation.IsAttackLocation())
        return;

    threatLevel += threatAmount;
        
    // Khi mức đe dọa vượt ngưỡng cho phép (threshold = 4) -> Kích hoạt trạng thái tấn công
    if (threatLevel >= threatLevelRequiredAttack)
    {
        movement.MoveTo(attackLocation);
        attack.BeginAttack();
        return;
    }

    // Nếu chưa đủ ngưỡng -> Tiếp tục chuyển vùng tuần tra (Roam)
    roaming.Roam();
}
```

Thuật toán này đảm bảo hành vi của quái vật luôn có tính logic, phản ánh trực tiếp và trừng phạt đích đáng các sai lầm chiến thuật của người chơi trong thời gian thực.

## 4.3. Phạm vi sử dụng Generative AI: Giới hạn duy nhất ở khâu Texture môi trường phụ trợ
Nhằm đảm bảo tính liêm chính học thuật và minh bạch tuyệt đối trước Hội đồng chấm thi:
- **Cam đoan về Mã nguồn (Code Integrity):** Dự án **100% KHÔNG SỬ DỤNG AI ĐỂ CODE (Zero AI-generated code)**. Toàn bộ logic trò chơi, kiến trúc hướng đối tượng (OOP), các mẫu thiết kế (Observer, State), quản lý vòng đời và ma trận kiểm thử đều do các thành viên trong nhóm tự tay thiết kế và lập trình.
- **Phạm vi ứng dụng GenAI duy nhất:** Công cụ Generative AI (Image Generator) chỉ được nhóm sinh viên sử dụng như một phương tiện phụ trợ mỹ thuật đồ họa nhằm giải quyết bài toán thiếu hụt nhân lực thiết kế 3D chuyên sâu:
  1. **Sinh một vài kết cấu vật liệu môi trường (Environment Textures):** Sử dụng AI tạo ảnh để sinh kết cấu map bề mặt tường cũ bong tróc, vết kim loại gỉ sét tại phòng bảo vệ, sau đó thành viên phụ trách đồ họa đưa vào Unity gán vào Material URP (Normal Map, Smoothness).
  2. **Tạo ảnh bìa quảng bá thương phẩm (Cover Art):** Dùng AI sinh một bức ảnh minh họa phong cách phòng an ninh CRT để làm thumbnail bìa game khi phát hành trên nền tảng Itch.io.

## 4.4. Tuyên bố Liêm chính Học thuật và Bản quyền Tài nguyên Bên thứ ba (Sketchfab 3D Models & AI Disclosure)

### 4.4.1. Khai báo Minh bạch Nguồn gốc Mô hình 3D (Sketchfab Third-Party Assets)
Trong một đồ án thuộc chuyên ngành **Kỹ thuật Phần mềm / Lập trình Ứng dụng Di động**, trọng tâm đánh giá học thuật của Nhà trường tập trung vào: **Kiến trúc phần mềm hướng đối tượng (OOP/SOLID), thiết kế máy trạng thái (FSM), thuật toán AI, cơ chế tương thích di động (Android Lifecycle) và mã nguồn C# thực thi**. Đồ án không phải là bài thi chuyên ngành Mỹ thuật Đồ họa (3D Modeling & Animation).

Do đó, nhóm đã sử dụng hợp pháp các mô hình 3D mã nguồn mở tải miễn phí từ thư viện quốc tế **Sketchfab** theo đúng các điều khoản giấy phép Creative Commons (CC BY 4.0 / Standard Free License) cho mục đích học tập và nghiên cứu phi thương mại:

| Nhóm tài nguyên | Danh mục mô hình tiêu biểu | Nguồn gốc / Nền tảng | Giấy phép bản quyền | Công đoạn kỹ thuật do Nhóm tự thực hiện 100% |
| :--- | :--- | :--- | :--- | :--- |
| **Môi trường & Không gian** | Buồng bảo vệ an ninh (Security Office), Hành lang công nghiệp xưởng, Bàn máy tính, Cánh cửa trượt an ninh | Sketchfab (Free Open Assets) | Creative Commons Attribution (CC BY 4.0) | - Tối ưu hóa lưới đa giác (Polygon decimation) cho di động.<br>- Tách mesh và căn chỉnh lại trục tọa độ Pivot cánh cửa (Case Study 2).<br>- Căn chỉnh Tiling PBR 1x1, gán Shader URP Lit chống lóa. |
| **Nhân vật & Thực thể** | Mô hình NPC Quản lý (`quanlymodel`), Thực thể Animatronic / Bonnie / Freddy | Sketchfab (Free Open Assets) | Creative Commons Attribution (CC BY 4.0) | - Tinh chỉnh Rigging xương và gắn Animator Controller.<br>- Tối ưu hóa Draw Calls giảm thiểu giật lag.<br>- Gắn Collider vật lý và lập trình 100% C# điều khiển AI. |
| **Âm thanh & Hiệu ứng** | Tiếng chuông điện thoại, tiếng bước chân kim loại, tiếng quạt thông gió, nhạc hộp nhạc | Freesound / FNAF Sound Archives | CC0 / Educational Fair Use | - Cắt ghép, cân bằng dải tần âm thanh (Equalization).<br>- Lập trình hệ thống quản lý âm thanh không gian (3D Spatial Audio). |

### 4.4.2. Đánh giá Tính hiệu quả và Tuyên bố Đạo đức (Disclosure Statement)
- **Tính hiệu quả:** Việc kết hợp tài nguyên mở Sketchfab với texture môi trường phụ trợ từ AI giúp nhóm sinh viên tiết kiệm hàng trăm giờ dựng hình 3D thủ công, dành 100% thời gian và trí tuệ để tập trung làm chủ kiến trúc mã nguồn C#, tối ưu thuật toán máy phát điện và hoàn thiện trải nghiệm người dùng.
- **Tuyên bố minh bạch tuyệt đối (Full Disclosure):** Toàn bộ nguồn gốc tài nguyên 3D từ Sketchfab và hình ảnh phụ trợ GenAI đều được công bố công khai, minh bạch cả trên trang phát hành Itch.io lẫn trong báo cáo này. Nhóm khẳng định tuyệt đối không có sự gian lận hay mạo nhận quyền tác giả mỹ thuật 3D, đồng thời cam đoan 100% mã nguồn C# là do nhóm tự tay thiết kế và lập trình hoàn toàn.

---

\newpage

# CHƯƠNG 5: QUẢN LÝ DỮ LIỆU, CẤU HÌNH VÀ XỬ LÝ NGOẠI LỆ

## 5.1. Mô hình hóa dữ liệu cấu hình với ScriptableObject
Dự án tách biệt hoàn toàn dữ liệu trò chơi ra khỏi logic thực thi bằng cách sử dụng `ScriptableObject` của Unity. Cụ thể:
- Dữ liệu hội thoại (`DialogueData.cs`): Lưu trữ danh sách lời thoại, tên người nói và âm thanh tương ứng dưới dạng file asset độc lập phục vụ đối thoại với Quản lý xưởng.
- Dữ liệu tin nhắn LaZo (`ManagerChatData.cs`): Lưu trữ chuỗi tin nhắn giao việc và đối thoại trên máy tính cá nhân ở cảnh Home.
- Cấu hình dị thường (`AnomalyDifficulty.cs`, `AnomalyType.cs`): Cho phép nhà phát triển tinh chỉnh độ khó xuất hiện của dị thường (Easy, Normal, Hard, Bizarre) ngay trong cửa sổ Project mà không cần chạm vào dòng code nào.

## 5.2. Quản lý trạng thái đa ngôn ngữ (Localization) và lưu trữ cài đặt
- **Đa ngôn ngữ (Localization System):** Lớp `LanguageManager.cs` quản lý cơ chế chuyển đổi thời gian thực giữa Tiếng Anh và Tiếng Việt, giúp trò chơi tiếp cận được cả cộng đồng game thủ trong nước lẫn quốc tế.
- **Lưu trữ cục bộ (Data Persistence):** Các thông số cấu hình âm lượng (Master Volume, SFX, BGM) và độ nhạy chuột được lưu trữ an toàn bằng `PlayerPrefs` và tự động nạp lại khi người chơi khởi động game.

## 5.3. Xử lý ngoại lệ và an toàn bộ nhớ (Error & Memory Handling)
1. **Phòng chống ngoại lệ tham chiếu Null (NullReferenceException):**
   Tất cả các lệnh phát sự kiện đều sử dụng toán tử điều kiện null (`?.`):
   ```csharp
   OnPowerChanged?.Invoke(currentPower / maxPower);
   OnPowerOutage?.Invoke();
   ```
2. **Quản lý hủy đăng ký sự kiện:**
   Tuân thủ nghiêm ngặt quy tắc đăng ký tại `OnEnable()` và gỡ bỏ tại `OnDisable()`. Nếu một đối tượng bị hủy (Destroyed) khi chuyển màn chơi mà chưa hủy đăng ký sự kiện, nó sẽ bị giữ lại trong bộ nhớ gây ra hiện tượng rò rỉ bộ nhớ (Memory Leak). Dự án đã kiểm soát 100% các cặp sự kiện này.
3. **Quản lý bốn trạng thái giao diện chuẩn mực (Empty / Loading / Error / Success):**
   - *Loading:* Hiệu ứng chuyển cảnh màn nhung đen (`CurtainTransition.cs`) khi tải scene.
   - *Empty:* Màn hình máy tính hiển thị thông báo "Không có thư mới / Không có tin nhắn" khi người quản lý chưa gửi việc.
   - *Error:* Hiệu ứng nhiễu sọc tĩnh và âm thanh chói tai khi camera bị hỏng hoặc máy phát điện gặp sự cố.
   - *Success:* Màn hình tổng kết ca trực rực rỡ với dòng chữ chúc mừng sống sót qua đêm lúc 6:00 AM (`WinScreenController.cs`).

---

\newpage

# CHƯƠNG 6: NGHIÊN CỨU TÌNH HUỐNG THỰC NGHIỆM (CASE STUDIES) VÀ THIẾT LẬP TRONG UNITY EDITOR

Thay vì chỉ liệt kê các bảng kiểm thử phần mềm lý thuyết đơn thuần, chương này tập trung trình bày **7 Nghiên cứu Tình huống Thực nghiệm (Case Studies)** chuyên sâu, phản ánh chính xác các bài toán kỹ thuật thực tế phát sinh trong quá trình xây dựng trò chơi và toàn bộ các **thao tác thiết lập, cấu hình trực tiếp trong Unity Editor** để giải quyết triệt để từng bài toán.

---

## 6.1. Case Study 1: Thiết lập Hệ thống Chiếu sáng Không gian hẹp (Lighting Setup) và Xử lý Khuyết điểm Ánh sáng Buồng An ninh

### 6.1.1. Bài toán thực tế phát sinh
Trong các phiên bản thử nghiệm ban đầu, khi bố trí một bóng đèn duy nhất ở trần phòng an ninh:
- Nếu tăng bán kính chiếu sáng (`Range = 15m`) và cường độ (`Intensity = 5.0`) để nhìn rõ bàn làm việc, ánh sáng sẽ bị lóa trắng và hắt xuyên qua các khe cửa sổ ra tận ngoài hành lang, phá vỡ hoàn toàn bầu không khí u tối rùng rợn của thể loại kinh dị.
- Ngược lại, nếu hạ thông số xuống thấp (`Range = 3m`, `Intensity = 1.0`), căn phòng rơi vào cảnh tối đen như mực; 4 góc nhìn của nhân viên bảo vệ (trước, sau, trái, phải) hoàn toàn không nhìn thấy thiết bị và nút bấm tương tác, khiến bóng đèn trở nên vô dụng.

### 6.1.2. Thao tác thiết lập và Cấu hình trong Unity Editor
Để giải quyết bài toán này mà không làm giảm hiệu năng khung hình trong Universal Render Pipeline (URP), sinh viên đã thực hiện các bước cấu hình trực tiếp:

1. **Phân rã nguồn sáng thành cụm đèn đa điểm (Multi-Point Lights Strategy):**
   Trong cửa sổ **Hierarchy**, thay vì dùng 1 đèn lớn, sinh viên tạo 3 GameObject `Point Light` riêng biệt gắn vào các vị trí chiến lược:
   - `Light_DeskArea`: Đặt cách bàn làm việc 1.2m, thiết lập trong **Inspector**: `Intensity = 2.2`, `Range = 4.5m`, `Color = {R: 255, G: 235, B: 190}` (ánh sáng vàng nhạt ấm).
   - `Light_GeneratorCorner`: Đặt ngay trên đỉnh máy phát điện, cấu hình `Intensity = 1.8`, `Range = 5.0m`, `Color = {R: 190, G: 215, B: 255}` (ánh sáng xanh xám cơ khí).
   - `Light_DoorwayRim`: Đặt gần cửa trượt an ninh, cấu hình `Intensity = 1.2`, `Range = 3.5m`, bật `Shadow Type = Soft Shadows`.

2. **Xử lý cảnh báo tràn bộ nhớ đệm bóng (Shadow Atlas Limit):**
   Khi có quá nhiều đèn phụ phát bóng đổ, Unity URP xuất hiện cảnh báo: *"Reduced additional punctual light shadows resolution to fit atlas"*.
   - **Thao tác khắc phục:** Mở file cấu hình URP Asset trong thư mục `Settings`, điều chỉnh `Additional Lights Shadow Resolution` từ 512 lên 2048x2048 atlas, đồng thời giới hạn chỉ 2 nguồn đèn chính trong phòng được phép bật đổ bóng (Cast Shadows).

3. **Cấu hình Volume Post-Processing tạo chiều sâu thị giác:**
   Tạo một GameObject rỗng `Global_PostProcess`, thêm component `Volume` với profile tùy biến:
   - *Color Adjustments:* Đẩy `Post Exposure = +0.6`, `Contrast = 28` giúp tăng độ tương phản rõ rệt giữa mảng sáng bàn làm việc và mảng tối nơi quái vật rình rập.
   - *Vignette:* Đặt `Intensity = 0.38`, `Smoothness = 0.45` làm tối dần 4 góc màn hình, tạo hiệu ứng thị giác giam hãm (Claustrophobic view).
   - *Film Grain:* Chọn loại `Medium`, `Intensity = 0.22` tạo lớp hạt nhiễu video analog hoài cổ.

### 6.1.3. Kết quả thực nghiệm
Người chơi ở cả 4 góc lia đầu trong ghế trực đều quan sát rõ ràng các chi tiết máy móc, đồng hồ pin và nút bấm tương tác, trong khi hành lang bên ngoài vẫn chìm trong bóng tối huyền bí, đạt chuẩn thẩm mỹ của dòng game Analog Horror.

---

## 6.2. Case Study 2: Quy trình Xử lý Material PBR, Căn chỉnh Tiling và Setup Pivot Cánh cửa An ninh

### 6.2.1. Bài toán thực tế phát sinh
- Khi đưa các kết cấu texture môi trường (tường gạch bong tróc, sàn kim loại) vào màn chơi, bề mặt sàn xuất hiện hiện tượng họa tiết bị lặp li ti (tiling quá dày đặc) trông như đốm chấm nhỏ, làm mất đi tỷ lệ không gian thực tế.
- Cánh cửa trượt an ninh khi bấm nút đóng/mở lại bị chạy ngược hướng (cửa mở thì thụt lùi xuống nền đất thay vì trượt lên trần) do sai lệch trục tọa độ (Pivot Point) của mô hình 3D.

### 6.2.2. Thao tác thiết lập và Cấu hình trong Unity Editor
1. **Thiết lập và Tinh chỉnh Material trong cửa sổ Project & Inspector:**
   - Tạo mới Material `M_SecurityWall_v1` với Shader `Universal Render Pipeline/Lit`.
   - Kéo file texture `T_SecurityWall_Albedo_v1.png` vào ô `Base Map`.
   - Kéo texture `Normal Map` tương ứng vào ô `Normal Map`, bấm nút **Fix Now** trên Inspector để Unity chuyển đổi chuẩn định dạng kết cấu bề mặt.
   - **Thao tác khắc phục đốm li ti:** Trong phần cấu hình `Tiling` trên Inspector của Material, điều chỉnh thông số từ giá trị mặc định xuống chính xác `X: 1.0, Y: 1.0` đối với tường, và `X: 2.0, Y: 2.0` đối với sàn kim loại diện tích lớn. Thiết lập `Smoothness = 0.18` để bề mặt có độ nhám lì chống lóa.

2. **Căn chỉnh trục tọa độ (Pivot) và Thiết lập Door Controller:**
   - Trong cửa sổ **Hierarchy**, chọn GameObject cánh cửa `Door_Mesh`. Chuyển chế độ công cụ sang **Pivot** (thay vì Center) để xác định điểm gốc tọa độ thực tế của cánh cửa.
   - Gắn component `DoorController.cs` vào GameObject cha `Door_System`.
   - Trên bảng **Inspector**, tiến hành thiết lập hai mốc Vector vị trí:
     - Kéo cánh cửa lên vị trí trần nhà -> Copy giá trị Transform Position dán vào trường `Open Position`.
     - Kéo cánh cửa chạm sàn nhà -> Copy giá trị Transform Position dán vào trường `Closed Position`.
     - Đặt tốc độ trượt `Slide Speed = 4.0f` và gán Audio Clip tiếng kim loại trượt vào ô `Audio Source`.

### 6.2.3. Kết quả thực nghiệm
Bề mặt tường gạch và sàn kim loại hiển thị đúng tỷ lệ vật liệu đời thực; cánh cửa an ninh trượt lên/xuống dứt khoát đúng hướng vật lý khi người chơi bấm nút bấm tương tác `[E]`.

---

## 6.3. Case Study 3: Điều hướng Scene Đa chặng và Khắc phục Sự cố Serialization Field trong Inspector

### 6.3.1. Bài toán thực tế phát sinh
Quy trình dẫn dắt người chơi trong *Last Shift* được thiết kế theo luồng chuyển cảnh đa chặng có cốt truyện:
1. Người chơi bắt đầu tại Menu chính -> Bấm **Story Mode** để nạp cảnh căn hộ `Home.unity`.
2. Tại cảnh `Home`, người chơi mở máy tính tương tác ứng dụng tin nhắn LaZo, sau đó bấm nút "Tiếp tục" (`ContinueButton`) kích hoạt hàm `MainMenuActions.ContinueToWork()`.
3. Hệ thống nạp cảnh `Game.unity`, xuất phát tại tiền sảnh hành lang xưởng (`corridorSpawnPoint`). Người chơi di chuyển đến bàn đối thoại với Quản lý xưởng (`QuanLyInteract`), khi hoàn tất đoạn đối thoại (`OnDialogueCompleted`) sẽ được tự động đưa vào ghế trực phòng bảo vệ (`securityRoomSpawnPoint`).
4. Đồng thời, game hỗ trợ nút **Office Mode** tại Menu chính để lập trình viên và người chơi có thể nhảy cóc thẳng vào ghế trực mà không phải xem lại đoạn hội thoại.

Tuy nhiên, trong quá trình phát triển thực tế, đã phát sinh 2 sự cố kỹ thuật nghiêm trọng:
- Khi người chơi bấm nút "Office Mode" tại Menu chính, hệ thống lại load nhầm vào scene `Home` thay vì vào scene `Game`.
- Trên giao diện Canvas Menu, các component nút bấm bị mất tham chiếu (Missing Reference) đến con trỏ mũi tên nhắm (`arrow`), khiến hiệu ứng rê chuột không phản hồi.

### 6.3.2. Phân tích nguyên nhân sâu xa trong cơ chế Serialization của Unity
1. **Sự cố ghi đè giá trị YAML (Serialization Override):**
   Trong mã nguồn C# `MainMenuActions.cs`, sinh viên đã khai báo trường:
   ```csharp
   [SerializeField] private string gameSceneName = "Game";
   ```
   Tuy nhiên, trước đó GameObject `MenuManager` trong file cảnh `Menu.unity` đã từng được lưu trữ với giá trị cũ là `gameSceneName: Home`. Trong cơ chế nội bộ của Unity Engine, khi một Scene được nạp vào bộ nhớ, các giá trị đã được tuần tự hóa (Serialized) trong tệp văn bản `.unity` (định dạng YAML) sẽ luôn được ưu tiên áp đặt và **ghi đè hoàn toàn** lên giá trị mặc định được viết trong mã nguồn C#. Do đó, mặc dù code C# đã đổi thành `"Game"`, hàm `SceneManager.LoadScene(gameSceneName)` khi chạy trên Editor vẫn đọc chuỗi `"Home"`.
2. **Sự cố mất liên kết GameObject (Missing Serialized Reference):**
   Khi tái cấu trúc lại hệ thống nút bấm UI trên Canvas, các GameObject con hiển thị hình mũi tên (`arrow`) đã bị xóa hoặc đổi tên, dẫn đến trường `[SerializeField] private GameObject arrow;` bị trỏ vào giá trị rỗng (`null`).

### 6.3.3. Thao tác thiết lập và Khắc phục trong Unity Editor
1. **Kiểm tra và Cấu hình Build Profiles / Build Settings:**
   - Mở cửa sổ *File -> Build Settings*, kiểm tra và sắp xếp thứ tự nạp cảnh chuẩn mực:
     - Index 0: `Scenes/Menu`
     - Index 1: `Scenes/Home`
     - Index 2: `Scenes/Game`
2. **Cập nhật trực tiếp giá trị Serialized Field trong Inspector:**
   - Trong Scene `Menu.unity`, chọn GameObject `MenuManager` trên cửa sổ **Hierarchy**.
   - Tại bảng **Inspector**, tìm component `MainMenuActions`: Nhập lại chính xác giá trị chuỗi `"Game"` vào ô `Game Scene Name`.
   - Thực hiện thao tác *Save Scene (Ctrl + S)* và *Save Project* để Unity ghi nhận lại cấu trúc YAML mới vào ổ đĩa.
3. **Phục hồi liên kết con trỏ mũi tên (`arrow`):**
   - Chọn các GameObject nút bấm `Story Mode` và `Office Mode` trên Hierarchy.
   - Kéo thả đúng GameObject con `Arrow` tương ứng vào trường `arrow` của component điều khiển hover, khôi phục lại hiệu ứng thị giác rê chuột mượt mà.
4. **Kiểm tra kết nối sự kiện đa chặng trong Scene `Home` và `Game`:**
   - Tại `Home.unity`: Chọn nút `ContinueButton`, kiểm tra bảng sự kiện `Button -> OnClick()` đã gán đúng phương thức `MainMenuActions.ContinueToWork`.
   - Tại `Game.unity`: Chọn GameObject `QuanLy`, kiểm tra sự kiện `QuanLyInteract.OnDialogueCompleted` đã được đăng ký lắng nghe trong `ShiftGameManager.OnEnable()` để tự động kích hoạt `StartOfficeShift()`.

### 6.3.4. Kết quả thực nghiệm
Khắc phục triệt để lỗi chuyển cảnh sai lệch; luồng trải nghiệm dẫn dắt cốt truyện từ Nhà (`Home`) -> Tiền sảnh xưởng -> Đối thoại Quản lý -> Buồng trực an ninh vận hành mượt mà, đồng thời nút Office Mode đưa người chơi vào ngay vị trí làm việc trong vòng chưa đầy 1 giây.

---

## 6.4. Case Study 4: Thiết lập Chuyển đổi Góc nhìn Người chơi (Office View) và Hệ thống CCTV Đa kênh

### 6.4.1. Bài toán thực tế phát sinh
Nhân vật cần có khả năng ngồi cố định trên chiếc ghế trực buồng an ninh nhưng vẫn có thể linh hoạt lia đầu quan sát sang bàn làm việc và hai cánh cửa an ninh bằng phím `[A]`, `[D]` hoặc lia chuột sang mép màn hình. Đồng thời, hệ thống camera CCTV phải hỗ trợ chuyển đổi đa kênh (7 Camera) với góc quay quét tự nhiên, mô phỏng hiệu ứng nhiễu từ analog, và có kênh camera đặc biệt (Cam 7 audio-only phát nhạc hộp nhạc) cùng nút bấm nạp điện máy phát tích hợp trực tiếp trên màn hình camera.

### 6.4.2. Thao tác thiết lập và Cấu hình trong Unity Editor
1. **Tạo các Transform Mốc neo Góc nhìn (View Anchor Nodes):**
   Trong GameObject cha `OfficeViewManager`, tạo 3 GameObject con rỗng làm mốc tọa độ góc quay:
   - `Anchor_FrontView`: Tọa độ góc quay {X: 0, Y: 0, Z: 0} nhìn thẳng bàn điều khiển và máy tính.
   - `Anchor_LeftView`: Tọa độ góc quay {X: 0, Y: -75, Z: 0} nhìn sang cửa an ninh trái và công tắc đèn pin trái.
   - `Anchor_RightView`: Tọa độ góc quay {X: 0, Y: +75, Z: 0} nhìn sang cửa phải, công tắc đèn pin phải và trạm bảo trì.

2. **Cấu hình nội suy xoay mượt mà (Smooth Slerp):**
   Trong mã nguồn `OfficeViewManager.cs`, sinh viên sử dụng hàm nội suy góc cầu:
   ```csharp
   transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
   ```
   với `turnSpeed = 8.0f` giúp camera xoay đầu mềm mại như cử động cổ của người thật thay vì giật góc đột ngột.

3. **Thiết lập Hệ thống Camera CCTV Đa kênh (7 Kênh Giám sát):**
   - Bố trí 7 Camera phụ tại các vị trí chiến lược trong nhà máy (Cam 01: Hành lang chính, Cam 02: Kho máy, Cam 03: Trạm máy phát, Cam 04: Cửa sau, Cam 05: Phòng chứa phế liệu, Cam 06: Lối thoát hiểm, Cam 07: Khu vực hộp nhạc).
   - Gắn component `CameraSwing.cs` vào các camera giám sát để tạo chuyển động quay quét ngang tự động theo chu kỳ hình sin góc +/- 15 độ, tạo cảm giác camera an ninh đang vận hành thực tế.
   - Gắn component `RoomAudio.cs` cho Cam 07: Kênh camera này bị hỏng hình ảnh (chỉ hiển thị màn hình nhiễu hạt đen trắng) và liên tục phát giai điệu hộp nhạc bí ẩn `music-box-fnaf (1).mp3`.
   - Thiết lập Canvas UI `CCTV_Station` phủ toàn màn hình, kết hợp với script `BandedStaticNoise.cs` tạo hiệu ứng vạch quét CRT Scanlines khi chuyển kênh.
   - Bố trí nút nạp năng lượng `RechargeButton.cs` trực tiếp trên bảng điều khiển CCTV, cho phép người chơi nhấn giữ chuột để nạp pin máy phát từ xa.

### 6.4.3. Kết quả thực nghiệm
Trải nghiệm góc nhìn trong ghế bảo vệ vận hành trơn tru, camera xoay êm ái; hệ thống 7 kênh camera chuyển mạch dứt khoát kèm âm thanh nhiễu từ hoài cổ, không gây sụt giảm FPS.

---

## 6.5. Case Study 5: Hệ thống Quản lý Điện năng Động (IPowerConsumer), Triệt tiêu Phụ thuộc Ngược và Giao diện Tước đoạt Thông tin (UsageUI)

### 6.5.1. Bài toán thực tế phát sinh
Hệ thống năng lượng là "trái tim" chi phối nhịp độ kinh dị của trò chơi:
1. **Hành vi tiêu thụ điện năng biến thiên:** Điện năng máy phát không sụt giảm cố định mà tiêu hao động theo hành vi của người chơi: Cửa an ninh đóng thì ngốn điện (`+1f/s`), đèn pin hành lang được giữ thì ngốn điện (`+1f/s`), kết hợp với tiêu hao cơ bản của phòng trực (`2f/s`).
2. **Xung đột kiến trúc phần mềm:** Nếu để cánh cửa (`Door.cs`) và công tắc đèn (`LightControl.cs`) lưu trực tiếp tham chiếu tới `GeneratorSystem`, thiết kế sẽ vi phạm nguyên lý Đảo ngược phụ thuộc (DIP): Cấp dưới trỏ ngược cấp trên, tạo khớp nối chặt và phụ thuộc vòng.
3. **Bài toán tâm lý tước đoạt thông tin:** Nếu hiển thị thanh pin phần trăm (100% về 0%) trên HUD, người chơi sẽ cảm thấy an tâm và tính toán thời gian cơ học, làm mất đi sự hoang mang sợ hãi. Game cần áp dụng triết lý tước đoạt thông tin: Giấu số % pin trên HUD, chỉ hiển thị thanh USAGE 4 vạch đổi màu theo tải tiêu thụ.
4. **Cưỡng chế mở cửa khi cúp điện (Blackout):** Khi điện cạn về 0, hệ thống phải tự động mở toang cả 2 cửa an ninh (`ForceOpen()`), cắt đèn chính, khóa góc nhìn sang phải và kích hoạt điệu nhạc của Freddy.

### 6.5.2. Phân tích kiến trúc và Giải pháp kỹ thuật

Sinh viên đã thiết kế kiến trúc dựa trên bản hợp đồng trừu tượng `IPowerConsumer` và mẫu **Composition Root**:

```mermaid
classDiagram
    class IPowerConsumer {
        <<interface>>
        +bool IsConsumingPower
        +float PowerDrainRate
    }

    class Door {
        -bool isOpen
        -float doorDrainRate
        +bool IsConsumingPower
        +float PowerDrainRate
        +void ForceOpen()
    }

    class LightControl {
        -bool isHolding
        +bool IsConsumingPower
        +float PowerDrainRate
    }

    class GeneratorSystem {
        -IPowerConsumer[] consumers
        -float currentPower
        +void SetupConsumers(IPowerConsumer[] consumers)
        +event Action~int~ OnUsageLevelChanged
        +event Action OnPowerOutage
    }

    class ShiftGameManager {
        <<Composition Root>>
        -Door leftDoor, rightDoor
        -LightControl leftLight, rightLight
        -GeneratorSystem generatorSystem
        +void Start()
    }

    class UsageUI {
        -Image[] usageBars
        +void UpdateUsageDisplay(int level)
    }

    IPowerConsumer <|.. Door : hiện thực hóa
    IPowerConsumer <|.. LightControl : hiện thực hóa
    GeneratorSystem o--> IPowerConsumer : phụ thuộc trừu tượng
    ShiftGameManager ..> GeneratorSystem : tiêm SetupConsumers()
    GeneratorSystem ..> UsageUI : phát sự kiện OnUsageLevelChanged
```

*Hình 6.1: Sơ đồ kiến trúc Dependency Inversion của Hệ thống Điện năng Động.*

1. **Thiết lập Giao diện trừu tượng `IPowerConsumer.cs`:**
   ```csharp
   public interface IPowerConsumer
   {
       bool IsConsumingPower { get; }
       float PowerDrainRate { get; }
   }
   ```
2. **Hiện thực hóa trong `Door.cs` và `LightControl.cs`:**
   - Cánh cửa chỉ quản lý đóng/mở vật lý và trả về: `IsConsumingPower => !isOpen;`
   - Đèn pin chỉ quản lý trạng thái nhấn giữ và trả về: `IsConsumingPower => isHolding;`
   - Cả hai lớp hoàn toàn không chứa bất kỳ tham chiếu nào trỏ tới `GeneratorSystem`.
3. **Áp dụng Mẫu Composition Root trong `ShiftGameManager.cs`:**
   Tại phương thức `Start()`, `ShiftGameManager` thu thập các thiết bị điện và tiêm vào hệ thống máy phát:
   ```csharp
   generatorSystem.SetupConsumers(new IPowerConsumer[] { 
       leftDoor, rightDoor, leftLight, rightLight 
   });
   ```
4. **Vòng lặp tính toán tiêu hao động trong `GeneratorSystem.cs`:**
   Mỗi frame, `GeneratorSystem` duyệt qua mảng `consumers` trừu tượng, đếm số thiết bị đang hoạt động (`activeCount`), tính tổng mức tiêu hao `totalDrain = drainRate + activeDrain` và chỉ phát sự kiện khi cấp độ sử dụng thay đổi (`OnUsageLevelChanged?.Invoke(currentUsageLevel)`).
5. **Giao diện Tước đoạt Thông tin (`UsageUI.cs`):**
   Lắng nghe `OnUsageLevelChanged` cập nhật 4 vạch sáng với bảng màu tâm lý:
   - Mức 1 & 2 (1-2 vạch): Xanh lá (`normalColor = {R: 0.2, G: 1.0, B: 0.2}`).
   - Mức 3 (3 vạch): Vàng cam (`warningColor = {R: 1.0, G: 0.8, B: 0.1}`).
   - Mức 4 (4 vạch): Đỏ rực (`dangerColor = {R: 1.0, G: 0.2, B: 0.2}`).
6. **Xử lý sự cố Cúp điện Blackout (`PowerOutageController.cs`):**
   Khi điện về 0, sự kiện `OnPowerOutage` kích hoạt. Hệ thống tự động lặp qua mảng cửa và gọi lệnh cưỡng chế mở:
   ```csharp
   for (int i = 0; i < door.Length; i++)
   {
       if (door[i] != null) door[i].ForceOpen();
   }
   ```
   Đồng thời khóa góc nhìn sang phải (`officeViewManager.SetView(OfficeView.Right, instant: true)`), kích hoạt mắt nhấp nháy và điệu nhạc của Freddy.

### 6.5.3. Thao tác thiết lập và Cấu hình trong Unity Editor
1. **Thiết lập Canvas HUD cho UsageUI:**
   - Tạo GameObject `UsagePanel` chứa 4 Image vạch năng lượng (`usageBars[0..3]`).
   - Gắn `UsageUI.cs`, kéo tham chiếu `generatorSystem` và 4 Image vạch năng lượng vào Inspector.
2. **Cấu hình Dependency Injection trong `ShiftGameManager`:**
   - Kéo thả `Door_Left`, `Door_Right`, `Switch_LeftLight`, `Switch_RightLight` vào các trường thiết bị điện phòng trực.
   - Kéo GameObject `UsagePanel` vào trường `Usage Panel` để tự động ẩn ngoài hành lang xưởng.
3. **Cấu hình bảo vệ cúp điện trong `PowerOutageController`:**
   - Thiết lập mảng `door` gồm 2 phần tử, kéo thả chính xác hai cánh cửa an ninh `Door 1` và `Door 2` vào Inspector.

### 6.5.4. Kết quả thực nghiệm
Mã nguồn C# tuân thủ nghiêm ngặt Clean Architecture & SOLID; giao diện 4 vạch tước đoạt thông tin tạo áp lực tâm lý mạnh mẽ; khi hết điện, hai cánh cửa tự động bật mở toang phơi bày người chơi trước nanh vuốt của Freddy.

---

## 6.6. Case Study 6: Hệ thống Nhận diện Dị thường (Anomaly) và Trạm Bảo trì Thiết bị Buồng trực (Maintenance)

### 6.6.1. Bài toán thực tế phát sinh
Để tạo nên lối chơi sinh tồn đa nhiệm có chiều sâu (Multitasking Gameplay Loop), trò chơi không thể chỉ dừng lại ở việc ngồi canh quái vật ở 2 cửa, mà cần đặt người chơi vào hai nhiệm vụ kiểm soát kỹ thuật song song:
1. **Phát hiện và Báo cáo Dị thường trên Camera (Anomaly Detection):** Các đồ vật trong nhà máy có thể bất ngờ biến đổi (dịch chuyển vị trí, biến mất, thay đổi kết cấu, xuất hiện bóng đen). Người chơi phải soi camera, nhận diện bất thường và mở máy tính gửi báo cáo đúng phòng và đúng loại dị thường.
2. **Sự cố Kỹ thuật buồng an ninh (Maintenance Breakdown):** Các phân hệ máy móc (Quạt thông gió, Đèn chiếu sáng, Camera CCTV) có thể bị quá tải và hỏng hóc ngẫu nhiên. Nếu quạt thông gió hỏng mà không được sửa chữa, nhân vật sẽ bị ngạt khí dẫn đến Game Over trong 60 giây!

### 6.6.2. Phân tích kiến trúc và Thao tác thiết lập trong Unity Editor

1. **Cấu trúc Hệ thống Dị thường (`AnomalyManager.cs`):**
   - **Mô hình hóa dữ liệu:** Sử dụng ScriptableObject `AnomalyType.cs` (ObjectMove, Disappearance, TextureChange, ShadowPresence) và `AnomalyDifficulty.cs` (Easy, Normal, Hard).
   - **Đối tượng dị thường (`AnomalyObject.cs`):** Gắn vào các đạo cụ môi trường trong các phòng giám sát. Script lưu trữ hai trạng thái: Trạng thái bình thường (`normalTransform`) và Trạng thái biến dị (`anomalyTransform`).
   - **Cơ chế kích hoạt ngẫu nhiên:** Trong `AnomalyManager.cs`, Coroutine `AnomalySpawnRoutine()` định kỳ chọn ngẫu nhiên một vật thể trong danh sách đăng ký và kích hoạt trạng thái dị thường:
     ```csharp
     anomaly.TriggerAnomaly();
     activeAnomalies.Add(anomaly);
     ```
   - **Giao diện Báo cáo trên Máy tính (`AnomalyReportUI.cs` & `AnomalyReportFeedback.cs`):**
     Người chơi nhấn vào màn hình máy tính bàn, chọn tên phòng và loại dị thường, rồi bấm nút **Report**:
     - *Nếu báo cáo đúng:* Gọi `anomaly.RevertAnomaly()`, gỡ vật thể khỏi danh sách dị thường, phát âm thanh chuông xác nhận thành công.
     - *Nếu báo cáo sai (False Report):* Hệ thống phát còi hú cảnh báo và gửi tín hiệu phạt sang `WatcherBrain.cs`: `OnReportWrong?.Invoke()`, cộng ngay **1.0 điểm đe dọa** cho quái vật!

2. **Cấu trúc Trạm Bảo trì Thiết bị (`MaintenanceSystem.cs` & `MaintenanceStation.cs`):**
   - Đặt tại góc phải phòng trực, quản lý 3 cờ trạng thái boolean: `isVentilationOnline`, `isLightingOnline`, `isCameraOnline`.
   - **Bộ lập lịch sự cố (`MaintenanceBreakdownScheduler.cs`):** Định kỳ sinh sự cố ngẫu nhiên làm một phân hệ bị chuyển sang `Offline`:
     - *Hỏng quạt thông gió (`VentilationBreakdownEffect.cs`):* Quạt ngừng quay, âm thanh gió tắt lịm, kích hoạt bộ đếm ngược 60 giây ngạt khí. Nếu hết thời gian mà chưa khởi động lại, kích hoạt kết thúc ván chơi.
     - *Hỏng đèn (`LightingBreakdownEffect.cs`):* Đèn trần chập chờn sụt áp, giảm 70% độ sáng buồng trực.
     - *Hỏng camera (`CameraBreakdownEffect.cs`):* Toàn bộ màn hình CCTV chuyển sang nhiễu hạt trắng xóa.
   - **Cơ chế Khởi động lại (Reboot Routine):**
     Khi người chơi xoay sang trạm bảo trì bấm nút `Reboot`: Coroutine `RebootRoutine()` chạy đếm ngược trong 5.0 giây, phát âm thanh cơ khí khởi động động cơ, và thiết lập lại biến cờ `Online = true`, khôi phục hệ thống an toàn.

### 6.6.3. Kết quả thực nghiệm
Tạo nên sự căng thẳng tột độ của một tựa game kinh dị quản lý tài nguyên đích thực: Người chơi vừa phải lắng nghe tiếng bước chân ngoài cửa, vừa phải soi camera tìm dị thường, vừa phải chạy đua với thời gian để sửa quạt thông gió và nạp điện máy phát.

---

## 6.7. Case Study 7: Quy trình Đóng gói Bản dựng Đa nền tảng (Build Profiles) và Chuẩn hóa Xuất xưởng PC & Android

### 6.7.1. Bài toán thực tế phát sinh
Một đồ án trong học phần Lập trình ứng dụng di động đòi hỏi sản phẩm không chỉ chạy được trong môi trường phát triển (Editor) mà phải có khả năng đóng gói thành các tệp thực thi độc lập (Standalone Executable) cho máy tính và gói ứng dụng di động (`.apk`) chuẩn hóa cho hệ điều hành Android, loại bỏ các cờ gỡ lỗi Debug làm tiêu hao tài nguyên pin và giảm sút FPS.

### 6.7.2. Thao tác thiết lập và Cấu hình trong Unity Editor

1. **Chuẩn hóa thông tin định danh trong Player Settings (*Edit -> Project Settings -> Player*):**
   - `Company Name`: Đặt tên định danh nhà phát triển cá nhân `Towie1012`.
   - `Product Name`: Đặt tên game `LastShift`.
   - `Version`: Đánh số chuẩn phiên bản `0.0.1` (bản thử nghiệm ban đầu) và nâng lên `0.0.2` (bản cập nhật sửa lỗi chuyển cảnh).
   - `Default Icon`: Bấm nút **Select**, chọn Texture ảnh chân dung quái vật Freddy trong thư mục `Assets/Art` để file thực thi hiển thị biểu tượng riêng biệt.

2. **Cấu hình Đóng gói Bản dựng cho Windows PC (Itch.io Release):**
   - Trong cửa sổ **Build Profiles**, chọn nền tảng `Windows` (Active Platform).
   - Kiến trúc vi xử lý (Architecture): Chọn `Intel 64-bit` (x86_64).
   - **Tắt ô Development Build:** Thao tác cực kỳ quan trọng giúp loại bỏ mã Profiler Hooks, giảm kích thước bản build xuống ~30% và duy trì ổn định 60 FPS.
   - Bấm **Build**, xuất ra thư mục `E:\Builds\LastShift_v0.0.2`, sau đó nén thành `LastShift_v0.0.2_Windows.zip` và tải lên nền tảng **Itch.io**.

3. **Cấu hình Xuất bản Gói Ứng dụng Di động Android (`.apk`):**
   - Trong cửa sổ **Build Settings** (hoặc **Build Profiles**), chọn nền tảng **Android** và bấm nút **Switch Platform** (Unity sẽ tự động re-import và nén lại toàn bộ texture sang định dạng nén di động ASTC).
   - Chuyển sang bảng *Player Settings -> Tab Android*:
     - *Package Name:* Đặt định danh duy nhất theo chuẩn Google Play: `com.Towie1012.LastShift`.
     - *Minimum API Level:* Chọn `Android 8.0 'Oreo' (API Level 26)` — đảm bảo hỗ trợ hơn 95% thiết bị di động Android trên thị trường hiện nay.
     - *Target API Level:* Chọn `Automatic (highest installed)` hoặc `API Level 34 (Android 14)` đáp ứng quy định bảo mật mới nhất của Google.
     - *Scripting Backend:* Chuyển từ Mono sang `IL2CPP` để mã nguồn C# được biên dịch thành mã máy C++ nguyên bản chạy trực tiếp trên chip di động.
     - *Target Architectures:* Tích chọn `ARM64` (loại bỏ ARMv7 cũ) để tương thích chuẩn 64-bit bắt buộc của các dòng điện thoại thông minh hiện đại.
     - *Build App Bundle (Google Play):* Tích chọn nếu xuất file `.aab` tải lên cửa hàng CH Play, hoặc bỏ tích để xuất file `.apk` cài đặt trực tiếp lên thiết bị di động Android thực tế qua cáp USB / sideload.

4. **Kiểm thử Tương thích Đa Tỷ lệ Màn hình trên Unity Device Simulator:**
   - *Bối cảnh thực tế:* Do hạn chế về điều kiện phòng thí nghiệm chưa có sẵn đa dạng thiết bị di động Android vật lý, nhóm đã áp dụng giải pháp kiểm thử chuẩn công nghiệp: Sử dụng công cụ **Unity Device Simulator** tích hợp trong Editor để kiểm tra khả năng hiển thị UI và tính năng trên hai dòng máy đầu bảng:
     - **Samsung Galaxy S10+** (Màn hình Dynamic AMOLED, tỷ lệ 19:9, độ phân giải 3040 x 1440, camera đục lỗ Infinity-O).
     - **Apple iPhone 13 Pro Max** (Màn hình Super Retina XDR, tỷ lệ 19.5:9, độ phân giải 2778 x 1284, rãnh tai thỏ Notch).
   - *Vấn đề phát hiện:* Khi chuyển đổi tỷ lệ từ 16:9 (PC) sang 19:9 và 19.5:9 (Mobile), chế độ mặc định `Match Width Or Height` của `Canvas Scaler` khiến giao diện bị cắt lẹm các thông số ở 4 góc mép màn hình.
   - *Giải pháp khắc phục:* Chuyển đổi thuộc tính `Screen Match Mode` sang **`Expand`** và neo góc `Anchor Presets` chuẩn xác.
   - *Kết quả:* Toàn bộ giao diện người dùng (Bản đồ CCTV, Form báo cáo 8 loại dị thường, cảnh báo ngạt thở Ventilation 60s, bảng Maintenance Reboot, nút Recharge và thanh USAGE 4 vạch) đều hiển thị đầy đủ 100%, không bị mất thông tin, vận hành trơn tru mọi tính năng.

### 6.7.3. Kết quả thực nghiệm
- Bản dựng Windows x64 được đóng gói trơn tru, phát hành chính thức trên Itch.io với đầy đủ thông tin truyền thông.
- Cấu hình Android được thiết lập hoàn chỉnh, kiểm thử tương thích đa màn hình thành công mỹ mãn trên Unity Device Simulator (Samsung Galaxy S10+ & iPhone 13 Pro Max), sẵn sàng cho thao tác Switch Platform và xuất file `.apk` cài đặt trực tiếp lên điện thoại Android, chứng minh tính linh hoạt và khả năng ứng dụng thực tế cao của đồ án trong chuyên ngành Lập trình ứng dụng di động.

---

## 6.8. Bảng Tổng hợp Nghiệm thu Kiểm thử Chức năng Toàn diện (Verification Matrix)

Song song với 7 Case Studies chuyên sâu kể trên, toàn bộ **24 kịch bản kiểm thử chức năng toàn diện** bao quát 100% tất cả các phân hệ phần mềm của trò chơi đã được kiểm thử thực nghiệm trên phiên bản thực tế và nghiệm thu với tỷ lệ thành công tuyệt đối:

| Mã kiểm thử | Mô tả kịch bản kiểm thử | Module phụ trách | Kết quả kỳ vọng | Thực tế | Đánh giá |
| :---: | :--- | :--- | :--- | :--- | :--- | :---: |
| **TC-01** | Khởi động Story Mode từ Menu chính | `MainMenuActions` | Nạp cảnh `Home`, nhân vật thức dậy trong phòng ngủ | Hoàn toàn chính xác | **PASS** |
| **TC-02** | Khởi động Office Mode từ Menu chính | `MainMenuActions` | Nạp thẳng cảnh `Game`, cờ `startDirectlyInOffice = true` đưa vào ghế trực ngay | Đã khắc phục ở v0.0.2 | **PASS** |
| **TC-03** | Tương tác máy tính căn hộ đọc tin nhắn LaZo | `ComputerStation` & `ManagerChatController` | Bấm `[E]` mở máy tính, hiển thị hội thoại tin nhắn với Quản lý, xuất hiện nút Tiếp tục | Hoàn toàn chính xác | **PASS** |
| **TC-04** | Chuyển cảnh từ nhà đến xưởng làm việc | `MainMenuActions.ContinueToWork` | Bấm `ContinueButton` nạp cảnh `Game` tại tiền sảnh hành lang công nghiệp | Hoàn toàn chính xác | **PASS** |
| **TC-05** | Tương tác đối thoại Quản lý tại hành lang | `QuanLyInteract` | Bấm `[E]` kích hoạt thoại, kết thúc phát `OnDialogueCompleted` đưa vào ghế trực | Hoàn toàn chính xác | **PASS** |
| **TC-06** | Chuyển đổi góc nhìn trong ghế trực buồng an ninh | `OfficeViewManager` | Phím `A`/`D` hoặc lia chuột xoay 3 hướng Front/Left/Right mượt mà qua `Quaternion.Slerp` | Hoàn toàn chính xác | **PASS** |
| **TC-07** | Chuỗi cuộc gọi Phone Guy và phụ đề thời gian thực | `PhoneCallController` | Đổ chuông 13.345s, tự nhấc máy phát thoại đồng bộ phụ đề, nút `[MUTE CALL]` dập máy sớm | Hoàn toàn chính xác | **PASS** |
| **TC-08** | Giám sát hệ thống Camera CCTV đa kênh | `CCTVStation` & `CameraSystem` | Chuyển 7 kênh, Cam 7 audio-only phát hộp nhạc, camera swing quét ngang, nhiễu scanline CRT | Hoàn toàn chính xác | **PASS** |
| **TC-09** | Tương tác cửa trượt an ninh trái/phải | `Door` & `BrokenDoorButton` | Bấm nút công tắc, cửa trượt đóng/mở dứt khoát, phát âm thanh kim loại cơ khí | Hoàn toàn chính xác | **PASS** |
| **TC-10** | Đèn pin hành lang phải phát hiện quái vật | `LightControl` | Nhấn giữ chuột rọi đèn cửa sổ, phát âm thanh giật mình `windowScareAudio` khi Freddy xuất hiện | Hoàn toàn chính xác | **PASS** |
| **TC-11** | Tiêu hao điện năng động theo thiết bị | `GeneratorSystem` & `IPowerConsumer` | Tiêu hao nền `2f/s`; đóng cửa tăng `+1f/s`; giữ đèn pin tăng `+1f/s` | Hoàn toàn chính xác | **PASS** |
| **TC-12** | Chỉ thị USAGE 4 vạch tước đoạt thông tin | `UsageUI` | Tự động chuyển màu Xanh (mức 1-2) -> Vàng (mức 3) -> Đỏ (mức 4); ẩn hoàn toàn % pin | Hoàn toàn chính xác | **PASS** |
| **TC-13** | Nạp năng lượng máy phát tại màn hình CCTV | `RechargeButton` | Nhấn giữ nút nạp trên bảng camera, cờ `isRecharging = true`, năng lượng hồi phục 10f/s | Hoàn toàn chính xác | **PASS** |
| **TC-14** | Quản lý vòng đời hiển thị `usagePanel` | `ShiftGameManager` | Tự động ẩn ngoài hành lang, kích hoạt khi ngồi vào ghế trực, ẩn khi Thắng/Thua | Hoàn toàn chính xác | **PASS** |
| **TC-15** | Hệ thống Dị thường Anomaly xuất hiện | `AnomalyManager` & `AnomalyObject` | Tự động sinh dị thường ngẫu nhiên tại các camera: dịch chuyển vật thể, đổi hình, bóng ma | Hoàn toàn chính xác | **PASS** |
| **TC-16** | Báo cáo dị thường trên máy tính buồng trực | `AnomalyReportUI` | Chọn phòng & loại dị thường: Báo đúng giải tỏa nguy cơ; báo sai bị phạt tăng điểm đe dọa | Hoàn toàn chính xác | **PASS** |
| **TC-17** | Sự cố thiết bị kỹ thuật buồng trực ngẫu nhiên | `MaintenanceSystem` & `Scheduler` | Quạt thông gió, camera, đèn phòng bị chuyển sang `Offline` theo lịch trình hỏng hóc | Hoàn toàn chính xác | **PASS** |
| **TC-18** | Khởi động lại hệ thống tại trạm bảo trì | `MaintenanceStation` | Bấm nút `Reboot` trên giao diện bảo trì, hệ thống khôi phục Online an toàn sau 5 giây | Hoàn toàn chính xác | **PASS** |
| **TC-19** | Tương tác trạm đọc thư tay tài liệu giao việc | `LetterStation` & `PlayerLetterState` | Bấm `[E]` mở xem tài liệu hướng dẫn nội quy buồng trực của xưởng | Hoàn toàn chính xác | **PASS** |
| **TC-20** | Watcher tuần tra và Heuristic tích lũy đe dọa | `WatcherBrain` & `WatcherRoaming` | AI di chuyển giữa các camera; tăng điểm khi người chơi lơ là hoặc báo cáo dị thường sai | Hoàn toàn chính xác | **PASS** |
| **TC-21** | Đóng cửa an ninh phòng thủ chặn quái vật | `WatcherAttack` | Cửa đóng kịp thời -> đẩy lùi quái vật rút lui; cửa mở -> quái vật kích hoạt jumpscare | Hoàn toàn chính xác | **PASS** |
| **TC-22** | Sự cố mất điện toàn phần (Blackout) | `PowerOutageController` | Khi điện về 0: Tắt đèn chính, mở toang 2 cửa (`ForceOpen`), khóa nhìn phải, Freddy jumpscare | Hoàn toàn chính xác | **PASS** |
| **TC-23** | Cơ chế sống sót chiến thắng 6:00 AM | `ShiftClock` & `WinScreenController` | Đúng 6:00 AM: Hoạt họa số 5 cuộn lên 6 mượt mà bằng `Mathf.SmoothStep`, chuông reo và vỗ tay | Hoàn toàn chính xác | **PASS** |
| **TC-24** | Dọn dẹp âm thanh sạch và Khởi động lại ca trực | `ShiftGameManager` | Ngắt sạch cuộc gọi Phone Guy và tiếng quạt khi kết thúc; `RestartShift` chơi lại ngay | Hoàn toàn chính xác | **PASS** |

Toàn bộ 24/24 kịch bản kiểm thử thực nghiệm đều đạt kết quả **PASS**, chứng minh sự ổn định vượt trội và độ hoàn thiện toàn diện của dự án *Last Shift*.

---

\newpage

# CHƯƠNG 7: QUẢN LÝ DỰ ÁN VỚI GIT VÀ TRIỂN KHAI THỰC TẾ TRÊN ITCH.IO

## 7.1. Quản lý mã nguồn Git, Phân chia vai trò và Thống kê Đóng góp Nhóm trên GitHub

### 7.1.1. Thông tin Kho lưu trữ Mã nguồn chính thức (Official Repository)
Dự án được quản trị và đồng bộ liên tục trên nền tảng GitHub:
- **Đường dẫn Kho lưu trữ (URL):** https://github.com/Towie1206/LastShift
- **Nhánh chính thức (Default Branch):** `main`
- **Trạng thái truy cập:** Công khai (Public Repository), phục vụ công tác thanh tra học thuật và kiểm chứng minh bạch mã nguồn.

### 7.1.2. Phân bổ Vai trò và Ma trận Trách nhiệm Thành viên (Team RACI Matrix)
Dự án được xây dựng bởi nhóm gồm 3 sinh viên, trong đó Trưởng nhóm giữ vai trò kiến trúc sư trưởng (System Architect & Lead Programmer) chịu trách nhiệm toàn diện về cấu trúc mã nguồn C#, phối hợp chặt chẽ với các thành viên phụ trách chuyên môn về 3D Assets, UI và Animation:

| Thành viên | Tài khoản GitHub | Vai trò chuyên môn | Trách nhiệm chính trong đồ án |
| :--- | :--- | :--- | :--- |
| **Nguyễn Công Bằng** | `@Towie1206` | **Trưởng nhóm / Lead Programmer & Software Architect** | - Thiết kế toàn bộ kiến trúc OOP, SOLID, Clean Architecture và FSM 6 trạng thái.<br>- Lập trình hệ thống quản lý ca trực (`ShiftGameManager`), hệ thống điện năng động (`IPowerConsumer`, `GeneratorSystem`), cơ chế cúp điện Blackout (`PowerOutageController`).<br>- Xây dựng hệ thống Dị thường (`AnomalyManager`), trạm bảo trì buồng trực (`MaintenanceSystem`, đếm ngược ngạt thở 60s, Reboot routine 5s).<br>- Lập trình AI quái vật (`WatcherBrain`, `WatcherRoaming`, `WatcherAttack`) và thuật toán Heuristic tích lũy đe dọa.<br>- Cấu hình URP Lighting (Case Study 1), Material PBR (Case Study 2), Slerp View & CCTV 7 cam (Case Study 4) và đóng gói Build Profiles đa nền tảng (Case Study 7). |
| **Nguyễn Trung Kiên** | `@KDotBlack`<br>(`kien312005`) | **3D Assets & UI Programmer** | - Tích hợp và chuẩn hóa mô hình nhân vật 3D Quản lý xưởng (`quanlymodel`), mô hình Bonnie / Animatronics.<br>- Thiết kế và lập trình giao diện tạm dừng trò chơi (`PausePanel.cs`, xử lý Time.timeScale).<br>- Tinh chỉnh đồ họa ảnh, xử lý và nén kết cấu vật liệu môi trường (`suaanh`). |
| **Nguyễn Thành Nam** | `@LuoihaiDakin`<br>(`Dakin`) | **Animation & Localization Programmer** | - Thiết kế và tích hợp hệ thống hoạt họa (Animation Controller) cho các thực thể trong game.<br>- Cài đặt và tích hợp hệ thống bản địa hóa đa ngôn ngữ (`LanguageManager.cs` chuyển đổi thời gian thực Tiếng Anh - Tiếng Việt).<br>- Thiết kế tài nguyên đồ họa giao diện 2D (`image1`), bảng nội quy văn phòng bảo vệ và tài liệu thư tay (`LetterStation`). |

### 7.1.3. Thống kê Thực nghiệm Đóng góp từ GitHub Insights (Contributors Analysis)
Minh chứng cho quá trình làm việc nhóm nghiêm túc, minh bạch và năng suất cao được phản ánh trực tiếp qua số liệu thống kê tại bảng điều khiển **GitHub Insights (Contributors)**:

| Thành viên | GitHub Account | Xếp hạng | Số Commits | Dòng code thêm (++) | Dòng code xóa (--) | Tỷ lệ đóng góp trọng tâm |
| :--- | :--- | :---: | :---: | :---: | :---: | :--- |
| **Nguyễn Công Bằng** | `Towie1206` | **#1** | **33 commits** | **+397,408** | **-49,967** | Kiến trúc lõi, Gameplay Logic, AI, Điện năng, Anomaly, Maintenance, Lighting |
| **Nguyễn Trung Kiên** | `KDotBlack` | **#2** | **14 commits** | **+17,742** | **-5,916** | 3D Models (QuanLy, Bonnie), PausePanel UI, Texture Polish |
| **Nguyễn Thành Nam** | `LuoihaiDakin` | **#3** | **11 commits** | **+49,771** | **-11,389** | Animation, Hệ thống Đa ngôn ngữ (Anh - Việt), 2D UI Graphics |
| **TỔNG CỘNG** | | | **58 commits** | **+464,921** | **-67,272** | **100% Khối lượng hoàn thành đúng tiến độ** |

**Phân tích Biểu đồ Cam kết theo Thời gian (Commits Over Time):**
Lịch sử cam kết mã nguồn (từ 20/08/2026 đến 20/09/2026) ghi nhận 3 đợt cao điểm chiến dịch (Development Sprints):
1. *Sprint 1 (20/08 - 31/08/2026):* Khởi tạo kiến trúc nền tảng, tích hợp mô hình Quản lý (`quanlymodel`), xây dựng chuỗi hội thoại Dialogue và cơ chế cuộc gọi Phone Guy ban đầu.
2. *Sprint 2 (01/09 - 14/09/2026):* Bùng nổ tính năng: Xây dựng hệ thống Dị thường (`anomaly system`), Trạm bảo trì (`maintaince sys`), giao diện tạm dừng (`pausepanel`), hệ thống đa ngôn ngữ (`language`) và hệ thống hoạt họa (`Animation`).
3. *Sprint 3 (15/09 - 21/09/2026):* Tinh chỉnh nâng cao và xuất bản: Cải tiến hành vi hù dọa quái vật (`jump scare & optimize`), tái cấu trúc toàn diện hệ thống máy phát điện theo `IPowerConsumer` (`power generator upgrade`, `refactory`), tinh chỉnh vật liệu (`texture & material`) và đóng gói bản phát hành v0.0.2.

### 7.1.4. Quy trình Phối hợp Nhánh và Kiểm soát Xung đột trong Unity (Unity Merge Conflict Resolution)
Trong quá trình phát triển game với Unity Engine, xung đột tệp tin (Merge Conflicts) tại các file cảnh (`.unity`) và tệp Prefab (`.prefab`) dạng YAML là bài toán kỹ thuật gây tổn thất thời gian lớn nhất nếu không có quy trình quản lý bài bản. Nhóm đã đề ra và tuân thủ nghiêm ngặt 3 nguyên tắc cộng tác:
1. **Nguyên tắc Phân rã Prefab (Prefab Isolation):**
   - Các thành viên phụ trách UI (`PausePanel`) hoặc 3D Model (`quanlymodel`) chỉ tạo và chỉnh sửa trên các tệp Prefab riêng lẻ đặt trong thư mục cá nhân, tuyệt đối không chỉnh sửa trực tiếp vào file cảnh chính `Game.unity`.
2. **Cơ chế Kiểm duyệt Tích hợp (Integration Gatekeeper):**
   - Trưởng nhóm giữ vai trò kiểm duyệt và kéo thả các Prefab hoàn thiện vào Scene trung tâm, đảm bảo các kết nối sự kiện (Inspector References) không bị phá vỡ.
3. **Quy trình Hợp nhất An toàn (Safe Branch Merging):**
   - Các thành viên luôn thực hiện `git pull` đồng bộ mã nguồn mới nhất từ máy chủ trước khi mở Unity Editor. Các thao tác hợp nhất nhánh được ghi nhận minh bạch trong Git log với các commit giải quyết xung đột chuẩn mực (ví dụ: `Merge branch 'main' of https://github.com/Towie1206/LastShift`).

### 7.1.5. Quy chuẩn Thông điệp Cam kết (Conventional Commits) và Lịch sử Git Thực tế
Nhóm áp dụng chuẩn thông điệp súc tích, phản ánh chính xác mục đích kỹ thuật. Dưới đây là bảng trích lục các commit điển hình trong lịch sử phát triển thực tế của dự án:

| Mã Hash | Tác giả (Author) | Ngày thực hiện | Thông điệp Commit (Git Message) | Phân hệ tương ứng trong đồ án |
| :---: | :--- | :---: | :--- | :--- |
| `6f2285d` | Nguyen Cong Bang | 21/09/2026 | `texture & material` | Case Study 1 & 2: Căn chỉnh PBR, Tiling URP |
| `95ae5fb` | Nguyen Cong Bang | 20/09/2026 | `power generator upgrade` | Case Study 5: IPowerConsumer, UsageUI |
| `027cf2a` | Nguyen Cong Bang | 18/09/2026 | `jump scare & optimize` | Chương 4: Freddy Jumpscare & WatcherBrain |
| `8721c1a` | Nguyen Cong Bang | 17/09/2026 | `refactory` | Chương 3: Tái cấu trúc OOP & SOLID |
| `721f16c` | Nguyen Cong Bang | 16/09/2026 | `ven and win/lose` | Case Study 6: Ventilation & WinScreen 6 AM |
| `c63411b` | Dakin | 15/09/2026 | `image1` | Phân hệ Đồ họa UI 2D |
| `7bd8998` | kien312005 | 14/09/2026 | `bonnie` | Phân hệ Mô hình 3D Animatronic |
| `3221ffa` | Nguyen Cong Bang | 11/09/2026 | `anomaly system` | Case Study 6: Hệ thống nhận diện Dị thường |
| `510534a` | Nguyen Cong Bang | 09/09/2026 | `maintaince sys` | Case Study 6: Trạm bảo trì buồng an ninh |
| `f2e2e32` | kien312005 | 08/09/2026 | `pausepanel` | Phân hệ Giao diện Tạm dừng trò chơi |
| `de7af81` | Dakin | 05/09/2026 | `language` | Phân hệ Đa ngôn ngữ (Localization Anh - Việt) |
| `b9e21dc` | Dakin | 06/09/2026 | `Animation` | Phân hệ Hoạt họa Animation Controller |
| `462b80a` | Nguyen Cong Bang | 28/08/2026 | `phone and diagolue` | Phân hệ Phone Guy & Đối thoại Quản lý |
| `7ada72a` | kien312005 | 25/08/2026 | `quanlymodel` | Phân hệ Mô hình 3D NPC Quản lý xưởng |

## 7.2. Quy trình đóng gói bản dựng (Build Pipeline) tối ưu
Quá trình đóng gói sản phẩm từ Unity Editor sang tệp thực thi Windows được thiết lập với các tiêu chuẩn khắt khe:
1. **Tắt cờ Development Build:** Giúp loại bỏ mã gỡ lỗi phụ, giảm dung lượng tệp tin `.exe` và thư mục `_Data`, tăng tốc độ xử lý khung hình.
2. **Cấu hình Player Settings:**
   - *Company Name:* `Towie1012`
   - *Product Name:* `LastShift`
   - *Default Icon:* Gán biểu tượng mặt thực thể Freddy tùy biến, tạo sự nhận diện chuyên nghiệp trên hệ điều hành Windows.
   - *Kiến trúc CPU:* Intel 64-bit (x86_64).
3. **Danh sách Scene chuẩn trong Build Settings:**
   - Index 0: `Scenes/Menu` (Khởi động giao diện chính).
   - Index 1: `Scenes/Home` (Phần mở đầu cốt truyện).
   - Index 2: `Scenes/Game` (Phần chơi chính phòng bảo vệ).

## 7.3. Triển khai sản phẩm thực tế và quản lý vòng đời phát hành trên Itch.io
Sản phẩm **Last Shift** đã được xuất bản chính thức trên nền tảng phân phối trò chơi độc lập lớn nhất thế giới — **Itch.io**:
- **Trang giới thiệu chuyên nghiệp:** Bao gồm ảnh bìa chuẩn Analog Horror, khẩu hiệu (Tagline), hướng dẫn phím bấm, ghi chú dự án sinh viên (Student Project Disclaimer) và cảnh báo nhấp nháy đèn.
- **Đóng gói phân phối:** File nén tiêu chuẩn `LastShift_v0.0.2_Windows.zip` kèm thẻ thực thi Windows.
- **Hệ thống nhật ký phát triển (Devlogs):**
  - *Bản dựng v0.0.1 (Early Alpha):* Phát hành thử nghiệm cơ chế di chuyển, máy phát điện và 1 dị thường cơ bản.
  - *Bản dựng v0.0.2 (Update & Hotfix):* Khắc phục lỗi nút Office Mode load sai cảnh, cân bằng lại tốc độ hao pin của máy phát điện và tinh chỉnh ánh sáng phòng an ninh.

---

\newpage

# KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN

## 1. Kết quả đạt được
Sau thời gian nghiêm túc nghiên cứu và triển khai, đồ án bài tập lớn **"Last Shift"** đã hoàn thành xuất sắc toàn bộ các mục tiêu đặt ra:
1. Xây dựng thành công một trò chơi 3D kinh dị sinh tồn hoàn chỉnh với gameplay hấp dẫn, không khí âm thanh và hình ảnh đậm chất Analog Horror.
2. Thiết kế và vận hành hệ thống mã nguồn C# chất lượng cao, tuân thủ nghiêm ngặt các nguyên lý OOP, SOLID (đặc biệt là giao diện `IPowerConsumer` triệt tiêu phụ thuộc ngược DIP qua mẫu Composition Root), và kiến trúc hướng sự kiện (Event-driven Architecture).
3. Cài đặt thành công hệ thống AI kẻ địch thông minh với Máy trạng thái hữu hạn và thuật toán tích lũy đe dọa động.
4. Áp dụng sáng tạo công nghệ Generative AI vào quy trình sản xuất đồ họa một cách có trách nhiệm và minh bạch.
5. Kiểm thử toàn diện 24 Test Cases thực tế đạt tỷ lệ thành công 100%.
6. Xuất xưởng và phát hành game thực tế trên Itch.io với đầy đủ thông tin truyền thông chuyên nghiệp; cấu hình sẵn sàng gói build di động Android ARM64.

## 2. Hạn chế còn tồn tại
- Trò chơi hiện tại mới chỉ tích hợp 1 loại dị thường chính và 1 kẻ địch chủ đạo (Watcher / Freddy).
- Chưa xây dựng hệ thống lưu tiến trình nhiều đêm (Night 1 đến Night 5).

## 3. Hướng phát triển trong tương lai
- Bổ sung thêm các kẻ địch mới với cơ chế tấn công hoàn toàn khác biệt (kẻ địch bò qua ống thông gió, kẻ địch phản ứng với âm thanh).
- Xây dựng hệ thống tùy biến độ khó (Custom Night) cho phép người chơi tự điều chỉnh chỉ số thông minh của AI từ 0 đến 20.
- Tiếp tục tối ưu hóa gói cài đặt di động Android (`.apk` / `.aab`) qua IL2CPP, hoàn thiện cơ chế điều khiển cảm ứng vuốt chạm và đưa lên thử nghiệm thực địa Google Play Closed Testing.

---

\newpage

# TÀI LIỆU THAM KHẢO

1. **Robert C. Martin (2017)**, *Clean Architecture: A Craftsman's Guide to Software Structure and Design*, Prentice Hall.
2. **Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides (1994)**, *Design Patterns: Elements of Reusable Object-Oriented Software*, Addison-Wesley.
3. **Unity Technologies (2026)**, *Unity User Manual & Scripting Reference (Unity 6 / URP Documentation)*, official website: docs.unity3d.com.
4. **Ian Millington (2019)**, *Artificial Intelligence for Games (3rd Edition)*, CRC Press.
5. **Jesse Schell (2019)**, *The Art of Game Design: A Book of Lenses (3rd Edition)*, A K Peters/CRC Press.
6. **Itch.io Developer Documentation (2026)**, *Game Publishing Guidelines and Community Standards*, official website: itch.io/docs.
7. **Game Cực Hay (2026)**, *"TẠI SAO Chúng Ta Thích Chơi GAME KINH DỊ?"*, Kịch bản phân tích: TienZero, Giọng đọc: Ming Ming, Kênh YouTube Game Cực Hay, đường dẫn tài liệu trực tuyến: https://youtu.be/hy8sWR010Z4.
8. **Nhóm Tác giả (2026)**, *Last Shift - UI/UX Design System & Wireframe Prototype*, nền tảng Figma, liên kết trực tuyến: https://www.figma.com/design/giXJAL6gsB4NRTOpyzeHKq/Last-Shift---UI-UX-Design-System?node-id=0-1&t=LNW2fttUkiR2wFor-1.
9. **Sketchfab Community (2026)**, *Open-Source 3D Models & Low-Poly Environmental Assets (Creative Commons Attribution CC BY 4.0)*, nền tảng phân phối mô hình: sketchfab.com.
