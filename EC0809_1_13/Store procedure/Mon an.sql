
-- PHÂN TRANG
if object_id('spPhanTrang', 'p') is not null
	drop proc spPhanTrang
go
create proc spPhanTrang
    @pageNum int,
    @pageSize int
AS
Begin
    Begin
		WITH s AS
		(
			SELECT ROW_NUMBER() OVER(ORDER BY MaMon, TenMon) AS RowNum, *
			FROM MON_AN
		)
		Select * From s
		Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize
    End
    Select Count(*) as Total from MON_AN
End
GO

--exec spPhanTrang 3, 5
if object_id('spLayDSMonAnHienThi', 'P') is not null
	drop proc spLayDSMonAnHienThi
go
create proc spLayDSMonAnHienThi
		@pageNum int,
		@pageSize int
as
begin
	WITH s AS
	(
		SELECT ROW_NUMBER() OVER(ORDER BY MaMon) AS RowNum, *
		FROM MON_AN
		where TrangThaiHienThi = 1
	)
	Select * From s
	Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize
	
end
go
--exec spLayDSMonAnHienThi 2, 4

--DANH SÃCH MÃ“N Ä‚N Cá»¦A 1 LOáº I MÃ“N á»ž Cáº¤P Báº¤T KÃŒ (giá»‘ng Ä‘á»‡ quy)
if object_id('spLayDSMonAnThuocLoaiMonBatKy', 'P') is not null
	drop proc spLayDSMonAnThuocLoaiMonBatKy
go
create proc spLayDSMonAnThuocLoaiMonBatKy
	@maloaimon int
as
begin
	declare @lala bit
	select @lala = LaLoaiMonLa
	from LOAI_MON
	where MaLoaiMon = @maloaimon
	
	if @lala = 1
	begin
		exec spLayDSMonAnThuocLoaiMon @maloaimon
		return
	end

	DECLARE @RecordList table (MaLoaiMon int, LaLoaiMonLa bit)

	--Seed the table with the @CatID value
	INSERT INTO @RecordList (MaLoaiMon, LaLoaiMonLa)
		SELECT MaLoaiMon, LaLoaiMonLa
		FROM LOAI_MON
		WHERE MaLoaiMonCha = @maloaimon

	--Add new child records until exhausted.
	WHILE @@RowCount > 0
	INSERT INTO @RecordList (MaLoaiMon, LaLoaiMonLa)
		SELECT lmon.MaLoaiMon, lmon.LaLoaiMonLa
		FROM LOAI_MON lmon
		INNER JOIN @RecordList RecordList ON lmon.MaLoaiMonCha = RecordList.MaLoaiMon
		WHERE NOT EXISTS(SELECT * FROM @RecordList CurrentRecords WHERE CurrentRecords.MaLoaiMon= lmon.MaLoaiMon)

	--Return the result set
	--SELECT MaLoaiMon
	--FROM @RecordList 

	declare cur_DSKetQua cursor scroll
	for select MaLoaiMon from @RecordList where LaLoaiMonLa = 1
	open cur_DSKetQua

	--DECLARE @MonAnList table (MaLoaiMon int, LaLoaiMonLa bit)

	declare @malm int
	fetch next from cur_DSKetQua into @malm
	while @@fetch_status = 0
	begin
		exec spLayDSMonAnThuocLoaiMon @malm
		fetch next from cur_DSKetQua into @malm
	end

	close cur_DSKetQua
	deallocate cur_DSKetQua
end
go



--exec spLayDSMonAnThuocLoaiMonBatKy 4
--select * from loai_mon

if object_id('spLayTongSoMonAn', 'P') is not null
	drop proc spLayTongSoMonAn
go
create proc spLayTongSoMonAn
as
begin
	select count(*) from MON_AN
end
go

--exec spLayTongSoMonAn


if object_id('spLayDanhSachLoaiMonLa', 'p') is not null
	drop proc spLayDanhSachLoaiMonLa
go
create proc spLayDanhSachLoaiMonLa
as
begin
	select * from LOAI_MON
	where LaLoaiMonLa = 1
end
go

--exec spLayDanhSachLoaiMonLa


--L?Y DANH SÁCH MÓN ?N
if object_id('spLayDanhSachMonAn', 'p') is not null
	drop proc spLayDanhSachMonAn
go
create proc spLayDanhSachMonAn
@pageNum int,
@pageSize int
as
begin
	WITH s AS
	(
		SELECT ROW_NUMBER() OVER(ORDER BY MaMon) AS RowNum, * FROM Mon_An
	)
	Select * From s
	Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize
end
go
--EXEC spLayDanhSachMonAn

--insert into Loai_mon(TenLoaiMon, LaLoaiMonLa) values(N'B? g?' , 1)
--insert into Loai_mon(TenLoaiMon, LaLoaiMonLa) values(N'N??c u?ng' , 0)
--insert into Loai_mon(TenLoaiMon, LaLoaiMonLa) values(N'C?m' , 0)

