if object_id('spTimKiemTheoTen', 'p') is not null
	drop proc spTimKiemTheoTen
go
create proc spTimKiemTheoTen
	@ten nvarchar(50)
as
begin
	select * from MON_AN
	where TenMon like '%'+@ten+'%'
	
	select * from THUC_DON
	where TenThucDon like '%'+@ten+'%'
end
go

--tim kiem nang cao
if object_id('spTimKiemNangCao', 'p') is not null
	drop proc spTimKiemNangCao
go
create proc spTimKiemNangCao
	@ten nvarchar(50), @ma_loai int, @tag nvarchar(50), @gia_min money, @gia_max money
as
begin
	declare @tab varchar(1000);
	declare @tab1 varchar(1000);
	set @tab = 'select * from MON_AN ma, TAG_MON_AN tag, TAG t where tag.MaMon = ma.MaMon and t.MaTag = tag.MaTag'
	set @tab1 = 'select * from THUC_DON td, TAG_THUC_DON tag, TAG t where tag.MaThucDon = td.MaThucDon and t.MaTag = tag.MaTag'
	if(@ten <> '')
	begin	
		set @tab = @tab + ' and TenMon like ''%' + @ten + '%'''
		set @tab1 = @tab1 + ' and TenThucDon like ''%' + @ten + '%'''
	end
	if(cast(@ma_loai as varchar(10)) <> '-1')
	begin
		set @tab = @tab + ' and MaLoaiMon = ' + cast(@ma_loai as varchar(10))
		set @tab1 = @tab1 + ' and MaLoaiThucDon = ' + cast(@ma_loai as varchar(10))
	end
	if(@tag <> '')
	begin
		set @tab = @tab + ' and t.TenTag like ''%' + @tag + '%'''
		set @tab1 = @tab1 + ' and t.TenTag like ''%' + @tag + '%'''
	end
	if(cast(@gia_min as varchar(20)) <> '-1.00')
	begin		
		set @tab = @tab + ' and Gia > ' + cast(@gia_min as varchar(20))
		set @tab1 = @tab1 + ' and Gia > ' + cast(@gia_min as varchar(20))
	end
	if(cast(@gia_min as varchar(20)) <> '-1.00')
	begin		
		set @tab = @tab + ' and Gia < ' + cast(@gia_max as varchar(20))
		set @tab1 = @tab1 + ' and Gia < ' + cast(@gia_max as varchar(20))
	end
	print @tab1
	print @tab
	exec(@tab)
	exec(@tab1)
end
go