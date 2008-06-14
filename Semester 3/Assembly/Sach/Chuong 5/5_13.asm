.MODEL	SMALL
.STACK	100h
.DATA
	TBao1	DB	'Dia chi doan : $'
	TBao2	DB	13, 10, 'Dia chi o    : $'
	TBao3	DB	13, 10, 'Noi dung     : $'
.CODE
Main	PROC
	; Dua dia chi doan du lieu vao ds
	mov	ax, @data
	mov	ds, ax
	; Xuat thong bao 1
	mov	ah, 9
	lea	dx, TBao1
	int	21h
	; Goi ham nhap_TLP
	call	Nhap_TLP
	mov	es, bx
	; Xuat thong bao 2
	mov	ah, 9
	lea	dx, TBao2
	int	21h
	; Goi ham nhap_TLP
	call	Nhap_TLP
	mov	bp, bx
	; Xuat thong bao 3
	mov	ah, 9
	lea	dx, TBao3
	int	21h
	; Thuc hien lap
	mov	si, 0
Lap:
	mov	bl, es:bp+si
	call	Xuat_TLP

	mov	ah, 2
	mov	dl, ' '
	int	21h

	inc	si
	cmp	si, 8
	jne	_If
	mov	ah, 2
	; Xuong hang
	mov	dl, 13
	int	21h
	mov	dl, 10
	int	21h
	; Xuat 2 tab
	mov	dl, 9
	int	21h
	int	21h

_If:	cmp	si, 16
	jne	Lap
	; Ket thuc chuong trinh	
	mov	ah, 4ch
	int	21h
Main	ENDP
;-----------------------Nhap_TLP-----------------------
Nhap_TLP	PROC
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
	; Kiem tra ky tu nhap co phai la so khong
	cmp	al, '0'
	jb	Lap1
	cmp	al, '9'
	jbe	LaSo
	; Kiem tra ky tu nhap co phai la chu hoa khong
	cmp	al, 'A'
	jb	Lap1
	cmp	al, 'F'
	jbe	LaChuHoa
	; Kiem tra ky tu nhap co phai la chu thuong khong
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
	jnz	Lap1
CuoiLap1:
	ret
Nhap_TLP	ENDP
;-----------------------XuatKyTu----------------------
XuatKyTu	PROC
	mov	ah, 2
	mov	dl, al
	int	21h
	mov	al, dl
	mov	ah, 8
	ret
XuatKyTu	ENDP
;-----------------------Xuat_TLP-----------------------
Xuat_TLP	PROC
	mov	cl, 4
	mov	di, 2
	mov	ah, 2
Lap2:
	mov	dl, bl
	shr	dl, cl
	rol	bl, cl

	cmp	dl, 10
	jb	XuatSo
	add	dl, 55
	jmp	Xuat
XuatSo:
	or	dl, 30h
Xuat:
	int	21h
	
	dec	di
	jnz	Lap2

	ret
Xuat_TLP	ENDP
END	Main