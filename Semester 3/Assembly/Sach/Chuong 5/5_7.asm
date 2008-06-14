.MODEL	SMALL
.STACK	100h
.DATA	
	TBao1	DB	'Hay nhap so thap luc (toi da 4 ky so) : $'
	TBao2	DB	13, 10, 'So thap luc phan da nhap : $'
.CODE
Main	PROC
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	; Xoa man hinh
	mov	ax, 3
	int	10h
	; Xuat thong bao TBao1
	mov	ah, 9
	lea	dx, Tbao1
	int	21h
	; Goi ham Nhap_TL
	call	Nhap_TL
	; Xuat thong bao TBao2
	mov	ah, 9
	lea	dx, TBao2
	int	21h
	; Goi ham xuat_TL
	call	Xuat_TL
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
ENDP	Main
;--------------------------------Nhap_TL----------------------------
Nhap_TL	PROC
	mov	ah, 8
	mov	cl, 4
	mov	si, 4
	xor	bx, bx
Lap1:
	int	21h
	cmp	al, 13
	je	CuoiLap1
	cmp	al, 0
	jne	TiepTuc
	int	21h
	jmp	Lap1
	; Kiem tra ky tu vua nhap co phai la ky tu so hay khong
Tieptuc:
	cmp	al, '0'
	jb	Lap1
	cmp	al, '9'
	jbe	LaSo
	; Kiem tra ky tu vua nhap co phai la chu cai (hoa) hay khong
	cmp	al, 'A'
	jb	Lap1
	cmp	al, 'Z'
	jbe	LaChuHoa
	; Kiem tra ky tu vua nhap co phai la chu cai (thuong) hay khong
	cmp	al, 'a'
	jb	Lap1
	cmp	al, 'z'
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
ENDP	Nhap_TL
;------------------------XuatKyTu--------------------------
XuatKyTu	PROC
	mov	ah, 2
	mov	dl, al
	int	21h
	mov	al, dl
	mov	ah, 8
	ret
ENDP	XuatKyTu
;-------------------------Xuat_TL--------------------------
Xuat_TL	PROC	
	mov	ah, 2
	mov	cl, 4
	mov	si, 4
Lap2:
	mov	dl, bh
	rol	bx, cl
	shr	dl, cl

	cmp	dl, 10
	jb	XuatSo
	; La chu
	add	dl, 55
	jmp	_Xuat
XuatSo:
	or	dl, 30h
_Xuat:
	int	21h

	dec	si
	jnz	Lap2
CuoiLap2:
	ret
ENDP	Xuat_TL
END	Main