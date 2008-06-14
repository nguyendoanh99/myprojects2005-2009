.MODEl	SMALL
.STACK	100h
.DATA
	d	db	50 dup(?)
	d1	db	'21324$'
.CODE
	mov	ax, seg	d
	mov	es, ax
	mov	dx, ax
	mov	di, offset d
	mov	ah, 9
	mov	dx, offset d1
	int	21h
	call	ReadStr
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
ReadStr	PROC
	push	ax
	push	dx
	push	di
	xor	bx, bx
	cld
Repeat1:
	mov	ah, 8
	int	21h
	or	al, al
	jz	IsCtr
	cmp	al, 27
	je	Until1
	cmp	al, 13
	je	Until1
	mov	ah, 2
	mov	dl, al
	int	21h
	cmp	al, 8
	je	IsBS
	stosb
	inc	bx
	jmp	RePeat1
IsCtr:
	int	21h
	jmp	Repeat1
IsBS:
	mov	dl, 20h
	int	21h
	mov	dl, 8
	int	21h
	or	bx, bx
	jz	Until1
	dec	bx
	dec	di
	jmp	Repeat1
Until1:
	pop	di
	pop	dx
	pop	ax
	ret
ReadStr	ENDP
END