.MODEL SMALL
.STACK 100h
.DATA
	TBao1	DB	'De chay duoc 1 chuong trinh hop ngu ban can thuc hien cac buoc sau:$'
	TBao2	DB	13, 10, '	Dich file asm thanh file obj$'
	TBao3	DB	13, 10, '	Lien ket file obj thanh file exe$'
	TBao4	DB	13, 10, '	Chay file exe$'
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @DATA
	mov	ds, ax
	; Xuat chuoi thong bao 1
	mov	ah, 9
	mov	dx, offset TBao1
	int	21h
	; Xuat chuoi thong bao 2
;	mov	ah, 9
	mov	dx, offset TBao2
	int	21h
	; Xuat chuoi thong bao 3
;	mov	ah, 9
	mov	dx, offset TBao3
	int	21h
	; Xuat chuoi thong bao 4
;	mov	ah, 9
	mov	dx, offset TBao4
	int 21h
	; Thoat chuong trinh
	mov	ah, 4Ch
	int	21h
END