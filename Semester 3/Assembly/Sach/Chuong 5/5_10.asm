.MODEL	SMALL
.STACK	100h
.DATA
	TBao1	DB	'Nhap so thap luc 1 (16 bit): $'
	TBao2	DB	13, 10, 'Nhap so thap luc 2 (16 bit): $'
	TBao3	DB	13, 10, 'Tong : $'
	So1	DW	?
	So2	DW	?
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
	; Goi ham Nhap_TL va luu trong So1
	call	Nhap_TL
	mov	So1, BX
	; Xuat thong bao 2
	mov	ah, 9
	lea	dx, TBao2
	int	21h
	; Goi ham Nhap_TL va luu trong So2
	call	Nhap_TL
	mov	So2, bx
	; Tinh tong
	add	bx, So1
	; Xuat thong bao 3
	mov	ah, 9
	lea	dx, TBao3
	int	21h
	; Goi ham Xuat_TL
	call Xuat_TL
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
Main	ENDP
;--------------------------Nhap_TL-----------------------
Nhap_TL	PROC
	xor	bx, bx
	mov	cl, 4
	mov	si, 4
	mov	ah, 8
Lap1:
	int	21h
	
	cmp	al, 0
	jne	ThucHien
	int	21h
	jmp	Lap1

ThucHien:
	cmp	al, 13
	je	CuoiLap1
	; Kiem tra ky tu nhap la so
	cmp	al, '0'
	jb	Lap1
	cmp	al, '9'
	jbe	LaSo
	; Kiem tra ky tu nhap la chu hoa
	cmp	al, 'A'
	jb	Lap1
	cmp	al, 'F'
	jbe	LaChuHoa
	; Kiem tra ky tu nhap la chu thuong
	cmp	al, 'a'
	jb	Lap1
	cmp	al, 'f'
	jbe	LaChuThuong
	jmp	Lap1
LaSo:
	call	XuatKyTu
	and	al, 0Fh
	jmp	DichBX
LaChuHoa:
	call	XuatKyTu
	sub	al, 55
	jmp	DichBX
LaChuThuong:
	call	XuatKyTu
	sub	al, 87
DichBX:
	shl	bx, cl
	or	bl, al

	dec	si
	jnz	Lap1 ; Lap si lan
CuoiLap1:
	ret
Nhap_TL	ENDP
;--------------------------XuatKyTu---------------------
XuatKyTu	PROC
	mov	ah, 2
	mov	dl, al
	int	21h
	mov	al, dl
	mov	ah, 8

	ret
XuatKyTu	ENDP
;--------------------------Xuat_TL-----------------------
Xuat_TL	PROC
	mov	cl, 4
	mov	si, 4
	mov	ah, 2
Lap2:
	mov	dl, bh
	shr	dl, cl
	rol	bx, cl

	cmp	dl, 10
	jb	XuatSo
	add	dl, 55
	jmp	Xuat
XuatSo:	
	or	dl, 30h
Xuat:
	int	21h
	
	dec	si
	jnz	Lap2 ; Lap si lan

	ret
Xuat_TL	ENDP
END	Main