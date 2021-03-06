-- BÀI TẬP TUẦN 6
-- Mã số sinh viên :  0512175
-- Họ và tên	   : Nguyễn Đăng Khoa
-- Ca thực hành    :  4  Thứ :  6

-----------------------------------------------------------------------------------------
-- <Cau~34>
select HangSX, L.SoHieu, L.MaLoai
from LichBay L join LoaiMB LMB on LMB.MaLoai = L.MaLoai
group by HangSX, L.SoHieu, L.MaLoai
having count(*) >= all(	select count(*)
			from LichBay
			group by SoHieu, MaLoai)
-- </Cau~34> 
-----------------------------------------------------------------------------------------
-- <Cau~35>
select Ten
from PhanCong P join NhanVien N on P.MaNV = N.MaNV
group by P.MaNV, Ten
having count(*) >= all(	select count(*)
			from PhanCong
			group by MaNV)
-- </Cau~35> 
-----------------------------------------------------------------------------------------
-- <Cau~36>
select Ten Tên, DChi [Địa chỉ], DThoai [Điện thoại]
from PhanCong P join NhanVien N on P.MaNV = N.MaNV
where N.LoaiNV = 1
group by P.MaNV, Ten, DChi, DThoai
having count(*) >= all(	select count(*)
			from PhanCong P1 join NhanVien N1 on P1.MaNV = N1.MaNV
			where N1.LoaiNV = 1
			group by P1.MaNV)
-- </Cau~36> 
-----------------------------------------------------------------------------------------
-- <Cau~37>
select SBDen, count(*) [So luong chuyen bay dap xuong]
from ChuyenBay
group by SBDen
having count(*) <= all(	select count(*)
			from ChuyenBay
			group by SBDen)
-- </Cau~37> 
-----------------------------------------------------------------------------------------
-- <Cau~38>
select SBDi, count(*) [So luong chuyen bay xuat bay]
from ChuyenBay
group by SBDi
having count(*) >= all(	select count(*)
			from ChuyenBay
			group by SBDi)
-- </Cau~38> 
-----------------------------------------------------------------------------------------
-- <Cau~39>
select Ten Tên, DChi [Địa chỉ], DThoai [Điện thoại]
from KhachHang K join DatCho D on K.MaKH = D.MaKH
group by D.MaKH, Ten, DChi, DThoai
having count (*) >= all(select count(*)
			from DatCho
			group by MaKH)
-- </Cau~39> 
-----------------------------------------------------------------------------------------
-- <Cau~40>
select K.MaNV, Ten, Luong
from NhanVien N join KhaNang K on N.MaNV = K.MaNV
group by K.MaNV, Ten, Luong
having count(*) >= all(	select count(*)
			from KhaNang
			group by MaNV)
-- </Cau~40> 
-----------------------------------------------------------------------------------------
-- <Cau~41>
select *
from NhanVien
where luong = (	select max(luong)
		from NhanVien)
-- </Cau~41> 
-----------------------------------------------------------------------------------------
-- <Cau~42>
select distinct Ten, DChi
from NhanVien N join PhanCong P on N.MaNV = P.MaNV
where luong = (	select max(luong)
		from NhanVien N1 join PhanCong P1 on N1.MaNV = P1.MaNV
		where	P.MaCB = P1.MaCB and
			P.NgayDi = P1.NgayDi)
-- </Cau~42> 
-----------------------------------------------------------------------------------------
-- <Cau~43>
select distinct C.MaCB, GioDi, GioDen
from ChuyenBay C join LichBay L on C.MaCB = L.MaCB
where GioDi = (	select min(GioDi)
		from ChuyenBay C1 join LichBay L1 on C1.MaCB = L1.MaCB
		where L.NgayDi = L1.NgayDi)
-- </Cau~43> 
-----------------------------------------------------------------------------------------
-- <Cau~44>
select *
from ChuyenBay
where GioDen - GioDi = (select max(GioDen - GioDi)
			from ChuyenBay)
-- </Cau~44> 
-----------------------------------------------------------------------------------------
-- <Cau~45>
select * 
from ChuyenBay
where GioDen - GioDi = (select min(GioDen - GioDi)
			from ChuyenBay)
-- </Cau~45> 
-----------------------------------------------------------------------------------------
-- <Cau~46>
select MaCB
from LichBay
where MaLoai = 'B747'
group by MaCB
having count(*) >= all(	select count(*)
			from LichBay
			where MaLoai = 'B747'
			group by MaCB)
-- </Cau~46> 
-----------------------------------------------------------------------------------------
-- <Cau~47>
select P.MaCB, count(*) [So luong nhan vien]
from PhanCong P
group by P.MaCB, P.NgayDi
having (select count(*)
	from DatCho D
	where D.NgayDi = P.NgayDi and
	      D.MaCB = P.MaCB) > 3
-- </Cau~47> 
-----------------------------------------------------------------------------------------
-- <Cau~48>
select LoaiNV, count(*) [So luong nhan vien]
from NhanVien
group by LoaiNV
having sum(luong) > 600000
-- </Cau~48> 
-----------------------------------------------------------------------------------------
-- <Cau~49>
select dc.macb, count(MaKH)
from datcho dc
group by dc.macb, dc.ngaydi
having (select count(*)
		from phancong pc 
		where pc.macb = dc.macb and pc.ngaydi = dc.ngaydi) >3

select L.MaCB, count(MaKH) [So luong khach hang]
from LichBay L left join DatCho D on (L.NgayDi = D.NgayDi and L.MaCB = D.MaCB)
group by L.MaCB, L.NgayDi
having ( select count(*)
	from PhanCong P
	where P.NgayDi = L.NgayDi and
		P.MaCB = L.MaCB) > 3
-- </Cau~49> 
-----------------------------------------------------------------------------------------
-- <Cau~50>
select MaLoai, count(*)
from LichBay L
group by MaLoai
having (select count(*)
	from MayBay M
	where L.MaLoai = M.MaLoai
	group by MaLoai) > 1
-- </Cau~50> 