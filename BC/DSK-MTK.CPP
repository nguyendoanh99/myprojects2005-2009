// Cho truoc danh sach ke cua do thi. Hay viet chuong trinh tao ra ma tran ke
// cua do thi do.

#include <iostream.h>
#include <conio.h>
#include <stdio.h>
#include <iomanip.h>

struct ct
	{
	 int so;
	 ct *tiep;
	};
const char *tf="C:\\DANHSACH.OUT";
const char *tg="C:\\MATRANKE.INP";
typedef int MTK[10][10];
typedef ct *DSK[10];

void Input(int &,DSK);
void XuatMT(int,MTK);
void Them(ct *&,ct *&,int);
void DSK_MTK(int,DSK,MTK);
void XuatDS(int,DSK);

void main()
{
 int n;
 MTK B;
 DSK A;

 clrscr();
 Input(n,A);
 cout<<"Danh sach ke cua do thi\n";
 XuatDS(n,A);
 DSK_MTK(n,A,B);
 cout<<"Ma tran ke cua do thi\n";
 XuatMT(n,B);


 getch();
}
// Doc du lieu tu tap tin
void Input(int &n,DSK A)
{
 FILE *f;
 char *s;
 int t;
 ct *ht;

 f=fopen(tf,"rt");
 fscanf(f,"%d",&n);
 fgets(s,255,f);
 for (int i=0;i<n;i++)
 {
  fscanf(f,"%d",&t);
  A[i]=0;
  while (t)
  {
   Them(A[i],ht,t);
   fscanf(f,"%d",&t);
  }
  fgets(s,255,f);
 }
 fclose(f);
}
// Xuat ma tran ke
void XuatMT(int n,MTK B)
{
 FILE *g;

 g=fopen(tg,"wt");
 fprintf(g,"%d\n",n);
 for (int i=0;i<n;i++)
 {
  for (int j=0;j<n;j++)
  {
   fprintf(g,"%d ",B[i][j]);
   cout<<setw(5)<<B[i][j];
  }
  fprintf(g,"\n");
  cout<<endl;
 }
 fclose(g);
}
// Them 1 phan tu vao danh sach lien ket
void Them(ct *&dt,ct *&ht,int m)
{
 ct *tam=new ct;

 tam->so=m;
 tam->tiep=0;
 if (!dt) dt=tam;
 else ht->tiep=tam;
 ht=tam;
}
// Chuyen tu ma tran ke thanh danh sach ke
void DSK_MTK(int n,DSK A,MTK B)
{
 ct *ht;

 for (int i=0;i<n;i++)
  for (int j=0;j<n;j++) B[i][j]=0;
 for (i=0;i<n;i++)
 {
  ht=A[i];
  while (ht)
  {
   B[i][ht->so-1]=1;
   ht=ht->tiep;
  }
 }
}
// Xuat danh sach ke
void XuatDS(int n,DSK A)
{
 ct *ht;

 for (int i=0;i<n;i++)
 {
  ht=A[i];
  while (ht)
  {
   cout<<setw(5)<<ht->so;
   ht=ht->tiep;
  }
  cout<<endl;
 }
}