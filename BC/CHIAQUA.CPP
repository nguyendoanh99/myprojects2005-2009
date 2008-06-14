#include <iostream.h>
#include <conio.h>
#include <stdio.h>

const char *tf="C:\\CHIAQUA.INP";
int n,a[20],t[3]={0,0,0},d[2][3],max,min,b[3][5],c[3][5];

void Input(int&,int []);
void Try(int);
// Chuong trinh chinh
void main()
{
 clrscr();
 for (int i=0;i<2;i++)
  for (int j=0;j<3;j++) d[i][j]=0;
 min=-32000;
 max=0;
 Input(n,a);
 Try(0);
 cout<<max-min<<"\n";
 for (i=0;i<3;i++)
 {
  for (int j=0;j<d[1][i];j++) cout<<c[i][j]<<" ";
  cout<<endl;
 }
 getch();
}
// Doc du lieu tu tap tin
void Input(int &n,int a[])
{
 FILE *f;
 char *s;

 f=fopen(tf,"rt");
 fscanf(f,"%d",&n);
 fgets(s,255,f);
 for (int i=0;i<n;i++) fscanf(f,"%d",&a[i]);
 fclose(f);
}
// De qui de tim ket qua
void Try(int j)
{
 int max1,min1,i;

 if (j==n)
 {
  min1=t[0];
  max1=t[0];
  for (i=1;i<3;i++)
  {
   if (max1<t[i]) max1=t[i];
   else
    if (min1>t[i]) min1=t[i];
  }
  if (max1-min1<max-min)
  {
   for (i=0;i<3;i++)
   {
    d[1][i]=d[0][i];
    for (int j=0;j<d[1][i];j++)
    {
     c[i][j]=b[i][j];
    }
   }
   max=max1;
   min=min1;
  }
 }
 else
  for (i=0;i<3;i++)
  {
   t[i]+=a[j];
   b[i][d[0][i]++]=j;
   Try(j+1);
   b[i][d[0][i]--]=0;
   t[i]-=a[j];
  }
}