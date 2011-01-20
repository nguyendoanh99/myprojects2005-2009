if object_id('spThemChiTietDonHang', 'p') is not null
	drop proc spThemChiTietDonHang
go
create proc spThemChiTietDonHang
	@madonhang int, @maitem int, @loaiitem int, @soluong int, @thanhtien money, 
@laquatang bit,
@machitietdonhang int out
as
begin
	insert into CT_DON_HANG(MaDonHang, MaItem, LoaiItem, SoLuong, ThanhTien, LaQuaTang)
	values(@madonhang, @maitem, @loaiitem, @soluong, @thanhtien, @laquatang)

	set @machitietdonhang = ident_current('CT_DON_HANG')
end
go

-- Lấy danh sách ct đơn hàng
if object_id('spLayDSCTDonHang', 'p') is not null
	drop proc spLayDSCTDonHang
go
create proc spLayDSCTDonHang
	@maDonHang int
as
begin
	select * from CT_Don_Hang where MaDonHang = @maDonHang
end
go