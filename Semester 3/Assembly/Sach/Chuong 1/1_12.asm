.MODEL SMALL
.STACK 100h
.DATA
	CR	EQU	13
	LF	EQU	10
	TBao1	DB	'Hello, world!', CR, LF, '$'
	TBao2	DB	'Hello, solar system!', CR, LF, '$'
	TBao3	DB	'Hello, universe!', CR, LF, '$'
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	AX, @DATA
	mov	DS, AX
	; Xuat thong bao 1
	mov	DX, offset Tbao1
	mov	AH, 9
	int	21h
	; Xuat thong bao 2
	mov	DX, offset Tbao2
	mov	AH, 9
	int	21h
	; Xuat thong bao 3
	mov	DX, offset Tbao3
	mov	AH, 9
	int	21h
	; Ket thuc chuong trinh
	mov	AH, 4Ch
	int	21h
END