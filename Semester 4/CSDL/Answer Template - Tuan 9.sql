-- BÀI TẬP TUẦN 9
-- Mã số sinh viên :  0512175
-- Họ và tên	   : Nguyễn Đăng Khoa
-- Ca thực hành    :    4 Thứ :  6
select * from nhanvien

-----------------------------------------------------------------------------------------
-- <Cau~1>
--Phái của nhân viên chỉ có thể là Nam hoặc là Nữ
create table NhanVien
(
	HoNV 	nvarchar(30),
	TenLot 	nvarchar(30),
	TenNV 	nvarchar(30),
	MaNV	char(9) not null,
	NgSinh	datetime,
	DChi	nvarchar(50),
	Phai	nchar(6),
	Luong	float,
	Ma_NQL	char(9),	
	Phg	int,
	primary key(MaNV)
)
insert into nhanvien values (N'honv', N'tenlot', N'tennv', '0512175', '1/1/1999', N'dchi', N'nam', '324', '0512176', '2')

create trigger Phai_NV
on NhanVien
for insert, update
as
begin
	if exists (select * 
			from Inserted
			where Phai not in (N'Nam', N'Nữ'))
	begin	
		raiserror ('Phái phải là Nam hoặc Nữ', 16, 1)
		rollback
	end
end

-- </Cau~1> 
-----------------------------------------------------------------------------------------	
-- <Cau~2>
--Lương của nhân viên phải nhỏ hơn lương người quản lý nhân viên đó
create trigger Luong_NV_NQL
on NhanVien
for Insert, Update
as
begin
	if exists (select *
			from Inserted N1, NhanVien N2
			where (N1.Ma_NQL = N2.MaNV and N1.Luong >= N2.Luong) --N1: Nhan vien, N2: nguoi quan ly
				or (N1.MaNV = N2.Ma_NQL and N1.Luong <= N2.Luong)) --N2: Nhan vien, N1: nguoi quan ly
	begin
		raiserror(N'Lương của nhân viên phải nhỏ hơn lương người quản lý nhân viên đó', 16, 1)
		rollback
		return
	end	
end

update nhanvien set luong = '221' where Manv = '0512176'
update nhanvien set ma_nql = '0512177' where manv = '0512176'

insert into nhanvien values (N'honv', N'tenlot', N'tennv', '0512179', '1/1/1999', N'dchi', N'nam', '1132', null, '2')
-- </Cau~2> 
-----------------------------------------------------------------------------------------
-- <Cau~3>
--Phân công trong lịch bay phải phù hợp với khả năng của nhân viên
create trigger trigPhanCong_LichBay
on PhanCong
for Insert, Update
as
begin
	if exists (select *
			from Inserted P join LichBay L on (P.NgayDi = L.NgayDi and P.MaCB = L.MaCB) 
				join KhaNang K on (P.MaNV = K.MaNV)
			where L.MaLoai <> K.MaLoai)
	begin
		raiserror(N'Phân công trong lịch bay phải phù hợp với khả năng của nhân viên', 16, 1)
		rollback
		return
	end
end

-- </Cau~3> 
-----------------------------------------------------------------------------------------
-- <Cau~4>
--Không phân công lái máy bay cho nhân viên không phải là phi công.
create trigger trigKhongPhaiPhiCong_KhaNang
on KhaNang
for Insert, Update
as
begin
	if exists (select *
			from Inserted K join NhanVien N on (K.MaNV = N.MaNV)
			where LoaiNV = '0')
	begin
		raiserror(N'Không phân công lái máy bay cho nhân viên không phải là phi công.', 16, 1)
		rollback
		return
	end	
end

create trigger trigKhongPhaiPhiCong_NhanVien
on NhanVien
for Insert, Update
as
begin
	if exists (select *
			from Inserted N join KhaNang K on (K.MaNV = N.MaNV)
			where LoaiNV = '0')
	begin
		raiserror(N'Không phân công lái máy bay cho nhân viên không phải là phi công.', 16, 1)
		rollback
		return
	end	
