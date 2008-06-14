.MODEL	SMALL
.STACK	100h
.DATA
	TBao1	DB	'Hay nhap so nhi phan (toi da 16 bit) : $'
	TBao2	DB	13, 10, 'So nhi phan da nhap : $'
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
	lea	dx, TBao1
	int	21h
	; Goi ham nhap so nhi phan
	call	Nhap_NP
	; Xuat thong bao TBao2
	mov	ah, 9
	lea	dx, TBao2
	int	21h
	; Goi ham xuat so nhi phan
	call	Xuat_NP
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
ENDP	Main
;----------------------------------Nhap_NP------------------------
Nhap_NP	PROC
	mov	ah, 8
	mov	si, 0
	xor	bx, bx
Lap1:
	int	21h
	cmp	al, 13
	je	CuoiLap1
	; Kiem tra ky tu vua nhap co phai la ky tu '0', '1' hay khong
	cmp	al, '0'
	je	ThucHien
	cmp	al, '1'
	je	ThucHien
	jmp	Lap1
	; Xuat ky tu vua nhap ra man hinh
ThucHien:
	mov	ah, 2
	mov	dl, al
	int	21h
	mov	ah, 8
	; Chuyen ky tu vua nhap thanh so va dua vao bit tuong ung trong bi
	and	dl, 0Fh
	shl	bx, 1
	or	bl, dl
	inc	si
	cmp	si, 16
	jb	Lap1	; Lap toi da 16 lan
CuoiLap1:
	ret
ENDP	Nhap_NP
;---------------------------------------Xuat_NP------------------------
Xuat_NP	PROC
	; Quay trai bx 16-si lan de bo bot cac con so 0 o dau
	mov	dx, si
	mov	cl, 16
	sub	cl, dl
	rol	bx, cl
	; Thuc hien lap si lan
	mov	ah, 2
	mov	cx, si
Lap2:
	rol	bx, 1
	jc	Xuat1
Xuat0:
	mov	dl, '0'
	jmp	Xuat
Xuat1:
	mov	dl, '1'
Xuat:
	int	21h
	loop	Lap2	; Lap cx lan
	ret
ENDP	Xuat_NP

END	Main