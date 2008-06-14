// Xac dinh tap thao tac tren danh sach moc noi kep
// - Tao lap danh sach moc noi kep
// - Them 1 phan tu vao dau DS
// - Them 1 phan tu vao cuoi DS
// - Them 1 phan tu vao giua DS
// - Loai bo phan tu o dau DS
// - Loai bo phan tu o cuoi DS
// - Duyet DS
// - Sap xep theo cac phan tu DS theo 1 khoa nao do
// - Tim kiem theo cac phan tu cua DS theo 1 khoa nao do

#include <iostream.h>
#include <conio.h>
#include <stdlib.h>

struct DS
	{
	 int so;
	 DS *p[2];
	};

void Tao(DS *&,DS *&);
void ThemTruoc(DS *&,DS *&,DS *,int);
void ThemSau(DS *&,DS *&,DS *,int);
void Xoa(DS *&,DS *&,DS *&);
void Duyet(DS *,DS *);
void Hoanvi(DS *&,DS *&,DS *,DS *);

void main()
{
 DS *DDS=0,*CDS=0;

 randomize();
 clrscr();
 Tao(DDS,CDS);
 getch();
}
// Tao DS moc noi kep
void Tao(DS *&DDS,DS *&CDS)
{
 int a;
 DS *ht,*ht2;

 for (int i=0;i<5;i++)
 {
  a=random(100);
  cout<<a<<" ";
  ThemTruoc(DDS,CDS,DDS,a);
 }
 cout<<endl;
 Duyet(DDS,CDS);
 ht=DDS;
 ht=ht->p[1]->p[1];
 cout<<"\nht="<<ht->so;
 a=random(100);
 cout<<"\nChen vao truoc ht. a="<<a<<endl;
 ThemTruoc(DDS,CDS,ht,a);
 Duyet(DDS,CDS);
 cout<<"\nht="<<ht->so;
 a=random(100);
 cout<<"\nChen vao sau ht. a="<<a<<endl;
 ThemSau(DDS,CDS,ht,a);
 Duyet(DDS,CDS);
 ht=DDS->p[1];
 ht2=ht->p[1];
 cout<<"\nHoan vi giua "<<ht->so<<" va "<<ht2->so<<"\n";
 Hoanvi(DDS,CDS,ht,ht2);
 Duyet(DDS,CDS);
// ht=DDS;
// for (i=0;i<7;i++) Xoa(DDS,CDS,ht);
// Duyet(DDS,CDS);
}
// Them 1 phan tu vao truoc ht
void ThemTruoc(DS *&DDS,DS *&CDS,DS *ht,int so)
{
 DS *tam=new DS;

 tam->so=so;
 if (!DDS)
 {
  tam->p[0]=0;
  tam->p[1]=0;
  DDS=CDS=tam;
 }
 else
  if (ht==DDS)
  {
   tam->p[0]=0;
   tam->p[1]=DDS;
   DDS->p[0]=tam;
   DDS=tam;
  }
  else
   if (ht)
   {
    tam->p[0]=ht->p[0];
    tam->p[1]=ht;
    ht->p[0]->p[1]=tam;
    ht->p[0]=tam;
   }
}
// Them 1 phan tu vao sau ht
void ThemSau(DS *&DDS,DS *&CDS,DS *ht,int so)
{
 DS *tam=new DS;

 tam->so=so;
 if (!CDS)
 {
  tam->p[0]=0;
  tam->p[1]=0;
  DDS=CDS=tam;
 }
 else
  if (ht==CDS)
  {
   tam->p[1]=0;
   tam->p[0]=CDS;
   CDS->p[1]=tam;
   CDS=tam;
  }
  else
   if (ht)
   {
    tam->p[1]=ht->p[1];
    tam->p[0]=ht;
    ht->p[1]->p[0]=tam;
    ht->p[1]=tam;
   }
}
// Xoa phan tu hien tai ra khoi DS
void Xoa(DS *&DDS,DS *&CDS,DS *&ht)
{
 if (ht && DDS && CDS)
 {
  DS *tam=ht;

  if (ht==DDS)
  {
   DDS=DDS->p[1];
   DDS->p[0]=0;
  }
  if (ht==CDS)
  {
   CDS=CDS->p[0];
   CDS->p[1]=0;
  }
  if (DDS!=ht && CDS!=ht)
  {
   ht->p[0]->p[1]=ht->p[1];
   ht->p[1]->p[0]=ht->p[0];
  }
  if (ht->p[1]) ht=ht->p[1];
  else ht=ht->p[0];
  delete tam;
 }
}
// Duyet DS
void Duyet(DS *DDS,DS *CDS)
{
 cout<<"Duyet tu dau danh sach\n";
 while (DDS)
 {
  cout<<DDS->so<<" ";
  DDS=DDS->p[1];
 }
 cout<<"\nDuyet tu cuoi danh sach\n";
 while (CDS)
 {
  cout<<CDS->so<<" ";
  CDS=CDS->p[0];
 }
 cout<<endl;
}
// Hoan vi giua ht1 va ht2
void Hoanvi(DS *&DDS,DS *&CDS,DS *ht1,DS *ht2)
{
 DS *p1[2]={ht1->p[0],ht1->p[1]},*p2[2]={ht2->p[0],ht2->p[1]},*t=DDS;

 p1[0]->p[1]=ht2;
 p1[1]->p[0]=ht2;
 p2[1]->p[0]=ht1;
 p2[0]->p[1]=ht1;
 if (ht1!=p2[0]) ht1->p[0]=p2[0];
 else ht1->p[0]=ht2;
 if (ht1!=p2[1]) ht1->p[1]=p2[1];
 else ht1->p[1]=ht2;
 if (ht2!=p1[0]) ht2->p[0]=p1[0];
 else ht2->p[0]=ht1;
 if (ht2!=p1[1]) ht2->p[1]=p1[1];
 else ht2->p[1]=ht1;
 if (ht2==DDS) DDS=ht1;
 else
  if (ht2==CDS) CDS=ht1;
 if (ht1==t) DDS=ht2;
 else
  if (ht1==CDS) CDS=ht2;
}