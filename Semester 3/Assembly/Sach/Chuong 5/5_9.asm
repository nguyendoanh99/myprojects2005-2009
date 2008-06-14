.MODEL	SMALL
.STACK	100h
.DATA
	TBao1	DB	'Nhap so nhi phan 1 (8 bit): $'
	TBao2	DB	13, 10, 'Nhap so nhi phan 2 (8 bit): $'
	TBao3	DB	13, 10, 'Tong: $'
	so1	DB	?
	so2	DB	?
	tong	DB	?
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
	; Goi ham nhap_NP
	call	Nhap_NP
	mov	so1, bl
	; Xuat thong bao 2
	mov	ah, 9
	lea	dx, TBao2
	int	21h
	; Goi ham nhap_NP
	call	Nhap_NP
	mov	so2, bl
	; Xuat thong bao 3
	mov	ah, 9
	lea	dx, TBao3
	int	21h
	; Tinh tong
	mov	bl, so1
	add	bl, so2
	; Goi ham xuat_NP 
	call	Xuat_NP
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
Main	ENDP
;-----------------------------Nhap_NP-------------------------
Nhap_NP	PROC
	mov	cx, 8
	mov	ah, 8
	xor	bl, bl
Lap1:
	int	21h
	cmp	al, 13
	je	CuoiLap1
	cmp	al, '0'
	je	ThucHien
	cmp	al, '1'
	je	ThucHien
	jmp	Lap1
ThucHien:
	; Xuat so vua nhap ra man hinh
	mov	ah, 2
	mov	dl, al
	int	21h
	mov	ah, 8

	and	dl, 0Fh
	shl	bl, 1
	or	bl, dl
	loop	Lap1 ; Thuc hien cx lan lap
CuoiLap1:
	ret
Nhap_NP	ENDP
;--------------------------------Xuat_NP---------------------------
Xuat_NP	PROC
	mov	cx, 8
	mov	ah, 2
Lap_:
	rol	bl, 1
	jc	Nhay
	dec	cx
	cmp	cx, 1
	jne	Lap_
Lap2:
	rol	bl, 1
Nhay:
	jc	_So1
	mov	dl, '0'
	jmp	Xuat
_So1:
	mov	dl, '1'
Xuat:
	int	21h
	loop	Lap2

	ret
Xuat_NP	ENDP
END	Main