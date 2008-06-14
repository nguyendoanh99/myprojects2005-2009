Create table KHACHHANG
(
	MAKH char(15),
	TEN char(15),
	DCHI char(50),
	DTHOAI char(12),
	Primary key (MAKH)
)

Create table NHANVIEN 
(
	MANV char(15),
	TEN	char(15),
	DCHI char(50),
	DTHOAI char(12),
	LUONG float(2),
	LOAINV bit,
	Primary key (MANV)
)

Create table LOAIMB
(
	MALOAI char(15),
	HANGSX char(15),
	Primary key (MALOAI)
)

Create table MAYBAY
(
	SOHIEU int,
	MALOAI char(15)
	Primary key (SOHIEU, MALOAI)
)

Create table CHUYENBAY
(
	MACB char(4),
	SBDI char(3),
	SBDEN char(3),
	GIODI datetime,
	GIODEN datetime,
	Primary key (MACB)
)

Create table LICHBAY
(
	NGAYDI datetime,
	MACB char(4),
	SOHIEU int,
	MALOAI char(15),
	Primary key(NGAYDI, MACB)
)

Create table DATCHO
(
	MAKH char(15),
	NGAYDI datetime,
	MACB char(4),
	Primary key (MAKH, NGAYDI, MACB)
)

Create table KHANANG
(
	MANV char(15),
	MALOAI char(15),
	Primary key(MANV, MALOAI)
)

Create table PHANCONG
(
	MANV char(15),
	NGAYDI datetime,
	MACB char(4),
	Primary key (MANV, NGAYDI, MACB)
)