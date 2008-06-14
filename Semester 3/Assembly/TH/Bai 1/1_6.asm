.MODEL SMALL
.STACK 100h
.DATA
	TBao1	DB	'Nhap x1:$'
	TBao2	DB	13, 10, 'Nhap x2:$'
	TBao3	DB	13, 10, 'x1 = $'
	TBao4	DB	13, 10, 'x2 = $'
	TBao5	DB	13, 10, 'x1 - 1 = $'
	TBao6	DB	13, 10, 'x1 + 1 = $'
	TBao7	DB	13, 10, 'x1 + x2 = $'
	TBao8	DB	13, 10, 'x1 - x2 = $'
	x1	DB	?
	x2	DB	?
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @DATA
	mov	ds, ax
	; Xuat thong bao 1
	mov	ah, 9
	mov	dx, offset TBao1
	int	21h
	; Nhap ky tu tu ban phim va gan cho x1
	mov	ah, 1
	int	21h
	mov	x1, al	
	; Xuat thong bao 2
	mov	ah, 9
	mov	dx, offset TBao2
	int	21h
	; Nhap ky tu tu ban phim va gan cho x2
	mov	ah, 1
	int	21h
	mov	x2, al	
	; Xuat thong bao 3
	mov	ah, 9
	mov	dx, offset TBao3
	int	21h
	; Xuat x1 ra man hinh
	mov	ah, 2
	mov	dl, x1	
	int	21h
	; Xuat thong bao 4
	mov	ah, 9
	mov	dx, offset TBao4
	int	21h
	; Xuat x2 ra man hinh
	mov	ah, 2
	mov	dl, x2
	int	21h
	; Doi x1, x2 thanh so
	sub	x1, '0'
	sub	x2, '0'
	; Xuat thong bao 5
	mov	ah, 9
	mov	dx, offset TBao5
	int	21h
	; Xuat ket qua x1 - 1 ra man hinh
	mov	ah, 2
	mov	dl, x1
	dec	dl
	add	dl, '0'	 ; Chuyen thanh DL tu dang so sang dang ky tu
	int	21h
	; Xuat thong bao 6
	mov ah, 9
	mov dx, offset TBao6
	int	21h
	; Xuat ket qua x1 + 1 ra man hinh
	mov	ah, 2
	mov	dl, x1
	inc	dl
	add	dl, '0'	 ; Chuyen thanh DL tu dang so sang dang ky tu
	int	21h
	; Xuat thong bao 7
	mov	ah, 9
	lea	dx, TBao7
	int	21h
	; Xuat ket qua cua x1 + x2 ra man hinh
	mov	ah, 2
	mov	dl, x1
	add	dl, x2
	add	dl, '0'	 ; Chuyen thanh DL tu dang so sang dang ky tu
	int	21h
	; Xuat thong bao 8
	mov	ah, 9
	lea	dx, TBao8
	int	21h
	; Xuat ket qua cua x1 - x2 ra man hinh
	mov	ah, 2
	mov	dl, x1
	sub	dl, x2
	add	dl, '0'	 ; Chuyen thanh DL tu dang so sang dang ky tu
	int	21h
	; Ket thuc chuong trinh
	mov	ah, 4Ch
	int	21h
END