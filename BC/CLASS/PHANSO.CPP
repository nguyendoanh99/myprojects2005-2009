// Cong, tru, nhan, chia phan so.
#include <conio.h>
#include <iostream.h>

class PhanSo
	{
	 public:
	  PhanSo(int a=0,int b=1): t(a), m(b) {};
	  int UCLN(int,int);
	  void ToiGian(int &,int &);
	  int Kiemtra(int b) {return b!=0;}
	  int Tong(int,int);
	  int Hieu(int,int);
	  int Tich(int,int);
	  int Thuong(int,int);
	  void InKQ() { cout<<kq_t<<"/"<<kq_m; };
	  void In() { cout<<t<<"/"<<m; };
	  void Gan(int &a,int &b) { a=t; b=m; };
	 private:
	  int t,m,kq_t,kq_m;
	};

void main()
{
 int t,m;

 clrscr();
 cout<<"Nhap phan so 1\n";
 cout<<"Tu=";
 cin>>t;
 cout<<"Mau=";
 cin>>m;

 PhanSo ps1(t,m);

 cout<<"Nhap phan so 2\n";
 cout<<"Tu=";
 cin>>t;
 cout<<"Mau=";
 cin>>m;

 PhanSo ps2(t,m);

 ps1.In();
 cout<<"+";
 ps2.In();
 cout<<"=";
 if (!ps1.Tong(t,m)) cout<<"Loi";
 else ps1.InKQ();
 cout<<endl;

 ps1.In();
 cout<<"-";
 ps2.In();
 cout<<"=";
 if (!ps1.Hieu(t,m)) cout<<"Loi";
 else ps1.InKQ();
 cout<<endl;

 ps1.In();
 cout<<"*";
 ps2.In();
 cout<<"=";
 if (!ps1.Tich(t,m)) cout<<"Loi";
 else ps1.InKQ();
 cout<<endl;

 ps1.In();
 cout<<"/";
 ps2.In();
 ps2.Gan(t,m);
 cout<<"=";
 if (!ps1.Thuong(t,m)) cout<<"Loi";
 else ps1.InKQ();
 cout<<endl;
 getch();
}
// UCLN cua a va b
int PhanSo::UCLN(int a,int b)
{
 int t;

 if (b!=0)
 {
  for (;a%b!=0;)
  {
   t=a;
   a=b;
   b=t%b;
  }
  return b;
 }
 return 1;
}
// Toi gian phan so
void PhanSo::ToiGian(int &a,int &b)
{
 int t=UCLN(a,b);

 a/=t;
 b/=t;
}
// Tong cua 2 phan so
int PhanSo::Tong(int a,int b)
{
 if (!Kiemtra(b) || !Kiemtra(m)) return 0;
 kq_m=(m*b)/UCLN(m,b);
 kq_t=(t*(kq_m/m))+(a*(kq_m/b));
 ToiGian(kq_t,kq_m);
 return 1;
}
// Hieu cua 2 phan so
int PhanSo::Hieu(int a,int b)
{
 if (!Kiemtra(b) || !Kiemtra(m)) return 0;
 kq_m=(m*b)/UCLN(m,b);
 kq_t=(t*(kq_m/m))-(a*(kq_m/b));
 ToiGian(kq_t,kq_m);
 return 1;
}
// Tich cua 2 phan so
int PhanSo::Tich(int a,int b)
{
 if (!Kiemtra(b) || !Kiemtra(m)) return 0;
 kq_t=t*a;
 kq_m=m*b;
 ToiGian(kq_t,kq_m);
 return 1;
}
// Thuong cua 2 phan so
int PhanSo::Thuong(int a,int b)
{
 if (!Kiemtra(b) || !Kiemtra(m)) return 0;
 kq_t=t*b;
 kq_m=a*m;
 ToiGian(kq_t,kq_m);
 return 1;
}