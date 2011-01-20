
--THÊM TAG
if object_id('spThemTag', 'p') is not null
	drop proc spThemTag
go
create proc spThemTag
	@tentag nvarchar(50),@douutien int,  @matag int out
as
begin
	insert into TAG(TenTag, DoUuTien) values(@tentag, @douutien)
	set @matag = ident_current('TAG')
end

--declare @ma int
--exec spThemTag 'Nghi', @ma out
--select @ma
go

--THÊM TAG MÓN ?N
if object_id('spThemTagMonAn', 'p') is not null
	drop proc spThemTagMonAn
go
create proc spThemTagMonAn
	@matag int, @mamon int
as
begin
	insert into TAG_MON_AN(MaTag, MaMon) values(@matag, @mamon)
end

--exec spThemTagMonAn 1, 1

go
--THÊM TAG TH?C ??N
if object_id('spThemTagThucDon', 'p') is not null
	drop proc spThemTagThucDon
go
create proc spThemTagThucDon
	@matag int, @mathucdon int
as
begin
	insert into TAG_THUC_DON(MaTag, MaThucDon) values(@matag, @mathucdon)
end

go
--Lay danh sach TAG
if object_id('spLayDanhSachTag', 'p') is not null
	drop proc spLayDanhSachTag
go
create proc spLayDanhSachTag
as
begin
	select top 10 * from TAG
end
go


if object_id('spCapNhatDoUuTienTagMonAn', 'p') is not null
	drop proc spCapNhatDoUuTienTagMonAn
go
create proc spCapNhatDoUuTienTagMonAn
	@maitem int
as
begin
	declare @matag int

--------------------------------------------------------------------------
	declare cur_DSKetQua cursor scroll
	for select Tag.MaTag from Tag_mon_an ttd, Tag where MaMon = @maitem and ttd.MaTag = Tag.MaTag 
	open cur_DSKetQua

	--DECLARE @MonAnList table (MaLoaiMon int, LaLoaiMonLa bit)
	fetch next from cur_DSKetQua into @matag
	while @@fetch_status = 0
	begin
		update Tag set DoUuTien = DoUuTien + 1 where MaTag = @matag
		fetch next from cur_DSKetQua into @matag
	end

	close cur_DSKetQua
	deallocate cur_DSKetQua
--------------------------------------------------------------------	
end
go

--exec spCapNhatDoUuTienTagMonAn 96


if object_id('spCapNhatDoUuTienTagThucDon', 'p') is not null
	drop proc spCapNhatDoUuTienTagThucDon
go
create proc spCapNhatDoUuTienTagThucDon
	@maitem int
as
begin
	declare @matag int

--------------------------------------------------------------------------
	declare cur_DSKetQua cursor scroll
	for select Tag.MaTag from Tag_Thuc_don ttd, Tag where MaThucDon = @maitem and ttd.MaTag = Tag.MaTag 
	open cur_DSKetQua

	--DECLARE @MonAnList table (MaLoaiMon int, LaLoaiMonLa bit)
	fetch next from cur_DSKetQua into @matag
	while @@fetch_status = 0
	begin	
		update Tag set DoUuTien = DoUuTien + 1 where MaTag = @matag
		fetch next from cur_DSKetQua into @matag
	end

	close cur_DSKetQua
	deallocate cur_DSKetQua
--------------------------------------------------------------------	
end
go

--exec spCapNhatDoUuTienTagThucDon 46