.model	small
.stack	100h
.data
	sint	dw	3,2,60,4,3,3,2,0,0
	alen	equ	9
.code
	mov	ax, seg sint
	mov	es, ax
	mov	di, offset	sint +(alen-1)*2
	mov	cx, alen
	xor	ax, ax
	std
	repe	scasw
	jne	found
	;;
	found:
	inc	di
	inc	di
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
end