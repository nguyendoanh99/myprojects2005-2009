// In ra cac so nguyen to< n.
#include <iostream.h>
#include <conio.h>
#include <math.h>
int nt(int a)
{
 if (a==1) return 0;
 else
 {
  for (int i=2;i<=sqrt(a);i++)
   if (a%i==0)
   {
    return 0;
    break;
   }
  return 1;
 }
}
void main()
{
 clrscr();
 int n;
 cout<<"n=";
 cin>>n;
 for (int i=1;i<=n;i++)
  if (nt(i)!=0) cout<<"\t"<<i;
 getch();
}