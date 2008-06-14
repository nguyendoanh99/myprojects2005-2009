.MODEL SMALL
.STACK 100h
.DATA
	TBao1	DB	'Nhap so N1 = $'
	TBao2	DB	13, 10, 'Nhap so N2 = $'
	TBao3	DB	13, 10, 'N = N1 + N2 = $'
	S1	DB	6 dup(?)
	S2	DB	6 dup(?)
	len1	DB	? ; Chieu dai chuoi S1
	len2	DB	? ; Chieu dai chuoi S2
	N1	DW	0
	N2	DW	0
	N	DW	?
	S	DB	?
.CODE
; Dua dia chi doan du lieu vao DS
	mov	ax, @DATA
	mov	ds, ax
	; Xuat chuoi thong bao 1
	mov	ah, 9
	mov	dx, offset TBao1
	int	21h
; Nhap Chuoi S1
	mov si, 0
NhapS1:
	mov	ah, 1
	int	21h
	cmp	al, 13
	je	ThoatS1	
	mov	S1[si], al
	inc	si
	jmp short NhapS1
ThoatS1:
; Them ky tu ket thuc chuoi cho S1 va lay chieu dai cua S1
	mov	S1[si], '$'
; Doi chuoi vua nhap thanh so
	mov	cx, si
	mov	bx, 0 ; bx se giu gia tri cua S1
	mov	bl, S1 - '0'
	mov	dl, 10
	mov	al, dl ; Chuan bi thuc hien phep nhan
LapN1:
;	cmp	S1[si], '$'
;	je	ThoatN1
	mov	dl, 10
	mul	dl
	mov	dx, ax ; Luu ket qua luy thua 10 tai lan lap thu i
	mov	si, cx
	mul	S1[si - 1] - '0'; 
	add	bx, ax
	mov	ax, dx 
	loop LapN1
ThoatN1:
	mov	N1, bx

END