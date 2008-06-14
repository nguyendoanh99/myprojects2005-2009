#include <iostream.h>
#include <conio.h>
main()
{
 clrscr();
 int a;
 cout<<"Nhap vao 1 so: ";
 cin>>a;
 switch (a)
 {
  case 1:cout<<"MOT";break;
  case 2:cout<<"HAI";break;
  case 3:cout<<"BA";break;
  case 4:cout<<"BON";break;
  case 5:cout<<"NAM";break;
  case 6:cout<<"SAU";break;
  case 7:cout<<"BAY";break;
  case 8:cout<<"TAM";break;
  case 9:cout<<"CHIN";break;
  case 10:cout<<"MUOI";break;
  default:cout<<"Thua thay, em chua hoc.";
 }
 return 0;
}