
-- THEM THUC DON ca nhan
if object_id('spThemThucDonTuTao', 'p') is not null
	drop proc spThemThucDonTuTao
go
create proc spThemThucDonTuTao
	@makhachhang int, @tenthucdon nvarchar(30), @dongia money, @hinhanh nvarchar(255), @mathucdoncanhan int out
as
begin
	INSERT INTO THUC_DON_CA_NHAN(MaKhachHang, TenThucDon, HinhAnh, Gia)
     VALUES(@makhachhang, @tenthucdon, @hinhanh, @dongia)

	 set @mathucdoncanhan = ident_current('THUC_DON_CA_NHAN')
end
go

--declare @ma int
--exec spThemThucDonTuTao 9, 'abc', @ma out

if object_id('spThemCTThucDonCaNhan', 'p') is not null
	drop proc spThemCTThucDonCaNhan
go
create proc spThemCTThucDonCaNhan
	@mathucdoncanhan int, @mamon int, @mactthucdoncanhan int out
as
begin
	insert into CT_THUC_DON_CA_NHAN(MaThucDonCaNhan, MaMon)
    values(@mathucdoncanhan, @mamon)

	 set @mactthucdoncanhan = ident_current('CT_THUC_DON')
end
go

-- Lấy thông tin thực đơn cá nhân
if object_id('spLayThongTinThucDonCaNhan', 'p') is not null
	drop proc spLayThongTinThucDonCaNhan
go
create proc spLayThongTinThucDonCaNhan
		@maThucDonCaNhan int
as
begin
	select * from THUC_DON_CA_NHAN
	where MaThucDonCaNhan = @maThucDonCaNhan
end
go
--declare @ma int
--exec spThemCTThucDonCaNhan 2, 61, @ma out

--select * from mon_an
--select * from thuc_don_ca_nhan
--select * from ct_thuc_don_ca_nhan
--select * from khach_hang
--select * from nguoi_dung

--lay danh sach thuc don ca nhan cua khach hang
if object_id('spLayDSThucDonTuTao', 'p') is not null
	drop proc spLayDSThucDonTuTao
go
create proc spLayDSThucDonTuTao
	@makhachhang int
as
begin
	select * from THUC_DON_CA_NHAN where MaKhachHang = @makhachhang	 
end
go

-- Lay danh sách các món ăn trong thực đơn cá nhân
if object_id('spLayChiTietThucDonCaNhan', 'p') is not null
	drop proc spLayChiTietThucDonCaNhan
go
create proc spLayChiTietThucDonCaNhan
		@maThucDonCaNhan int
as
begin
	select MaMon from CT_THUC_DON_CA_NHAN
	where MaThucDonCaNhan = @maThucDonCaNhan
end
go