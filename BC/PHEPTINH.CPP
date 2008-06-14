// Viet chuong trinh cong, tru, nhan, chia 2 so nguyen lon (Dung danh sach
// lien ket).

#include <iostream.h>
#include <conio.h>
#include <string.h>
#include <ctype.h>

struct ct
	{
	 unsigned char so;
	 ct *tiep;
	};

void Chentruoc(ct *&,unsigned char);
void Chensau(ct *&,unsigned char);
void Nhap(ct *&);
void Xuat(ct *);
unsigned char Dk(unsigned char,ct *&);
ct *Tong(ct *,ct *);
ct *Hieu(ct *,ct *);
ct *Tich(ct *,ct *);
ct *Thuong(ct *,ct *,ct *&);
void Dao(ct *&);
char Sosanh(ct *,ct *);
void Xoa0(ct *&);
void XoaCT(ct *&);
// Chuong trinh chinh
void main()
{
 ct *so1=0,*so2=0,*kq_tong,*kq_hieu,*kq_tich,*kq_thuong_N,*kq_thuong_D=0;

 clrscr();
 Nhap(so1);
 Nhap(so2);
 kq_tong=Tong(so1,so2);
 kq_hieu=Hieu(so1,so2);
 kq_tich=Tich(so1,so2);
 kq_thuong_N=Thuong(so1,so2,kq_thuong_D);
 cout<<"Tong(";
 Xuat(so1);
 cout<<",";
 Xuat(so2);
 cout<<")=";
 Xuat(kq_tong);
 cout<<endl;
 cout<<"Hieu(";
 Xuat(so1);
 cout<<",";
 Xuat(so2);
 cout<<")=";
 Xuat(kq_hieu);
 cout<<endl;
 cout<<"Tich(";
 Xuat(so1);
 cout<<",";
 Xuat(so2);
 cout<<")=";
 Xuat(kq_tich);
 cout<<endl;
 cout<<"Thuong(";
 Xuat(so1);
 cout<<",";
 Xuat(so2);
 cout<<")=";
 Xuat(kq_thuong_N);
 cout<<" du ";
 Xuat(kq_thuong_D);
 getch();
}
// Chen 1 phan tu moi vao dau danh sach lien ket
void Chentruoc(ct *&dt,unsigned char a)
{
 ct *tam=new ct;

 tam->so=a;
 if (!dt) tam->tiep=0;
 else tam->tiep=dt;
 dt=tam;
}
// Chen 1 phan tu moi vao cuoi danh sach lien ket
void Chensau(ct *&dt,unsigned char a)
{
 ct *tam=new ct;

 tam->so=a;
 tam->tiep=0;
 if (!dt) dt=tam;
 else
 {
  ct *ht=dt;

  while (ht->tiep) ht=ht->tiep;
  ht->tiep=tam;
 }
}

void Nhap(ct *&dt)
{
 unsigned char c[255];

 cout<<"Nhap vao 1 so ";
 cin>>c;
 for (int i=0;i<strlen(c);i++)
  if (!isdigit(c[i])) Chensau(dt,c[i]);
  else Chensau(dt,c[i]-48);
 Xoa0(dt);
}
// Xuat ket qua cua danh sach lien ket ra man hinh
void Xuat(ct *dt)
{
 ct *ht=dt;

 while (ht)
 {
  if (ht->so>=0 && ht->so<=9) cout<<int (ht->so);
  else cout<<ht->so;
  ht=ht->tiep;
 }
}

