.MODEL SMALL
.STACK 100h
.DATA
	TBao	DB	'Nhap vao mot chuoi: $'
	t	dw	?
.CODE
Main	PROC
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	; Xuat cau thong bao
	mov	ah, 9
	lea	dx, TBao
	int	21h
	; Goi ham nhap chuoi
	call	NhapChuoi
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
ENDP	Main
;---------------------------Nhap chuoi-------------------------------
NhapChuoi	PROC
	mov	ah, 8
	xor	bx, bx ; bx dong vai tro bien dem
For:

	int	21h
	; Kiem tra ky tu vua nhap co phai la Enter hay khong
	cmp	al, 13
	je	CuoiFor

	push	ax ; Dua ky tu vua nhap vao stack
	call	KiemTra
	pop	cx ; Lay ket qua tra ve cua thu tuc KiemTra
	; Neu ky tu vua nhap khong nam trong khoang cho phep thi nhap lai
	cmp	cl, 0
	jne	XuLy
	int	21h ; bo qua ky tu dieu khien
	jmp	For
XuLy:
	mov	[si + bx], al
	; Xuat ky tu vua nhap ra man hinh
	mov	ah, 2
	mov	dl, al
	int	21h
	mov	ah, 8
	; Tang bien dem
	inc	bx
	cmp	bx, 255
	jne	For
CuoiFor:
	mov	[si + bx], byte ptr 0 ; Them ky tu ket thuc chuoi
ENDP	NhapChuoi
;--------------------------------Kiem tra-------------------------
KiemTra	PROC
	mov	bp, sp
	mov	dl, [bp + 2] ; Lay tham so truyen vao (ky tu vua nhap) dua vao dl
	cmp	dl, 20h
	jb	Sai
	cmp	dl, 0FFh
	jbe	Dung
	; Dua ket qua vao tham so
Sai:
	mov	[bp + 2], byte ptr 0 
	ret	2
Dung:
	mov	byte ptr [bp + 2], 1
	ret
ENDP	KiemTra

END	Main