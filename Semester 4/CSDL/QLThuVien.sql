create table DOC_GIA(
	IDDocGia char(10),
	TenDocGia char(30),
	GioiTinh char(3),
	NamSinh datetime,
	TienKyQuy decimal(2),
	primary key(IDDocGia)
)

create table NGUOI_LON
(
	IDDocGia char(10),
	DiaChi char(50),
	SoDienThoai char(10),
	primary key(IDDocGia)
)

create table TUA_SACH
(
	IDTuaSach char(10),
	TuaSach char(30),
	TacGia char(30),
	TomTat char(50),
	primary key(IDTuaSach)
)

create table DAU_SACH
(
	ISBN char(10),
	IDTuaSach char(10),
	NgonNgu char(20),
	LoaiBia char(10),
	TrangThai char,
	primary key (ISBN)
)

create table CUON_SACH
(
	ISBN char(10),
	IDCuonSach char (10),
	TinhTrang char,
	primary key(ISBN, IDCuonSach)
)

create table MUON_SACH
(
	ISBN char(10),
	IDCuonSach char(10),
	IDDocGia char(10),
	NgayMuon datetime,
	NgayHetHan datetime,
	NgayTra datetime,
	TienPhat decimal(2),
	primary key(ISBN, IDCuonSach, IDDocGia)
)

create table GIA_HAN
(
	ISBN char (10),
	IDCuonSach char(10),
	IDDocGia char(10),
	LanGiaHan int,
	NgayGiaHan datetime,
	primary key (ISBN, IDCuonSach, IDDocGia, LanGiaHan)
)

alter table Nguoi_Lon add constraint FK_NguoiLon_IDDocGia
foreign key (IDDocGia) references Doc_Gia(IDDocGia)

alter table Tre_Em add constraint FK_TreEm_IDDocGia
foreign key (IDDocGia) references Doc_Gia(IDDocGia)

alter table Tre_Em add constraint FK_TreEm_IDDocGiaBaoLanh
foreign key (IDDocGiaBaoLanh) references Doc_Gia(IDDocGia)

alter table Dau_Sach add constraint FK_DauSach_IDTuaSach
foreign key (IDTuaSach) references Tua_Sach(IDTuaSach)

alter table Cuon_Sach add constraint FK_CuonSach_ISBN
foreign key (ISBN) references Dau_Sach(ISBN)

alter table Muon_Sach add constraint FK_MuonSach_ISBN_IDCuonSach
foreign key (ISBN, IDCuonSach) references Cuon_Sach(ISBN, IDCuonSach)

alter table Muon_Sach add constraint FK_MuonSach_IDDocGia
foreign key (IDDocGia) references Doc_Gia(IDDocGia)

alter table Gia_Han add constraint FK_GiaHan_ISBN_IDCuonSach_IDDocGia
foreign key (ISBN, IDCuonSach, IDDocGia) references Muon_Sach(ISBN, IDCuonSach, IDDocGia)
--Cau 1
insert into Doc_Gia values('01', 'A', 'Nam', '12/30/1980', '10')
insert into Doc_Gia values('02', 'B', 'Nam', '1/12/2000', '02')
insert into Doc_Gia values('03', 'C', 'Nam', '2/14/1981', '10')
insert into Doc_Gia values('04', 'D', 'Nu', '04/19/2002', '01')
insert into Doc_Gia values('05', 'E', 'Nu', '12/20/2001', '03')
insert into Doc_Gia values('06', 'F', 'Nam', '05/30/1982', '08')
insert into Doc_Gia values('07', 'G', 'Nu', '07/10/1979', '09')
insert into Doc_Gia values('08', 'H', 'Nu', '07/10/2000', '02')

insert into Tre_Em values('02', '01')
insert into Tre_Em values('04', '07')
insert into Tre_Em values('05', '03')
insert into Tre_Em values('08', '03')

insert into Nguoi_Lon(IDDocGia) values('01')
insert into Nguoi_Lon(IDDocGia) values('03')
insert into Nguoi_Lon(IDDocGia) values('06')
insert into Nguoi_Lon(IDDocGia) values('07')

--Cau 2

insert into Tua_Sach(IDTuaSach) values ('001')
insert into Tua_Sach(IDTuaSach) values ('002')
insert into Tua_Sach(IDTuaSach) values ('003')

insert into Dau_Sach(ISBN, IDTuaSach, NgonNgu, LoaiBia) values ('0001', '001', 'E', 'cung')
insert into Dau_Sach(ISBN, IDTuaSach, NgonNgu, LoaiBia) values ('0002', '001', 'E', 'cung')
insert into Dau_Sach(ISBN, IDTuaSach, NgonNgu, LoaiBia) values ('0003', '001', 'V', 'mem')
insert into Dau_Sach(ISBN, IDTuaSach, NgonNgu, LoaiBia) values ('0004', '002', 'E', 'cung')
insert into Dau_Sach(ISBN, IDTuaSach, NgonNgu, LoaiBia) values ('0005', '003', 'V', 'cung')
insert into Dau_Sach(ISBN, IDTuaSach, NgonNgu, LoaiBia) values ('0006', '003', 'E', 'mem')

insert into Cuon_Sach(ISBN, IDCuonSach) values('0001', '00001')
insert into Cuon_Sach(ISBN, IDCuonSach) values('0001', '00002')
insert into Cuon_Sach(ISBN, IDCuonSach) values('0002', '00001')
insert into Cuon_Sach(ISBN, IDCuonSach) values('0003', '00001')
insert into Cuon_Sach(ISBN, IDCuonSach) values('0004', '00001')
insert into Cuon_Sach(ISBN, IDCuonSach) values('0005', '00001')
insert into Cuon_Sach(ISBN, IDCuonSach) values('0005', '00002')

insert into Muon_Sach(ISBN, IDCuonSach, IDDocGia, TienPhat) values ('0001', '00001', '01', '0')
insert into Muon_Sach(ISBN, IDCuonSach, IDDocGia, TienPhat) values ('0001', '00002', '01', '2')
insert into Muon_Sach(ISBN, IDCuonSach, IDDocGia, TienPhat) values ('0002', '00001', '01', '3')
insert into Muon_Sach(ISBN, IDCuonSach, IDDocGia, TienPhat) values ('0005', '00002', '01', '1')
insert into Muon_Sach(ISBN, IDCuonSach, IDDocGia, TienPhat) values ('0003', '00001', '02', '1')
insert into Muon_Sach(ISBN, IDCuonSach, IDDocGia, TienPhat) values ('0004', '00001', '03', '0')
insert into Muon_Sach(ISBN, IDCuonSach, IDDocGia, TienPhat) values ('0005', '00001', '04', '4')

insert into Gia_Han(ISBN, IDCuonSach, IDDocGia, LanGiaHan) values ('0001', '00001', '01', '1')
insert into Gia_Han(ISBN, IDCuonSach, IDDocGia, LanGiaHan) values ('0001', '00001', '01', '2')
insert into Gia_Han(ISBN, IDCuonSach, IDDocGia, LanGiaHan) values ('0001', '00002', '01', '1')
insert into Gia_Han(ISBN, IDCuonSach, IDDocGia, LanGiaHan) values ('0002', '00001', '01', '1')
insert into Gia_Han(ISBN, IDCuonSach, IDDocGia, LanGiaHan) values ('0003', '00001', '02', '1')
