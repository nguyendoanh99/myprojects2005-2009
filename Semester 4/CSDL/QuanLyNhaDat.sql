create table ChiNhanh
(
	ma_chinhanh char(4),
	duong nvarchar(30),
	quan nchar(15),
	tp char(4),
	ma_khuvuc char(7),
	dthoai char(15),
	fax char(15),
	primary key(ma_chinhanh)
)

create table ChuNha
(
	ma_chunha char(4),
	ten nvarchar(10),
	dchi nvarchar(30),
	dthoai char(15),
	primary key (ma_chunha)
)

create table LoaiNha
(
	ma_loainha char,
	mota nvarchar(30),
	primary key (ma_loainha)
)

create table NguoiThue
(
	ma_nguoithue char(4),
	ten nvarchar(10),
	dchi nvarchar(30),
	dthoai char(15),
	ma_loainha char,
	knang_thue int,
	ma_chinhanh char(4),
	primary key (ma_nguoithue)
)



create table Nha
(
	ma_nha char(4),
	duong nvarchar(30),
	quan nvarchar(15),
	tp char(4),
	ma_khuvuc nvarchar(5),
	ma_loainha char,
	sophong int,
	tienthue int,
	ma_chunha char(4),
	manv char(4),
	macn char(4),
	primary key (ma_nha)	
)

create table NhanVien
(
	ma_nhanvien char(4),
	ten nvarchar(10),
	dchi nvarchar(30),
	dthoai char(15),
	phai char,
	ngaysinh datetime,
	luong int, 
	ma_chinhanh char(4),
	primary key (ma_nhanvien)
)

create table XemNha
(
	ma_nha char(4),
	ma_nguoithue char(4),
	ngayxemnha datetime,
	nhanxet nvarchar(20),
	primary key (ma_nha, ma_nguoithue)
)

--/////////////////////////////////////constraint foreign key

alter table NhanVien 
add constraint FK_NV_CN
foreign key (ma_chinhanh)
references ChiNhanh(ma_chinhanh)


alter table Nha 
add constraint FK_N_LN
foreign key (ma_loainha)
references LoaiNha(ma_loainha)

alter table Nha
add constraint FK_N_CNHA
foreign key (ma_chunha)
references ChuNha(ma_chunha)

alter table Nha
add constraint FK_N_NV
foreign key (manv)
references NhanVien(ma_nhanvien)

alter table Nha
add constraint FK_N_CNhanh
foreign key (macn)
references ChiNhanh(ma_chinhanh)

alter table NguoiThue
add constraint FK_NT_LN
foreign key (ma_loainha)
references LoaiNha(ma_loainha)

alter table NguoiThue
add constraint FK_NT_CNhanh
foreign key (ma_chinhanh)
references ChiNhanh(ma_chinhanh)


alter table XemNha
add constraint FK_XN_LN
foreign key (ma_nha)
references Nha(ma_nha)


alter table XemNha
add constraint FK_XN_NT
foreign key (ma_nguoithue)
references NguoiThue(ma_nguoithue)

--/////////////////////////////////////////insert value

insert into ChiNhanh values('B2', '56 Chu Manh Trinh',  'Q1', 'BH', 'NW16EU', '0181-963-1030', '0181-453-7992')
insert into ChiNhanh values('B3', '163 Mac Dinh Chi', 'HK', 'HN', 'G119QX', '0141-339-2178', '0141-339-4439')
insert into ChiNhanh values('B4','32 Mai Thi Luu', 'Q1', 'TG', 'BS91NZ', '0117-916-1170', '0117-776-1114')
insert into ChiNhanh values('B7', '16 An Duong Vuong', 'Q5', 'HCM', 'AB23SU', '0122-467-1125', '0122-467-1111')
insert into ChiNhanh values('B5', '22 Dong Khoi', 'PN', 'DN', 'SW14EH', '0171-886-1212', '0171-886-1214')

