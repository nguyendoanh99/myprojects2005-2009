// Phan tich 1 so ra thua so nguyen to.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int n;
 cout<<"n=";
 cin>>n;
 cout<<n<<"=";
 int a=n;
 for (int i=2;a!=1;i++)
  if (a%i==0)
  {
   int t=1;
   a=a/i;
   for (;a%i==0;)
   {
    t++;
    a=a/i;
   }
   if (a!=1) cout<<i<<"^"<<t<<"*";
   else cout<<i<<"^"<<t;
  }
 getch();
}