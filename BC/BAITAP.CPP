// Hay lap chuong trinh tim mot duong di cua con ma tren ban co tu o s den o t
// (s,t nhap tu ban phim)

// Cho co so du lieu ghi lai thong tin ve N tuyen bay(N<=100) of 1 hang hang
// khong. Trong do, thong tin ve moi tuyen bay duoc mo ta boi: Diem khoi hanh
// (departure), diem den (destination), khoang cach (length). Departure, destination
// la 1 xau ky tu do dai khong qua 32, khong chua dau trong o giua, length la
// mot so nho hon 32767.
//
// Ta goi "Hanh trinh bay" tu diem khoi hanh A toi diem den B la day cac hanh
// trinh [A,a1,n1],[A1,A2,n2].., [Ak,B,nk] voi Ai la diem den cua tuyen i nhung
// lai la diem khoi hanh cua tuyen i+1, ni la khoang cach cua tuyen bay thu i
// (1<=i<=k). Trong do, khoang cach cua hanh trinh la tong khoang cach cua cac
// tuyen ma hanh trinh di qua(n1+n2+..+nk).
//
// Cho tep du lieu kieu text hanhtrinh.in duoc ghi theo tung dong, so cac dong
// trong tep du lieu khong vuot qua N, tren moi dong ghi lai thong tin ve 1 tuyen
// bay, trong do departure, destination, length duoc phan biet voi nhau boi 1
// hoac vai dau trong. Hay tim giai phap de thoa man nhu cau of khach hang di
// tu A den B theo 1 so tinh huong sau:
//
// Tim hanh trinh co khoang cach be nhat tu A den B. in ra man hinh tung diem
// ma hanh trinh da qua va khoang cach cua hanh trinh. neu hanh trinh khong
// ton tai hay dua ra thong bao "Hanh trinh khong ton tai".
//
// Vi du ve co so du lieu hanhtrinh.in
// New_York	Chicago	   	1000
// Chicago	Denver	   	1000
// New_York	Toronto	   	800
// New_York	Denver	   	1900
// Toronto      Calgary    	1500
// Toronto 	Los_Angeles     1800
// Toronto 	Chicago	   	500
// Denver 	Urbana		1000
// Denver	Houston		1500
// Houston	Los_Angeles 	1500
// Denver	Los_Angeles	1000
// Voi diem di: New_York, diem den: Los-Angeles; chung ta se co ket qua sau:
// Hanh trinh ngan nhat :
// New_York to Toronto to Los_Angeles;Khoang cach: 2600.

// Cho tep du lieu duoc to chuc giong nhu bai 6.6. Hay tim tat ca cac hanh
// trinh di tu diem s den t.

// Cho tep du lieu duoc to chuc giong nhu bai 6.6. Hay tim hanh trinh di tu
// diem s den t sao cho hanh trinh di qua nhieu node nhat.

// Cho tep du lieu duoc to chuc giong nhu bai 6.6. Hay tim hanh trinh di tu
// diem s den t sao cho hanh trinh di qua it node nhat.
