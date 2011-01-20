if object_id('spLayDanhSach', 'p') is not null
	drop proc spLayDanhSach
go
create proc spLayDanhSach
	
as
begin
	select * from NoiDungEmail
end
go

if object_id('spThemNoiDungEmail', 'p') is not null
	drop proc spThemNoiDungEmail
go
create proc spThemNoiDungEmail
	 @UserName varchar(30),
     @Email varchar(30),
     @NgayGui datetime,
     @TieuDe varchar(150),
     @NoiDung text
as
begin
	INSERT INTO [dbo].[NoiDungEMail]
           ([UserName]
           ,[Email]
           ,[NgayGui]
           ,[TieuDe]
           ,[NoiDung])
     VALUES(@UserName, @Email, @NgayGui, @TieuDe, @NoiDung)
end
go
if object_id('spLayNoiDungEmail', 'p') is not null
	drop proc spLayNoiDungEmail
go
create proc spLayNoiDungEmail
	@MaMail int
as
begin
	select * from NoiDungEmail where MaMail = @MaMail
end
go