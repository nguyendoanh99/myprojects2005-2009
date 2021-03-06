-- BÀI TẬP TUẦN 10
-- Mã số sinh viên : 0512175	
-- Họ và tên	   : Nguyễn Đăng Khoa
-- Ca thực hành    : 4   Thứ :  6

-----------------------------------------------------------------------------------------
-- <Cau~1>


-- </Cau~1> 
-----------------------------------------------------------------------------------------	
-- <Cau~2>


-- </Cau~2> 
-----------------------------------------------------------------------------------------
-- <Cau~3>


-- </Cau~3> 
-----------------------------------------------------------------------------------------
-- <Cau~4>


-- </Cau~4> 
-----------------------------------------------------------------------------------------
-- <Cau~5>


-- </Cau~5> 
-----------------------------------------------------------------------------------------
-- <Cau~6>
--Cho biết thành phố có nhiều loại nhà 'căn hộ cao cấp' cho thuê nhất
select tp --, couNT(*)
from LoaiNha L join Nha N on N.Ma_LoaiNha = L.Ma_LoaiNha
where L.mota = 'Can ho cao cap'
group by N.tp, L.Ma_LoaiNha
having couNT(*) >= all	(select couNT(*)
			from Nha N2
			where N2.Ma_LoaiNha = L.Ma_LoaiNha
			group by N2.tp)

-- </Cau~6> 
-----------------------------------------------------------------------------------------
-- <Cau~7>
--Cho biết thành phố có nhiều loại nhà 'nhà ở' cho thuê nhất
select tp --, couNT(*)
from LoaiNha L join Nha N on N.Ma_LoaiNha = L.Ma_LoaiNha
where L.mota = 'Nha o'
group by N.tp, L.Ma_LoaiNha
having couNT(*) >= all	(select couNT(*)
			from Nha N2
			where N2.Ma_LoaiNha = L.Ma_LoaiNha
			group by N2.tp) 
-- </Cau~7> 
-----------------------------------------------------------------------------------------
-- <Cau~8>
--Cho biết chi nhánh (Ma_ChiNhanh) nào có đông nhân viên nữ nhất
select N.Ma_ChiNhanh --, couNT(*)
from NhanVien N
where N.phai = 'F'
group by N.Ma_ChiNhanh
having couNT(*) >= all	(select couNT(*)
			from NhanVien N2
			where N2.Phai = 'F'
			group by N2.Ma_ChiNhanh)
-- </Cau~8> 
-----------------------------------------------------------------------------------------
-- <Cau~9>
--Cho biết địa chỉ (duong, quan, tp) căn nhà nào có số người đến xem đông nhất
select N.duong, N.quan, N.tp
from XemNha X, Nha N
where X.Ma_Nha = N.Ma_Nha 
group by N.Ma_Nha, N.duong, N.quan, N.tp
having couNT(X.Ma_Nha) >= all	(select couNT(*)
				from XemNha X2
				group by X2.Ma_Nha)
-- </Cau~9> 
-----------------------------------------------------------------------------------------
-- <Cau~10>
--Cho biết tên người thuê (Ten) không có nhận xét gì sau khi xem nhà trong khỏang
--từ tháng 4/98 đến 6/98
select distinct NT.Ten
from NguoiThue NT, XemNha XN
where NT.Ma_NguoiThue = XN.Ma_NguoiThue
and (xn.NhanXet is null)
and (xn.NgayXemNha between '4/1/1998' and '6/1/1998')
-- </Cau~10> 
-----------------------------------------------------------------------------------------
-- <Cau~11>

select ten
from ChiNhanh cn join NhanVien nv on (cn.ma_chinhanh = nv.ma_chinhanh)
where nv.luong = (
		select max (nv2.luong)
		from NhanVien nv2
		where nv2.ma_chinhanh = cn.ma_chinhanh)

-- </Cau~11> 
-----------------------------------------------------------------------------------------
-- <Cau~12>

select ten
from ChiNhanh cn join NhanVien nv on (cn.ma_chinhanh = nv.ma_chinhanh)
where nv.luong = (
			select min (nv2.luong)
			from NhanVien nv2
			where nv2.ma_chinhanh = cn.ma_chinhanh)

-- </Cau~12> 
-----------------------------------------------------------------------------------------
-- <Cau~13>

select cn.ma_chinhanh, avg (luong) luong_tb
from ChiNhanh cn join NhanVien nv on (cn.ma_chinhanh = nv.ma_chinhanh)
group by cn.ma_chinhanh
-- </Cau~13> 
-----------------------------------------------------------------------------------------
-- <Cau~14>

select distinct ten, dthoai
from ChuNha cn join  Nha n on (cn.ma_chunha = n.ma_chunha)
where n.sophong between 3 and 4

