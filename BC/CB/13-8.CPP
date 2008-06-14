// Viet chuong trinh in ra bang cuu chuong, bang cuu chuong may se duoc in ra
// khi thi hanh.
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 int a;
 cout<<"Ban muon xem bang cuu chuong may ? ";
 cin>>a;
 for (int i=1;i<=10;i++)
  cout<<setw(5)<<a<<setw(5)<<"*"<<setw(5)<<i<<setw(5)<<"="<<setw(5)<<a*i<<endl;
 getch();
}