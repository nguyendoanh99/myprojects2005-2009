.MODEL SMALL
.STACK 100h
.DATA 
	CR	EQU	13
	LF	EQU	10
	s	DB	'Chao ban!', CR, LF, '$'
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	AX, @DATA
	mov	DS, AX
	; Xuat chuoi thong bao ra man hinh
	mov	DX, offset s
	mov	AH, 9
	int	21h
	; Ket thuc chuong trinh
	mov	AH, 4Ch
	int	21h
END