// Viet chuong trinh tim UCLN, BCNN cua 2 so nhap tu ban phim.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int a,b,c,a1,b1;
 cout<<"Tim UCLN, BCNN cua 2 so\n";
 cout<<"Nhap vao 2 so a, b = ";
 cin>>a>>b;
 a1=a;b1=b;
 while (a1%b1!=0)
 {
  c=b1;
  b1=a1%b1;
  a1=c;
 }
 cout<<"UCLN cua "<<a<<" va "<<b<<" la "<<b1<<endl;
 cout<<"BCNN cua "<<a<<" va "<<b<<" la "<<a*b/b1;
 getch();
}