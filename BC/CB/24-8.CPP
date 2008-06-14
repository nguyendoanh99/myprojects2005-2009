// Viet chuong trinh ve 1 tam giac dac va 1 tam giac rong bang ki tu *.
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 for (int i=1;i<=10;i++)
 {
  cout<<setw(41-i);
  for (int j=1;j<=i*2-1;j++) cout<<"*";
  cout<<endl;
 }
 getch();
 clrscr();
 for (i=1;i<=10;i++)
 {
  cout<<setw(41-i);
  for (int j=1;j<=i*2-1;j++)
   if (i<10)
    if (j==1 || j==i*2-1) cout<<"*";
    else cout<<" ";
   else cout<<"*";
  cout<<endl;
 }
 getch();
}