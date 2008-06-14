.MODEL	SMALL
.STACK	100h
.DATA
	N	DB	?
	x	DW	10 dup(?)
	TBao1	DB	"Nhap mot so duong (2 < N < 10): $"
	TBao2	DB	13, 10, "Mang sau khi tao: ", 13, 10, 9, '$'
	TBao3	DB	13, 10, 'Mang sau khi sap xep: ', 13, 10, 9, '$'
.CODE
Main	PROC
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	; Xuat thong bao 1
	mov	ah, 9
	lea	dx, TBao1
	int	21h
	; Cho nhap mot ky tu va chuyen thanh so gan cho N
	mov	ah, 1
	int	21h
	and	al, 0Fh
	mov	N, al
	; Tao mang
	call	TaoMang
	; Xuat thong bao 2
	mov	ah, 9
	lea	dx, TBao2
	int	21h
	; Xuat mang
	call	XuatMang
	; Xuat thong bao 3
	mov	ah, 9
	lea	dx, TBao3
	int	21h
	; Sap xep va xuat mang
	call	SapXep	
	call	XuatMang
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
Main	ENDP
;-------------------------TaoMang---------------------
TaoMang	PROC
	mov	x[0], 1
	mov	x[2], 5
	mov	si, 4
	xor	cx, cx
	mov	cl, n
	mov	al, 2
	mul	cl
	mov	cl, al
Lap1:
	mov	ax, 3
	imul	x[si-2] ; dx:ax = 3*x[si-1]
	mov	bx, ax	; bx = 3*x[si-1]

	mov	ax, 5
	imul	x[si-4] ; dx:ax = 5*x[si-2]
	sub	bx, ax	; bx = 3*x[si-1] - 5*x[si-2]
	mov	x[si], bx
	add	si, 2
	cmp	si, cx
	jbe	Lap1

	ret
TaoMang	ENDP
;-------------------------Xuat_TP---------------------
Xuat_TP	PROC
	push	ax
	push	bx
	push	cx
	push	dx

	or	ax, ax
	jge	ThucHien
	; Xuat dau tru neu la so am
	push	ax
	mov	ah, 2
	mov	dl, '-'
	int	21h
	pop	ax
	neg	ax
ThucHien:
	xor	dx, dx
	mov	bx, 10
	mov	cx, 0
Lap_:
	div	bx ; dx = dx:ax % 10, ax = dx:ax / 10
	push	dx
	xor	dx, dx ; bo di phan du
	
	inc	cx
	or	ax, ax
	jnz	Lap_
	; Xuat cac ky tu ra man hinh
	mov	ah, 2
Repeat:
	pop	dx
	or	dl, 30h
	int	21h
	loop	Repeat

	pop	dx
	pop	cx
	pop	bx
	pop	ax
	ret
Xuat_TP	ENDP
;-------------------------XuatMang--------------------
XuatMang	PROC
	xor	cx, cx
	mov	si, 0

	mov	cl, n
	mov	al, 2
	mul	cl
	mov	cl, al
Lap2:
	mov	ax, x[si]
	call	Xuat_TP

	mov	ah, 2
	mov	dl, ' '
	int	21h
	
	add	si, 2
	cmp	si, cx
	jbe	Lap2

	ret
XuatMang	ENDP
;-------------------------SapXep----------------------
SapXep	PROC
	mov	si, 0
	xor	cx, cx

	mov	cl, n
	mov	al, 2
	mul	cl
	mov	cl, al
LapSI:
	mov	di, si
	mov	ax, x[si]
	add	di, 2
	cmp	di, cx
	ja	CuoiLapDI
	LapDI:		
		cmp	ax, x[di]
		jng	Tiep

		mov	bx, ax
		mov	ax, x[di]
		mov	x[di], bx
		mov	x[si], ax

	Tiep:	add	di, 2
		cmp	di, cx
		jbe	LapDI
	CuoiLapDI:
	add	si, 2
	cmp	si, cx
	jb	LapSI
	ret
SapXep	ENDP
END