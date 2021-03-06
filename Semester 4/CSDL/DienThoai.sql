create table Nha_San_Xuat
(
	IDNSX char(10),
	TenNhaSanXuat char(30),
	primary key(IDNSX)
)

create table Nha_Cung_Cap
(
	IDNCC char(10),
	TenNCC char(30),
	DiaChi char(40),
	DienThoai char(10),
	primary key(IDNCC)
)

create table Loai_Dien_Thoai
(
	IDLoaiDT char(10),
	TenLoai char(20),
	IDNhaSanXuat char(10),
	Mau char(20),
	KichThuoc char(20),
	DonGia float,
	SoLuongTon int,
	primary key(IDLoaiDT)
)

create table Cung_Cap
(
	IDLoaiDT char(10),
	IDNCC char(10),
	primary key(IDLoaiDT, IDNCC)
)

create table Hoa_Don
(
	IDHoaDon char(10),
	NgayLap datetime,
	TenKhachHang char(30),
	primary key(IDHoaDon)
)

create table Chi_Tiet_HD
(
	IDHoaDon char(10),
	IDChiTiet char(10),
	IDLoaiDT char(10),
	TiLeGiamGia float, 
	SoLuong int,
	DonGiaBan float,
	primary key(IDHoaDon, IDChiTiet)
)

alter table Loai_Dien_Thoai add constraint FK_LoaiDT_IDNSX
foreign key (IDNhaSanXuat) references Nha_San_Xuat(IDNSX)

alter table Cung_Cap add constraint FK_CungCap_IDLoaiDT
foreign key (IDLoaiDT) references Loai_Dien_Thoai(IDLoaiDT)

alter table Cung_Cap add constraint FK_CungCap_IDNCC
foreign key (IDNCC) references Nha_Cung_Cap(IDNCC)

alter table Chi_Tiet_HD add constraint FK_ChiTietHD_IDLoaiDT
foreign key (IDLoaiDT) references Loai_Dien_Thoai(IDLoaiDT)

alter table Chi_Tiet_HD add constraint FK_ChiTietHD_IDHoaDon
foreign key (IDHoaDon) references Hoa_Don(IDHoaDon)

insert into Nha_San_Xuat values ('1', 'A')
insert into Nha_San_Xuat values ('2', 'B')
insert into Nha_San_Xuat values ('3', 'C')

insert into Nha_Cung_Cap values ('01', '0A', 'asdf', '132')
insert into Nha_Cung_Cap values ('02', '0B', 'asd23f', '13')
insert into Nha_Cung_Cap values ('03', '0C', '123asdf', '12')
insert into Nha_Cung_Cap values ('04', '0D', 'asf', '1322')
insert into Nha_Cung_Cap values ('05', '0E', 'ad12f', '1132')

insert into Loai_Dien_Thoai values ('001', 'Z', '1', 'kv1', '1x2', '5000000', '100')
insert into Loai_Dien_Thoai values ('002', 'Y', '1', 'kv1', '1x2', '2000000', '200')
insert into Loai_Dien_Thoai values ('003', 'X', '2', 'kv2', '2x2', '5000000', '100')
insert into Loai_Dien_Thoai values ('004', 'T', '1', 'kv3', '1x2', '3000000', '200')
insert into Loai_Dien_Thoai values ('005', 'U', '2', 'kv3', '4x2', '5000000', '110')
insert into Loai_Dien_Thoai values ('006', 'V', '1', 'kv2', '1x2', '5000000', '400')
insert into Loai_Dien_Thoai values ('007', 'M', '3', 'kv2', '2x2', '4000000', '100')
insert into Loai_Dien_Thoai values ('008', 'N', '2', 'kv1', '1x2', '5000000', '130')
insert into Loai_Dien_Thoai values ('009', 'K', '3', 'kv3', '4x2', '1000000', '100')
insert into Loai_Dien_Thoai values ('010', 'L', '1', 'kv4', '1x2', '1100000', '300')

insert into Cung_Cap values('001', '01')
insert into Cung_Cap values('002', '03')
insert into Cung_Cap values('003', '02')
insert into Cung_Cap values('004', '04')
insert into Cung_Cap values('005', '05')
insert into Cung_Cap values('006', '05')
insert into Cung_Cap values('007', '04')
insert into Cung_Cap values('008', '02')
insert into Cung_Cap values('009', '01')
insert into Cung_Cap values('010', '03')
insert into Cung_Cap values('001', '02')

insert into Hoa_Don values('0001', '1/1/2000', 'k6')
insert into Hoa_Don values('0002', '1/1/2000', 'k2')
insert into Hoa_Don values('0003', '3/1/2000', 'k1')
insert into Hoa_Don values('0004', '2/1/2000', 'k2')

insert into Chi_Tiet_HD values ('0001', '00001', '001', '0.1', '10', '5000000')
insert into Chi_Tiet_HD values ('0001', '00002', '002', '0.2', '5', '2000000')
insert into Chi_Tiet_HD values ('0004', '00003', '003', '0.1', '20', '5000000')
insert into Chi_Tiet_HD values ('0003', '00004', '004', '0.1', '15', '3000000')
insert into Chi_Tiet_HD values ('0004', '00005', '005', '0.3', '10', '5000000')
insert into Chi_Tiet_HD values ('0004', '00006', '006', '0.1', '30', '5000000')
insert into Chi_Tiet_HD values ('0003', '00007', '008', '0.1', '10', '5000000')
insert into Chi_Tiet_HD values ('0002', '00008', '007', '0.2', '15', '4000000')
insert into Chi_Tiet_HD values ('0003', '00009', '009', '0.1', '25', '1000000')
insert into Chi_Tiet_HD values ('0002', '00010', '010', '0.2', '10', '1100000')
insert into Chi_Tiet_HD values ('0001', '00011', '001', '0.1', '30', '5000000')
insert into Chi_Tiet_HD values ('0004', '00012', '002', '0.2', '20', '2000000')
insert into Chi_Tiet_HD values ('0002', '00013', '003', '0.1', '10', '5000000')