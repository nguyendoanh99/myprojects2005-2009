#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 for (int i=1;i<=10;i++)
 {
  for (int j=1;j<=i;j++) cout<<"*";
  cout<<endl;
 }
 getch();
}