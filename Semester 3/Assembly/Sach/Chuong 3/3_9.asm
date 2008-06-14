.MODEL SMALL
.STACK 100h
.DATA
	TBao1	DB	'Nhap mot ky tu:$'
	TBao2	DB	13, 10, 'Nam ky tu truoc: $'
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	; Xuat thong bao 1
	mov	ah, 9
	lea	dx, TBao1
	int	21h
	; Cho nhap mot ky tu va gan ky tu do cho bl
	mov	ah, 1
	int	21h
	mov	bl, al
	; Xuat cau thong bao 2
	mov	ah, 9
	lea	dx, TBao2
	int	21h
	; Thuc hien vong lap
	mov	cx, 5
	dec	bl
	mov	ah, 2
For:
	mov	dl, bl
	int	21h

	mov	dl, 10
	int	21h
	mov	dl, 8
	int	21h

	dec	bl
	loop	For
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
END