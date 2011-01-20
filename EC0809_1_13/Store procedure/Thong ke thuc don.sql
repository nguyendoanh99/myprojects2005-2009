
--/////////////////THỐNG KÊ THỰC ĐƠN
--Thống kê số lượng thực đơn đã bán trong 1 khoảng time
if object_id('spThongKeThucDonTrongMotKhoangTime', 'p') is not null
	drop proc spThongKeThucDonTrongMotKhoangTime
go
create proc spThongKeThucDonTrongMotKhoangTime
	@mathucdon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime, @soluong int out
as
begin
	select @soluong = sum(SoLuong)
	from DON_HANG dh, CT_DON_HANG ct
	where dh.MaDonHang = ct.MaDonHang
	and ct.LoaiItem = 1		--> 0 : món ăn, 1 : thực đơn
	and ct.MaItem = @mathucdon
	and dh.DaGiaoHang = 1
	and datediff(d, NgayGioGiaoHang, @ngaybatdau) <= 0
	and datediff(d, NgayGioGiaoHang, @ngayketthuc) >= 0
end
go


--Thống kê món ăn theo ngày
if object_id('spThongKeThucDonTheoNgay', 'p') is not null
	drop proc spThongKeThucDonTheoNgay
go
create proc spThongKeThucDonTheoNgay
	@mathucdon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, SoLuongBan int)
	declare @soluongban int

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		exec spThongKeThucDonTrongMotKhoangTime @mathucdon, @ngaybatdau, @ngaybatdau, @soluongban out		
		if @soluongban is null			
			set @soluongban = 0
		
		insert into @table values(@ngaybatdau, @ngaybatdau, @soluongban)
		set @ngaybatdau = dateadd(day, 1, @ngaybatdau)
	end

	select * from @table
end
go

--select * from thuc_don
--EXEC spThongKeThucDonTheoThang 5, '20080104', '20080719'

--Thống kê thực đơn bán theo tuần
if object_id('spThongKeThucDonTheoTuan', 'p') is not null
	drop proc spThongKeThucDonTheoTuan
go
create proc spThongKeThucDonTheoTuan
	@mathucdon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, SoLuongBan int)
	declare @soluongban int
	declare @ngaycuoituan smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoituan = dateadd(day, 6, @ngaybatdau)

		exec spThongKeThucDonTrongMotKhoangTime @mathucdon, @ngaybatdau, @ngaycuoituan, @soluongban out		
		if @soluongban is null			
			set @soluongban = 0
		
		insert into @table values(@ngaybatdau, @ngaycuoituan, @soluongban)
		set @ngaybatdau = dateadd(day, 1, @ngaycuoituan)
	end

	select * from @table
end
go


--Thống kê thực đơn theo tháng
if object_id('spThongKeThucDonTheoThang', 'p') is not null
	drop proc spThongKeThucDonTheoThang
go
create proc spThongKeThucDonTheoThang
	@mathucdon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, SoLuongBan int)
	declare @soluongban int
	declare @ngaycuoithang smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoithang = dateadd(day, -1, dateadd(month, 1, @ngaybatdau))

		exec spThongKeThucDonTrongMotKhoangTime @mathucdon, @ngaybatdau, @ngaycuoithang, @soluongban out	
		if @soluongban is null			
			set @soluongban = 0
			
		insert into @table values(@ngaybatdau, @ngaycuoithang, @soluongban)
		set @ngaybatdau = dateadd(day, 1, @ngaycuoithang)
	end

	select * from @table
end
go

--DECLARE @mydate DATETIME
--SET @mydate = '20060201'
--SELECT dateadd(day, 1, DATEADD(MONTH,DATEDIFF(MONTH,30,@mydate)+1,30)

--DECLARE @mydate DATETIME
--SET @mydate = '20060201'
--select dateadd(month, 1, @mydate)
--SELECT dateadd(day, -1, dateadd(month, 1, @mydate))

--Thống kê số lượng thực đơn bán theo quý
if object_id('spThongKeThucDonTheoQuy', 'p') is not null
	drop proc spThongKeThucDonTheoQuy
go
create proc spThongKeThucDonTheoQuy
	@mathucdon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, SoLuongBan int)
	declare @soluongban int
	declare @ngaycuoiquy smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoiquy = dateadd(day, -1, dateadd(month, 3, @ngaybatdau))

		exec spThongKeThucDonTrongMotKhoangTime @mathucdon, @ngaybatdau, @ngaycuoiquy, @soluongban out		
		if @soluongban is null			
			set @soluongban = 0
		
		insert into @table values(@ngaybatdau, @ngaycuoiquy, @soluongban)
		set @ngaybatdau = dateadd(day, 1, @ngaycuoiquy)
	end

	select * from @table
end
go

/*
DECLARE @mydate DATETIME
SET @mydate = '20060101'
SELECT dateadd(day, -1, dateadd(month, 3, @mydate))
*/

--Thống kê doanh thu theo năm
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spThongKeThucDonTheoNam]
	@mathucdon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, SoLuongBan int)
	declare @soluongban int
	declare @ngaycuoinam smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoinam = dateadd(day, -1, dateadd(year, 1, @ngaybatdau))

		exec spThongKeThucDonTrongMotKhoangTime @mathucdon, @ngaybatdau, @ngaycuoinam, @soluongban out	
		if @soluongban is null			
			set @soluongban = 0
			
		insert into @table values(@ngaybatdau, @ngaycuoinam, @soluongban)
		set @ngaybatdau = dateadd(day, 1, @ngaycuoinam)
	end

	select * from @table
end
go