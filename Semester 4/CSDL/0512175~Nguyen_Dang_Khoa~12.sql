-- MSSV: 0512175
-- H? tên: Nguy?n Ðang Khoa
-- Ð? s?: 12
-- Ca: 3

create table CLB(
	IDCLB	char(10),
	TenCLB	nchar(50),
	DiaChi	nchar(40),
	primary key(IDCLB)
)

create table DOI(
	IDCLB	char(10),
	STTDoi	int,
	Ten	nchar(30),
	IDDoiTruong	char(10),
	primary key(IDCLB, STTDoi)
)

create table HOIVIEN(
	IDCLB	char(10),
	IDHoiVien	char(10),
	HoTen	nchar(30),
	NgaySinh	datetime,
	STTDoi	int,
	IDBanCungTapLuyen	char(10),
	primary key(IDCLB, IDHoiVien)
)

alter table HOIVIEN
add constraint _HV_IDCLB
foreign key (IDCLB)
references CLB(IDCLB)

alter table HOIVIEN
add constraint _HV_IDBan_
foreign key (IDCLB, IDBanCungTapLuyen)
references HOIVIEN(IDCLB, IDHoiVien)

alter table DOI
add constraint _DOI_IDCLB
foreign key (IDCLB)
references CLB(IDCLB)

alter table DOI
add constraint _DOI_IDDoiTruong
foreign key (IDCLB, IDDoiTruong)
references HOIVIEN(IDCLB, IDHoiVien)

alter table HOIVIEN
add constraint _HV_STTDoi
foreign key (IDCLB, STTDoi)
references DOI(IDCLB, STTDoi)

insert into CLB values('C01', N'Câu l?c b? Phan Ðình Phùng', N'P1, Q 5, H? Chí Minh')
insert into CLB values('C02', N'Câu l?c b? Võ Th? Sáu', N'P3, Q 1, H? Chí Minh')

insert into DOI values('C01', 1, N'Ð?i 1', null)
insert into DOI values('C01', 2, N'Ð?i 2', null)
insert into DOI values('C02', 1, N'Ð?i 1', null)

insert into HOIVIEN values('C01', 'H01', N'Ti?n', '07/05/1984', 1, null)
insert into HOIVIEN values('C01', 'H02', N'Tùng', '09/16/1983', 2, null)
insert into HOIVIEN values('C01', 'H03', N'Bình', '01/28/1986', 1, null)
insert into HOIVIEN values('C01', 'H04', N'M?', '02/19/1987', 2, null)
insert into HOIVIEN values('C02', 'H01', N'Âu', '05/23/1988', 1, null)
insert into HOIVIEN values('C02', 'H02', N'Phi', '06/15/1986', 1, null)

update DOI set IDDoiTruong = 'H01' where IDCLB = 'C01' and STTDoi = 1
update DOI set IDDoiTruong = 'H02' where IDCLB = 'C01' and STTDoi = 2
update DOI set IDDoiTruong = 'H01' where IDCLB = 'C02' and STTDoi = 1

update HOIVIEN set IDBanCungTapLuyen = 'H03' where IDCLB = 'C01' and IDHoiVien = 'H01'
update HOIVIEN set IDBanCungTapLuyen = 'H04' where IDCLB = 'C01' and IDHoiVien = 'H02'
update HOIVIEN set IDBanCungTapLuyen = 'H01' where IDCLB = 'C01' and IDHoiVien = 'H03'
update HOIVIEN set IDBanCungTapLuyen = 'H02' where IDCLB = 'C01' and IDHoiVien = 'H04'
update HOIVIEN set IDBanCungTapLuyen = 'H02' where IDCLB = 'C02' and IDHoiVien = 'H01'
update HOIVIEN set IDBanCungTapLuyen = 'H01' where IDCLB = 'C02' and IDHoiVien = 'H02'