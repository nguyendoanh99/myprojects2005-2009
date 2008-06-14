.MODEL	SMALL
.STACK	100h
.DATA	
	TBao1	DB	'	CHR		 HEX		   BIN', 13, 10, '$'
	TBao2	DB	13, 10, 9, '$'
Xuat_	MACRO	s
	mov	ah, 9
	lea	dx, s
	int	21h
ENDM
.CODE
Main	PROC
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	; Xoa man hinh
	mov	ax, 3
	int	10h
	; Xuat thong bao 1
	Xuat_ TBao1
	mov	bl, 0
	mov	ah, 2
	mov	dl, 9
	int	21h
Lap:
	mov	dl, bl
	int	21h
	; Xuat dau tab
	mov	dl, 9
	int	21h
	int	21h
	; Goi ham Xuat_TLP
	call	Xuat_TLP
	; xuat dau tab
	mov	dl, 9
	int	21h
	int	21h
	; Goi ham Xuat_NP
	call	Xuat_NP
	
	Xuat_	TBao2
	mov	ah, 2

	cmp	bl, 255
	je	KetThuc
	inc	bl
	jmp	Lap
KetThuc:
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
Main	ENDP
;----------------------------Xuat_NP----------------------
Xuat_NP	PROC
	mov	ah, 2
	mov	cx, 8
Lap1:
	rol	bl, 1
	jc	So1
	mov	dl, '0'
	jmp	_Xuat
So1:
	mov	dl, '1'
_Xuat:
	int	21h
	loop	Lap1
	ret
Xuat_NP	ENDP
;----------------------------Xuat_TLP---------------------
Xuat_TLP	PROC
	mov	ah, 2
	mov	cl, 4
	mov	si, 2
Lap2:
	mov	dl, bl
	shr	dl, cl
	rol	bl, cl

	cmp	dl, 10
	jb	LaSo
	add	dl, 55
	jmp	_Xuat1
LaSo:
	or	dl, 30h
_Xuat1:
	int	21h

	dec	si
	jnz	Lap2

	ret
Xuat_TLP	ENDP

END	Main