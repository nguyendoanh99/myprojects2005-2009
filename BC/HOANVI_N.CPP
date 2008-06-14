// Viet 1 ham de qui in tat ca tu hoan vi cua n ky tu dau tien tong 1 chuoi.
// Vi du, lenh goi print("ABC",3) se in
// ABC, ACB, BAC, BCA, CBA, CAB

#include <conio.h>
#include <iostream.h>
#include <string.h>

char A[10];
int B[10];

void Hv(char *,int,int,int);

void main()
{
 char *s;
 int n;

 clrscr();
 cout<<"s=";
 cin>>s;
 cout<<"n=";
 cin>>n;
 Hv(s,n,0,0);
 getch();
}

void Hv(char *s,int n,int t,int d)
{
 if (t==n)
 {
  A[n]='\0';
  cout<<A<<endl;
 }
 else
 {
  for (int i=0;i<n;i++)
   if (!B[i])
   {
    A[d++]=s[i];
    B[i]=1;
    Hv(s,n,t+1,d);
    B[i]=0;
    A[d--]='\0';
   }
 }
}