--THEM DON HANG DINH KY
if object_id('spThemDonHangDinhKy', 'p') is not null
	drop proc spThemDonHangDinhKy
go
create proc spThemDonHangDinhKy
	@madonhangkinhky int, @loaidinhky nvarchar(10), @ngaybatdau datetime, @ngayketthuc datetime, 
	@ngaygiao varchar(100), @thugiao varchar(20), @giogiao datetime, @tinhtrang bit
as
begin
	insert into DON_HANG_DINH_KY(MaDonHangDinhKy, LoaiDinhKy, NgayBatDau, NgayKetThuc, NgayGiao, ThuGiao, GioGiao, TinhTrang)
	values(@madonhangkinhky, @loaidinhky, @ngaybatdau, @ngayketthuc, @ngaygiao, @thugiao, @giogiao, @tinhtrang)
end
go

--Cap nhat trang thai da thanh toan
if object_id('spCapNhatDaThanhToan', 'p') is not null
	drop proc spCapNhatDaThanhToan
go
create proc spCapNhatDaThanhToan
	@madonhang int, @trangthai bit
as
begin
		update DON_HANG
       		set DaThanhToan = @trangthai
		where MaDonHang = @madonhang
end
go

--Cap nhat trang thai da giao hang
if object_id('spCapNhatDaGiaoHang', 'p') is not null
	drop proc spCapNhatDaGiaoHang
go
create proc spCapNhatDaGiaoHang
	@madonhang int, @trangthai bit
as
begin
		update DON_HANG
       		set DaGiaoHang = @trangthai
		where MaDonHang = @madonhang
end
go

--Cap nhat trang thai da giao hang
if object_id('spCapNhatDaDatHang', 'p') is not null
	drop proc spCapNhatDaDatHang
go
create proc spCapNhatDaDatHang
	@madonhang int, @trangthai bit
as
begin
		update DON_HANG
       		set DaDatHang = @trangthai
		where MaDonHang = @madonhang
end
go
--Cap nhat ngày giao hàng
if object_id('spCapNhatNgayGioGiaoHang', 'p') is not null
	drop proc spCapNhatNgayGioGiaoHang
go
create proc spCapNhatNgayGioGiaoHang
	@madonhang int, @ngayGioGiaoHang datetime
as
begin
		update DON_HANG
       		set NgayGioGiaoHang = @ngayGioGiaoHang
		where MaDonHang = @madonhang
end
go

--them don hang cho customer
if object_id('spThemDonHang', 'p') is not null
	drop proc spThemDonHang
go
create proc spThemDonHang
	@makhachhang int, @ngaygiolap datetime, @diachinhan nvarchar(50), @nguoinhan nvarchar(50), 
	@ngaygiogiaohang datetime, @loaidondathang int, @hinhthuckhuyenmai int, @tienkhuyenmai money, 
	@giatri money, @mahinhthucthanhtoan int, @dadathang bit, @dathanhtoan int, @dagiaohang bit, @tienthue money, @madonhang int out
as
begin
	insert into DON_HANG(MaKhachHang, NgayGioLap, DiaChiNhan, NguoiNhan, NgayGioGiaoHang, LoaiDonDatHang, HinhThucKhuyenMai, TienKhuyenMai, GiaTri, MaHinhThucThanhToan, DaDatHang, DaThanhToan, DaGiaoHang, TienThue)
	values(@makhachhang, @ngaygiolap, @diachinhan, @nguoinhan, @ngaygiogiaohang, @loaidondathang, @hinhthuckhuyenmai, @tienkhuyenmai, @giatri, @mahinhthucthanhtoan, @dadathang, @dathanhtoan, @dagiaohang, @tienthue)

	set @madonhang = ident_current('DON_HANG')
end
go

--them don hang cho guest
if object_id('spThemDonHangGuest', 'p') is not null
	drop proc spThemDonHangGuest
go
create proc spThemDonHangGuest
	@ngaygiolap datetime, @diachinhan nvarchar(50), @nguoinhan nvarchar(50), 
	@ngaygiogiaohang datetime, @loaidondathang int, @hinhthuckhuyenmai int, @tienkhuyenmai money, 
	@giatri money, @mahinhthucthanhtoan int, @dadathang bit, @dathanhtoan int, @dagiaohang bit, @madonhang int out
