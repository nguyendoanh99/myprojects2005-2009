// Viet chuong trinh kiem tra so nguyen to.
#include <iostream.h>
#include <conio.h>
#include <math.h>
void main()
{
 clrscr();
 int a;
 cout<<"Nhap vao 1 so = ";
 cin>>a;
 cout<<a;
 if (a>1)
 {
  int k=1;
  for (int i=2;i<=floor(sqrt(a));i++)
   if (a%i==0)
   {
    k=0;
    break;
   }
  if (k==0) cout<<" khong phai la so nguyen to.";
  else cout<<" la so nguyen to.";
 }
 else cout<<" khong phai la so nguyen to.";
 getch();
}