
-- Sử dụng cơ sở dữ liệu QLTour
USE QLTour;

CREATE TABLE PhuongTien (
    MaPhuongTien varchar(20) NOT NULL,
    TenPhuongTien nvarchar(255) NULL,
    LoaiPhuongTien nvarchar(50) NULL,
    SoChoNgoi int NULL,
    PRIMARY KEY CLUSTERED (MaPhuongTien)
);
CREATE TABLE NhanVien (
    MaNhanVien varchar(20) NOT NULL,
    HoTen nvarchar(255) NULL,
    GioiTinh nvarchar(10) NULL,
    DiaChi nvarchar(255) NULL,
    SoDienThoai nvarchar(20) NULL,
    ChucVu nvarchar(20) NULL,
    PRIMARY KEY CLUSTERED (MaNhanVien)
);
CREATE TABLE Tours (
    MaTour varchar(20) NOT NULL,
    TenTour nvarchar(255) NULL,
    NgayBatDau date NULL,
    NgayKetThuc date NULL,
    Gia money NULL,
    MaPhuongTien varchar(20) NULL,
    MaNhanVien varchar(20) NULL,
    PRIMARY KEY CLUSTERED (MaTour),
    CONSTRAINT FK_Tours_Vehicles FOREIGN KEY (MaPhuongTien) REFERENCES PhuongTien(MaPhuongTien),
	CONSTRAINT FK_Tours_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
-- Tạo bảng DiemThamQuan
CREATE TABLE DiemThamQuan (
    MaDiemThamQuan varchar(20) NOT NULL,
    TenDiemThamQuan nvarchar(255) NULL,
    PRIMARY KEY CLUSTERED (MaDiemThamQuan)
);

-- Tạo bảng DiemThamQuanCuaTour
CREATE TABLE DiemThamQuanCuaTour (
    MaTour varchar(20) NOT NULL,
    MaDiemThamQuan varchar(20) NOT NULL,
    CONSTRAINT PK_TourTouristSpot PRIMARY KEY CLUSTERED (MaTour, MaDiemThamQuan),
    CONSTRAINT FK_TourTouristSpot_Tour FOREIGN KEY (MaTour) REFERENCES Tours(MaTour),
    CONSTRAINT FK_TourTouristSpot_TouristSpot FOREIGN KEY (MaDiemThamQuan) REFERENCES DiemThamQuan(MaDiemThamQuan)
);


-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
    MaKhachHang varchar(20) NOT NULL,
    TenKhachHang nvarchar(255) NULL,
    GioiTinh nvarchar(10) NULL,
    DiaChi nvarchar(255) NULL,
    SoDienThoai nvarchar(20) NULL,
    PRIMARY KEY CLUSTERED (MaKhachHang)
);

-- Tạo bảng KhachHangDatTour
CREATE TABLE KhachHangDatTour (
    MaKhachHang varchar(20) NOT NULL,
    MaTour varchar(20) NOT NULL,
    CONSTRAINT PK_CustomerTour PRIMARY KEY CLUSTERED (MaKhachHang, MaTour),
    CONSTRAINT FK_CustomerTour_Customer FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    CONSTRAINT FK_CustomerTour_Tour FOREIGN KEY (MaTour) REFERENCES Tours(MaTour)
);




-- Tạo bảng TaiKhoan
CREATE TABLE TaiKhoan (
    TenDangNhap varchar(30) NOT NULL,
    MatKhau varchar(50) NULL,
    MaNhanVien varchar(20) NULL,
    CONSTRAINT PK_Account PRIMARY KEY CLUSTERED (TenDangNhap),
    CONSTRAINT FK_Account_TourGuides FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);



-- Chuyển cơ sở dữ liệu về chế độ đọc và ghi
ALTER DATABASE QLTour SET READ_WRITE;
ALTER TABLE Tours
ADD PhuongTien_MaPhuongTien nvarchar(20) NULL;