as
begin
	insert into DON_HANG(NgayGioLap, DiaChiNhan, NguoiNhan, NgayGioGiaoHang, LoaiDonDatHang, HinhThucKhuyenMai, TienKhuyenMai, GiaTri, MaHinhThucThanhToan, DaDatHang, DaThanhToan, DaGiaoHang)
	values(@ngaygiolap, @diachinhan, @nguoinhan, @ngaygiogiaohang, @loaidondathang, @hinhthuckhuyenmai, @tienkhuyenmai, @giatri, @mahinhthucthanhtoan, @dadathang, @dathanhtoan, @dagiaohang)

	set @madonhang = ident_current('DON_HANG')
end
go

-- Xem thông tin tổng quát về giao dịch đơn hàng loại từ 1 - 4 (tổng đơn hàng, tổng trị giá)
-- loại 1: đơn hàng khách hàng đã lưu (@daDatHang = 0, @daThanhToan = 0, @daGiaoHang = 0)
-- loại 2: đơn hàng đã đặt hàng nhưng chưa thanh toán (@daDatHang = 1, @daThanhToan = 0, @daGiaoHang = 0)
-- loại 3: đơn hàng đã thanh toán nhưng chưa giao hàng (@daDatHang = 1, @daThanhToan = 1, @daGiaoHang = 0)
-- loại 4: đơn hàng đã hoàn tất(@daDatHang = 1, @daThanhToan = 1, @daGiaoHang = 1)
if object_id('spXemThongTinDonHangLoai1_4', 'p') is not null
	drop proc spXemThongTinDonHangLoai1_4
go
create proc spXemThongTinDonHangLoai1_4
	@maKhachHang int, @daDatHang bit, @daThanhToan bit, @daGiaoHang bit
as
begin
	select count(*) as SoLuongDonHang, sum(GiaTri) as TongTriGia from Don_Hang
	where MaKhachHang = @maKhachHang and LoaiDonDatHang = 0 and DaDatHang = @daDatHang
		and DaThanhToan = @daThanhToan and DaGiaoHang = @daGiaoHang
	
end
go 

-- Xem thông tin tổng quát về giao dịch đơn hàng loại 5 (tổng đơn hàng, tổng trị giá)
-- đơn hàng trong ngày (có thể đã thanh toán, hoặc chưa thanh toán)
if object_id('spXemThongTinDonHangTrongNgay', 'p') is not null
	drop proc spXemThongTinDonHangTrongNgay
go
create proc spXemThongTinDonHangTrongNgay
	@maKhachHang int
as
begin
	select count(*) as SoLuongDonHang, sum(GiaTri) as TongTriGia from Don_Hang
	where MaKhachHang = @maKhachHang and DATEDIFF(day, NgayGioLap, getdate()) = 0
		and LoaiDonDatHang = 0 and DaDatHang = 1 and DaGiaoHang = 0
end
go

-- Xem thông tin tổng quát về giao dịch đơn hàng loại 6 (tổng đơn hàng, tổng trị giá)
-- đơn hàng định kỳ
if object_id('spXemThongTinDonHangDinhKy', 'p') is not null
	drop proc spXemThongTinDonHangDinhKy
go
create proc spXemThongTinDonHangDinhKy
	@maKhachHang int
as
begin
	select count(*) as SoLuongDonHang, sum(GiaTri) as TongTriGia from Don_Hang
	where MaKhachHang = @maKhachHang and LoaiDonDatHang = 1
end
go

-- Xem danh sách các đơn hàng thuộc đơn hàng loại từ 1 - 4
-- loại 1: đơn hàng khách hàng đã lưu (@daDatHang = 0, @daThanhToan = 0, @daGiaoHang = 0)
-- loại 2: đơn hàng đã đặt hàng nhưng chưa thanh toán (@daDatHang = 1, @daThanhToan = 0, @daGiaoHang = 0)
-- loại 3: đơn hàng đã thanh toán nhưng chưa giao hàng (@daDatHang = 1, @daThanhToan = 1, @daGiaoHang = 0)
-- loại 4: đơn hàng đã hoàn tất(@daDatHang = 1, @daThanhToan = 1, @daGiaoHang = 1)
if object_id('spXemDanhSachDonHangLoai1_4', 'p') is not null
	drop proc spXemDanhSachDonHangLoai1_4
go
create proc spXemDanhSachDonHangLoai1_4
	@maKhachHang int, @daDatHang bit, @daThanhToan bit, @daGiaoHang bit,
	@pageNum int,
	@pageSize int
