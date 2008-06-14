// Viet ham de qui cho ra 1 chuoi co chua dang bieu dien thap luc phan cua 1
// so nguyen duong.

#include <iostream.h>
#include <conio.h>
#include <string.h>

char tl[16]="0123456789ABCDEF";

char *thapluc(int);

void main()
{
 int a;

 clrscr();
 cout<<"Nhap 1 so nguyen duong : ";
 cin>>a;
 cout<<thapluc(a);
 getch();
}

char *thapluc(int a)
{
 char s[1];

 s[0]=tl[a%16];
 s[1]='\0';
 if (a/16!=0) return strcat(thapluc(a/16),s);

 char *t=new char;

 strcpy(t,s);
 return t;
}