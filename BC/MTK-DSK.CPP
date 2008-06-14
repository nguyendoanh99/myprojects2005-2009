// Cho truoc ma tran ke cua do thi. Hay viet chuong trinh tao ra danh sach ke
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
const char *tf="C:\\MATRANKE.INP";
const char *tg="C:\\DANHSACH.OUT";
typedef int MTK[10][10];
typedef ct *DSK[10];

void Input(int &,MTK);
void XuatMT(int,MTK);
void Them(ct *&,ct *&,int);
void MTK_DSK(int,MTK,DSK);
void XuatDS(int,DSK);

void main()
{
 int n;
 MTK A;
 DSK B;

 clrscr();
 Input(n,A);
 cout<<"Ma tran ke cua do thi\n";
 XuatMT(n,A);
 MTK_DSK(n,A,B);
 cout<<"Danh sach ke cua do thi\n";
 XuatDS(n,B);
 getch();
}
// Doc du lieu tu tap tin
void Input(int &n,MTK A)
{
 FILE *f;
 char *s;

 f=fopen(tf,"rt");
 fscanf(f,"%d",&n);
 fgets(s,255,f);
 for (int i=0;i<n;i++)
 {
  for (int j=0;j<n;j++) fscanf(f,"%d",&A[i][j]);
  fgets(s,255,f);
 }
 fclose(f);
}
// Xuat ma tran ke
void XuatMT(int n,MTK A)
{
 for (int i=0;i<n;i++)
 {
  for (int j=0;j<n;j++) cout<<setw(5)<<A[i][j];
  cout<<endl;
 }
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
void MTK_DSK(int n,MTK A,DSK B)
{
 ct *ht;

 for (int i=0;i<n;i++)
 {
  ht=0;
  B[i]=0;
  for (int j=0;j<n;j++)
   if (A[i][j]==1) Them(B[i],ht,j+1);
 }
}
// Xuat danh sach ke
void XuatDS(int n,DSK B)
{
 ct *ht;
 FILE *g;

 g=fopen(tg,"wt");
 fprintf(g,"%d\n",n);
 for (int i=0;i<n;i++)
 {
  ht=B[i];
  while (ht)
  {
   fprintf(g,"%d ",ht->so);
   cout<<setw(5)<<ht->so;
   ht=ht->tiep;
  }
  fprintf(g,"0\n");
  cout<<endl;
 }
 fclose(g);
}