as
begin

	WITH s AS
	(
		SELECT ROW_NUMBER() OVER(ORDER BY NgayGioLap) AS RowNum, * FROM Don_Hang
		where MaKhachHang = @maKhachHang and LoaiDonDatHang = 0 and DaDatHang = @daDatHang
		and DaThanhToan = @daThanhToan and DaGiaoHang = @daGiaoHang
	)
	Select * From s
	Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize

end
go 

-- Xem danh sách các đơn hàng thuộc đơn hàng loại 5
-- đơn hàng trong ngày (có thể đã thanh toán, hoặc chưa thanh toán)
if object_id('spXemDanhSachDonHangTrongNgay', 'p') is not null
	drop proc spXemDanhSachDonHangTrongNgay
go
create proc spXemDanhSachDonHangTrongNgay
	@maKhachHang int,
	@pageNum int,
	@pageSize int
as
begin
	WITH s AS
	(
		SELECT ROW_NUMBER() OVER(ORDER BY NgayGioLap) AS RowNum, * FROM Don_Hang
		where MaKhachHang = @maKhachHang and DATEDIFF(day, NgayGioLap, getdate()) = 0
		and LoaiDonDatHang = 0 and DaDatHang = 1 and DaGiaoHang = 0
	)
	Select * From s
	Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize
end
go

-- Xem danh sách các đơn hàng thuộc đơn hàng loại 6
-- đơn hàng định kỳ
if object_id('spXemDanhSachDonHangDinhKy', 'p') is not null
	drop proc spXemDanhSachDonHangDinhKy
go
create proc spXemDanhSachDonHangDinhKy
	@maKhachHang int,
	@pageNum int,
	@pageSize int
as
begin
	WITH s AS
	(
		SELECT ROW_NUMBER() OVER(ORDER BY NgayGioLap) AS RowNum, * 
		FROM Don_Hang dh join Don_Hang_Dinh_Ky dhdk on dh.MaDonHang = dhdk.MaDonHangDinhKy
		where MaKhachHang = @maKhachHang and LoaiDonDatHang = 1
	)
	Select * From s
	Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize
end
go

-- Tổng đơn hàng loại từ 1 - 4 (dùng cho khách hàng, nhân viên)
-- loại 1: đơn hàng khách hàng đã lưu (@daDatHang = 0, @daThanhToan = 0, @daGiaoHang = 0)
-- loại 2: đơn hàng đã đặt hàng nhưng chưa thanh toán (@daDatHang = 1, @daThanhToan = 0, @daGiaoHang = 0)
-- loại 3: đơn hàng đã thanh toán nhưng chưa giao hàng (@daDatHang = 1, @daThanhToan = 1, @daGiaoHang = 0)
-- loại 4: đơn hàng đã hoàn tất(@daDatHang = 1, @daThanhToan = 1, @daGiaoHang = 1)
if object_id('spTongDonHangLoai1_4', 'p') is not null
	drop proc spTongDonHangLoai1_4
go
create proc spTongDonHangLoai1_4
	@maKhachHang int, @daDatHang bit, @daThanhToan bit, @daGiaoHang bit
as
begin
	select count(*) as SoLuongDonHang from Don_Hang
	where MaKhachHang = @maKhachHang and LoaiDonDatHang = 0 and DaDatHang = @daDatHang
		and DaThanhToan = @daThanhToan and DaGiaoHang = @daGiaoHang
	
end
go 

-- Tổng đơn hàng loại 5
-- đơn hàng trong ngày (có thể đã thanh toán, hoặc chưa thanh toán)
if object_id('spTongDonHangTrongNgay', 'p') is not null
	drop proc spTongDonHangTrongNgay
go
create proc spTongDonHangTrongNgay
	@maKhachHang int
as
begin
	select count(*) as SoLuongDonHang from Don_Hang
	where MaKhachHang = @maKhachHang and DATEDIFF(day, NgayGioLap, getdate()) = 0
		and LoaiDonDatHang = 0 and DaDatHang = 1 and DaGiaoHang = 0
	
end
go

-- Tổng đơn hàng loại 6
-- đơn hàng định kỳ
if object_id('spTongDonHangDinhKy', 'p') is not null
	drop proc spTongDonHangDinhKy
go
create proc spTongDonHangDinhKy
	@maKhachHang int
