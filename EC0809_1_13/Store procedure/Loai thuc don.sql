-- LAY DANH SACH LOAI THUC DON
if object_id('spLayDanhSachLoaiThucDon', 'p') is not null
	drop proc spLayDanhSachLoaiThucDon
go
create proc spLayDanhSachLoaiThucDon
as
begin
	select * from LOAI_THUC_DON
end

go

---LAY DANH SACH LOAI THUC DON La
if object_id('spLayDSLoaiThucDonLa', 'p') is not null
	drop proc spLayDSLoaiThucDonLa
go
create proc spLayDSLoaiThucDonLa
as
begin
	select * from LOAI_THUC_DON
	where LaLoaiThucDonLa = 'True'
end

go


-- LAY DANH SACH LOAI THUC DON C?P CAO NH?T
if object_id('spLayDSLoaiThucDonCapRoot', 'p') is not null
	drop proc spLayDSLoaiThucDonCapRoot
go
create proc spLayDSLoaiThucDonCapRoot
as
begin
	select * from LOAI_THUC_DON
	where MaLoaiThucDonCha = 0
	or MaLoaiThucDonCha is null;
end

go

--exec spLayDSLoaiThucDonCapRoot

-- LAY DANH SACH LOAI THUC DON CON TR?C TI?P C?A M?T LO?I TH?C ??N
if object_id('spLayDSLoaiThucDonConTrucTiep', 'p') is not null
	drop proc spLayDSLoaiThucDonConTrucTiep
go
create proc spLayDSLoaiThucDonConTrucTiep
		@maloaithucdoncha int
as
begin
	select * from LOAI_THUC_DON
	where MaLoaiThucDonCha = @maloaithucdoncha;
end

go


--select * from loai_thuc_don
--exec spLayDSLoaiThucDonConTrucTiep 4

-- Lay thong tin chi tiet cua 1 loai thuc don
if object_id('spChiTietLoaiThucDon', 'p') is not null
	drop proc spChiTietLoaiThucDon
go
create proc spChiTietLoaiThucDon
@ma_loai_thuc_don int
AS begin
	select * from LOAI_THUC_DON where MaLoaiThucDon = @ma_loai_thuc_don
end