end
-- </Cau~4> 
-----------------------------------------------------------------------------------------
-- <Cau~5>
--Giờ đến phải lớn hơn giờ đi
create trigger triGioBay
on ChuyenBay
for Insert, Update
as 
begin
	if exists(select *
			from Inserted C
			where GioDi >= GioDen)
	begin
		raiserror(N'Giờ đến phải lớn hơn giờ đi', 16, 1)
		rollback
		return
	end	
end
-- </Cau~5> 
-----------------------------------------------------------------------------------------
-- <Cau~6>
--Sân bay đến và sân bay đi phải khác nhau
create trigger triSanBay
on ChuyenBay
for Insert, Update
as
begin
	if exists (select *
			from Inserted C
			where SBDi = SBDen)
	begin
		raiserror(N'Sân bay đến và sân bay đi phải khác nhau', 16, 1)
		rollback
		return
	end	
end
-- </Cau~6> 
-----------------------------------------------------------------------------------------
-- <Cau~7>
--Các chuyến bay đều kết thúc trong ngày
create trigger trigKetThuc
on ChuyenBay
for Insert, Update
as
begin
	if exists (select *
			from Inserted C
			where datediff(d, GioDi, GioDen) <> 0)
	begin
		raiserror(N'Các chuyến bay đều kết thúc trong ngày', 16, 1)
		rollback
		return
	end	
end
-- </Cau~7> 
-----------------------------------------------------------------------------------------
-- <Cau~8>
--Một máy bay chỉ do tối đa 4 nhân viên phụ trách (2 phi công và 2 nhân viên bình thường)
create trigger trigPhuTrach
on PhanCong
for Insert, Update
as
begin 
	if exists (select MaCB, NgayDi
			from Inserted P join NhanVien N on (P.MaNV = N.MaNV)
			group by MaCB, NgayDi
			having not (count(case when LoaiNV = '1' then 1 end) <= 2 and
					count(case when LoaiNV = '0' then 1 end) <= 2))
	begin
		raiserror(N'Một máy bay chỉ do tối đa 4 nhân viên phụ trách (2 phi công và 2 nhân viên bình thường)', 16, 1)
		rollback
		return
	end
end
-- </Cau~8> 
-----------------------------------------------------------------------------------------
-- <Cau~9>
--Một chuyến bay tối đa 5 hành khách.
create trigger trigHanhKhach
on DatCho
for Insert, Update
as
begin
	if exists (select NgayDi, MaCB
			from Inserted D
			group by NgayDi, MaCB
			having count(*) > 5)
	begin
		raiserror(N'Một chuyến bay tối đa 5 hành khách.', 16, 1)
		rollback
		return
	end
end
-- </Cau~9> 
-----------------------------------------------------------------------------------------
-- <Cau~10>
--Điểm trung bình phải được chấm trên thang 10 và chính xác đến 0.5
--SINHVIEN(MASV, HOTEN, DIEMTB, XEPLOAI,HANG)

create table sinhvien
(
	masv char(5),
	hoten char(10),
	diemtb float,
	xeploai char(10),
	hang int,
	primary key(masv)
)
create trigger trigDiem
on Sinhvien
for insert, update
as
begin
	update sinhvien
	set diemtb = '0' 
	where exists (select * from inserted I where sinhvien.masv = i.masv) and not (diemtb between 0 and 10)

	update sinhvien
	set diemtb = ceiling(diemtb) + 0.5
	where exists (select * from inserted I where sinhvien.masv = i.masv)
