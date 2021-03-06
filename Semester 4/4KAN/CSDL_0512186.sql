-- BÀI TẬP TUẦN 6
-- Mã số sinh viên :	0512186  
-- Họ và tên	   : 	Huynh Duy Khuong
-- Ca thực hành    :    4 	Thứ : 	6  

-----------------------------------------------------------------------------------------
-- <Cau~34>
Select		distinct l.HANGSX, lb.MALOAI, lb.SOHIEU
From 		LICHBAY lb, LOAIMB l
Where		lb.MALOAI = l.MALOAI 
Group by	lb.MALOAI, lb.SOHIEU, l.HANGSX
Having		Count(*) >= All (Select Count(*)
		From 	LICHBAY lb
		Group by lb.MALOAI, lb.SOHIEU)

-- </Cau~34> 
-----------------------------------------------------------------------------------------
-- <Cau~35>
Select 		distinct nv.TEN
From		NHANVIEN nv, PHANCONG pc
Where		nv.MANV = pc.MANV
Group by	nv.TEN, nv.MANV
Having 		Count(*) >= All (Select Count(*)
				From PHANCONG
				Group by MANV)
-- </Cau~35> 
-----------------------------------------------------------------------------------------
-- <Cau~36>
Select		distinct nv.TEN, nv.DCHI, nv.DTHOAI
From		NHANVIEN nv, PHANCONG pc
Where		nv.MANV = pc.MANV and nv.LOAINV = 1
Group by	nv.TEN, nv.DCHI, nv.DTHOAI
Having 		Count(*) >= All (Select	Count(*)
				 From NHANVIEN nv, PHANCONG pc
				 Where nv.MANV = pc.MANV and nv.LOAINV = 1
				 Group by pc.MANV)
-- </Cau~36> 
-----------------------------------------------------------------------------------------
-- <Cau~37>
Select 		SBDEN, Count(*) [So luong may bay dap xuong]
From		CHUYENBAY 
Group by	SBDEN
Having		Count(*) <= All (Select Count(*)
				 From CHUYENBAY 
				 Group by SBDEN)

-- </Cau~37> 
-----------------------------------------------------------------------------------------
-- <Cau~38>
Select		SBDI, Count(*) [So luong chuyen bay xuat phat]
From		CHUYENBAY
Group by	SBDI
Having		Count(*) >= All (Select Count(*)
				 From CHUYENBAY
				 Group by SBDI)
-- </Cau~38> 
-----------------------------------------------------------------------------------------
-- <Cau~39>
Select		distinct kh.TEN, kh.DCHI, kh.DTHOAI
From		KHACHHANG kh, DATCHO dc
Where		kh.MAKH = dc.MAKH
Group by	kh.MAKH, kh.TEN, kh.DCHI, kh.DTHOAI
Having		Count(*) >= All (Select Count(*)
			 	 From DATCHO
				 Group by MAKH)
-- </Cau~39> 
-----------------------------------------------------------------------------------------
-- <Cau~40>
Select		distinct nv.MANV, nv.TEN, nv.LUONG
From		NHANVIEN nv, KHANANG kn
Where		nv.LOAINV = 1 and nv.MANV = kn.MANV
Group by	nv.MANV , nv.TEN, nv.LUONG
Having		Count(*) >= All (Select Count(*)
				 From KHANANG
				 Group by MANV)
-- </Cau~40> 
-----------------------------------------------------------------------------------------
-- <Cau~41>
Select		*
From		NHANVIEN
Where		LUONG = (Select Max(LUONG)
			 From NHANVIEN) 
			
-- </Cau~41> 
-----------------------------------------------------------------------------------------
-- <Cau~42>
Select		distinct nv.TEN, nv.DCHI
From 		NHANVIEN nv, PHANCONG pc
Where		nv.MANV = pc.MANV
		and nv.LUONG = (Select Max(LUONG)
				From NHANVIEN nv, PHANCONG pc
				Where nv.MANV = pc.MANV)
-- </Cau~42> 
-----------------------------------------------------------------------------------------
-- <Cau~43>
Select		distinct cb.MACB, cb.GIODI, cb.GIODEN
From		CHUYENBAY cb, LICHBAY lb1
Where		cb.MACB = lb1.MACB and
		GIODI = (Select Min(GIODI)
			 From CHUYENBAY cb, LICHBAY lb2
			 Where cb.MACB = lb2.MACB and lb1.NGAYDI = lb2.NGAYDI)
-- </Cau~43> 
-----------------------------------------------------------------------------------------
-- <Cau~44>
Select		*
From		CHUYENBAY 
Where		GIODEN - GIODI = (Select Max(GIODEN - GIODI)
				  From CHUYENBAY)
-- </Cau~44> 
-----------------------------------------------------------------------------------------
-- <Cau~45>
Select		*
From		CHUYENBAY 
Where		GIODEN - GIODI = (Select Min(GIODEN - GIODI)
				  From CHUYENBAY)
-- </Cau~45> 
-----------------------------------------------------------------------------------------
-- <Cau~46>
Select		MACB, NGAYDI
From		LICHBAY
Where		MALOAI = 'B747'
Group by	MACB, NGAYDI
Having		Count(*) >= All (Select Count(*)
			    From LICHBAY
			    Where maloai = 'B747'
			    Group by MACB, NGAYDI)
-- </Cau~46> 
-----------------------------------------------------------------------------------------
-- <Cau~47>
Select		pc.MACB, Count(*)[So luong nhan vien] 
From		PHANCONG pc
Group by	pc.MACB, pc.NGAYDI
Having		(Select Count(*)
		 From DATCHO dc
		 Where dc.NGAYDI = pc.NGAYDI and dc.MACB = pc.MACB) > 3
-- </Cau~47> 
-----------------------------------------------------------------------------------------
-- <Cau~48>
Select		LOAINV, Count(*) [So luong nhan vien]
From		NHANVIEN
Group by	LOAINV
Having 		Sum(LUONG) > 600000
-- </Cau~48> 
-----------------------------------------------------------------------------------------
-- <Cau~49>
Select		MACB, Count(*) [So luong khach hang]
From		DATCHO dc 
Group by	MACB, NGAYDI
Having		(Select Count(*)
		 From PHANCONG pc
		 Where dc.NGAYDI = pc.NGAYDI and dc.MACB = pc.MACB) > 3

-- </Cau~49> 
-----------------------------------------------------------------------------------------
-- <Cau~50>
Select		lb.MALOAI, Count(*) [So luong chuyen bay]
From		LICHBAY lb
Group by	lb.MALOAI
Having		(Select Count(*)
			From MAYBAY mb
			Where lb.MALOAI = mb.MALOAI) > 1
-- </Cau~50> 


