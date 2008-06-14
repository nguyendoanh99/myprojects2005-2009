// Viet 1 ham boole de qui xac dinh xem 1 chuoi co phai la 1 tu doc xuoi doc
// nguoc deu giong nhau hay khong. (1 tu doc xuoi doc nguoc deu giong nhau la
// 1 chuoi gom cac ky tu giong nhu chuoi co duoc tu no bang cach dao nguoc cac
// mau tu cua no.)

#include <conio.h>
#include <iostream.h>
#include <string.h>
#include <math.h>

int boole(char *,int);

void main()
{
 char *s;
 clrscr();
 cout<<"s=";
 cin.getline(s,255);
 cout<<boole(s,0);
 getch();
}

int boole(char *s,int n)
{
 if (n==floor(strlen(s)/2.0)) return s[n]==s[strlen(s)-n-1];
 if (s[n]==s[strlen(s)-n-1]) return boole(s,n+1);
 else return 0;
}