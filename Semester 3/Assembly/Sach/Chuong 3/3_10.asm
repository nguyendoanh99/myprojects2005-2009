.MODEL SMALL
.STACK 100h
.DATA
	TBao1	DB	'Hay nhap mot chu thuong (a - z): $'
	Tbao2	DB	13, 10, 'Chu hoa tuong ung la: $'
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	; Xuat cau thong bao 1
	mov	ah, 9
	lea	dx, TBao1
	int	21h
	; Cho nhap ky tu thuong, neu khong phai ky tu thuong thi nhap lai
	mov	ah, 8
For:
	int	21h
	cmp	al, 'a'
	jb	For
	cmp	al, 'z'
	ja	For
	; Xuat ky tu vua nhap ra man hinh
	mov	dl, al
	mov	bl, al
	mov	ah, 2
	int	21h
	; Xuat cau thong bao 2
	mov	ah, 9
	lea	dx, TBao2
	int	21h
	; Doi ky tu da nhap thanh chu hoa va xuat ra man hinh
	mov	ah, 2
	and	bl, 0DFh
	mov	dl, bl
	int	21h
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
END