end
-- </Cau~10> 
-----------------------------------------------------------------------------------------
-- <Cau~11>
--Nếu DIEMTB >= 9  Loại xuất sắc; 9>DIEMTB >= 8 : Giỏi; 
--8> DIEMTB >= 7 : Khá; 7> DIEMTB >= 6 : TB-Khá; 6> DIEMTB >= 5: Trung bình; 
--5>DIEMTB >= 7. Khi thêm, xóa, sửa vào một bộ của bảng SINHVIEN, hãy xếp hạng cho các sinh viên.
select * from sinhvien
delete from sinhvien
insert into sinhvien values('3', '3ds', '7', 'sdf','3')
insert into sinhvien values('1', '3ds', '8', 'sdf','3')
insert into sinhvien values('2', '3ds', '8', 'sdf','3')
insert into sinhvien values('4', '3ds', '5', 'sdf','3')

delete from sinhvien where masv = '1'

create trigger trigDiemTB_Hang
on SinhVien
for Insert, Update, Delete
as
begin
	update SinhVIen
	set xeploai = (case 
			when DiemTB >= 9 then N'Xuất sắc'
			when DiemTB >= 8 then N'Giỏi'
			when DiemTB >= 7 then N'Khá'
			when DiemTB >= 6 then N'TB-Khá'
			when DiemTB >= 5 then N'Trung bình'
			else 'Yếu' end) 		
	where exists (select *
			from Inserted I
			where I.MaSV = sinhvien.MaSV)

	update SinhVien
	set hang = (select count(*) from sinhvien I where I.diemtb >= sinhvien.diemtb)
end
-- </Cau~11> 
-----------------------------------------------------------------------------------------
-- <Cau~12>
--Thêm vào bảng NHAN_VIEN thuộc tính SoLoaiMBCoTheLai. Giá trị của thuộc tính này chính là số 
--lượng loại máy bay mà nhân viên có khả năng lái được. Viết các trigger cập nhật nhằm đảm bảo ràng buộc này. 
create trigger trigSoLoaiMBCoTheLai
on KhaNang
for insert, delete, update
as
begin 
	update nhanvien
	set SoLoaiMBCoTheLai = (select count(*) from KhaNang K where K.MaNV = nhanvien.MaNV)
	where exists (select *
			from Inserted I
			where I.MaNV = nhanvien.MaNV)

	update nhanvien
	set SoLoaiMBCoTheLai = (select count(*) from KhaNang K where K.MaNV = nhanvien.MaNV)
	where exists (select *
			from deleted I
			where I.MaNV = nhanvien.MaNV)
end
-- </Cau~12> 
-----------------------------------------------------------------------------------------
-- <Cau~13>
--Giả sử chưa cài đặt khóa ngoại của bảng DAT_CHO  LICH_BAY. Hãy cài đặt các trigger nhằm đảm bảo  rằng : 
--khách hàng chỉ có thể đặt chổ trên những lịch bay đã đưa ra. Báo lỗi nếu nhập sai quy định.
create trigger trigDatCho_LichBay
on DatCho
for Insert, Update
as
begin
	if not exists (select *
			from Inserted D join LichBay L on (D.NgayDi = L.NgayDi and D.MaCB = L.MaCB))
	begin
		raiserror(N'Nhập sai quy định', 16, 1)
		rollback
		return
	end
end
-- </Cau~13> 
-----------------------------------------------------------------------------------------
-- <Cau~14>
--Giả sử chưa cài đặt khóa ngoại của bảng LICH_BAYMAY_BAY. Hãy cài đặt các trigger nhằm đảm bảo rằng: 
--Chỉ có thể xếp những lịch bay với những máy bay đã có. Báo lỗi nếu nhập sai quy định.
create trigger trigLichBay_MayBay
on LichBay
for Insert, Update
as
begin
	if not exists (select *
			from Inserted L join MayBay M on (L.SoHieu = M.SoHieu and L.MaLoai = M.Maloai))
	begin
		raiserror(N'Nhập sai quy định', 16, 1)
		rollback
		return
	end
end
-- </Cau~14> 
-----------------------------------------------------------------------------------------