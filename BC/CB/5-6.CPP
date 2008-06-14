#include <iostream.h>
#include <conio.h>
main()
{
 clrscr();
 char tl;
 int tong,sl1,sl2,sl3;
 sl1=0;
 sl2=0;
 sl3=0;
 tong=0;
 cout<<"Ban co muon mua ve hang 1 khong?(y/n)";
 cin>>tl;
 if ((tl=='y') || (tl=='Y'))
 {
  cout<<"So luong ve= ";
  cin>>sl1;
 }
 tong=sl1*5000;
 cout<<"Ban co muon mua ve hang 2 khong?(y/n)";
 cin>>tl;
 if ((tl=='y') || (tl=='Y'))
 {
  cout<<"So luong ve= ";
  cin>>sl2;
 }
 tong=tong+sl2*4000;
 cout<<"Ban co muon mua ve hang 3 khong?(y/n)";
 cin>>tl;
 if ((tl=='y') || (tl=='Y'))
 {
  cout<<"So luong ve= ";
  cin>>sl3;
 }
 tong=tong+sl3*3000;
 cout<<"Tong tien= "<<tong<<"d";
 return 0;
}