#include <iostream.h>
#include <conio.h>
main()
{
 clrscr();
 int a;
 cout<<"Mua ve hang nao? ";
 cin>>a;
 cout<<"Hang "<<a<<": ";
 switch (a)
 {
  case 1:cout<<"7000d";break;
  case 2:cout<<"5000d";break;
  case 3:cout<<"4000d";break;
  default:cout<<"Khong co hang nay!";
 }
 return 0;
}