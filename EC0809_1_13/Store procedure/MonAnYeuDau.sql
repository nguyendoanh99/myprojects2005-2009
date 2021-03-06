if object_id('spThemMonAnYeuDau', 'p') is not null
	drop proc spThemMonAnYeuDau
go
create proc spThemMonAnYeuDau
	@makhachhang int, @mamon int, @mamonyeudau int out
as
begin
	INSERT INTO MON_AN_YEU_DAU(MaKhachHang, MaMon)
     VALUES(@makhachhang, @mamon)

	 set @mamonyeudau = ident_current('MON_AN_YEU_DAU')
end
go

--lay danh sách món ăn yêu thích của khách hàng
if object_id('spLayDSMonAnYeuThich', 'p') is not null
	drop proc spLayDSMonAnYeuThich
go
create proc spLayDSMonAnYeuThich
	@makhachhang int
as
begin
	select * from MON_AN_YEU_DAU where MaKhachHang = @makhachhang	 
end
go

--xoa đi 1 thực đơn ưa thích của khách hàng
if object_id('spXoaMonAnYeuDau', 'p') is not null
	drop proc spXoaMonAnYeuDau
go
create proc spXoaMonAnYeuDau
	@makhachhang int, @mamon int
as
begin
	delete from MON_AN_YEU_DAU where MaKhachHang = @makhachhang and MaMon = @mamon
end
go