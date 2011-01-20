
--Thông kê doanh thu trong một khoảng time 
if object_id('spThongKeDoanhThuTrongMotKhoangTime', 'p') is not null
	drop proc spThongKeDoanhThuTrongMotKhoangTime
go
create proc spThongKeDoanhThuTrongMotKhoangTime
	@ngaybatdau smalldatetime, @ngayketthuc smalldatetime, @doanhthu money out
as
begin
	select @doanhthu = sum(GiaTri)
	from DON_HANG
	where DaThanhToan = 1
	and datediff(d, NgayGioGiaoHang, @ngaybatdau) <= 0
	and datediff(d, NgayGioGiaoHang, @ngayketthuc) >= 0

end
go

/*
declare @dt money
exec spThongKeDoanhThuTrongMotKhoangTime '01/01/2008', '01/02/2008', @dt out
select @dt

select sum(GiaTri) from don_hang
where DaThanhToan = 1
and NgayGioGiaoHang between '20080101' and '20080201'


select * from loai_nguoi_dung
select * from nguoi_dung
select * from khach_hang
*/

--Thống kê doanh thu theo ngày
if object_id('spThongKeDoanhThuTheoNgay', 'p') is not null
	drop proc spThongKeDoanhThuTheoNgay
go
create proc spThongKeDoanhThuTheoNgay
	@ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, DoanhThu money)
	declare @doanhthu money

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		exec spThongKeDoanhThuTrongMotKhoangTime @ngaybatdau, @ngaybatdau, @doanhthu out	

		if @doanhthu is NULL			
			set @doanhthu = 0
		
		insert into @table values(@ngaybatdau, @ngaybatdau, @doanhthu)

		set @ngaybatdau = dateadd(day, 1, @ngaybatdau)
	end

	select * from @table
end
go

--exec spThongKeDoanhThuTheoNgay '20080101', '20080107'

--Thống kê doanh thu theo tuần
if object_id('spThongKeDoanhThuTheoTuan', 'p') is not null
	drop proc spThongKeDoanhThuTheoTuan
go
create proc spThongKeDoanhThuTheoTuan
	@ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, DoanhThu money)
	declare @doanhthu money
	declare @ngaycuoituan smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoituan = dateadd(day, 6, @ngaybatdau)

		exec spThongKeDoanhThuTrongMotKhoangTime @ngaybatdau, @ngaycuoituan, @doanhthu out	
		if @doanhthu is NULL			
			set @doanhthu = 0
		
		insert into @table values(@ngaybatdau, @ngaycuoituan, @doanhthu)
		set @ngaybatdau = dateadd(day, 1, @ngaycuoituan)
	end

	select * from @table
end
go

--exec spThongKeDoanhThuTheoTuan '20080101', '20080222'

--Thống kê doanh thu theo tháng
if object_id('spThongKeDoanhThuTheoThang', 'p') is not null
	drop proc spThongKeDoanhThuTheoThang
go
create proc spThongKeDoanhThuTheoThang
	@ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, DoanhThu money)
	declare @doanhthu money
	declare @ngaycuoithang smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoithang = dateadd(day, -1, dateadd(month, 1, @ngaybatdau))

		exec spThongKeDoanhThuTrongMotKhoangTime @ngaybatdau, @ngaycuoithang, @doanhthu out		
		if @doanhthu is NULL			
			set @doanhthu = 0		
		insert into @table values(@ngaybatdau, @ngaycuoithang, @doanhthu)
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

--Thống kê doanh thu theo tháng
if object_id('spThongKeDoanhThuTheoQuy', 'p') is not null
	drop proc spThongKeDoanhThuTheoQuy
go
create proc spThongKeDoanhThuTheoQuy
	@ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, DoanhThu money)
	declare @doanhthu money
	declare @ngaycuoiquy smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoiquy = dateadd(day, -1, dateadd(month, 3, @ngaybatdau))

		exec spThongKeDoanhThuTrongMotKhoangTime @ngaybatdau, @ngaycuoiquy, @doanhthu out	
		if @doanhthu is NULL			
			set @doanhthu = 0			
		insert into @table values(@ngaybatdau, @ngaycuoiquy, @doanhthu)
		set @ngaybatdau = dateadd(day, 1, @ngaycuoiquy)
	end

	select * from @table
end
go
--DECLARE @mydate DATETIME
--SET @mydate = '20060101'
--SELECT dateadd(day, -1, dateadd(month, 3, @mydate))


--Thống kê doanh thu theo năm
if object_id('spThongKeDoanhThuTheoNam', 'p') is not null
	drop proc spThongKeDoanhThuTheoNam
go
create proc spThongKeDoanhThuTheoNam
	@ngaybatdau smalldatetime, @ngayketthuc smalldatetime
as
begin
	declare @table Table(NgayBatDau smalldatetime, NgayKetThuc smalldatetime, DoanhThu money)
	declare @doanhthu money
	declare @ngaycuoinam smalldatetime

	while(datediff(day, @ngaybatdau, @ngayketthuc) >= 0)
	begin
		set @ngaycuoinam = dateadd(day, -1, dateadd(year, 1, @ngaybatdau))

		exec spThongKeDoanhThuTrongMotKhoangTime @ngaybatdau, @ngaycuoinam, @doanhthu out
		if @doanhthu is NULL			
			set @doanhthu = 0
				
		insert into @table values(@ngaybatdau, @ngaycuoinam, @doanhthu)
		set @ngaybatdau = dateadd(day, 1, @ngaycuoinam)
	end

	select * from @table
end
go
--DECLARE @mydate DATETIME
--SET @mydate = '20060101'
--SELECT dateadd(day, -1, dateadd(year, 1, @mydate))



