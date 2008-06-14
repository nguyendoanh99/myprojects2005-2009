// Viet chuong trinh tinh so hang thu n cua day Fibonasi.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int n;
 cout<<"n=";
 cin>>n;
 int f,f1=1,f2=1;
 if (n==1 || n==2) f=1;
 for (int i=3;i<=n;i++)
 {
  f=f1+f2;
  f1=f2;
  f2=f;
 }
 cout<<"So hang thu "<<n<<" cua day Fibo la "<<f;
 getch();
}