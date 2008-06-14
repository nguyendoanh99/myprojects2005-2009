//The hien phep nhan bang tay.
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>

unsigned long a,b;
void Try(unsigned long,int);
int dem(unsigned long);
const int c=50;

void main()
{
 clrscr();
 cout<<"a=";
 cin>>a;
 cout<<"b=";
 cin>>b;
 clrscr();
 cout<<setw(c)<<a<<endl;
 if (a>b) cout<<setw(c-dem(a))<<"x"<<setw(dem(a))<<b<<endl;
 else cout<<setw(c-dem(b))<<"x"<<b<<endl;
 unsigned long m=a>b?a:b;
 int n=dem(m);
 cout<<setw(c-n+1);
 for (int i=1;i<=n;i++) cout<<"-";
 cout<<endl;
 Try(b,0);
 cout<<setw(c-dem(a*b)+1);
 for (i=1;i<=dem(a*b);i++) cout<<"-";
 cout<<"\n"<<setw(c)<<a*b;
 getch();
}

void Try(unsigned long i,int j)
{
 cout<<setw(c-j)<<a*(i%10)<<endl;
 if (i/10!=0) Try(i/10,j+1);
}

int dem(unsigned long a)
{
 if (a/10!=0) return dem(a/10)+1;
 else return 1;
}