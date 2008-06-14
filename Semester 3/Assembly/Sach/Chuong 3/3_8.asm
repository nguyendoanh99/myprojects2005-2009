.MODEL SMALL
.STACK 100h
.DATA	
	TBao1	DB	'Nhap mot ky tu:$'
	TBao2	DB	13, 10, 'Nam ky tu ke:$'
	KyTu	DB	?
	LF	EQU	10
	BS	EQU	8
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @DATA
	mov	ds, ax
	; Xuat cau thong bao 1
	mov	ah, 9
	lea	dx, TBao1
	int	21h
	; Cho nhap mot phim va dua ky tu vua nhap vao bl
	mov	ah, 1
	int	21h
	mov	bl, al
	; Xuat cau thong bao 2
	mov	ah, 9
	lea	dx, TBao2
	int	21h	
	; Thuc hien vong lap
	inc	bl
	mov	cx, 5
	mov	ah, 2
For:
	mov	dl, bl
	int	21h

	mov	dl, 10
	int	21h
	mov	dl, 8
	int	21h
	
	inc	bl
	loop For
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
END