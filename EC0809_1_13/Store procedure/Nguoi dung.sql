

--exec spThemKH 'nghi', '03/14/1987', 'VietNam', '086653', '024212366', 'B324334', ''

--LẤY DANH SÁCH LOẠI NGƯỜI DÙNG (TRỪ KHÁCH HÀNG)
if object_id('spLayDanhSachLoaiNguoiDung', 'p') is not null
	drop proc spLayDanhSachLoaiNguoiDung
go
create proc spLayDanhSachLoaiNguoiDung
as
begin
	select * from LOAI_NGUOI_DUNG
end

--exec spLayDanhSachLoaiNguoiDung
go

--THÊM NGƯỜI DÙNG
if object_id('spThemNguoiDung', 'p') is not null
	drop proc spThemNguoiDung
go
create proc spThemNguoiDung
	@hoten nvarchar(30), @diachi nvarchar(60), @ngaysinh smalldatetime, @gioitinh bit,
	@email varchar(30), @dienthoai varchar(15), @username varchar(30), @password varchar(50), 
	@maloainguoidung int, @tinhtrangkichhoat bit, @manguoidung int out
as
begin
	insert into NGUOI_DUNG(HoTen, Email, DiaChi, NgaySinh, GioiTinh, DienThoai, Username, Password, MaLoaiNguoiDung, TinhTrangKichHoat)
	values(@hoten, @email, @diachi, @ngaysinh, @gioitinh, @dienthoai, @username, @password, @maloainguoidung, @tinhtrangkichhoat)

	set @manguoidung = ident_current('NGUOI_DUNG')
end

--declare @manguoidung int
--exec spThemNguoiDung N'Nguyễn Huệ Nghi', N'214 Nguyễn Duy', '03/14/1987', 1, 'tinyfootuns@yahoo.com.vn', 
--		'0909534838', 'nghinghi', 'qwerty', 1, 1,  @manguoidung out

--select * from nguoi_dung
go

--THÊM KHÁCH HÀNG MỚI
if object_id('spThemKhachHang', 'p') is not null
	drop proc spThemKhachHang
go
create proc spThemKhachHang
	@hoten nvarchar(30), @diachi nvarchar(60), @ngaysinh smalldatetime, @gioitinh bit,
	@email varchar(30), @dienthoai varchar(15), @username varchar(30), @password varchar(50),
	@maloaithe int, @sothe varchar(50), @ngayhethan smalldatetime, 
	--@diemkhuyenmai int, @tinhtrangkichhoat bit, @maquyen int, 
	@makhachhang int out
as
begin
	insert into THE_THANH_TOAN(MaLoaiThe, SoThe, NgayHetHan)
	values(@maloaithe, @sothe, @ngayhethan)

	declare @mathethanhtoan int
	set @mathethanhtoan = ident_current('THE_THANH_TOAN')
	
	insert into NGUOI_DUNG(HoTen, Email, DiaChi, NgaySinh, GioiTinh, DienThoai, Username, Password, MaLoaiNguoiDung, TinhTrangKichHoat)
	values(@hoten, @email, @diachi, @ngaysinh, @gioitinh, @dienthoai, @username, @password, 1, 1)

	set @makhachhang = ident_current('NGUOI_DUNG')
	
	insert into KHACH_HANG(MaKhachHang, MaTheThanhToan, DiemKhuyenMai, DiemTichLuy)
	values(@makhachhang, @mathethanhtoan, 0, 0)
end

--declare @manguoidung int
--exec spThemKhachHang N'Nguyễn Huệ Nghi', N'214 Nguyễn Duy', '03/14/1987', 1, 'tinyfootuns@yahoo.com.vn', 
--		'0909534838', 'tinyfoot23435', 'qwerty', 1, '12345678', '01/01/2009', @manguoidung out

--select * from the_thanh_toan
--select * from nguoi_dung
--select * from khach_hang
go
--KIỂM TRA USERNAME
if object_id('spKiemTraUsername', 'p') is not null
	drop proc spKiemTraUsername
go
create proc spKiemTraUsername
	@username varchar(30), @exist bit out
as
begin
	declare @user varchar(30)

	select @user = Username
	from NGUOI_DUNG
	where Username = @username

	if(@user <> '')
		set @exist = 1;
	else
		set @exist = 0;
end

--declare @exist bit
--exec spKiemTraUsername 'tinyfoot', @exist out
--select @exist
go

--KIỂM TRA ĐĂNG NHẬP
if object_id('spKiemTraAccount', 'p') is not null
	drop proc spKiemTraAccount
go
create proc spKiemTraAccount
	@username varchar(30), @password varchar(50)
