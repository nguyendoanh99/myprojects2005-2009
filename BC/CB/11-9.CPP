// In ra man hinh tong cua tat ca cac uoc so cua 1 so cho truoc.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int a;
 cout<<"Nhap vao 1 so = ";
 cin>>a;
 int i=1,t=0;
 while (i<=a)
 {
  if (a%i==0) t+=i;
  i++;
 }
 cout<<"Tong cua tat ca cac uoc cua so "<<a<<" la "<<t;
 getch();
}