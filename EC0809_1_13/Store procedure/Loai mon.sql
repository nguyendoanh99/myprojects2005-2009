-- THEM LOAI MON
if object_id('spThemLoaiMon', 'p') is not null
	drop proc spThemLoaiMon
go
create proc spThemLoaiMon
	@tenloaimon nvarchar(50), @maloaimoncha int, @laloaimonla bit
as
begin
	if (@maloaimoncha = -1)
		insert into LOAI_MON
           ([TenLoaiMon]
		   ,[LaLoaiMonLa])
		VALUES(@tenloaimon, @laloaimonla)
	else
		insert into LOAI_MON
           ([TenLoaiMon]
           ,[MaLoaiMonCha]
		   ,[LaLoaiMonLa])
		VALUES(@tenloaimon, @maloaimoncha, @laloaimonla)
end
go
-- XOA LOAI MON
if object_id('spXoaLoaiMon', 'p') is not null
	drop proc spXoaLoaiMon
go
create proc spXoaLoaiMon
	@maloaimon int
as
begin
		delete from LOAI_MON
        where
			MaLoaiMon = @maloaimon
end
go

-- Lay danh sach loai mon lá
if object_id('spLayDanhSachLoaiMonLa', 'p') is not null
	drop proc spLayDanhSachLoaiMonLa
go
CREATE proc spLayDanhSachLoaiMonLa
AS
BEGIN		    
	select * from LOAI_MON where LaLoaiMonLa = 'True'
END
GO

-- Lay danh sach loai mon an
if object_id('spLayDanhSachLoaiMonAn', 'p') is not null
	drop proc spLayDanhSachLoaiMonAn
go
CREATE proc spLayDanhSachLoaiMonAn
AS
BEGIN		    
	select * from LOAI_MON
END
GO

--lay danh sach mon an thuoc loai mon
if object_id('spLayDSMonAnThuocLoaiMon', 'p') is not null
	drop proc spLayDSMonAnThuocLoaiMon
go
CREATE proc spLayDSMonAnThuocLoaiMon
@ma_loai_mon int
AS begin
	select * from MON_AN where MaLoaiMon = @ma_loai_mon
end
go

--lay thong tin chi tiet cua 1 loai mon an
if object_id('spChiTietLoaiMon', 'p') is not null
	drop proc spChiTietLoaiMon
go
CREATE proc spChiTietLoaiMon
@ma_loai_mon int
AS begin
	select * from LOAI_MON where MaLoaiMon = @ma_loai_mon
end
go

--LẤY DANH SÁCH LOẠI MÓN GỐC
if object_id('spLayDSLoaiMonGoc', 'p') is not null
	drop proc spLayDSLoaiMonGoc
go
CREATE proc spLayDSLoaiMonGoc
AS begin
	select * from LOAI_MON 
	where MaLoaiMonCha is null
	or MaLoaiMonCha = 0
end
go

--exec spLayDSLoaiMonGoc


if object_id('spDanhSachLoaiMonCon', 'p') is not null
	drop proc spDanhSachLoaiMonCon
go

CREATE PROCEDURE spDanhSachLoaiMonCon
	@malmcha int
AS
BEGIN	
	if (@malmcha = -1)
		select * from LOAI_MON where MaLoaiMonCha is null
	else	    
		select * from LOAI_MON where MaLoaiMonCha = @malmcha
END
GO


if object_id('spLayDanhSachLoaiMonAn', 'p') is not null
	drop proc spLayDanhSachLoaiMonAn
go
CREATE proc spLayDanhSachLoaiMonAn
AS
BEGIN		    
	select * from LOAI_MON
END
GO