//Tim boi so chung nho nhat cua hai so.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int a,b;
 cout<<"a,b = ";
 cin>>a>>b;
 cout<<"Boi so chung nho nhat cua hai so "<<a<<" va "<<b<<" la ";
 for (int a1=a,b1=b,c;a1%b1!=0;)
 {
  c=b1;
  b1=a1%b1;
  a1=c;
 }
 cout<<a*b/b1;
 getch();
}