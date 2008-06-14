// Ho ten: NGUYEN DANG KHOA
// MSSV: 0512175
// Lop: C1
// Ca thuc hanh: ca 2 chieu thu 6
#include "CMyString.h"
#include <iostream.h>
#include <stdlib.h>
#include <conio.h>

void main()
{	
	char *strDS[2] = {"Sai", "Dung"};
	CMyString a;
	CMyString b("Toi la");
	CMyString c = b; // c(b)
	CMyString d('K', 10);
	CMyString e;
	CMyString f;
	char *str = "MSSV: 0512175";

	cout << "Nhap chuoi e: ";
	cin >> e;
	// Xuat cac chuoi ra man hinh
	cout << endl;
	cout << "a(\"" << a << "\")" << endl;
	cout << "b(\"" << b << "\")" << endl;
	cout << "c(\"" << c << "\")" << endl;
	cout << "d(\"" << d << "\")" << endl;
	cout << "e(\"" << e << "\")" << endl;
	cout << "Chuoi char * str = \"" << str << "\"" << endl;
	cout << endl;

	// Thuc hien cac toan tu so sanh
	cout << "Cac phep so sanh co phan biet hoa thuong" << endl;
	cout << "c == b : " << strDS[(c == b)] << endl;
	cout << "a == str : " << strDS[(a == str)] << endl;
	cout << "b > c : " << strDS[(b > c)] << endl;
	cout << "b > str : " << strDS[(b > str)] << endl;
	cout << "b >= c : " << strDS[(b >= c)] << endl;
	cout << "b >= str : " << strDS[(b >= str)] << endl;
	cout << "b < a : " << strDS[(b < a)] << endl;
	cout << "b < str : " << strDS[(b < str)] << endl;
	cout << "b <= a : " << strDS[(b <= a)] << endl;
	cout << "b <= str : " << strDS[(b <= str)] << endl;
	cout << endl;

	// Thuc hien cac phep cong chuoi
	f = b + " " + e + " " + str;
	cout << "f = (b + \" \" + e + \" \" + str) : (\"" << f << "\")" << endl;
	
	d += a += str;
	cout << "d += a += str " << endl;
	cout << " --> a(\"" << a << "\")" << endl;
	cout << "     d(\"" << d << "\")" << endl;

	// Lay chieu dai cua chuoi, kiem tra chuoi rong
	cout << "Chieu dai cua chuoi d la " << d.GetLength() << endl;
	d.Empty();
	cout << "Sau khi dung lenh d.Empty().\nd la chuoi rong: " << strDS[d.IsEmpty()] << endl;
	
	// Cho nhan phim de xoa man hinh
	cout << endl << "Nhap mot phim bat ky de tiep tuc" << endl;
	getch();
	system("cls");
	
	// Dung ham de so sanh 2 chuoi
	char *ss[] = {"==", ">", "<"};
	CMyString s1 = "   Nguyen Dang Khoa ";
	CMyString s2 = "   nguyen dang khoa ";	
	cout << "So sanh 2 chuoi s1 va s2 (dung ham)" << endl;
	
	int kq = s1.Compare(s2);
	kq = (kq >= 0 ? kq : 2);
	cout << "Co phan biet hoa thuong : s1(\"" << s1 << "\") " << ss[kq] << " s2(\"" << s2 << "\")" << endl;

	kq = s1.CompareNoCase(s2);
	kq = (kq >= 0 ? kq : 2);
	cout << "Khong phan biet hoa thuong : s1(\"" << s1 << "\") " << ss[kq] << " s2(\"" << s2 << "\")" << endl;
	cout << endl;

	// Doi chuoi thanh chu hoa, chu thuong
	cout << "Chuoi s1 sau khi doi sang chu thuong : s1(\"" << s1.MakeLower() << "\")" << endl;
	cout << "Chuoi s2 sau khi doi sang chu hoa : s2(\"" << s2.MakeUpper() << "\")" << endl;
	cout << endl;

	// Xoa cac khoang trang o dau, cuoi chuoi
	cout << "Chuoi s1 sau khi cat bo cac ky tu trang dau chuoi: s1(\"" << s1.TrimLeft() << "\")" << endl;
	cout << "Chuoi s2 sau khi cat bo cac ky tu trang dau chuoi: s2(\"" << s2.TrimRight() << "\")" << endl;
	cout << endl;
	
	// Lay chuoi con trong 1 chuoi
	cout << "Lay 6 ky tu tu s1 bat dau tu vi tri 2 = \"" << s1.Mid(2,6) << "\"" << endl;
	cout << "Lay 7 ky tu dau tien cua s1 = \"" << s1.Left(7) << "\"" << endl;
	cout << "Lay 7 ky tu cuoi cung cua s1 = \"" << s1.Right(7) << "\"" << endl;
	cout << endl;

	// Tim chuoi con trong 1 chuoi
	cout << "Vi tri xuat hien dau tien cua chuoi \"ng\" trong chuoi s1 la " << s1.Find("ng") << endl;
	cout << "Vi tri xuat hien cuoi cung cua chuoi \"ng\" trong chuoi s1 la " << s1.ReverseFind("ng") << endl;


}