-- </Cau~14> 
-----------------------------------------------------------------------------------------
-- <Cau~15>

select ma_nha, duong, quan, tp, tienthue, mota
from Nha n join  LoaiNha ln on (n.ma_loainha = ln.ma_loainha), NguoiThue nt
where nt.ten = 'Mai'
and nt.knang_thue >= n.tienthue
and n.ma_nha NOT IN (
			select xn.ma_nha
			from XemNha xn
			where xn.ma_nguoithue = nt.ma_nguoithue
			)
-- </Cau~15> 
-----------------------------------------------------------------------------------------
-- <Cau~16>

select ma_nha, duong, quan, tp, tienthue, mota
from Nha n join  LoaiNha ln on (n.ma_loainha = ln.ma_loainha), NguoiThue nt
where nt.ten = 'Mai'
and nt.knang_thue >= n.tienthue
and n.ma_nha IN (
			select xn.ma_nha
			from XemNha xn
			where xn.ma_nguoithue = nt.ma_nguoithue
			)


-- </Cau~16> 
-----------------------------------------------------------------------------------------
-- <Cau~17>

select ma_nha, duong, quan, tp, tienthue
from Nha n join LoaiNha ln on (n.ma_loainha = ln.ma_loainha)
where ln.mota = 'Can ho cao cap'
and n.ma_nha IN (
			select xn.ma_nha
			from XemNha xn
			)

-- </Cau~17> 
-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
-- <Cau~18>

select n.ma_nguoithue , ten , dchi , dthoai , count(xn.ma_nha) solanxem
from NguoiThue n join XemNha xn on (n.ma_nguoithue = xn.ma_nguoithue)
group by n.ma_nguoithue , ten , dchi , dthoai


-- </Cau~18> 
-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
-- <Cau~19>

select distinct n.ma_nha , duong , tp , quan , mota 
from Nha n join  XemNha xn on (n.ma_nha = xn.ma_nha) join LoaiNha ln on (ln.ma_loainha = n.ma_loainha)
where datediff(yy,'1998',xn.ngayxemnha)  >= 0 

-- </Cau~19> 
-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
-- <Cau~20>
--Cho biết tên các chủ nhà, địa chỉ, địn thọi, cùng với số lượng nhà mà họ cho thuê

select ten , dchi , dthoai , count(n.ma_nha) sonhachothue
from ChuNha cn join Nha n on (cn.ma_chunha = n.ma_chunha)
group by cn.ma_chunha , ten , dchi , dthoai

-- </Cau~20>  
-----------------------------------------------------------------------------------------
-- <Cau~21>
--Cho biết tên NV và tên ng thuê (Ten, Ten, Ma_ChiNhanh) do cùng 1 chi nhánh quản lý
select	NV.Ten TennhaNVien, NT.Ten Tennguoithue, NV.Ma_ChiNhanh
from 	NguoiThue NT  join NhanVien NV on (NV.Ma_ChiNhanh = NT.Ma_ChiNhanh)
-- </Cau~21> 
-----------------------------------------------------------------------------------------
-- <Cau~22>
--Liệt kê những căn nhà và tên người chủ nhà mà chưa có ai xem qua
select	Ma_Nha, ma_chunha
from	Nha N
where	not exists (select *
		from XemNha x
		where x.Ma_Nha = n.Ma_Nha)
-- </Cau~22> 
-----------------------------------------------------------------------------------------
-- <Cau~23>
--Liệt kê những ng thuê nào đi xem nhà nhiều nhất
select	Ma_NguoiThue
from	XemNha X
group by X.Ma_NguoiThue
having	count(*) >= all (Select count(*)	
			from	XemNha x
			group by x.Ma_NguoiThue)

-- </Cau~23> 
-----------------------------------------------------------------------------------------
-- <Cau~24>
--Cho biết người thuê nào(Ma_NguoiThue, Ten) đã đi xem hết tất cả các nhà có số phòng = 4
select	Ma_NguoiThue, Ten
from	NguoiThue NT
where	not exists (
		select *
		from	Nha n
		where	n.sophong = 4 and not exists (
						select	*
						from	XemNha x
						where	x.Ma_Nha = n.Ma_Nha and x.Ma_NguoiThue = NT.Ma_NguoiThue ))
-- </Cau~24> 
-----------------------------------------------------------------------------------------
-- <Cau~25>
--Cho biết người thuê nào(Ma_NguoiThue, Ten) đã đi xem hết tất cả các nhà tại tp HCM
select 	Ma_NguoiThue, Ten
from	NguoiThue NT
where 	not exists (
		select	*
		from	Nha n
		where	n.tp = 'HCM' and not exists(
						select *
						from	XemNha x
						where	x.Ma_Nha = n.Ma_Nha and x.Ma_NguoiThue = NT.Ma_NguoiThue))
