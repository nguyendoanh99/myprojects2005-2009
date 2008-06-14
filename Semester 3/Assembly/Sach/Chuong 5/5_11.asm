.MODEL	SMALL
.STACK	100h
.DATA
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @data
	mov	ds, ax
	; 
	mov	ax, 1111vh
	call Random
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
Random	PROC
	shl	ax, 1
	mov	bl, ah
	
	mov	cl, 7
	shr	bl, cl
	
	rol	ax, 1
	mov	bh, ah
	shr	bh, cl
	ror	ax, 1

	xor	bh, bl
	or	al, bh

	and	ah, 7Fh
	
	ret
Random	ENDP
END