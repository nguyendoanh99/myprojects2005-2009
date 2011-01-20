-- THEM THUC DON
if object_id('spThemThucDon', 'p') is not null
	drop proc spThemThucDon
go
create proc spThemThucDon
	@tenthucdon nvarchar(30), @maloaithucdon int, @mota ntext, @hinhanhminhhoa nvarchar(255), 
	@gia money, @diembinhchon int, @trangthaihienthi bit, @tinhtrang bit, @mathucdon int out
as
begin
	INSERT INTO [OFFS].[dbo].[THUC_DON]
           ([TenThucDon]
           ,[MaLoaiThucDon]
           ,[MoTa]
           ,[HinhAnhMinhHoa]
           ,[Gia]
           ,[DiemBinhChon]
           ,[TrangThaiHienThi]
           ,[TinhTrang])
     VALUES(@tenthucdon, @maloaithucdon, @mota, @hinhanhminhhoa, @gia, @diembinhchon, @trangthaihienthi, @tinhtrang)

	 set @mathucdon = ident_current('THUC_DON')
end
go
--declare @ma int
--exec spThemThucDon 'abc', 1, 'ddfdfd', 'url', 50000, 100, 1, 1, @ma out
--select @ma
--select * from thuc_don

if object_id('spThemCTThucDon', 'p') is not null
	drop proc spThemCTThucDon
go
create proc spThemCTThucDon
	@mathucdon int, @mamon int, @mactthucdon int out
as
begin
	insert into CT_THUC_DON(MaThucDon, MaMon)
    values(@mathucdon, @mamon)

	 set @mactthucdon = ident_current('CT_THUC_DON')
end
go

-- LAY DANH SACH TH?C ??N C?A M?T LO?I TH?C ??N
if object_id('spLayDSThucDonCuaMotLoaiThucDonLa', 'p') is not null
	drop proc spLayDSThucDonCuaMotLoaiThucDonLa
go
create proc spLayDSThucDonCuaMotLoaiThucDonLa
		@maloaithucdon int
as
begin
	select * from THUC_DON
	where MaLoaiThucDon = @maloaithucdon;
end

go

--select * from thuc_don
--exec spLayDSThucDonCuaMotLoaiThucDonLa 2



--DANH SCH TH?C ??N C?A 1 LO?I TH?C ??N ? C?P B?T K� (gi?ng ?? quy)
if object_id('spLayDSThucDonThuocLoaiThucDonBatKy', 'P') is not null
	drop proc spLayDSThucDonThuocLoaiThucDonBatKy
go
create proc spLayDSThucDonThuocLoaiThucDonBatKy
	@maloaithucdon int
as
begin
	declare @lala bit
	select @lala = LaLoaiThucDonLa
	from LOAI_THUC_DON
	where MaLoaiThucDon = @maloaithucdon
	
	if @lala = 1
	begin
		exec spLayDSThucDonCuaMotLoaiThucDonLa @maloaithucdon
		return
	end

	DECLARE @RecordList table (MaLoaiThucDon int, LaLoaiThucDonLa bit)

	--Seed the table with the @CatID value
	INSERT INTO @RecordList (MaLoaiThucDon, LaLoaiThucDonLa)
		SELECT MaLoaiThucDon, LaLoaiThucDonLa
		FROM LOAI_THUC_DON
		WHERE MaLoaiThucDonCha = @maloaithucdon

	--Add new child records until exhausted.
	WHILE @@RowCount > 0
	INSERT INTO @RecordList (MaLoaiThucDon, LaLoaiThucDonLa)
		SELECT ltd.MaLoaiThucDon, ltd.LaLoaiThucDonLa
		FROM LOAI_THUC_DON ltd
		INNER JOIN @RecordList RecordList ON ltd.MaLoaiThucDonCha = RecordList.MaLoaiThucDon
		WHERE NOT EXISTS(SELECT * FROM @RecordList CurrentRecords WHERE CurrentRecords.MaLoaiThucDon= ltd.MaLoaiThucDon)

	--Return the result set
	SELECT MaLoaiThucDon
	FROM @RecordList 
	where LaLoaiThucDonLa = 1

	declare cur_DSKetQua cursor scroll
	for select MaLoaiThucDon from @RecordList where LaLoaiThucDonLa = 1
	open cur_DSKetQua

	--DECLARE @MonAnList table (MaLoaiMon int, LaLoaiMonLa bit)

	declare @maltd int
	fetch next from cur_DSKetQua into @maltd
	while @@fetch_status = 0
	begin
		exec spLayDSThucDonCuaMotLoaiThucDonLa @maltd
		fetch next from cur_DSKetQua into @maltd
	end

	close cur_DSKetQua
	deallocate cur_DSKetQua
end
go



--exec spLayDSThucDonThuocLoaiThucDonBatKy 22
--select * from loai_thuc_don


-- LAY THONG TIN M?T TH?C ??N
if object_id('spLayThongTinThucDon', 'p') is not null
	drop proc spLayThongTinThucDon
go
create proc spLayThongTinThucDon
		@mathucdon int
as
begin
	select * from THUC_DON
	where MaThucDon = @mathucdon
end

go

--exec spLayThongTinThucDon 4


if object_id('spLayDanhSachThucDon', 'p') is not null
	drop proc spLayDanhSachThucDon
go
create proc spLayDanhSachThucDon
@pageNum int,
@pageSize int
as
begin
	WITH s AS
	(
		SELECT ROW_NUMBER() OVER(ORDER BY MaThucDon) AS RowNum, * FROM Thuc_Don
	)
	Select * From s
	Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize
end
go

--LAY DANH SACH THUC D?N THEO TAG
if object_id('spDanhSachThucDonTheoTag', 'p') is not null
	drop proc spDanhSachThucDonTheoTag
go
CREATE proc spDanhSachThucDonTheoTag
@ma_tag int
AS begin
	select * from THUC_DON td join TAG_THUC_DON tag on tag.MaThucDon = td.MaThucDon where tag.MaTag = @ma_tag
end
go

if object_id('spTongSoThucDon', 'p') is not null
	drop proc spTongSoThucDon
go
CREATE proc spTongSoThucDon
AS begin
	select count(*) from Thuc_Don
end
go

if object_id('spCapNhatTinhTrangThucDon', 'p') is not null
	drop proc spCapNhatTinhTrangThucDon
go
CREATE proc spCapNhatTinhTrangThucDon
@maThucDon int,
@tinhTrang bit
AS begin
	update Thuc_Don set TinhTrang = @tinhTrang where MaThucDon = @maThucDon
end
go

if object_id('spCapNhatTrangThaiHienThiThucDon', 'p') is not null
	drop proc spCapNhatTrangThaiHienThiThucDon
go
CREATE proc spCapNhatTrangThaiHienThiThucDon
@maThucDon int,
@trangThai bit
AS begin
	update Thuc_Don set TrangThaiHienThi = @trangThai where MaThucDon = @maThucDon
end
go
-- Xóa thực đơn
if object_id('spXoaThucDon', 'p') is not null
	drop proc spXoaThucDon
go
CREATE proc spXoaThucDon
@maThucDon int
AS begin
	delete from Thuc_Don where MaThucDon = @maThucDon
end
go