as
begin
	select count(*) as SoLuongDonHang from Don_Hang
	where MaKhachHang = @maKhachHang and LoaiDonDatHang = 1
end
go

-- Xóa đơn hàng
if object_id('spXoaDonHang', 'p') is not null
	drop proc spXoaDonHang
go
create proc spXoaDonHang
@maDonHang int
as 
begin
	delete from CT_DON_HANG
	where MaDonHang = @maDonHang

	delete from Don_Hang where MaDonHang=@maDonHang
end
go

--Xóa đơn hàng định kỳ
if object_id('spXoaDonHangDinhKy', 'p') is not null
	drop proc spXoaDonHangDinhKy
go
create proc spXoaDonHangDinhKy
@maDonHang int
as 
begin
	delete from CT_DON_HANG
	where MaDonHang = @maDonHang
	
	delete from Don_Hang_Dinh_Ky where MaDonHangDinhKy=@maDonHang

	delete from Don_Hang where MaDonHang=@maDonHang
end
go

-- Thông tin về đơn hàng
if object_id('spLayThongTinDonHang', 'p') is not null
	drop proc spLayThongTinDonHang
go
create proc spLayThongTinDonHang
@maDonHang int
as 
begin
	select * from Don_Hang where MaDonHang = @maDonHang
end

go
-- Tổng đơn hàng đã hoàn tất trong ngày (nhân viên)
if object_id('spTongDonHangDaHoanTatTrongNgay', 'p') is not null
	drop proc spTongDonHangDaHoanTatTrongNgay
go
create proc spTongDonHangDaHoanTatTrongNgay
as
begin
	select count(*) as SoLuongDonHang from Don_Hang
	where DATEDIFF(day, NgayGioGiaoHang, getdate()) = 0
		and LoaiDonDatHang = 0 and DaDatHang = 1 and DaGiaoHang = 1 and DaThanhToan = 1	
end
go

-- Tổng đơn hàng chưa hoàn tất (nhân viên)
if object_id('spTongDonHangChuaHoanTat', 'p') is not null
	drop proc spTongDonHangChuaHoanTat
go
create proc spTongDonHangChuaHoanTat	
@daThanhToan bit
as
begin
	select count(*) as SoLuongDonHang from Don_Hang
	where LoaiDonDatHang = 0 and DaDatHang = 1
		and DaThanhToan = @daThanhToan and DaGiaoHang = 0
end
go

-- Xem danh sách các đơn hàng đã hoàn tất trong ngày (nhân viên)
if object_id('spXemDanhSachDonHangDaHoanTatTrongNgay', 'p') is not null
	drop proc spXemDanhSachDonHangDaHoanTatTrongNgay
go
create proc spXemDanhSachDonHangDaHoanTatTrongNgay
	@pageNum int,
	@pageSize int
as
begin
	WITH s AS
	(
		SELECT ROW_NUMBER() OVER(ORDER BY NgayGioLap) AS RowNum, * FROM Don_Hang
		where DATEDIFF(day, NgayGioGiaoHang, getdate()) = 0
		and LoaiDonDatHang = 0 and DaDatHang = 1 and DaGiaoHang = 1 and DaThanhToan = 1
	)
	Select * From s
	Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize
end
go

-- Xem danh sách các đơn hàng chưa hoàn tất (nhân viên)
if object_id('spXemDanhSachDonHangChuaHoanTat', 'p') is not null
	drop proc spXemDanhSachDonHangChuaHoanTat
go
create proc spXemDanhSachDonHangChuaHoanTat
	@daThanhToan bit,
	@pageNum int,
	@pageSize int
as
begin
	WITH s AS
	(
		SELECT ROW_NUMBER() OVER(ORDER BY NgayGioLap) AS RowNum, * FROM Don_Hang
		where LoaiDonDatHang = 0 and DaDatHang = 1 and DaGiaoHang = 0 and DaThanhToan = @daThanhToan
	)
	Select * From s
	Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize
end
go

-- Thông tin về đơn hàng định kỳ
if object_id('spLayThongTinDonHangDinhKy', 'p') is not null
	drop proc spLayThongTinDonHangDinhKy
go
create proc spLayThongTinDonHangDinhKy
@maDonHang int
as 
begin
	SELECT * 
	FROM Don_Hang dh join Don_Hang_Dinh_Ky dhdk on dh.MaDonHang = dhdk.MaDonHangDinhKy
	where dh.MaDonHang = @maDonHang
end
go
