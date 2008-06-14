.MODEL SMALL
.STACK 100h
.DATA
	TBao	DB	13, 10, 'Bay gio laf (S)ang, (C)hieu hay (T)oi ? $'
	Sang	DB	13, 10, 'Chao buoi sang !$'
	Chieu	DB	13, 10, 'Chao buoi chieu !$'
	Toi	DB	13, 10, 'Chao buoi toi!$'
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @DATA
	mov	ds, ax
DauLap:
	; Xuat thong bao 
	mov	ah, 9
	mov	dx, OFFSET TBao
	int	21h
	; Cho nhap mot phim
	mov	ah, 1
	int	21h
	; Kiem tra phim vua nhap
	cmp	al, 's'
	je	XuatSang
	cmp	al, 'S'
	je	XuatSang

	cmp	al, 'c'
	je	XuatChieu
	cmp	al, 'C'
	je	XuatChieu

	cmp	al, 't'
	je	XuatToi
	cmp	al, 'T'
	je	XuatToi
	jmp	DauLap
XuatSang:
	mov	dx, OFFSET Sang
	jmp	Xuat
XuatChieu:
	mov	dx, OFFSET Chieu
	jmp	Xuat
XuatToi:
	mov	dx, OFFSET Toi
Xuat:
	mov	ah, 9
	int	21h
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
END