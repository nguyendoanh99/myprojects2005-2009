
--/////////////////THỐNG KÊ MÓN ĂN
--Thống kê số lượng món ăn đã bán trong 1 khoảng time
if object_id('spThongKeMonAnTrongMotKhoangTime', 'p') is not null
	drop proc spThongKeMonAnTrongMotKhoangTime
go
create proc spThongKeMonAnTrongMotKhoangTime
	@mamon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime, @soluong int out
as
begin
	select @soluong = SUM(SoLuong)
	from DON_HANG dh, CT_DON_HANG ct
	where dh.MaDonHang = ct.MaDonHang
	and ct.LoaiItem = 0		--> 0 : món ăn, 1 : thực đơn
	and ct.MaItem = @mamon
	and dh.DaGiaoHang = 1
	and datediff(d, NgayGioGiaoHang, @ngaybatdau) <= 0
	and datediff(d, NgayGioGiaoHang, @ngayketthuc) >= 0
end
go

--select * from mon_an
--declare @soluong int
--exec spThongKeMonAnTrongMotKhoangTime 61, '20080101', '20080119', @soluong out
--select @soluong

--Thống kê món ăn theo ngày
if object_id('spThongKeMonAnTheoNgay', 'p') is not null
	drop proc spThongKeMonAnTheoNgay
go
create proc spThongKeMonAnTheoNgay
	@mamon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, SoLuongBan int)
	declare @soluongban int

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		exec spThongKeMonAnTrongMotKhoangTime @mamon, @ngaybatdau, @ngaybatdau, @soluongban out				
		if @soluongban is NULL			
			set @soluongban = 0

		insert into @table values(@ngaybatdau, @ngaybatdau, @soluongban)
		set @ngaybatdau = dateadd(day, 1, @ngaybatdau)
	end

	select * from @table
end
go

--select * from don_hang
--EXEC spThongKeMonAnTheoNgay 61, '20080101', '20080119'

--Thống kê món ăn bán theo tuần
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spThongKeMonAnTheoTuan]
	@mamon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, SoLuongBan int)
	declare @soluongban int
	declare @ngaycuoituan smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoituan = dateadd(day, 6, @ngaybatdau)
		exec spThongKeMonAnTrongMotKhoangTime @mamon, @ngaybatdau, @ngaycuoituan, @soluongban out				
		if @soluongban is NULL			
			set @soluongban = 0

		insert into @table values(@ngaybatdau, @ngaycuoituan, @soluongban)
		set @ngaybatdau = dateadd(day, 1, @ngaycuoituan)
	end

	select * from @table
end
go

--EXEC spThongKeMonAnTheoTuan 61, '20080101', '20080119'

--Thống kê món ăn bán theo tháng
if object_id('spThongKeMonAnTheoThang', 'p') is not null
	drop proc spThongKeMonAnTheoThang
go
create proc spThongKeMonAnTheoThang
	@mamon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, SoLuongBan int)
	declare @soluongban int
	declare @ngaycuoithang smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoithang = dateadd(day, -1, dateadd(month, 1, @ngaybatdau))

		exec spThongKeMonAnTrongMotKhoangTime @mamon, @ngaybatdau, @ngaycuoithang, @soluongban out		
		if @soluongban is NULL			
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

--Thống kê món ăn theo quý
if object_id('spThongKeMonAnTheoQuy', 'p') is not null
	drop proc spThongKeMonAnTheoQuy
go
create proc spThongKeMonAnTheoQuy
	@mamon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, SoLuongBan int)
	declare @soluongban int
	declare @ngaycuoiquy smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoiquy = dateadd(day, -1, dateadd(month, 3, @ngaybatdau))

		exec spThongKeMonAnTrongMotKhoangTime @mamon, @ngaybatdau, @ngaycuoiquy, @soluongban out	
		if @soluongban is NULL			
			set @soluongban = 0			
		insert into @table values(@ngaybatdau, @ngaycuoiquy, @soluongban)
		set @ngaybatdau = dateadd(day, 1, @ngaycuoiquy)
	end

	select * from @table
end
go
--DECLARE @mydate DATETIME
--SET @mydate = '20060101'
--SELECT dateadd(day, -1, dateadd(month, 3, @mydate))


--Thống kê món ăn bán theo năm
if object_id('spThongKeMonAnTheoNam', 'p') is not null
	drop proc spThongKeMonAnTheoNam
go
create proc spThongKeMonAnTheoNam
	@mamon int, @ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, SoLuongBan int)
	declare @soluongban int
	declare @ngaycuoinam smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoinam = dateadd(day, -1, dateadd(year, 1, @ngaybatdau))

		exec spThongKeMonAnTrongMotKhoangTime @mamon, @ngaybatdau, @ngaycuoinam, @soluongban out		
		if @soluongban is NULL			
			set @soluongban = 0
		
		insert into @table values(@ngaybatdau, @ngaycuoinam, @soluongban)
		set @ngaybatdau = dateadd(day, 1, @ngaycuoinam)
	end

	select * from @table
end
go