// Viet chuong trinh nhap vao cac so tuy y, khi nhap vao so 0 thi dung lai cho
// in ra man hinh cac ket qua sau: Tong cua cac so do, tong so cac so>0, tong
// cac so<0.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int a,tc=0,td=0,ta=0;
 do
 {
  cout<<"Nhap vao 1 so khac 0 : ";
  cin>>a;
  tc+=a;
  if (a>0) td+=a;
  else
   if (a<0) ta+=a;
 }
 while (a!=0);
 cout<<"Tong cac so vua nhap la "<<tc<<endl;
 cout<<"Tong cac so>0 la "<<td<<endl;
 cout<<"Tong cac so<0 la "<<ta<<endl;
 getch();
}