

if object_id('spLayThamSo', 'p') is not null
	drop proc spLayThamSo
go
create proc spLayThamSo
as
begin
	select * from THAM_SO
end
go

if object_id('spLuuThamSo', 'p') is not null
	drop proc spLuuThamSo
go
create proc spLuuThamSo
@GiaTriDiemSo money,
@DiemKhachHangThanThiet int, 
@TiLeGiamGiaThucDon float,
@Thue float, 
@GiaTriDoiDiemKhuyenMai money,
@GioiHanDoiDiemKhuyenMai float
as
begin
	update Tham_So set GiaTriDiemSo = @GiaTriDiemSo, DiemKhachHangThanThiet = @DiemKhachHangThanThiet,
		TiLeGiamGiaThucDon = @TiLeGiamGiaThucDon, Thue = @Thue, GiaTriDoiDiemKhuyenMai = @GiaTriDoiDiemKhuyenMai,
		GioiHanDoiDiemKhuyenMai = @GioiHanDoiDiemKhuyenMai
end
go

