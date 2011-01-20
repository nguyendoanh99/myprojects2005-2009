if object_id('spLayDanhSachHTTT', 'p') is not null
	drop proc spLayDanhSachHTTT
go
create proc spLayDanhSachHTTT
as
begin
	select * from HINH_THUC_THANH_TOAN
end
go