unsigned char Dk(unsigned char a,ct *&so)
{
 if (a>=10)
 {
  Chentruoc(so,a-10);
  return 1;
 }
 else
 {
  Chentruoc(so,a);
  return 0;
 }
}
//Tong hai so
ct *Tong(ct *so1,ct *so2)
{
 ct *ht1,*ht2,*so=0;
 unsigned char a,b,nho=0,k1=so1->so=='-',k2=so2->so=='-';

 if ((k1 && k2) || (!k1 && !k2))
 {
  char k=0;

  if (k1)
  {
   so1=so1->tiep;
   so2=so2->tiep;
   k=1;
  }
  Dao(so1);
  Dao(so2);
  ht1=so1;
  ht2=so2;
  while (ht1)
  {
   a=ht1->so;
   ht1=ht1->tiep;
   if (ht2)
   {
    b=ht2->so;
    ht2=ht2->tiep;
   }
   else b=0;
   nho=Dk(a+b+nho,so);
  }
  while (ht2)
  {
   nho=Dk(ht2->so+nho,so);
   ht2=ht2->tiep;
  }
  if (nho) Chentruoc(so,nho);
  if (k) Chentruoc(so,'-');
  Dao(so1);
  Dao(so2);
 }
 else
 {
  if (k1)
  {
   so1=so1->tiep;
   so=Hieu(so2,so1);
  }
  else
  {
   so2=so2->tiep;
   so=Hieu(so1,so2);
  }
 }
 return so;
}
// Hieu 2 so
ct *Hieu(ct *so1,ct *so2)
{
 ct *ht1,*ht2,*so=0;
 char a,b,nho=0,k,k1=so1->so=='-',k2=so2->so=='-';

 if ((k1 && k2) || (!k1 && !k2))
 {
  if (k1)
  {
   ct *t;

   so1=so1->tiep;
   so2=so2->tiep;
   t=so1;
   so1=so2;
   so2=t;
  }
  k=Sosanh(so1,so2);
  Dao(so1);
  Dao(so2);
  if (k==-1)
  {
   ht1=so2;
   ht2=so1;
  }
  else
  {
   ht1=so1;
   ht2=so2;
  }
  while (ht1)
  {
   a=ht1->so;
   ht1=ht1->tiep;
   if (ht2)
   {
    b=ht2->so;
    ht2=ht2->tiep;
   }
   else b=0;
   if (a+nho-b>=0)
   {
    Chentruoc(so,a+nho-b);
    nho=0;
   }
   else
   {
    Chentruoc(so,10+a+nho-b);
    nho=-1;
   }
  }
  Xoa0(so);
  if (k==-1) Chentruoc(so,'-');
  Dao(so1);
  Dao(so2);
 }
 else
 {
  char k=0;
  if (k1)
  {
   so1=so1->tiep;
   k=1;
  }
  else so2=so2->tiep;
  so=Tong(so1,so2);
  if (k) Chentruoc(so,'-');
 }
 return so;
}
// Tich 2 so
ct *Tich(ct *so1,ct *so2)
{
 ct *so=0,*ht1,*ht2,*t=0,*tam;
 unsigned char m=0,nho=0,a,b,k=0,k1=so1->so=='-',k2=so2->so=='-';

 if (k1 && k2)
 {
  so1=so1->tiep;
  so2=so2->tiep;
 }
 else
  if (k1)
  {
   so1=so1->tiep;
   k=1;
  }
  else
   if (k2)
   {
    so2=so2->tiep;
    k=1;
   }
 Chentruoc(so,0);
 Dao(so1);
 Dao(so2);
 ht2=so2;
 while (ht2)
 {
  a=ht2->so;
  ht1=so1;
  while (ht1)
  {
   b=ht1->so;
   if (a*b+nho>=10)
   {
    Chentruoc(t,(a*b+nho)%10);
    nho=(a*b+nho)/10;
   }
   else
   {
    Chentruoc(t,a*b+nho);
    nho=0;
   }
   ht1=ht1->tiep;
  }
  if (nho)
  {
   Chentruoc(t,nho);
   nho=0;
  }
  for (int i=1;i<=m;i++) Chensau(t,0);
  tam=Tong(so,t);
  XoaCT(so);
  XoaCT(t);
  so=tam;
  ht2=ht2->tiep;
  m++;
 }
 Dao(so1);
 Dao(so2);
 Xoa0(so);
 if (k && so->so>0) Chentruoc(so,'-');
 return so;
}
// Thuong cua 2 so lay nguyen va du
ct *Thuong(ct *so1,ct *so2,ct *&du)
{
 ct *ht1,*so=0,*t=0,*tam=0,*t2=0;
 char ss,m,i,k1=so1->so=='-',k2=so2->so=='-';

 Chensau(tam,0);
 if (Sosanh(so2,tam))
 {
  if (k1) so1=so1->tiep;
  if (k2) so2=so2->tiep;
  delete tam;
  tam=0;
  ht1=so1;
  while (ht1)
  {
   Chensau(du,ht1->so);
   ss=Sosanh(du,so2);
   if (ss==-1) Chensau(so,0);
   else
   {
    m=du->so/so2->so;
    if (m==0) m=9;
    i=m;
    Chensau(tam,i);
    t=Tich(so2,tam);
    while (Sosanh(du,t)==-1)
    {
     i--;
     XoaCT(tam);
     XoaCT(t);
     Chensau(tam,i);
     t=Tich(so2,tam);
    }
    XoaCT(tam);
    Chensau(so,i);
    t2=Hieu(du,t);
    XoaCT(du);
    du=t2;
   }
   ht1=ht1->tiep;
  }
  Xoa0(so);
  Xoa0(du);
  if (((!k1 && k2) || (k1 && !k2)) && so->so>0) Chentruoc(so,'-');
  if (k1 && du->so>0) Chentruoc(du,'-');
 }
 return so;
}
// Dao vi tri cac thanh phan cua danh sach lien ket
void Dao(ct *&dt)
{
 ct *p1,*p2;

 p1=dt;
 dt=0;
 while (p1)
 {
  p2=p1->tiep;
  p1->tiep=dt;
  dt=p1;
  p1=p2;
 }
}
// So sanh 2 so (-1:so1<so2; 0:so1=so2; 1:so1>so2)
char Sosanh(ct *so1,ct *so2)
{
 ct *ht1,*ht2;
 unsigned char d1=0,d2=0;
 char m;

 ht1=so1;
 ht2=so2;
 if (so1->so=='-' && so2->so!='-') m=-1;
 else
  if (so1->so!='-' && so2->so=='-') m=1;
  else
  {
   while (ht1)
   {
    d1++;
    ht1=ht1->tiep;
   }
   while (ht2)
   {
    d2++;
    ht2=ht2->tiep;
   }
   if (d1>d2) m=1;
   else
    if (d1<d2) m=-1;
    else
    {
     ht1=so1;
     ht2=so2;
     while (ht1->tiep && ht1->so==ht2->so)
     {
      ht1=ht1->tiep;
      ht2=ht2->tiep;
     }
     if (ht1->so>ht2->so) m=1;
     else
      if (ht1->so<ht2->so) m=-1;
      else m=0;
    }
   if (m==1 && so1->so=='-') m=-1;
   else
    if (m==-1 && so1->so=='-') m=1;
  }
 return m;
}
// Cat bo cac so 0 o dau danh sach lien ket
void Xoa0(ct *&dt)
{
 ct *ht=dt;

 if (dt->so!='-')
 {
  while (ht->tiep && ht->so==0)
  {
   ht=ht->tiep;
   delete dt;
   dt=ht;
  }
 }
 else
 {
  ct *p=ht,*nho;

  ht=ht->tiep;
  while (ht->tiep && ht->so==0)
  {
   p->tiep=ht->tiep;
   nho=ht;
   delete nho;
   ht=ht->tiep;
  }
 }
}
// Xoa 1 danh sach lien ket
void XoaCT(ct *&dt)
{
 ct *ht=dt;

 while (ht)
 {
  ht=ht->tiep;
  delete dt;
  dt=ht;
 }
}