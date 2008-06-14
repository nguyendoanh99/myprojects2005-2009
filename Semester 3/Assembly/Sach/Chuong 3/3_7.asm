.MODEL SMALL
.STACK 100h
.DATA
	TBao	DB	'Cac chu hoa: $'
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @DATA
	mov	ds, ax
	; Xuat cau thong bao
	mov	ah, 9
	lea	dx, TBao
	int	21h
	; Chay vong lap For
	mov	dl, 'A'
	mov	ah, 2
For:	
	int	21h
	mov	bl, dl
	inc	bl

	mov	dl, ' ' ; Xuat khoang trang
	int	21h

	mov	dl, bl
	cmp	dl, 'Z'
	jbe	For
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
END