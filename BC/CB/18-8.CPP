//Tinh tong binh phuong cua 100 so tu 1 den 100.
#include <iostream.h>
#include <conio.h>
#include <math.h>
void main()
{
 clrscr();
 cout<<"Tong binh phuong cua 100 so tu 1 den 100 = ";
 for (int i=1,t=0;i<=100;i++) t+=pow(i,2);
 cout<<t;
 getch();
}