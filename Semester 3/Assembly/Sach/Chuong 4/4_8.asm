.MODEL SMALL
.STACK 
.DATA
	TBao	DB	'Xuat chuoi tai DS:SI ra man hinh : $'
.CODE
Main	PROC
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	; Xuat thong bao
	mov	ah, 9
	lea	dx, TBao
	int	21h
	; Goi ham xuat
	call	Xuat
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
ENDP	Main

Xuat	PROC
	mov	bx, 0
	mov	ah, 2
Lap:
	mov	dl, si[bx]
	cmp	dl, 0
	je	CuoiLap
	inc	bx
	int	21h
	jmp	Lap
CuoiLap:
	ret
ENDP	Xuat
END	Main