-- BÀI TẬP TUẦN 3
-- Mã số sinh viên :	0512175
-- Họ và tên	   :	Nguyễn Đăng Khoa
-- Ca thực hành    :    4	Thứ :  6
-----------------------------------------------------------------------------------------
-- <Cau~1>
select N.MANV, TEN, DCHI, DTHOAI
from NHANVIEN N, PHANCONG P, LICHBAY L
where N.MANV = P.MANV and P.NGAYDI = L.NGAYDI and P.MACB = L.MACB 
	and L.MALOAI = 'B747' and N.LOAINV = '1'
-- </Cau~1> 
-----------------------------------------------------------------------------------------	
-- <Cau~2>
select LICHBAY.MACB, NGAYDI 
from LICHBAY, CHUYENBAY
where LICHBAY.MACB = CHUYENBAY.MACB and CHUYENBAY.SBDI = 'DCA' and (CHUYENBAY.GIODI between '14:00:00' and '18:00:00')
-- </Cau~2> 
-----------------------------------------------------------------------------------------
-- <Cau~3>
select distinct N.TEN
from NHANVIEN N, PHANCONG P, CHUYENBAY C
where N.MANV = P.MANV and P.MACB = C.MACB and P.MACB = '100' and C.SBDI = 'SLC'
-- </Cau~3> 
-----------------------------------------------------------------------------------------
-- <Cau~4>
select distinct L.MALOAI, L.SOHIEU
from CHUYENBAY C, LICHBAY L
where C.MACB = L.MACB and C.SBDI = 'MIA'
-- </Cau~4> 
-----------------------------------------------------------------------------------------
-- <Cau~5>
select L.MACB, L.NGAYDI, TEN, DCHI, DTHOAI
from LICHBAY L, DATCHO D, KHACHHANG K
where L.MACB = D.MACB and L.NGAYDI = D.NGAYDI and D.MAKH = K.MAKH
order by L.MACB, L.NGAYDI desc
-- </Cau~5> 
-----------------------------------------------------------------------------------------
-- <Cau~6>
select L.MACB, L.NGAYDI, TEN, DCHI, DTHOAI
from LICHBAY L, PHANCONG P, NHANVIEN N
where L.NGAYDI = P.NGAYDI and L.MACB = P.MACB and N.MANV = P.MANV
order by L.MACB, L.NGAYDI desc
-- </Cau~6> 
-----------------------------------------------------------------------------------------
-- <Cau~7>
select P.MACB, P.NGAYDI, N.MANV, N.TEN
from CHUYENBAY C, PHANCONG P, NHANVIEN N
where C.MACB = P.MACB and P.MANV = N.MANV and C.SBDEN = 'ORD' and N.LOAINV = '1'
-- </Cau~7> 
-----------------------------------------------------------------------------------------
-- <Cau~8>
select P.MACB, P.NGAYDI, N.TEN
from NHANVIEN N, PHANCONG P
where N.MANV = P.MANV and N.MANV = '1001' and N.LOAINV = '1'
-- </Cau~8> 
-----------------------------------------------------------------------------------------
-- <Cau~9>
select C.MACB, L.NGAYDI, C.SBDI, C.SBDEN, C.GIODI, C.GIODEN, L.SOHIEU, L.MALOAI
from CHUYENBAY C, LICHBAY L
where C.SBDEN = 'DEN' and C.MACB = L.MACB
order by L.NGAYDI desc, C.SBDI
-- </Cau~9> 
-----------------------------------------------------------------------------------------
-- <Cau~10>
select distinct L.*
from LOAIMB L, KHANANG K
where L.MALOAI = K.MALOAI
-- </Cau~10> 
-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
-- <Cau~11>
select N.MANV, N.TEN
from NHANVIEN N, PHANCONG P
where P.MACB = '100' and datediff(d, P.NGAYDI, '11/01/2000') = 0 and N.LOAINV = '1' and N.MANV = P.MANV
-- </Cau~11> 
-----------------------------------------------------------------------------------------
-- <Cau~12>
select P.MACB, N.MANV, N.TEN
from NHANVIEN N, PHANCONG P, CHUYENBAY C
where N.MANV = P.MANV and P.MACB = C.MACB and datediff(d, P.NGAYDI, '10/31/2000') = 0 and  C.SBDI = 'MIA' and C.GIODI = '20:30'
-- </Cau~12> 
-----------------------------------------------------------------------------------------
-- <Cau~13>
select distinct L.MACB, L.SOHIEU, L.MALOAI, LOAIMB.HANGSX
from NHANVIEN N, PHANCONG P, LICHBAY L, LOAIMB
where N.TEN like 'Quang' and N.LOAINV = '1' and N.MANV = P.MANV and P.MACB = L.MACB and P.NGAYDI = L.NGAYDI 
	and L.MALOAI = LOAIMB.MALOAI
-- </Cau~13> 
-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
-- <Cau~14>
select N.TEN
from NHANVIEN N
where N.LOAINV = '1' and N.MANV not in (select P.MANV 
					from PHANCONG P, NHANVIEN N1 
					where N1.LOAINV = '1' and P.MANV = N1.MANV)
-- </Cau~14> 
-----------------------------------------------------------------------------------------
-- <Cau~15>
select distinct K.MAKH, K.TEN
from KHACHHANG K, DATCHO D, LICHBAY L, LOAIMB
where K.MAKH = D.MAKH and D.NGAYDI = L.NGAYDI and D.MACB = L.MACB 
	and L.MALOAI = LOAIMB.MALOAI and LOAIMB.HANGSX = 'Boeing'
-- </Cau~15> 
-----------------------------------------------------------------------------------------
-- <Cau~16>
select C.*
from CHUYENBAY C, LICHBAY L
where C.MACB = L.MACB and L.SOHIEU = '10' and L.MALOAI = 'B747'
-- </Cau~16> 
-----------------------------------------------------------------------------------------