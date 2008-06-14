Create table NHAN_VIEN1
(
	manv char(10),
	luong float,
	PRIMARY KEY (manv)
)
drop table Nhan_vien1
insert into Nhan_Vien1 Values('A', '100')
insert into Nhan_Vien1 Values('B', '200')
insert into Nhan_Vien1 Values('C', '100')
insert into Nhan_Vien1 Values('D', '100')
select * from Nhan_Vien1
select count(Luong) from Nhan_Vien1
group by Luong