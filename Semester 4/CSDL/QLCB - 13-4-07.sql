-- BÀI TẬP TUẦN 4
-- Mã số sinh viên : 0512175
-- Họ và tên	   : Nguyễn Đăng Khoa
-- Ca thực hành    :    4	Thứ :  6

-----------------------------------------------------------------------------------------
-- <Cau~17>
select 	SBDen, count (*) SoLuong
from 	ChuyenBay
group by 	SBDen
order by 	SBDen
-- </Cau~17> 
-----------------------------------------------------------------------------------------	
-- <Cau~18>
select 	SBDi, count(*) SoLuong
from 	ChuyenBay
group by 	SBDi
order by 	SBDi
-- </Cau~18> 
-----------------------------------------------------------------------------------------
-- <Cau~19>
select 	SBDi, NgayDi, count(*) SoLuong
from 	ChuyenBay C, LichBay L
where 	C.MaCB = L.MaCB
group by 	SBDi, NgayDi
-- </Cau~19> 
-----------------------------------------------------------------------------------------
-- <Cau~20>
select 	SBDen, NgayDi, count(*) SoLuong
from 	ChuyenBay C, LichBay L
where 	C.MaCB = L.MaCB
group by 	SBDen, NgayDi
-- </Cau~20> 
-----------------------------------------------------------------------------------------	
-- <Cau~21>
select 	L.MACB, L.NgayDi, count(*) SoLuongNV
from 	LichBay L, PhanCong P, NhanVien N
where 	L.MaCB = P.MaCB and
	L.NgayDi = P.NgayDi and
	N.MaNV = P.MaNV and
	N.LoaiNV = '0'
group by	L.MaCB, L.NgayDi
-- </Cau~21> 
-----------------------------------------------------------------------------------------	
-- <Cau~22>
select 	count(*) SoLuong
from 	ChuyenBay C, LichBay L
where 	C.MaCB = L.MaCB and
	C.SBDi like 'MIA' and
	datediff(d, L.NgayDi, '11/01/2000') = 0
-- </Cau~22> 
-----------------------------------------------------------------------------------------	
-- <Cau~23>
select 	L.MaCB, L.NgayDi, count(*) SoLuongNV
from 	LichBay L, PhanCong P, NhanVien N
where 	L.MaCB = P.MaCB and
	L.NgayDi = P.NgayDi and
	P.MaNV = N.MaNV
group by	L.MaCB, L.NgayDi
order by 	SoLuongNV Desc
-- </Cau~23> 
-----------------------------------------------------------------------------------------	
-- <Cau~24>
select 	L.MaCB, L.NgayDi, count(*) as SoLuongKH
from 	LichBay L, DatCho D
where 	L.NgayDi = D.NgayDi and
	L.MaCB = D.MaCB 
group by 	L.MaCB, L.NgayDi
order by 	SoLuongKH desc
-- </Cau~24> 
-----------------------------------------------------------------------------------------	
-- <Cau~25>
select 	L.MaCB, L.NgayDi, sum(N.Luong) as TongLuong
from 	LichBay L, PhanCong P, NhanVien N
where	L.MaCB = P.MaCB and
	L.NgayDi = P.NgayDi and
	P.MaNV = N.MaNV
group by 	L.MaCB, L.NgayDi
order by 	TongLuong
-- </Cau~25> 
-----------------------------------------------------------------------------------------	
-- <Cau~26>
select 	avg(Luong) LuongTrungBinh
from 	NhanVien
where 	LoaiNV = '0'
-- </Cau~26> 
-----------------------------------------------------------------------------------------	
-- <Cau~27>
select 	avg(Luong) LuongTrungBinh
from	NhanVien
where 	LoaiNV = '1'
-- </Cau~27> 
-----------------------------------------------------------------------------------------	
-- <Cau~28>
select 	L.MaLoai, count(*) SoLuong
from 	LichBay L, ChuyenBay C
where 	L.MaCB = C.MaCB and
	C.SBDen like 'ORD'
group by 	L.MaLoai
-- </Cau~28> 
-----------------------------------------------------------------------------------------	
-- <Cau~29>
select 	SBDi, count(*) SoLuong
from 	ChuyenBay
where	datediff(n, '10:00:00', GioDi) >= 0 and
	datediff(n, '22:00:00', GioDi) <= 0
group by	SBDi
having	count(*) > 2
-- </Cau~29> 
-----------------------------------------------------------------------------------------	
-- <Cau~30>

select distinct Ten
from (select 	N.MaNV, N.Ten, P.NgayDi
	from	NhanVien N, PhanCong P
	where 	N.LoaiNV = '1' and
		N.MaNV = P.MaNV 
	group by 	N.MaNV, N.Ten, P.NgayDi
	having 	count(*) >= 2) _temp
-- </Cau~30> 
-----------------------------------------------------------------------------------------	
-- <Cau~31>
select 	L.MaCB, L.NgayDi
from 	LichBay L, DatCho D
where	L.NgayDi = D.NgayDi and
	L.MaCB = D.MaCB 
group by	L.MaCB, L.NgayDi
having 	count(*) < 3
-- </Cau~31> 
-----------------------------------------------------------------------------------------	
-- <Cau~32>
select 	L.SoHieu, L.MaLoai
from	LichBay L, PhanCong P, NhanVien N
where	L.NgayDi = P.NgayDi and
	L.MaCB = P.MaCB and
	P.MaNV = N.MaNV and
	N.LoaiNV = '1' and
	N.MaNV = '1001'
group by 	L.SoHieu, L.MaLoai
having 	count(*) > 2
-- </Cau~32> 
-----------------------------------------------------------------------------------------	
-- <Cau~33>
select 	HangSX, count(MaLoai) SoLuong
from 	LoaiMB
group by	HangSX
-- </Cau~33> 
