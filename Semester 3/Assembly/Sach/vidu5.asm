.model	small
.stack	100h
.data
	t	db	4 dup(?)
	s	label	byte
	maxlen	db	10
	actlen	db	?
	chars	db	80 dup(?)
.code
	mov	ah, 0ah
	mov	bx, seg s
	mov	ds, bx
	mov	dx, offset s
	int	21h
	mov	ah, 2
	mov	dl, 10
	int	21h
	
	mov	ah, 40h
	mov	bx, 1
	xor	ch, ch
	mov	cl, actlen
	mov	dx, seg chars
	mov	ds, dx
	mov	dx, offset chars
	int	21h
;	mov	ah, 3fh
;	mov	bx, 0
;	xor	ch, ch
;	mov	cl, maxlen
;	mov	dx, seg	chars
;	mov	ds, dx
;	mov	dx, offset chars
;	int	21h
	; ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
end