--THÊM MÓN ?N
if object_id('spThemMonAn', 'p') is not null
	drop proc spThemMonAn
go
create proc spThemMonAn
	@tenmon nvarchar(50), @hinhanhminhhoa nvarchar(255), @mota ntext, 
	@diembinhchon int, @donvitinh nvarchar(20), @gia money, @maloaimon int, 
	@tinhtrang bit, @trangthaihienthi bit, @mamon int out
as
begin
	insert into MON_AN
           ([TenMon]
           ,[HinhAnhMinhHoa]
           ,[MoTa]
           ,[DiemBinhChon]
           ,[DonViTinh]
           ,[Gia]
           ,[MaLoaiMon]
           ,[TinhTrang]
           ,[TrangThaiHienThi])
     VALUES(@tenmon, @hinhanhminhhoa, @mota, @diembinhchon, @donvitinh, @gia, @maloaimon, @tinhtrang,
			@trangthaihienthi)
	set @mamon = ident_current('MON_AN')
	     
end
GO

--declare @mamon int
--exec spThemMonAn 'aaa', 'url', 'mota', 100, 'chai', 12000, 3, 1, 1, @mamon out
--select @mamon

--LAY DANH SACH MON AN THEO TAG
if object_id('spDanhSachMonTheoTag', 'p') is not null
	drop proc spDanhSachMonTheoTag
go
CREATE proc spDanhSachMonTheoTag
@ma_tag int
AS begin
	select * from MON_AN ma join TAG_MON_AN tag on tag.MaMon = ma.MaMon where tag.MaTag = @ma_tag
end
go

--LAY DANH SACH QUA TANG
if object_id('spLayDanhSachQuaTang', 'p') is not null
	drop proc spLayDanhSachQuaTang
go
create proc spLayDanhSachQuaTang
@gia money
as
begin
	select * from MON_AN
	where Gia < @gia
end
go
-- Lấy thông tin món ăn
if object_id('spLayThongTinMonAn', 'p') is not null
	drop proc spLayThongTinMonAn
go
create proc spLayThongTinMonAn
@maMon int
as
begin
	select * from MON_AN
	where MaMon = @maMon
end
go
-- Xóa món ăn
if object_id('spXoaMonAn', 'p') is not null
	drop proc spXoaMonAn
go
CREATE proc spXoaMonAn
@maMon int
AS begin
	delete from Mon_An where MaMon = @maMon
end
go
----------------------
if object_id('spCapNhatTinhTrangMonAn', 'p') is not null
	drop proc spCapNhatTinhTrangMonAn
go
CREATE proc spCapNhatTinhTrangMonAn
@maMon int,
@tinhTrang bit
AS begin
	update Mon_An set TinhTrang = @tinhTrang where MaMon = @maMon
end
go

if object_id('spCapNhatTrangThaiHienThiMonAn', 'p') is not null
	drop proc spCapNhatTrangThaiHienThiMonAn
go
CREATE proc spCapNhatTrangThaiHienThiMonAn
@maMon int,
@trangThai bit
AS begin
	update Mon_An set TrangThaiHienThi = @trangThai where MaMon = @maMon
end
go
-----------------------------------
if object_id('spTinhSoLuongMonAnThuocLoaiMon', 'p') is not null
	drop proc spTinhSoLuongMonAnThuocLoaiMon
go

CREATE PROCEDURE spTinhSoLuongMonAnThuocLoaiMon
	@maloaimon int, @soluong int out
AS
BEGIN		    
	set @soluong = 	(select count(*)
					from MON_AN 
					where MaLoaiMon = @maloaimon )
END
GO


---------------------------------
if object_id('spLayDSMonAnThuocLoaiMon', 'p') is not null
	drop proc spLayDSMonAnThuocLoaiMon
go
CREATE PROCEDURE spLayDSMonAnThuocLoaiMon

	@ma_thuc_don int
AS begin
	select MaMon from CT_THUC_DON where MaThucDon = @ma_thuc_don
end
go 
---select * from ct_thuc_don


if object_id('spLayDSMonAnThuocLoaiMon', 'p') is not null
	drop proc spLayDSMonAnThuocLoaiMon
go
CREATE proc spLayDSMonAnThuocLoaiMon
@ma_loai_mon int
AS begin
	select * from MON_AN where MaLoaiMon = @ma_loai_mon
end
go


if object_id('spDanhSachMonAn', 'p') is not null
	drop proc spDanhSachMonAn
go
create proc spDanhSachMonAn
AS
BEGIN		    
	select * from MON_AN
END
GO

--exec spDanhSachMonAn


if object_id('spLayDanhSachLoaiMonAn', 'p') is not null
	drop proc spLayDanhSachLoaiMonAn
go
CREATE proc spLayDanhSachLoaiMonAn
AS
BEGIN		    
	select * from LOAI_MON
END
GO