insert into ChuNha values('CO40', 'Trung', '63 QuangTrung, BaDinh, HaNoi', '0141-943-1728')
insert into ChuNha values('CO46', 'Giao', '2 Phan Liem, Q1, HCM', '01224-861212')
insert into ChuNha values('CO87', 'Chau', '6 An Duong Vuong, Ha Noi', '0141-357-7419')
insert into ChuNha values('CO93', 'Thanh', '12 Phan Dinh Phung,TayHo,HaNoi', '0141-225-7025')

insert into LoaiNha values('B', 'Nha tranh')
insert into LoaiNha values('C', 'Can ho chung cu')
insert into LoaiNha values('D', 'Nha o')
insert into LoaiNha values('E', 'Nha go 1 tang')
insert into LoaiNha values('F', 'Can ho cao cap')
insert into LoaiNha values('M', 'Biet thu')
insert into LoaiNha values('S', 'Nha betong')

insert into NguoiThue values('CR56', 'An', '64 Hung Dao, Hoan Kiem, HN', '0141-848-1825', 'F', 350, 'B3')
insert into NguoiThue values('CR62', 'Mai', '5 Hoang Van Thu, PN, HCM', '01224-196720', 'F', 600, 'B7')
insert into NguoiThue values('CR74', 'Minh', '18 Thang Long, Cai Lay, TG', '01475-392178', 'C', 750.00, 'B3')
insert into NguoiThue values('CR76', 'Tai', '56 Tran Hung Dao, Q1, HCM', '01224-195632', 'F', 425.00, 'B5')

insert into NhanVien values('SA9', 'Mai', '2 Nguyen Trai, Q1, HCM', null, 'F', '2/19/1970', 9000, 'B7')
insert into NhanVien values('SG14', 'Danh', '63 Hang Dao, Ba Dinh, HN', '0141-339-2177', 'M', '3/24/1958', 18000, 'B3')
insert into NhanVien values('SG37', 'An', '81 Van Mieu, Ba Dinh, HN', '0141-848-3345', 'F', '11/10/1960', 12000.00, 'B3')
insert into NhanVien values('SG5', 'Sang', '5 Tran Hung Dao, HN', '0141-334-2001', 'F', '6/3/1940', 24000.00, 'B3')
insert into NhanVien values('SL21', 'Tuan', '19 Taylor St, Cranford, TG', '0171-884-5112', 'M', '10/1/1945', 30000.00, 'B5')
insert into NhanVien values('SL41', 'Vinh', '28 Malvern St, BH', '0181-554-3541', 'F', '6/13/1965', 9000.00, 'B5')

insert into Nha values('PA14', '16 Tran Hung Dao', 'Q1', 'HCM', 'Nam', 'D', 6, 650.00, 'CO46', 'SA9', 'B7')
insert into Nha values('PG16', '6 Pho Dinh Ngang', 'Hoan Kiem', 'HN', 'Bac', 'F', '4', 450.00, 'CO93', 'SG14', 'B3')
insert into Nha values('PG21', '18 Phan Chu Trinh', 'Cai Lay', 'TG', 'Nam', 'D', 5, 600.00, 'CO40', 'SG37', 'B3')
insert into Nha values('PG36', '2 Nguyen Trai', null, 'HCM', 'Nam', 'F', 3, 375.00, 'CO93', 'SG37', 'B3')
insert into Nha values('PG40', 'Ngo 203 Chua Boc', 'Dong Da', 'HN', 'Bac', 'F', 3, 350.00, 'CO40', 'SG14', 'B3')
insert into Nha values('PL94', '6 Phan Dinh Phung', 'PN', 'HCM', 'Nam', 'F', 4, 400.00, 'CO87', 'SL41', 'B5')

insert into XemNha values('PA14', 'CR56', '5/24/1998', 'qua khu')
insert into XemNha values('PA14', 'CR62', '5/14/1998', 'khong co phong an')
insert into XemNha values('PA14', 'CR74', '12/1/2000', null)
insert into XemNha values('PG36', 'CR56', '4/28/1998', null)
insert into XemNha values('PG40','CR56', '5/26/1998', null)
insert into XemNha values('PG40', 'CR76', '4/20/1998', 'qua xa')

