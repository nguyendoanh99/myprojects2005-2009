.MODEL SMALL
.STACK 100h
.DATA
	TBao1	DB	'Nhap ky tu 1:$'
	TBao2	DB	13, 10, 'Nhap ky tu 2:$'
	TBao3	DB	13, 10, 'Ky tu tong:$'
	cTong	DB	?
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	AX, @DATA
	mov	DS, AX
	; Xuat thong bao 1
	lea	DX, TBao1
	mov	AH, 9
	int	21h
	; Cho nhap ky tu tu ban phim
	mov	AH, 1
	int	21h
	mov	cTong, AL
	; Xuat thong bao 2
	lea	DX, TBao2
	mov	AH, 9
	int	21h
	; Cho nhap ky tu tu ban phim
	mov	AH, 1
	int	21h
	add	cTong, AL
	; Xuat thong bao 3
	lea	DX, TBao3
	mov	AH, 9
	int	21h
	; Xuat ky tu cTong
	mov	DL, cTong
	mov	AH, 2
	int	21h
	; Ket thuc chuong trinh
	mov	AH, 4Ch
	int	21h
END