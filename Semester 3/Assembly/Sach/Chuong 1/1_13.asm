.MODEL SMALL
.STACK 100h
.DATA
	TBao1	DB	'Hay nhap mot ky tu:$'
	Tbao2	DB	13, 10, 'Ky tu da nhap:$'
	KyTu	DB	?
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	AX, @DATA
	mov	DS, AX
	; Xuat thong bao 1
	mov	DX, offset TBao1
	mov	AH, 9
	int	21h
	; Cho nhap phim
	mov	AH, 1
	int	21h
	mov	KyTu, AL
	; Xuat thong bao 2
	mov	DX, offset TBao2
	mov	AH, 9
	int	21h
	; Xuat ky tu vua nhap 
	mov	DL, KyTu
	mov	AH, 2
	int	21h
	; Ket thuc chuong trinh
	mov	AH, 4Ch
	int	21h
END