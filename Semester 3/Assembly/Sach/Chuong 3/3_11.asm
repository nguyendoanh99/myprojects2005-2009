.MODEL SMALL
.STACK	100h
.DATA
	TBao	DB	'Cac ky tu co ma tu 20h den FFh la:', 13, 10, '$'

.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	; Xuat cau thong bao
	mov	ah, 9
	lea	dx, TBao
	int	21h
	; Thuc hien vong lap
	mov	bl, 20h
	mov	ah, 2
	mov	cl, 10
For:
	mov	dl, bl
	int	21h
	mov	dl, ' '
	int	21h

	dec	cl
	cmp	cl, 0
	jne	Nhay
	mov	cl, 10
	; Dua con tro ve dau hang duoi
	mov	dl, 10
	int	21h
	mov	dl, 13
	int	21h
Nhay:	inc	bl
	cmp	bl, 0FFh
	jne	For
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
END