INSERT INTO NhanVien (MaNhanVien, HoTen, GioiTinh, DiaChi, SoDienThoai, ChucVu)
VALUES
('NV001', N'Nguyễn Văn Cảm', N'Nam', N'Đà Nẵng', '0987654321', N'Hướng dẫn viên'),
('NV002', N'Huỳnh Thị Tươi', N'Nữ', N'Quảng Nam', '0912345678', N'Quản trị viên'),
('NV003', N'Vũ Hoài', N'Nam', N'Đà Nẵng', '0901234567', N'Nhân viên'),
('NV004', N'Hoa Thị Huệ', N'Nữ', N'Quảng Bình', '0934567890', N'Nhân viên'),
('NV005', N'Trần Thị Kim', N'Nữ', N'Thừa Thiên Huế', '0921234567', N'Hướng dẫn viên'),
('NV006', N'Lê Thảo', N'Nữ', N'Đà Nẵng', '0967890123', N'Nhân viên'),
('NV007', N'Vô Danh', N'Nữ', N'Quảng Nam', '0998765432', N'Nhân viên'),
('NV008', N'Nguyễn Lam', N'Nam', N'Thừa Thiên Huế', '0956789012', N'Nhân viên'),
('NV009', N'Huỳnh Trọng Tài', N'Nam', 'Đà Nẵng', '0945678901', N'Hướng dẫn viên'),
('NV010', N'Lê Trọng Nhân', N'Nam', 'Quảng Bình', '0976543210', N'Hướng dẫn viên');
Select * FROM NhanVien

INSERT INTO Tours (MaTour, TenTour, NgayBatDau, NgayKetThuc, Gia, MaPhuongTien, MaNhanVien)
VALUES
('TT001', N'Tour du lịch Vịnh Hạ Long 3 ngày 2 đêm', '2023-08-01', '2023-08-03', 10000000, 'PT005', 'NV001'),
('TT002', N'Tour du lịch Phố cổ Hội An 2 ngày 1 đêm', '2023-08-05', '2023-08-06', 5000000, 'PT004', 'NV002'),
('TT003', N'Tour du lịch Cố đô Huế 3 ngày 2 đêm', '2023-08-08', '2023-08-10', 7000000, 'PT003', 'NV003'),
('TT004', N'Tour du lịch Biển Nha Trang 4 ngày 3 đêm', '2023-08-12', '2023-08-15', 15000000, 'PT004', 'NV005'),
('TT005', N'Tour du lịch Công viên quốc gia Phú Quốc 5 ngày 4 đêm', '2023-08-17', '2023-08-21', 20000000, 'PT002', 'NV005'),
('TT006', N'Tour du lịch Đà Lạt 4 ngày 3 đêm', '2024-01-12', '2024-01-16', 5000000,'PT001','NV005'),
('TT007', N'Tour du lịch Đà Lạt 10 ngày 9 đêm', '2024-01-12', '2024-01-22', 5000000,'PT001',null),
('TT009', N'Tour du lịch Vịnh Hạ Long 9 ngày 2 đêm', '2023-08-01', '2023-08-09', 100000000, 'PT001', NULL);

Select * FROM Tours

INSERT INTO PhuongTien (MaPhuongTien, TenPhuongTien, LoaiPhuongTien, SoChoNgoi)
VALUES 
    ('PT001', N'Toyota Fortuner', N'Oto', 4),
    ('PT002', N'VietNamArline Boeing 787', N'Hang Khong', 150),
    ('PT003', N'Tàu Thống Nhất', N'Đường Sắt', 80),
    ('PT004', N'Mercedes-Benz Sprinter 2023', N'4 bánh', 16),
	('PT005', N'Tàu VIP',N'Tàu Thủy',50);
Select *from phuongtien

