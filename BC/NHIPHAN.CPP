// Viet ham de qui cho ra 1 chuoi co chua dang bieu dien nhi phan cua 1 so
// nguyen duong.

#include <iostream.h>
#include <conio.h>
#include <string.h>

char np[2]="01";

char *nhiphan(int);

void main()
{
 int n;

 clrscr();
 cout<<"Nhap vao 1 so nguyen duong : ";
 cin>>n;
 cout<<nhiphan(n);
 getch();
}

char *nhiphan(int a)
{
 char s[1];

 s[0]=np[a%2];
 s[1]='\0';
 if (a/2!=0) return strcat(nhiphan(a/2),s);

 char *t=new char;

 strcpy(t,s);
 return t;
}