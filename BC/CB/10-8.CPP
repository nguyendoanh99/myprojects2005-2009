#include <iostream.h>
#include <conio.h>
#include <ctype.h>
#include <string.h>
void main()
{
 clrscr();
 char s[80],s1[80],s2[80];
 int max,min;
 cout<<"Nhap vao 10 chuoi\n";
 cout<<"Chuoi 1 : ";
 cin>>s;
 max=min=strlen(s);
 *s1=*s2=*s;
 for (int i=2;i<=10;i++)
 {
  cout<<"Chuoi "<<i<<" : ";
  cin>>s;
  if (max<strlen(s))
  {
   max=strlen(s);
   *s1=*s;
  }
  else
   if (min>strlen(s))
   {
    min=strlen(s);
    *s2=*s;
   }
 }
 cout<<"Chuoi dai nhat la "<<s1<<"\nChuoi ngan nhat la "<<s2;
 getch();
}
