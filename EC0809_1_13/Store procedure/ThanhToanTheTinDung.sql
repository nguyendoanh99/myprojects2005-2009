-- THEM THANH TOAN THE TIN DUNG
if object_id('spThemThanhToanTheTinDung', 'p') is not null
	drop proc spThemThanhToanTheTinDung
go
create proc spThemThanhToanTheTinDung
	@madonhang int, @maloaithe int, @sothe varchar(50), @ngayhh datetime
as
begin
		insert into THANH_TOAN_THE_TIN_DUNG
           ([MaDonHang]
           ,[MaLoaiThe]
		   ,[SoThe]
		   ,[NgayHetHan])
		VALUES(@madonhang, @maloaithe, @sothe, @ngayhh)
end
go


--Xoa thanh toan the tin dung
if object_id('spXoaThanhToanTheTinDung', 'p') is not null
	drop proc spXoaThanhToanTheTinDung
go
create proc spXoaThanhToanTheTinDung
@maDonHang int
as 
begin
	delete from CT_DON_HANG
	where MaDonHang = @maDonHang

	delete from Thanh_toan_the_tin_dung where MaDonHang=@maDonHang
end
go