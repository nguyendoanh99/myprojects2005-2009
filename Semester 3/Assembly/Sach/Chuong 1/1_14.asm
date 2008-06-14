.MODEL SMALL
.STACK 100h
.DATA
	TBao1	DB	'Hay nhap mot ky tu:$'
	TBao2	DB	13, 10, 'Ky tu dung truoc:$'
	TBao3	DB	13, 10, 'Ky tu dung sau:$'
	cTruoc	DB	?
	cSau	DB	?
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	AX, @DATA
	mov	DS, AX
	; Xuat thong bao 1
	mov	DX, offset TBao1
	mov	AH, 9
	int	21h
	; Nhap phim tu man hinh
	mov	AH, 1
	int	21h
	mov	cTruoc, AL
	mov	cSau, AL
	; Xuat thong bao 2
	mov	DX, offset TBao2
	mov	AH, 9
	int	21h
	; Xuat ky tu cTruoc
	dec	cTruoc
	mov	DL, cTruoc
	mov	AH, 2
	int	21h
	; Xuat thong bao 3
	mov	DX, offset TBao3
	mov	AH, 9
	int	21h
	; Xuat ky tu cSau
	inc	cSau
	mov	DL, cSau
	mov	AH, 2
	int	21h
	; Ket thuc chuong trinh
	mov	AH, 4Ch
	int	21h
END