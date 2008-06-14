// Viet ham de qui in ra gia tri lon nhat cua n phan tu dau tien cua mang

#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
#include <stdlib.h>

int max(int,int []);

void main()
{
 int a[20],n;

 clrscr();
 randomize();
 for (int i=0;i<20;i++) a[i]=random(100);
 for (i=0;i<20;i++) cout<<setw(3)<<a[i];
 cout<<"\nn=";
 cin>>n;
 cout<<max(n-1,a);
 getch();
}
// Tim so lon nhat trong n phan tu dau tien cua mang
int max(int n,int a[])
{
 int t;

 if (n==0) return a[0];
 t=max(n-1,a);
 return t>a[n]?t:a[n];
}