#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 for (int t=0,i=101;i<=100+101;i++) t+=i;
 cout<<t<<endl;
 t=0;
 for (i=1;i<=100;i++) t+=i*2+200;
 cout<<t<<"\n";
 getch();
}