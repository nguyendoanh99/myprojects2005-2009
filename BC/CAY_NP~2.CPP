// Hay xay dung cac thao tac sau tren cay nhi phan:
// - Dem so node cua cay nhi phan
// - Xac dinh chieu sau cua cay nhi phan
// - Xac dinh so node la cua cay nhi phan
// - Xac dinh so node trung gian cua cay nhi phan
// - Xac dinh so node trong tung muc of cay nhi phan
// - Xay dung tap thao tac tuong tu nhu tren doi voi cac nhanh cay con
// - Them 1 node vao node phai cua 1 node
// - Them 1 node vao node trai cua 1 node
// - Loai bo node phai cua 1 node
// - Loai bo node trai cua 1 node
// - Loai bo ca cay
// - Duyet cay theo thu tu truoc
// - Duyet cay theo thu tu giua
// - Duyet cay theo thu tu sau

#include <iostream.h>
#include <conio.h>

struct CayNP
	{
	 int so;
	 CayNP *p[2];// 0:trai   1:phai
	};

CayNP *ThemNode(CayNP *&,int,int);
void XoaNode(CayNP *&);
void BoNode(CayNP *&,int);
void DemNode(CayNP *,int &);
void Ccao(CayNP *,int,int &);
void La(CayNP *,int &);
int  DemLa(CayNP *);
void TG(CayNP *,int &);
int DemTG(CayNP *);
void TungMuc(CayNP *,int,int,int &);
void Duyet(CayNP *,int);
void DuyetGiua(CayNP *);
// Chuong trinh chinh
void main()
{
 CayNP *caynp=0,*ht;
 int dn=0,cc=0,tc=0;

 clrscr();
 ht=ThemNode(caynp,1,0);
 ht=ThemNode(ht,2,0);
 ht=ThemNode(ht,3,0);
 ThemNode(ht,4,0);
 ThemNode(ht,5,1);
 ht=caynp->p[0];
 ht=ThemNode(ht,6,1);
 ThemNode(ht,7,0);
 ThemNode(ht,8,1);
 ht=ThemNode(caynp,9,1);
 ht=ThemNode(ht,10,1);
// Cay nhi phan sau khi xay dung
//		        1
//		2                9
//	   3         6                 10
//	4     5   7     8
 DemNode(caynp,dn);
 Ccao(caynp,0,cc);
 TungMuc(caynp,0,3,tc);
 cout<<"Cay nhi phan co chieu cao la "<<cc<<"\n";
 cout<<"Cay nhi phan co "<<dn<<" node.\n";
 cout<<"Cay nhi phan co "<<DemLa(caynp)<<" node la.\n";
 cout<<"Cay nhi phan co "<<DemTG(caynp)<<" node trung gian.\n";
 cout<<"Cay nhi phan co "<<tc<<" node tai muc 3\n";
 cout<<"Duyet truoc\n";
 Duyet(caynp,0);
 cout<<"\nDuyet giua\n";
 DuyetGiua(caynp);
 cout<<"\nDuyet sau\n";
 Duyet(caynp,1);
 getch();
}
// Them 1 phan tu vao cay nhi phan tai node.
// p=0  them vao ben trai node
// p=1  them vao ben phai node
CayNP *ThemNode(CayNP *&node,int so,int p)
{
 CayNP *tam=new CayNP;

 tam->so=so;
 tam->p[0]=0;
 tam->p[1]=0;
 if (!node) node=tam;
 else node->p[p]=tam;
 return tam;
}
// Loai bo node va cac con chau cua node
void XoaNode(CayNP *&node)
{
 if (node)
 {
  for (int i=0;i<2;i++) XoaNode(node->p[i]);
  delete node;
  node=0;
 }
}
// Loai bo 1 nhanh cua cay nhi phan co goc la node
// p=0  xoa node ben trai
// p=1  xoa node ben phai
void BoNode(CayNP *&node,int p)
{
 XoaNode(node->p[p]);
 node->p[p]=0;
}
// Dem so node cua cay nhi phan co goc la node
void DemNode(CayNP *node,int &a)
{
 if (node)
 {
  a++;
  for (int i=0;i<2;i++) DemNode(node->p[i],a);
 }
}
// Xac dinh chieu cao cua cay nhi phan co goc la node
void Ccao(CayNP *node,int c,int &d)
{
 if (node)
 {
  if (c>d) d++;
  for (int i=0;i<2;i++) Ccao(node->p[i],c+1,d);
 }
}

void La(CayNP *node,int &d)
{
 if (node)
  if (!node->p[0] && !node->p[1]) d++;
  else
   for (int i=0;i<2;i++) La(node->p[i],d);
}
// Xac dinh so node la cua cay nhi phan co goc la node
int DemLa(CayNP *node)
{
 int t=0;

 if (!node->p[0] && !node->p[1]) return 0;
 La(node,t);
 return t;
}

void TG(CayNP *node,int &d)
{
 if (node)
  if (node->p[0] || node->p[1])
  {
   d++;
   for (int i=0;i<2;i++) TG(node->p[i],d);
  }
}
// Xac dinh so node trung gian cua cay nhi phan co goc la node
int DemTG(CayNP *node)
{
 int t=-1;

 if (!node->p[0] && !node->p[1]) return 0;
 TG(node,t);
 return t;
}
// Xac dinh so node trong tung muc of cay nhi phan
void TungMuc(CayNP *node,int muc,int x,int &d)
{
 if (node)
  if (muc<x)
   for (int i=0;i<2;i++) TungMuc(node->p[i],muc+1,x,d);
  else d++;
}
// Duyet cay nhi phan theo
// t=0: thu tu truoc
// t=1: thu tu sau
void Duyet(CayNP *node,int t)
{
 if (node)
  if (node->p[0] || node->p[1])
  {
   Duyet(node->p[t-0],t);
   cout<<node->so<<" ";
   Duyet(node->p[1-t],t);
  }
  else cout<<node->so<<" ";
}
// Duyet cay theo thu tu giua
void DuyetGiua(CayNP *node)
{
 if (node)
  if (node->p[0] || node->p[1])
  {
   cout<<node->so<<" ";
   for (int i=0;i<2;i++) DuyetGiua(node->p[i]);
  }
  else cout<<node->so<<" ";
}