// Viet ham de qui tinh tong cua n luy thua dau tien cua co so b

#include <iostream.h>
#include <conio.h>
#include <math.h>

int TongLT(int,int);

void main()
{
 int n,b;

 clrscr();
 cout<<"n,b=";
 cin>>n>>b;
 cout<<TongLT(n,b);
 getch();
}

int TongLT(int n,int b)
{
 if (n>0) return pow(b,n)+TongLT(n-1,b);
 else return 1;
}