INSERT INTO KhachHangDatTour (MaKhachHang, MaTour)
VALUES
('KH001', 'TT001'),
('KH002', 'TT001'),
('KH003', 'TT001'),
('KH004', 'TT001'),
('KH005', 'TT001'),
('KH006', 'TT001'),
('KH007', 'TT001'),
('KH008', 'TT001'),
('KH009', 'TT001'),
--
('KH010', 'TT002'),
('KH011', 'TT002'),
('KH012', 'TT002'),
('KH013', 'TT002'),
('KH014', 'TT002'),
('KH015', 'TT002'),
('KH016', 'TT002'),
('KH017', 'TT002'),
('KH018', 'TT002'),
--
('KH001', 'TT003'),
('KH002', 'TT003'),
('KH003', 'TT003'),
('KH004', 'TT003'),
('KH005', 'TT003'),
('KH006', 'TT003'),
('KH007', 'TT003'),
('KH008', 'TT003'),
('KH009', 'TT003'),
--
('KH010', 'TT004'),
('KH011', 'TT004'),
('KH012', 'TT004'),
('KH013', 'TT004'),
('KH014', 'TT004'),
('KH015', 'TT004'),
('KH016', 'TT004'),
('KH017', 'TT004'),
('KH018', 'TT004'),
--
('KH001', 'TT005'),
('KH002', 'TT005'),
('KH003', 'TT005'),
('KH004', 'TT005'),
('KH005', 'TT005'),
('KH006', 'TT005'),
('KH007', 'TT005'),
('KH008', 'TT005'),
('KH009', 'TT005'),
--
('KH019', 'TT006'),
('KH020', 'TT006');
Select * from KhachHangDatTour

INSERT INTO KhachHang (MaKhachHang, TenKhachHang, GioiTinh, DiaChi, SoDienThoai)
VALUES 
    ('KH001', N'Nguyễn Trần Xuân Anh', N'Nam', N'123 Đường CMT8, Quận 3, TP.Hồ Chí Minh', '0901234567'),
    ('KH002', N'Trần Thị Bình', N'Nữ', N'456 Đường Lê Trọng Tấn, Quận Bình Tân, TP.Hồ Chí Minh', '0912345678'),
    ('KH003', N'Lê Văn Cảnh', N'Nam', N'155 Đường Tân Sơn Nhì, Quận Tân Phú, TP.Hồ Chí Minh', '0923456789'),
    ('KH004', N'Phạm Thị Dung', N'Nữ', N'100 Đường Cộng Hòa, Quận Tân Bình, TP.Hồ Chí Minh', '0934567890'),
	('KH005', N'Phạm Trần Anh Duy', N'Nam', N'115 Đường Phạm Văn Đồng, Quận Bình Thạnh, TP.Hồ Chí Minh', '0934567890'),
	('KH006', N'Nguyễn Thị Mai', N'Nữ', N'789 Đường Nguyễn Thị Minh Khai, Quận 1, TP.Hồ Chí Minh', '0909876543'),
    ('KH007', N'Võ Thị Ngọc Lan', N'Nữ', N'567 Đường Võ Văn Tần, Quận 5, TP.Hồ Chí Minh', '0918765432'),
    ('KH008', N'Huỳnh Thị Ngọc Trinh', N'Nữ', N'234 Đường Lý Thường Kiệt, Quận 10, TP.Hồ Chí Minh', '0927654321'),
    ('KH009', N'Đặng Thị Kim Ngân', N'Nữ', N'111 Đường Trần Hưng Đạo, Quận 4, TP.Hồ Chí Minh', '0936543210'),
    ('KH010', N'Phan Thị Hương Thảo', N'Nữ', N'456 Đường Hồ Bieu Chanh, Quận 7, TP.Hồ Chí Minh', '0930123456'),
    ('KH011', N'Mai Thị Phương Anh', N'Nữ', N'789 Đường Bùi Viện, Quận 1, TP.Hồ Chí Minh', '0907654321'),
    ('KH012', N'Lê Thị Thùy Linh', N'Nữ', N'567 Đường Hồ Bieu Chanh, Quận 3, TP.Hồ Chí Minh', '0912345678'),
    ('KH013', N'Nguyễn Thị Ngọc Trâm', N'Nữ', N'234 Đường Trần Hưng Đạo, Quận 5, TP.Hồ Chí Minh', '0923456789'),
    ('KH014', N'Phạm Thị Thu Thảo', N'Nữ', N'111 Đường Võ Văn Tần, Quận 10, TP.Hồ Chí Minh', '0934567890'),
    ('KH015', N'Hồ Thị Mai Anh', N'Nữ', N'456 Đường Nguyễn Thị Minh Khai, Quận 4, TP.Hồ Chí Minh', '0934567890'),
    ('KH016', N'Nguyễn Thị Thùy Trang', N'Nữ', N'789 Đường Trần Hưng Đạo, Quận 7, TP.Hồ Chí Minh', '0934567890'),
    ('KH017', N'Lê Thị Hồng Ngọc', N'Nữ', N'567 Đường Bùi Viện, Quận 3, TP.Hồ Chí Minh', '0934567890'),
    ('KH018', N'Phan Thị Thanh Hương', N'Nữ', N'234 Đường Lý Thường Kiệt, Quận 1, TP.Hồ Chí Minh', '0934567890'),
    ('KH019', N'Đỗ Thị Quỳnh Anh', N'Nữ', N'111 Đường Hồ Bieu Chanh, Quận 5, TP.Hồ Chí Minh', '0934567890'),
    ('KH020', N'Trần Thị Ngọc Ánh', N'Nữ', N'456 Đường Bùi Viện, Quận 10, TP.Hồ Chí Minh', '0934567890');
	Select *from KhachHang



