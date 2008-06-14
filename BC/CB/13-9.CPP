// 1 so goi la so hoan hao neu so do lai bang tong tat ca cac uoc so cua no
// (khong ke so do).
// a) Viet chuong trinh kiem tra 1 so co la so hoan hao hay khong.
// b) Viet chuong trinh tim tat ca cac so hoan hao trong khoang tu 1 den 1000.
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
int kt(int a)
{
 int i=1,t=0;
 while (i<=a/2)
 {
  if (a%i==0) t+=i;
  i++;
 }
 if (a==t) return 1;
 else return 0;
}
void main()
{
 clrscr();
 int a;
 cout<<"Nhap vao 1 so = ";
 cin>>a;
 cout<<a;
 if (kt(a)==1) cout<<" la so hoan hao.\n";
 else cout<<" khong phai la so hoan hao.\n";
 for (int i=1;i<=1000;i++)
  if (kt(i)==1)cout<<setw(5)<<i;
 getch();
}