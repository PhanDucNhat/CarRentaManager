# CarRentaManager
## 📝 Tổng quan
Đây là một **website quản lý cho thuê xe ô tô** được xây dựng để hỗ trợ các hoạt động kinh doanh cho thuê xe như: đăng ký tài khoản, quản lý xe, đặt xe, đăng bài viết, đánh giá và quản lý thông tin khách hàng. Hệ thống bao gồm **giao diện người dùng** (khách thuê xe) và **giao diện quản trị viên** (admin) để quản lý toàn bộ dữ liệu trên hệ thống.
## 🚀 Tính năng chính
### Người dùng
- Đăng ký / Đăng nhập
- Xem danh sách xe và chi tiết từng xe
- Tìm kiếm, lọc xe theo nhu cầu
- Đặt xe trực tuyến
- Gửi đánh giá, nhận xét xe
- Xem các bài viết liên quan (tin tức, kinh nghiệm thuê xe...)
### Quản trị viên (Admin)
- Quản lý tài khoản người dùng
- Thêm / sửa / xóa xe
- Quản lý đặt xe
- Quản lý bài viết, đánh giá
---
## 🛠 Công nghệ sử dụng
- **Ngôn ngữ lập trình:** C#, HTML, CSS, JavaScript, jQuery  
- **Framework:** ASP.NET MVC  
- **Database:** SQL Server  
- **Frontend:** Bootstrap  
- **Công cụ phát triển:** Visual Studio, SSMS (SQL Server Management Studio)
---
## 📦 Hướng dẫn cài đặt và chạy dự án
### Bước 1: Clone repository
git clone https://github.com/PhanDucNhat/CarRentaManager.git
### Bước 2: Mở bằng Visual Studio
- Mở Visual Studio > File > Open > Project/Solution
- Chọn file .sln trong thư mục vừa clone
### Bước 3: Cấu hình chuỗi kết nối CSDL
- Mở Web.config
- Cập nhật lại connectionString để trỏ đúng đến SQL Server trên máy bạn
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Data Source=.;Initial Catalog=CarRentalDb;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
## Nếu chưa có database: import file .bak hoặc chạy file script .sql trong thư mục Database/ để tạo dữ liệu mẫu.
### Bước 4: Chạy project
Nhấn F5 hoặc click Start trong Visual Studio
Trình duyệt sẽ mở website tại http://localhost:xxxx
## 📷 Giao diện khi chạy
Trang chủ: Hiển thị danh sách xe đang cho thuê
Trang chi tiết xe: Xem thông tin, đánh giá và đặt xe
Trang quản trị: Quản lý xe, người dùng, đơn đặt
Trang bài viết: Cập nhật tin tức, kinh nghiệm thuê xe
## ✅ Tài khoản mẫu để đăng nhập
Tài khoản người dùng:
Email: user1@example.com
Mật khẩu: 123456
Tài khoản admin:
Email: admin@example.com
Mật khẩu: admin123
