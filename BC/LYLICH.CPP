#include <iostream.h>
#include <conio.h>
#include <string.h>

struct ll
	{
	 char ten[41];
	 short tuoi;
	 char DC[81];
	};
struct ct
	{
	 ll nguoi;
	 ct *tiep;
	};
ct *dt;
//Khai bao cac CT con
void Khoitao(ct *&);
void Them(ct *&,ct *&,ll);
void Thembk(ct *&,ct *&,ll);
void Nhap(ct *&);
void Nhapbk(ct *&);
void Xuat(ct *);
// Chuong trinh chinh
void main()
{
 clrscr();
 Khoitao(dt);
 Nhap(dt);
 Xuat(dt);
 Nhapbk(dt);
 Xuat(dt);
 getch();
}

void Khoitao(ct *&dt)
{
 dt=0;
}
// Them 1 phan tu vao danh sach lien ket
void Them(ct *&dt,ct *&ht,ll lylich)
{
 ct *tam=new ct;

 strcpy(tam->nguoi.ten,lylich.ten);
 tam->nguoi.tuoi=lylich.tuoi;
 strcpy(tam->nguoi.DC,lylich.DC);
 tam->tiep=0;
 if (!dt) dt=tam;
 else ht->tiep=tam;
 ht=tam;
}
// Them 1 phan tu vao vi tri bat ky cua danh sach lien ket
void Thembk(ct *&dt,ct *&ht,ll lylich)
{
 ct *tam=new ct;

 strcpy(tam->nguoi.ten,lylich.ten);
 tam->nguoi.tuoi=lylich.tuoi;
 strcpy(tam->nguoi.DC,lylich.DC);
 if (ht==dt)
 {
  tam->tiep=dt;
  dt=tam;
 }
 else
 {
  tam->tiep=ht;
  ht=dt;
  while (ht->tiep!=tam->tiep) ht=ht->tiep;
  ht->tiep=tam;
 }
}

void Nhap(ct *&dt)
{
 ll tam;
 char c;
 ct *ht;

 do
 {
  cout<<"Ten : ";
  cin.getline(tam.ten,41);
  cout<<"Tuoi : ";
  cin>>tam.tuoi;
  cin.ignore(41,'\n');
  cout<<"Dia chi : ";
  cin.getline(tam.DC,81);
  Them(dt,ht,tam);
  cout<<"Ban co muon lam tiep khong (c/k) ? ";
  c=getche();
  cout<<endl;
 }
 while (c!='k');
 cout<<endl;
}

void Nhapbk(ct *&dt)
{
 ll tam;
 int v;
 ct *ht;

 cout<<"Ten : ";
 cin.getline(tam.ten,41);
 cout<<"Tuoi : ";
 cin>>tam.tuoi;
 cin.ignore(41,'\n');
 cout<<"Dia chi : ";
 cin.getline(tam.DC,81);
 cout<<"Vi tri muon chen : ";
 cin>>v;
 ht=dt;
 for (int i=1;i<v;i++) ht=ht->tiep;
 Thembk(dt,ht,tam);
 cout<<endl;
}

void Xuat(ct *dt)
{
 ct *ht=dt;

 while (ht)
 {
  cout<<"Ten : "<<ht->nguoi.ten<<endl;
  cout<<"Tuoi : "<<ht->nguoi.tuoi<<endl;
  cout<<"Dia chi : "<<ht->nguoi.DC<<"\n\n";
  ht=ht->tiep;
 }
}