-- </Cau~25> 
-----------------------------------------------------------------------------------------
-- <Cau~26>
--Cho biết người thuê nào(Ma_NguoiThue, Ten) đã đi xem hết tất cả các nhà có loại nhà là 'Nha o'
select	Ma_NguoiThue, Ten
from	NguoiThue NT
where	not exists (
		select *
		from 	LoaiNha ln join Nha n on ln.Ma_LoaiNha = n.Ma_LoaiNha
		where 	ln.mota = 'Nha o' and not exists (
							select 	*
							from	XemNha x
							where	x.Ma_Nha = n.Ma_Nha and x.Ma_NguoiThue = NT.Ma_NguoiThue))
-- </Cau~26> 
-----------------------------------------------------------------------------------------
-- <Cau~27>
--Cho biết người thuê nào(Ma_NguoiThue, Ten) đã đi xem hết tất cả các nhà có loại nhà là 'Can ho cao cap'
select	Ma_NguoiThue, Ten
from	NguoiThue NT
where	not exists (
		select	*
		from	Nha n join LoaiNha ln on n.Ma_LoaiNha = ln.Ma_LoaiNha
		where	ln.mota = 'Can ho cao cap' and not exists(
								select	*
								from	XemNha x
								where	x.Ma_NguoiThue = NT.Ma_NguoiThue and
									x.Ma_Nha = n.Ma_Nha))
-- </Cau~27> 
-----------------------------------------------------------------------------------------
-- <Cau~28>
--Liệt kê những loại nhà (Ma_LoaiNha, mota) chưa có ai xem qua
select	Ma_LoaiNha, mota
from	LoaiNha ln
where	not exists (
		select *
		from	XemNha x join Nha n on x.Ma_Nha = n.Ma_Nha
		where 	n.Ma_LoaiNha = ln.Ma_LoaiNha)
-- </Cau~28> 
-----------------------------------------------------------------------------------------
-- <Cau~29>
--Cho biết nhà nào có số phòng nhiều nhất
select	Ma_Nha, sum(n.sophong) SoPhong
from	Nha N
group by Ma_Nha
having 	sum(n.sophong) >= all (
			select	sum(n.sophong)
			from	Nha n
			group by n.Ma_Nha)
-- </Cau~29> 
-----------------------------------------------------------------------------------------
-- <Cau~30>
--Cho biết người thuê nào (Ma_NguoiThue, Ten) đã đi xem hết tất cả các nhà có tiền thuê nhỏ hơn $400
select Ma_NguoiThue, Ten
from NguoiThue NT
where not exists	(
			select *
			from Nha n
			where n.tieNThue < 400
			and not exists		(
						select *
						from XemNha xn
						where xn.Ma_NguoiThue = NT.Ma_NguoiThue and xn.Ma_Nha = n.Ma_Nha))
-- </Cau~30> 
-----------------------------------------------------------------------------------------
-- <Cau~31>
--Cho biết người thuê nào (Ma_NguoiThue, Ten) đã đi xem hết tất cả các nhà có tiền thuê lớn hơn $450
select Ma_NguoiThue, Ten
from NguoiThue NT
where not exists	(
			select *
			from Nha n
			where n.tieNThue > 450
			and not exists		(
						select *
						from XemNha xn
						where xn.Ma_NguoiThue = NT.Ma_NguoiThue AND xn.Ma_Nha = n.Ma_Nha
						
						))
-- </Cau~31> 
-----------------------------------------------------------------------------------------
-- <Cau~32>
--Cho biết người thuê nào (Ma_NguoiThue, Ten) đã đi xem hết tất cả các nhà do chi nhánh B3 quản lý
select Ma_NguoiThue, Ten
from NguoiThue NT
where not exists	(
			select *
			from Nha n JOIN ChiNhanh cn on cn.Ma_ChiNhanh = n.macn
			where cn.Ma_ChiNhanh = 'B3'
			and n.Ma_Nha not in	(
						select xn.Ma_Nha
						from XemNha xn
						where xn.Ma_NguoiThue = NT.Ma_NguoiThue
						and xn.Ma_Nha = n.Ma_Nha
						)
			)
-- </Cau~32> 
-----------------------------------------------------------------------------------------
-- <Cau~33>
--Cho biết người thuê nào (Ma_NguoiThue, Ten) đã đi xem hết tất cả các nhà do nhân viên Danh quản lý
select Ma_NguoiThue, Ten
from NguoiThue NT
where not exists	(
			select *
			from Nha n JOIN NhanVien NV on n.maNV =NV.Ma_NhaNVien 
			where NV.Ten = 'Danh'
			and n.Ma_Nha not in
					(
					select xn.Ma_Nha
					from XemNha xn
					where xn.Ma_NguoiThue = NT.Ma_NguoiThue
					)
			)
					
-- </Cau~33> 

