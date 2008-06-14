// Viet 1 ham de qui in ra chuoi du lieu nhap theo thu tu dao nguoc.

#include <conio.h>
#include <iostream.h>
#include <string.h>

void Dao(char *,int);

void main()
{
 char *s;

 clrscr();
 cout<<"s=";
 cin>>s;
 Dao(s,strlen(s)-1);
 getch();
}

void Dao(char *s,int n)
{
 if (n>=0)
 {
  cout<<s[n];
  Dao(s,n-1);
 }
}