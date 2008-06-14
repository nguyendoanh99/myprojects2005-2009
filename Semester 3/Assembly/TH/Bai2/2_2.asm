.MODEL SMALL
.STACK 100h
.DATA
	TBao1	DB	'Nhap vao mot ky tu:$'
	TBao2	DB	13, 10, 'Ky tu vua nhap:$'
	Thuong	DB	13, 10, ' la chu thuong.$'
	Hoa	DB	' la chu hoa.$'
	So	DB	' la so.$'
	KyTu	 DB	?
.CODE
	; Dua dia chi doan du lieu vao DS
	mov	ax, @DATA
	mov	ds, ax
	; Xuat thong bao 1
	mov	ah, 9
	mov	dx, offset TBao1
	int	21h
	; Cho nhap ky tu tu ban phim va luu vao KyTu
	mov	ah, 1
	int	21h
	mov	KyTu, al
	; Xuat thong bao 2
	mov	ah, 9
	mov	dx, offset TBao2
	int	21h
	; Xuat ky tu KyTu
	mov	ah, 2
	mov	dl, KyTu
	int	21h
	; Kiem tra KyTu thuoc loai nao
	cmp	KyTu, '0'
	jb	Thoat
	cmp	KyTu, '9'
	jbe	XuatSo

	cmp	KyTu, 'A'
	jb	Thoat
	cmp	KyTu, 'Z'
	jbe	XuatChuHoa

	cmp	KyTu, 'a'
	jb	Thoat
	cmp	KyTu, 'z'
	jbe	XuatChuThuong
	jmp	Thoat
XuatSo:
	mov	dx, offset So
	jmp	Xuat
XuatChuHoa:
	mov	dx, offset Hoa
	jmp	Xuat
XuatChuThuong:
	mov	dx, offset Thuong
Xuat:
	mov	ah, 9
	int	21h
Thoat:
	mov	ah, 4ch
	int	21h
END