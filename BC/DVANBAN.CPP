// Viet chuong trinh nhap 1 dong van ban sau do chay ngay qua man hinh.
#include <iostream.h>
#include <conio.h>
#include <dos.h>
#include <string.h>
void main()
{
 clrscr();
 char c[10];
 cout<<"Nhap vao 1 chuoi:";
 cin>>c;
 cout<<strlen(c);
 gotoxy(1,12);
 for (int i=1;i<80;i++)
 {
  delay(100);
  gotoxy(1,12);
  delline();
  gotoxy(i,12);
  if (strlen(c)+i>79)
  {
   for (int j=0;j<=79-i;j++) cout<<c[j];
   gotoxy(1,12);
   for (j=80-i;j<=strlen(c);j++) cout<<c[j];
  }
  else cout<<c;
 }
 getch();
}