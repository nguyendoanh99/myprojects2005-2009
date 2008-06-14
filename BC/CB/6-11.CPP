// Viet chuong trinh nhap vao mang 2 chieu 4-4 va in ra thanh bang vuong.
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 int a[4][4];
 for (int i=0;i<4;i++)
  for (int j=0;j<4;j++)
  {
   cout<<"A["<<i<<","<<j<<"] = ";
   cin>>a[i][j];
  }
 for (i=0;i<4;i++)
 {
  for (int j=0;j<4;j++) cout<<setw(5)<<a[i][j];
  cout<<endl;
 }
 getch();
}