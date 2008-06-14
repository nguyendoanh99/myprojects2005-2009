.MODEL	SMALL
.STACK	100h
.DATA
	TBao1	DB	13, 10, 'Nhap phep tinh +, -, *, / (hoac Enter):$'
	TBao2	DB	13, 10, 'Toan hang mot:$'
	TBao3	DB	13, 10, 'Toan hang hai:$'
	TBao4	DB	13, 10, 'Ket qua:$'
	TBao5	DB	'(du $'
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
Lap:
	; Xuat thong bao 1
	mov	ah, 9
	lea	dx, TBao1
	int	21h
	; Cho nhap mot phim
	mov	ah, 1
	int	21h
	; Neu la Enter thi dung
	cmp	al, 13
	je	CuoiLap
	
	mov	cl, al
	; Xuat thong bao 2
	mov	ah, 9
	lea	dx, TBao2
	int	21h
	
	call	NhapSoNguyen
	mov	bx, ax
	; Xuat thong bao 3
	mov	ah, 9
	lea	dx, TBao3
	int	21h

	call	NhapSoNguyen
	mov	si, ax
	; Xuat thong bao 4
	mov	ah, 9
	lea	dx, Tbao4
	int	21h
	; Thuc hien phep tinh
	mov	ax, bx
	xor	di, di
	cmp	cl, '+'
	je	Cong
	cmp	cl, '-'
	je	Tru
	cmp	cl, '*'
	je	Nhan
	cmp	cl, '/'
	je	Chia
	jmp	Lap
Cong:
	add	ax, si
	jmp	Xuat
Tru:
	sub	ax, si
	jmp	Xuat
Nhan:
	cwd
	mul	si
	jmp	Xuat
Chia:
	cwd
	div	si
	mov	di, 1
Xuat:
	call	XuatSoNguyen
	or	di, di
	jz	Lap
	mov	di, dx
	; Xuat thong bao 5
	mov	ah, 9
	lea	dx, TBao5
	int	21h
	
	mov	ax, di
	call	XuatSoNguyen
	
	mov	ah, 2
	mov	dl, ')'
	int	21h

	jmp	Lap
	; Ket thuc chuong trinh
CuoiLap:
	mov	ah, 4ch
	int	21h
;----------------------------------XuatSoNguyen-----------------------------
XuatSoNguyen	PROC
	push	ax
	push	bx
	push	cx
	push	dx
	or	ax, ax
	jge	ThucHien
	push	ax
	mov	ah, 2
	mov	dl, '-'
	int	21h
	pop	ax
	neg	ax

ThucHien:
	mov	bx, 10
	cwd
	xor	cx, cx
Lap1:
	div	bx
	push	dx
	cwd
	inc	cx
	or	ax, ax
	jnz	Lap1
	
	mov	ah, 2
Repeat1:
	pop	dx
	or	dl, 30h
	int	21h
	loop	Repeat1

	pop	dx
	pop	cx
	pop	bx
	pop	ax
	ret
XuatSoNguyen	ENDP
;----------------------------------NhapSoNguyen-----------------------------
NhapSoNguyen	PROC
	push	bx
	push	cx
	push	dx
	push	si

	xor	cx, cx ; Thong bao so nhap vao la duong hay am
	xor	bx, bx ; So nhap duoc se luu tam vao bx
	; Cho nhap phim
	mov	ah, 8
	int	21h

	cmp	al, '+'
	je	@Cong
	cmp	al, '-'
	je	@Tru
	jmp	Repeat2
@Tru:
	or	cx, 1
@Cong:
	; Xuat ky tu vua nhap
	mov	ah, 2
	mov	dl, al
	int	21h
	; Cho nhap phim
	mov	ah, 8
	int	21h
Repeat2:
	cmp	al, '0'
	jb	@Next
	cmp	al, '9'	
	ja	@Next
	; Xuat ky tu vua nhap ra man hinh
	mov	ah, 2
	mov	dl, al
	int	21h
	; tinh bieu thuc bx= bx*10+kytu
	and	al, 0Fh
	cbw
	mov	si, ax

	mov	ax, bx	
	cwd
	mov	bx, 10
	mul	bx ; ax = ax*10
	add	si, ax
	mov	bx, si

@Next:
	mov	ah, 8
	int	21h
	cmp	al, 13
	jne	Repeat2
	
	or	cx, cx
	jz	KetThuc
	neg	bx
KetThuc:
	mov	ax, bx
	pop	si
	pop	dx
	pop	cx
	pop	bx
	ret
NhapSoNguyen	ENDP
END