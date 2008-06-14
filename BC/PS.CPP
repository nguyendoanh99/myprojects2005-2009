//Thuc hien cac phep tinh phan so.
#include <iostream.h>
#include <conio.h>
struct ps
       {
	int t,m;
       };
ps a[2],tongps,hieups,tichps,thuongps;
int UCLN(int a,int b)
{
 int c;
 for (;a%b!=0;)
 {
  c=a;
  a=b;
  b=c%b;
 }
 return b;
}
void tong(ps a,ps b,ps &kq)
{
 kq.m=a.m*b.m;
 kq.t=a.t*b.m+b.t*a.m;
}
void hieu(ps a,ps b,ps &kq)
{
 kq.m=a.m*b.m;
 kq.t=a.t*b.m-b.t*a.m;
}
void tich(ps a,ps b,ps &kq)
{
 kq.m=a.m*b.m;
 kq.t=a.t*b.t;
}
void thuong(ps a,ps b,ps &kq)
{
 kq.m=a.m*b.t;
 kq.t=a.t*b.m;
}
void tg(ps &a)
{
 int t=UCLN(a.t,a.m);
 a.t=a.t/t;
 a.m=a.m/t;
}
void main()
{
 clrscr();
 for (int i=1;i<=2;i++)
 {
  cout<<"Phan so thu "<<i<<endl;
  cout<<"Tu = ";
  cin>>a[i-1].t;
  cout<<"Mau = ";
  cin>>a[i-1].m;
 }
 tong(a[0],a[1],tongps);
 hieu(a[0],a[1],hieups);
 tich(a[0],a[1],tichps);
 thuong(a[0],a[1],thuongps);
 tg(tongps);
 tg(hieups);
 tg(tichps);
 tg(thuongps);
 cout<<"Tong 2 phan so = "<<tongps.t<<"/"<<tongps.m<<endl;
 cout<<"Hieu 2 phan so = "<<hieups.t<<"/"<<hieups.m<<endl;
 cout<<"Tich 2 phan so = "<<tichps.t<<"/"<<tichps.m<<endl;
 cout<<"Thuong 2 phan so = "<<thuongps.t<<"/"<<thuongps.m<<endl;
 getch();
}