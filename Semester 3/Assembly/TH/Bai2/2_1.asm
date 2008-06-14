.MODEL SMALL
.STACK 100h
.DATA
	Hoi	DB	13, 10, 'Bay gio la buoi (S)ang, buoi (C)hieu hay buoi (T)oi?$'
	Sang	 DB	13, 10, 'Chao buoi sang$'
	Chieu	DB	13, 10, 'Chao buoi chieu$'
	Toi	DB	13, 10, 'Chao buoi toi$'
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @DATA
	mov	ds, ax	
Lap:
	; Xuat cau thong bao
	mov	ah, 9
	mov	dx, offset Hoi
	int	21h
	; Cho nhap 1 phim
	mov	ah, 1
	int	21h
	; Kiem tra phim vua nhap co phai la 'S' hoac 's' hay khong
	cmp	al, 's'
	je	ChaoSang
	cmp	al, 'S'
	je	ChaoSang
	; Kiem tra phim vua nhap co phai la 'c' hoac 'C' hay khong
	cmp	al, 'c'
	je	ChaoChieu
	cmp	al, 'C'	
	je	ChaoChieu
	; Kiem tra phim vua nhap co phai la 'T' hoac 't' hay khong
	cmp	al, 't'
	je	ChaoToi
	cmp	al, 'T'
	je	ChaoToi
	jmp	Lap
ChaoSang:
	mov	dx, offset Sang
	jmp	Xuat
ChaoChieu:
	mov	dx, offset Chieu
	jmp	Xuat
ChaoToi:
	mov	dx, offset Toi
Xuat:
	mov	ah, 9
	int	21h
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
END