if object_id('spLayDanhSachHTKM', 'p') is not null
	drop proc spLayDanhSachHTKM
go
create proc spLayDanhSachHTKM
as
begin
	select * from HINH_THUC_KHUYEN_MAI
end
go

if object_id('spThongTinHTKM', 'p') is not null
	drop proc spThongTinHTKM
go
create proc spThongTinHTKM
@maHinhThucKhuyenMai int
as
begin
	select * from HINH_THUC_KHUYEN_MAI where MaHinhThucKhuyenMai = @maHinhThucKhuyenMai
end
go