// Cho tam giac so duoc bieu dien nhu hinh duoi. Hay viet chuong trinh tim
// day cac so co tong lon nhat tren con duong tu dinh va ket thuc tai dau do
// o day. Biet rang, moi buoc di co the di cheo xuong phia trai hoac cheo
// xuong phia phai. So luong hang trong tam giac la lon hon 1 nhung nho hon
// 100; cac so trong tam giac deu la cac so tu 0..99.
//				7
//			  3           8
//		     8          1           0
//	       2          7           4         4
//	  4          5          2           6       5
//
// Du lieu vao boi file cay.in, dong dau tien ghi lai so tu nhien n la so
// hang trong tam giac, n hang tiep theo ghi lai tung hang moi phan tu duoc
// phan biet voi nhau boi 1 hoac vai dau trong. Ket qua ghi lai trong file
// cay.out dong dau tien ghi lai tong so lon nhat tim duoc, dong ke tiep ghi
// lai day cac so co tong lon nhat. Vi du voi hinh tren file input va output
// nhu sau:
// cay.in
// 5
// 7
// 3 8
// 8 1 0
// 2 7 4 4
// 4 5 2 6 5

// cay.out
// 30
// 7 3 8 7 5

#include <iostream.h>
#include <conio.h>
#include <stdio.h>

const char *tf="C:\\CAY.IN";
const char *tg="C:\\CAY.OUT";

struct CayNP
	{
	 int so;
	 CayNP *p[2]; //0:trai  1:phai
	};
struct Hangdoi
	{
	 CayNP *l;
	 Hangdoi *tiep;
	};

void Doc(FILE *,CayNP *&);
void Input(CayNP *&,int &);
void Them(CayNP *&,CayNP *,int);
Hangdoi *ThemHd(Hangdoi *&,Hangdoi *,CayNP *);
void Xoa(Hangdoi *&);
void Tim(CayNP *,int,int &,int,int [],int []);
void Output(int,int,int []);

void main()
{
 CayNP *caynp=0;
 int n,a[10],b[10],m=0;

 clrscr();
 Input(caynp,n);
 Tim(caynp,0,m,0,b,a);
 for (int i=0;i<n;i++) cout<<a[i]<<" ";
 Output(n,m,a);
 getch();
}
// Doc du lieu tu tap tin
void Input(CayNP *&node,int &n)
{
 FILE *f;
 char *a;
 int m;
 CayNP *tam;
 Hangdoi *dt=0,*ht;

 f=fopen(tf,"rt");
 fscanf(f,"%d",&n);
 fgets(a,255,f);
 Doc(f,tam);
 Them(node,tam,0);
 ht=ThemHd(dt,ht,tam);
 for (int i=2;i<=n;i++)
 {
  Doc(f,tam);
  Them(dt->l,tam,0);
  ht=ThemHd(dt,ht,tam);
  for (int j=3;j<=i;j++)
  {
   Doc(f,tam);
   Them(dt->l,tam,1);
   ht=ThemHd(dt,ht,tam);
   Xoa(dt);
   Them(dt->l,tam,0);
  }
  Doc(f,tam);
  Them(dt->l,tam,1);
  ht=ThemHd(dt,ht,tam);
  Xoa(dt);
  fgets(a,255,f);
 }
 for (i=1;i<=n;i++) Xoa(dt);
 fclose(f);
}
// Them phan tu tam vao 1 nhanh chi dinh cua cay nhi phan co goc la node
// p=0 nhanh trai
// p=1 nhanh phai
void Them(CayNP *&node,CayNP *tam,int p)
{
 if (node) node->p[p]=tam;
 else node=tam;
}
// Them vao hang doi 1 phan tu
Hangdoi *ThemHd(Hangdoi *&dt,Hangdoi *ht,CayNP *node)
{
 Hangdoi *tam=new Hangdoi;

 tam->l=node;
 tam->tiep=0;
 if (!dt)
 {
  dt=tam;
  ht=dt;
 }
 else
 {
  ht->tiep=tam;
  ht=ht->tiep;
 }
 return ht;
}
// Xoa phan tu dau tien cua hang doi
void Xoa(Hangdoi *&dt)
{
 Hangdoi *t=dt;

 dt=dt->tiep;
 delete t;
}
// Doc 1 so tu file roi dua vao tam
void Doc(FILE *f,CayNP *&tam)
{
 int m;

 fscanf(f,"%d",&m);
 tam=new CayNP;
 tam->so=m;
 tam->p[0]=0;
 tam->p[1]=0;
}
// De qui de tim ket qua lon nhat
void Tim(CayNP *node,int c,int &m,int d,int b[],int a[])
{
 if (node)
 {
  b[d]=node->so;
  for (int i=0;i<2;i++) Tim(node->p[i],c+node->so,m,d+1,b,a);
 }
 else
  if (c>m)
  {
   m=c;
   for (int i=0;i<=d;i++) a[i]=b[i];
  }
}
// Viet ket qua tim duoc vao file
void Output(int n,int m,int a[])
{
 FILE *g;

 g=fopen(tg,"wt");
 fprintf(g,"%d\n",m);
 for (int i=0;i<n;i++) fprintf(g,"%d ",a[i]);
 fclose(g);
}