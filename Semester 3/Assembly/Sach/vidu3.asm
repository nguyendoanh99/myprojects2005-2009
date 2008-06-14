.MODEL	SMALL
.STACK	100h
.DATA
	u	db	3 dup(?)
	Text	db	'Tesex'
	TLen	equ	($-Text)
	
.CODE
	mov	ax, @data
	mov	es, ax
	mov	di, offset text
	mov	al, 't'
	mov	cx, tLen
	cld
Scan:
	;scasb
	;je	Found
	;loop	Scan
	repne	scasb
	je	found
	;
	;
Found:
	dec	di
	; Ket thuc chuong trinh
	mov	ah, 4ch
	int	21h
END