//Tim uoc so chung lon nhat cua hai so.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int a,b,c;
 cout<<"a,b = ";
 cin>>a>>b;
 cout<<"Uoc so chung lon nhat cua hai so "<<a<<" va "<<b<<" la ";
 for (;a%b!=0;)
 {
  c=b;
  b=a%b;
  a=c;
 }
 cout<<b;
 getch();
}