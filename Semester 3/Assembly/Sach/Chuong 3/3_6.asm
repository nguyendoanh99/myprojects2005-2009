.MODEL SMALL
.STACK 100h
.DATA
	TBao	DB	'Nhap mot ky tu : $'
	LaChu	DB	13, 10, 'Ky tu nhap la chu.$'
	LaSo	DB	13, 10, 'Ky tu nhap la so.$'
	LaKhac	DB	13, 10, 'Ky tu nhap khac chu/so.$'
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @DATA
	mov	ds, ax
	; Xuat cau thong bao
	mov	ah, 9
	lea	dx, TBao
	int	21h
	; Cho nhap mot phim 
	mov	ah, 1
	int	21h
	; Kiem tra ky vua nhap
	cmp	al, '0'
	jb	XuatKhac
	cmp	al, '9'
	jbe	XuatSo

	cmp	al, 'A'
	jb	XuatKhac
	cmp	al, 'Z'
	jbe	XuatChu

	cmp	al, 'a'
	jb	XuatKhac
	cmp	al, 'z'
	jbe	XuatChu
XuatKhac:
	lea	dx, LaKhac
	jmp	Xuat
XuatChu:
	lea	dx, LaChu
	jmp	Xuat
XuatSo:
	lea	dx, LaSo
Xuat:
	mov	ah, 9
	int	21h
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
END