**# QuanLyKTXg**# 🏢 Dormitory Management System (Quản lý Ký túc xá)

Ứng dụng quản lý ký túc xá được xây dựng nhằm hỗ trợ nhà trường/ban quản lý trong việc:

- Quản lý thông tin sinh viên và phòng ở  
- Quản lý hợp đồng, hóa đơn điện/nước và thu phí  
- Quản lý nhân sự, kỷ luật và báo cáo thống kê  

Dự án được phát triển trong khuôn khổ học phần **Lập trình Cơ sở Dữ liệu** tại **Trường Đại học Mở TP.HCM**.

---

## 📑 Mục lục
- [Tính năng chính](#-tính-năng-chính)
- [Công nghệ sử dụng](#-công-nghệ-sử-dụng)
- [Kiến trúc phần mềm](#-kiến-trúc-phần-mềm)
- [Cấu trúc thư mục](#-cấu-trúc-thư-mục)
- [Hướng dẫn cài đặt & chạy](#-hướng-dẫn-cài-đặt--chạy)
- [Thành viên nhóm](#-thành-viên-nhóm)
- [License](#-license)

---

## 🚀 Tính năng chính
- **Quản lý phòng:** thêm/sửa/xóa phòng, loại phòng (thường, VIP), sức chứa tối đa  
- **Quản lý sinh viên:** hồ sơ, nhận – trả phòng, lịch sử ở, tình trạng kỷ luật  
- **Quản lý hợp đồng & phí:** lập hợp đồng thuê, tính tiền điện/nước, xuất hóa đơn  
- **Thống kê – báo cáo:** số lượng sinh viên, phòng trống, doanh thu theo tháng  
- **Quản lý nhân sự:** thêm/sửa/xóa cán bộ ban quản lý ký túc xá  

---

## 🛠 Công nghệ sử dụng
- **Ngôn ngữ:** C# (.NET Framework / WinForms)  
- **Cơ sở dữ liệu:** Microsoft SQL Server (2019/2022 Express hoặc LocalDB)  
- **ADO.NET:** kết nối & thao tác dữ liệu  
- **Mô hình:** 3-layer architecture (UI – BLL – DAL)

---

## 🏗 Kiến trúc phần mềm
### **Presentation Layer (WinForms)**
Giao diện, xử lý sự kiện người dùng.

### **Business Logic Layer (BLL)**
Xử lý logic nghiệp vụ: tính tiền phòng, xác thực hợp đồng, kiểm tra sức chứa phòng.

### **Data Access Layer (DAL)**
Kết nối SQL Server, thực thi Stored Procedures, CRUD.

### **Database**
Các bảng chính: `SinhVien`, `Phong`, `HopDong`, `HoaDon`, `NhanVien`, `KyLuat`, ...

---

## 📂 Cấu trúc thư mục
```bash
QuanLyKyTucXa_main/
│
├── QuanLyKyTucXa_GUI/ # Giao diện WinForms
├── QuanLy.BLL/ # Business Logic Layer
├── QuanLy.DAL/ # Data Access Layer
├── TransferObject/ # Data Transfer Objects
├── scripts/ # Script SQL (tạo DB + seed data)
├── docs/ # ERD, DFD, UML, báo cáo
├── README.md
└── .gitignore
```


---

## ⚙️ Hướng dẫn cài đặt & chạy

### **1) Yêu cầu môi trường**
- Visual Studio 2022+ (có workload *".NET Desktop Development"*)  
- SQL Server 2019/2022 + SSMS  
- .NET Framework (theo phiên bản dự án)

---

### **2) Tạo cơ sở dữ liệu**
1. Mở **SQL Server Management Studio**  
2. Chạy script:  
   - `scripts/scriptKTX_new.sql` → tạo database  
   - `scripts/Myscript.sql` → tạo Stored Procedures  

---

### **3) Cấu hình chuỗi kết nối**
Mở file `App.config` và chỉnh:

```xml
<connectionStrings>
    <add name="MyConnectionString"
         connectionString="Data Source=YOUR_SERVER;Initial Catalog=KTX_DB;Integrated Security=True" />
</connectionStrings>

---
### **4) Build & Run**

Mở file DormitoryManagementSystem.sln bằng Visual Studio

Chuột phải project GUI → Set as Startup Project

Nhấn Ctrl + F5 để chạy
