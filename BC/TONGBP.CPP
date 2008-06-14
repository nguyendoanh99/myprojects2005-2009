// Tinh 1^2+2^2+3^2+...+n^2.
#include <iostream.h>
#include <conio.h>
#include <math.h>
void main()
{
 clrscr();
 int n;
 cout<<"n=";
 cin>>n;
 int t=0;
 for (int i=1;i<=n;i++) t+=pow(i,2);
 cout<<t;
 getch();
}