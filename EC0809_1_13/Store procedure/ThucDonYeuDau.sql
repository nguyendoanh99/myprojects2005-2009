if object_id('spThemThucDonYeuThich', 'p') is not null
	drop proc spThemThucDonYeuThich
go
create proc spThemThucDonYeuThich
	@makhachhang int, @mathucdon int, @mathucdonyeudau int out
as
begin
	INSERT INTO THUC_DON_YEU_DAU(MaKhachHang, MaThucDon)
     VALUES(@makhachhang, @mathucdon)

	 set @mathucdonyeudau = ident_current('THUC_DON_YEU_DAU')
end
go

--lay danh sách thục đơn yêu thích của khách hàng
if object_id('spLayDSThucDonYeuThich', 'p') is not null
	drop proc spLayDSThucDonYeuThich
go
create proc spLayDSThucDonYeuThich
	@makhachhang int
as
begin
	select * from THUC_DON_YEU_DAU where MaKhachHang = @makhachhang	 
end
go

--xoa đi 1 thực đơn ưa thích của khách hàng
if object_id('spXoaThucDonYeuThich', 'p') is not null
	drop proc spXoaThucDonYeuThich
go
create proc spXoaThucDonYeuThich
	@makhachhang int, @mathucdon int
as
begin
	delete from THUC_DON_YEU_DAU where MaKhachHang = @makhachhang and MaThucDon = @mathucdon
end
go