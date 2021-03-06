-- BÀI TẬP TUẦN 7
-- Mã số sinh viên :  0512175
-- Họ và tên	   : Nguyễn Đăng Khoa
-- Ca thực hành    :    4	Thứ :  6

-----------------------------------------------------------------------------------------
-- <Cau~51>
insert into LichBay values('11/1/2001', '334', '22', 'B757')
insert into LichBay values('11/1/2002', '334', '11', 'B727')
delete LichBay where NgayDi = '11/1/2001' and MaCB = '334'
delete LichBay where NgayDi = '11/1/2002' and MaCB = '334'

select *
from ChuyenBay C
where not exists (
		select *
		from LoaiMB LMB
		where HangSX = 'Boeing' and 
			not exists ( 
				select *
				from LichBay L
				where LMB.MaLoai = L.MaLoai and
					MaCB = C.MaCB))

select C.MaCB, C.SBDi, C.SBDen, C.GioDi, C.GioDen
from ChuyenBay C join LichBay L on (C.MaCB = L.MaCB) join LoaiMB LMB on (L.MaLoai = LMB.MaLoai)
where LMB.HangSX = 'Boeing'
group by C.MaCB, C.SBDi, C.SBDen, C.GioDi, C.GioDen
having count(distinct L.MaLoai) = (select count(*)
					from LoaiMB 
					where HangSX = 'Boeing')

-- </Cau~51> 
-----------------------------------------------------------------------------------------
-- <Cau~52>
insert into KhaNang values ('1002', 'A310')
insert into KhaNang values ('1002', 'A330')

delete KhaNang where MaNV = '1002' and MaLoai = 'A310'
delete KhaNang where MaNV = '1002' and MaLoai = 'A330'

select N.*
from NhanVien N
where not exists (
		select *
		from LoaiMB LMB 
		where HangSX = 'Airbus' and
			not exists (
				select * 
				from KhaNang K
				where K.MaNV = N.MaNV and
					K.MaLoai = LMB.MaLoai))

select N.MaNV, N.Ten, N.DChi, N.DThoai, N.Luong
from  NhanVien N join KhaNang K on (N.MaNV = K.MaNV) join LoaiMB LMB on (LMB.MaLoai = K.MaLoai)
where HangSX = 'Airbus'
group by N.MaNV, N.Ten, N.DChi, N.DThoai, N.Luong
having count(*) = (select count(*)
			from LoaiMB
			where HangSX = 'Airbus')
-- </Cau~52> 
-----------------------------------------------------------------------------------------
-- <Cau~53>
insert into PhanCong values ('1004', '11/1/2000', '100')
delete PhanCong where MaNV = '1004' and NgayDi = '11/1/2000' and MaCB = '100'

select N.Ten
from NhanVien N
where N.LoaiNV = '0' and 
	not exists (
		select *
		from LichBay L
		where L.MaCB = '100' and
			not exists(
				select * 
				from PhanCong P
				where P.MaNV = N.MaNV and
					P.MaCB = L.MaCB and 
					P.NgayDi = L.NgayDi))

select N.Ten
from NhanVien N join PhanCong P on (N.MaNV = P.MaNV)
where P.MaCB = '100' and N.LoaiNV = '0'
group by N.Ten
having count(*) = (select count(*)
			from LichBay 
			where MaCB = '100')
-- </Cau~53> 
-----------------------------------------------------------------------------------------
-- <Cau~54>
insert into LichBay values ('10/31/2000', '395', '22', 'B757')
delete LichBay where NgayDi = '10/31/2000' and MaCB = '395'

select distinct L.NgayDi
from LichBay L
where not exists(
		select * 
		from LoaiMB LMB
		where HangSX = 'Boeing' and
			not exists (
				select *
				from LichBay L1
				where L1.MaLoai = LMB.MaLoai and
					L1.NgayDi = L.NgayDi))

select L.NgayDi
from LichBay L join LoaiMB LMB on (L.MaLoai = LMB.MaLoai)
where HangSX = 'Boeing'
group by L.NgayDi
having count (distinct L.MaLoai) = (select count(*)
					from LoaiMB
					where HangSX = 'Boeing')
