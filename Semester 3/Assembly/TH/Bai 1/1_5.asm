.MODEL SMALL
.STACK 100h
.DATA
	TBao1	DB	'Moi ban nhap 1 ky tu:$'
	TBao2	DB	13, 10, 'Ky tu HOA:$'
	c	DB	?
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @DATA
	mov	ds, ax
	; Xuat thong bao 1
	mov	ah, 9
	mov	dx, offset TBao1
	int	21h
	; Nhap ky tu va dua ky tu do vao c
	mov	ah, 1
	int	21h
	mov	c, al
	; Xuat thong bao 2
	mov	ah, 9
	mov	dx, offset TBao2
	int	21h
	; Doi c thanh chu hoa va xuat ra man hinh
	sub	c, 32
	mov	ah, 2
	mov	dl, c
	int 21h
	; Ket thuc chuong trinh
	mov	ah, 4Ch
	int	21h
END