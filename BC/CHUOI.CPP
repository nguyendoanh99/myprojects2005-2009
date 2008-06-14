// Nhap 1 chuoi. Xac dinh ky tu xuat hien nhieu nhat.

#include <iostream.h>
#include <conio.h>
#include <ctype.h>
#include <string.h>

void main()
{
 clrscr();
 int a[24];
 char c[50];
 for (int i=0;i<24;i++) a[i]=0;
 cout<<"Nhap vao 1 chuoi : ";
 cin.getline(c,51);
 for (i=0;i<strlen(c);i++) a[toupper(c[i])-65]++;
 int max=a[0];
 int v=0;
 for (i=1;i<24;i++)
 if (max<a[i])
 {
  max=a[i];
  v=i;
 }
 cout<<"Ky tu xuat hien nhieu nhat la "<<char(v+65);
 getch();
}