-- </Cau~54> 
-----------------------------------------------------------------------------------------
-- <Cau~55>
insert into LichBay values('11/1/2002', '449', '11', 'B727')
insert into LichBay values('11/1/2001', '449', '11', 'B727')
insert into LichBay values('11/1/2000', '449', '11', 'B727')
delete LichBay where NgayDi = '11/1/2002' and MaCB = '449'
delete LichBay where NgayDi = '11/1/2001' and MaCB = '449'
delete LichBay where NgayDi = '11/1/2000' and MaCB = '449'

select LMB.MaLoai
from LoaiMB LMB
where HangSX = 'Boeing' and 
	not exists (
		select *
		from LichBay L 
		where not exists(
				select *
				from LoaiMB LMB1 join LichBay L1 on (L1.MaLoai = LMB1.MaLoai)
				where LMB1.HangSX = 'Boeing' and
					L1.NgayDi = L.NgayDi and
					LMB1.MaLoai = LMB.MaLoai))

select L.MaLoai
from LichBay L join LoaiMB LMB on (L.MaLoai = LMB.MaLoai)
where HangSX = 'Boeing'
group by L.MaLoai
having count(distinct L.NgayDi) = (select count(distinct NgayDi)
					from LichBay)
-- </Cau~55> 
-----------------------------------------------------------------------------------------
-- <Cau~56>
select K.MaKH, K.Ten
from KhachHang K
where not exists (
		select *
		from LichBay L
		where (NgayDi between '10/31/2000' and '11/1/2000') and
			not exists(
				select *
				from DatCho D
				where D.MaKH = K.MaKH and
					D.NgayDi = L.NgayDi))

select K.MaKH, K.Ten
from KhachHang K join DatCho D on (K.MaKH = D.MaKH)
where NgayDi between '10/31/2000' and '11/1/2000'
group by K.MaKH, K.Ten
having count(distinct NgayDi) = (select count(distinct NgayDi)
					from LichBay
					where NgayDi between '10/31/2000' and '11/1/2000')
-- </Cau~56> 
-----------------------------------------------------------------------------------------
-- <Cau~57>
select N.MaNV, N.Ten
from NhanVien N
where LoaiNV = '1' and 
	exists (
		select * 
		from LoaiMB LMB
		where HangSX = 'Airbus' and
			not exists (
				select * 
				from KhaNang K
				where K.MaNV = N.MaNV and
					K.MaLoai = LMB.MaLoai))

select N.MaNV, N.Ten
from NhanVien N join KhaNang K on (N.MaNV = K.MaNV) left join LoaiMB LMB on (K.MaLoai = LMB.MaLoai)
where LMB.HangSX = 'Airbus'
group by N.MaNV, N.Ten
having count(LMB.MaLoai) < (select count(*)
			from LoaiMB
			where HangSX = 'Airbus')

-- </Cau~57> 
-----------------------------------------------------------------------------------------
-- <Cau~58>
select SBDi
from ChuyenBay C
where not exists (
		select *
		from LoaiMB LMB	
		where HangSX = 'Boeing' and 
			not exists (
				select * 
				from LichBay L
				where L.MaCB = C.MaCB and
					L.MaLoai = LMB.MaLoai))

select SBDi
from ChuyenBay C join LichBay L on (C.MaCB = L.MaCB) join LoaiMB LMB on (LMB.MaLoai = L.MaLoai)
where HangSX = 'Boeing'
group by SBDi
having count(distinct L.MaLoai) = (select count(*)	
					from LoaiMB
					where HangSX = 'Boeing')
-- </Cau~58> 
-----------------------------------------------------------------------------------------
-- <Cau~59>
select C.*
from ChuyenBay C join LichBay L on (C.MaCB = L.MaCB)
where NgayDi = '10/31/2000' and
	SBDi = 'STL' and
	GioDen < '10:00:00'
-- </Cau~59> 