as
begin
	declare @user varchar(30)
		
	select *
	from NGUOI_DUNG
	where Username = @username
	and Password = @password
end

--declare @exist bit
--exec spKiemTraAccount 'tinyfoot', 'qwerty'

go
--LẤY THÔNG TIN KHÁCH HÀNG KHI BIẾT USERNAME
if object_id('spLayThongTinKhachHang', 'p') is not null
	drop proc spLayThongTinKhachHang
go
create proc spLayThongTinKhachHang
	@username varchar(30)
as
begin
	select *
	from VIEW_THONG_TIN_KHACH_HANG
	where Username = @username
end
go

--LẤY THÔNG TIN Người dùng KHI BIẾT USERNAME
if object_id('spLayThongTinNguoiDung', 'p') is not null
	drop proc spLayThongTinNguoiDung
go
create proc spLayThongTinNguoiDung
	@username varchar(30)
as
begin
	select *
	from NGUOI_DUNG
	where Username = @username
end
go

--LẤY THÔNG TIN KHÁCH HÀNG KHI BIẾT USERNAME
if object_id('spCapNhatThongTinNguoiDung', 'p') is not null
	drop proc spCapNhatThongTinNguoiDung
go
create proc spCapNhatThongTinNguoiDung
	@manguoidung int, @hoten nvarchar(30), @ngaysinh smalldatetime, @gioitinh bit, 
	@diachi nvarchar(60), @dienthoai varchar(15), @email varchar(30)
as
begin
	update NGUOI_DUNG
	set HoTen = @hoten
	, NgaySinh = @ngaysinh
	, GioiTinh = @gioitinh
	, DiaChi = @diachi
	, DienThoai = @dienthoai
	, Email =@email
	where MaNguoiDung =@manguoidung
end

--exec spCapNhatThongTinNguoiDung 9, 'aaaa', '01/01/2001', 1, 'nguyen duy', '876665', 'iii@yahoo.com'
go

--LẤY DANH SÁCH LOẠI THẺ
if object_id('spLayDanhSachLoaiThe', 'p') is not null
	drop proc spLayDanhSachLoaiThe
go
create proc spLayDanhSachLoaiThe
as
begin
	select * from LOAI_THE
end
go
--exec spLayDanhSachLoaiThe

-- Xoa nguoi dung
if object_id('spXoaNguoiDung', 'p') is not null
	drop proc spXoaNguoiDung
go
create proc spXoaNguoiDung
@manguoidung int
as 
begin
	delete from Nguoi_Dung where MaNguoiDung=@manguoidung
end
go

--Lay danh sach nguoi dung
if object_id('spLayDanhSachNguoiDung', 'P') is not null
	drop proc spLayDanhSachNguoiDung
go
create proc spLayDanhSachNguoiDung
@pageNum int,
@pageSize int
as
begin
	WITH s AS
	(
		SELECT ROW_NUMBER() OVER(ORDER BY MaNguoiDung) AS RowNum, *
		FROM NGUOI_DUNG where MaLoaiNguoiDung != 4
	)
	Select * From s
	Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize
end
go

--Cap nhat tinh trang kich hoat
if object_id('spCapNhatTinhTrangKichHoat', 'p') is not null
	drop proc spCapNhatTinhTrangKichHoat
go
create procedure spCapNhatTinhTrangKichHoat
@tinhTrangKichHoat bit,
@maNguoiDung int
as
begin
	update Nguoi_Dung set TinhTrangKichHoat = @tinhTrangKichHoat
	where MaNguoiDung = @maNguoiDung
end
go
--CAP NHAT DIEM KHUYEN MAI
if object_id('spCapNhatDiemKhuyenMai', 'p') is not null
	drop proc spCapNhatDiemKhuyenMai
go
create procedure spCapNhatDiemKhuyenMai
@makhachhang int,
@diemmoi int
as
begin
	update Khach_Hang set DiemKhuyenMai = @diemmoi
	where MaKhachHang = @makhachhang
end
go

--Lay tong so dong cua Nguoi_Dung
if object_id('spTongSoNguoiDung', 'p') is not null
	drop proc spTongSoNguoiDung
go
create procedure spTongSoNguoiDung
as
begin
	select count(*) from Nguoi_Dung
end
go

--Lấy thông tin người dùng
if object_id('spThongTinNguoiDung', 'p') is not null
	drop proc spThongTinNguoiDung
go
create procedure spThongTinNguoiDung
@maNguoiDung int
as
begin
	select * from Nguoi_Dung where MaNguoiDung = @maNguoiDung
end
go