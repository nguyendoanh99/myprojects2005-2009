.MODEL	SMALL
.STACK	100h
.DATA
	TBao1	DB	'Nhap mot ky tu: $'
	TBao2	DB	13, 10, 'Ma ASCII: $'	
.CODE
Main	PROC
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	; Xoa man hinh
	mov	ax, 3
	int	10h
	; Xuat thong bao 1
	mov	ah, 9
	lea	dx, TBao1
	int	21h
	; Cho nhap mot phim va luu phim vua nhap vao bl
	mov	ah, 1
	int	21h
	mov	bl, al
	; Xuat thong bao 2
	mov	ah, 9
	lea	dx, TBao2
	int	21h
	; 
	mov	ah, 2
	mov	dl, '('
	int	21h
	; Goi ham Xuat_TLP
	call	Xuat_TLP
	;
	mov	ah, 2
	mov	dl, ')'
	int	21h
	;
	mov	dl, ' '
	int	21h
	; Goi ham Xuat_NP
	call	Xuat_NP
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
Main	ENDP
;--------------------------Xuat_TLP-----------------------------
Xuat_TLP	PROC
	mov	cl, 4
	mov	si, 2
	mov	ah, 2
Lap1:
	mov	dl, bl
	shr	dl, cl
	rol	bl, cl
	; Kiem tra dl
	cmp	dl, 10
	jb	LaSo
	add	dl, 55
	jmp	Xuat1
LaSo:
	or	dl, 30h
Xuat1:
	int	21h
	dec	si
	jnz	Lap1

	mov	dl, 'h'
	int	21h
	ret
Xuat_TLP	ENDP
;------------------------------Xuat_NP--------------------------
Xuat_NP	PROC
	mov	cx, 8
	mov	ah, 2
Lap2:
	rol	bl, 1
	jc	So1
	mov	dl, '0'
	jmp	Xuat2
So1:
	mov	dl, '1'
Xuat2:
	int	21h
	loop	Lap2

	mov	dl, 'b'
	int	21h
	ret
Xuat_NP	ENDP

END	Main