INSERT INTO DiemThamQuanCuaTour (MaTour, MaDiemThamQuan)
VALUES
('TT001', 'DT001'),
('TT001', 'DT002'),
('TT001', 'DT003'),
('TT001', 'DT004'),
('TT001', 'DT005'),
--
('TT002', 'DT006'),
('TT002', 'DT007'),
('TT002', 'DT008'),
('TT002', 'DT009'),
('TT002', 'DT010'),
--
('TT003', 'DT011'),
('TT003', 'DT012'),
('TT003', 'DT013'),
('TT003', 'DT014'),
('TT003', 'DT015'),
--
('TT004', 'DT016'),
('TT004', 'DT017'),
('TT004', 'DT018'),
('TT004', 'DT019'),
('TT004', 'DT020'),
--
('TT005', 'DT021'),
('TT005', 'DT022'),
('TT005', 'DT023'),
('TT005', 'DT024'),
('TT005', 'DT025'),
--
('TT006', 'DT026'),
('TT006', 'DT027'),
('TT006', 'DT028'),
('TT006', 'DT029'),
('TT006', 'DT030');
Select * from DiemThamQuanCuaTour

INSERT INTO DiemThamQuan (MaDiemThamQuan, TenDiemThamQuan)
VALUES
--Vịnh Hạ Long
('DT001', N'Vịnh Hạ Long'),
('DT002', N'Đảo Ti Top'),
('DT003', N'Hang Đầu Gỗ'),
('DT004', N'Bãi Cháy'),
('DT005', N'Chùa Long Tiên'),
--Phố cổ Hội An
('DT006', N'Phố cổ Hội An'),
('DT007', N'Chùa Cầu'),
('DT008', N'Quảng Bình'),
('DT009', N'Chùa Fujian'),
('DT010', N'Biển An Bàng'),
--Cố đô Huế
('DT011', N'Di tích Hoàng thành Huế'),
('DT012', N'Lăng mộ Gia Long'),
('DT013', N'Chùa Thiên Mụ'),
('DT014', N'Cầu Tràng Tiền'),
('DT015', N'Đại Nội'),
--Biển Nha Trang
('DT016', N'Vinpearl Land'),
('DT017', N'Núi Cô Tiên'),
('DT018', N'Triều Dương Bay'),
('DT019', N'Đảo Hòn Mun'),
('DT020', N'Tháp Po Nagar Cham'),
--Phú Quốc
('DT021', N'Công viên quốc gia Phú Quốc'),
('DT022', N'Bãi Sao'),
('DT023', N'Dinh Cậu Night Market'),
('DT024', N'Bãi Dài'),
('DT025', N'Vinpearl Safari Phú Quốc'),
--Đà Lạt
('DT026', N'Ho Xuan Huong'),
('DT027', N'Đà Lạt Flower Gardens'),
('DT028', N'Trúc Lâm Zen Monastery'),
('DT029', N'Langbiang Mountain'),
('DT030', N'Dambri Waterfall');
Select *from DiemThamQuan



INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNhanVien)
VALUES
('nv1', '1', 'NV001'),
('nv2', '1', 'NV002'),
('nv3', '1', 'NV003'),
('nv4', '1', 'NV004'),
('nv5', '1', 'NV005'),
('nv6', '1', 'NV006'),
('nv7', '1', 'NV007'),
('nv8', '1', 'NV008'),
('nv9', '1', 'NV009'),
('nv10', '1', 'NV010');
select *from TaiKhoan