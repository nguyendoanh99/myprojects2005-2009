#include <stdio.h>
#include <conio.h>
void nhap(float [],int &);
int tansuat(float [],int,int);
void lietke(float [],int);
void main()
{
 float a[100];
 int n;
 nhap(a,n);
 lietke(a,n);
 getch();
}
void nhap(float a[],int &n)
{
 printf("Nhap n=");
 scanf("%d",&n);
 for (int i=0;i<n;i++)
 {
  printf("Nhap a[%d]: ",i);
  scanf("%f",&a[i]);
 }
}
int tansuat(float a[],int n,int x)
{
 int dem=0;
 for (int i=0;i<n;i++)
 if (x==a[i])
  dem++;
  return dem;
}
void lietke(float a[],int n)
{
 float b[100];
 int n1=0;
 for (int i=0;i<n;i++)
 {
  for (int j=0;b[j]!=a[i] && j<n1;j++);
  if (j==n1)
  {
   b[n1]=a[i];
   n1++;
   printf("\nTan suat xuat hien cua gia tri %8.3f la: %d",a[i],tansuat(a,n,a[i]));
  }
 }
}