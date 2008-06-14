.MODEL	SMALL
.STACK	100h
.DATA
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	mov	al, 200
	mov	ah, 40
	add	al, ah
	call	OutDec
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
OutDec	PROC
	push	ax
	push	bx
	push	cx
	push	dx
	
	or	ax, ax
	jge	@Positive

	push	ax
	mov	ah, 2
	mov	dl, '-'
	int	21h
	pop	ax
	neg	ax
@Positive:
	xor	cx, cx
	mov	bx, 10
@Repeat1:
	xor	dx, dx
	div	bx
	push	dx
	inc	cx
	or	ax, ax
	jnz	@Repeat1
	mov	ah, 2
@For1:
	pop	dx
	or	dl, '0'
	int	21h
	loop	@For1

	pop	dx
	pop	cx
	pop	bx
	pop	ax
	ret
OutDec	ENDP
END