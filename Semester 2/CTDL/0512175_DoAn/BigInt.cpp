#include "stdafx.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include "stack.h"
#include "bigint.h"
#include <conio.h>
#include <ctype.h>
#include <string.h>
// Lay do uu tien cua toan tu
int uutien(char x)
{	
	switch(x)
	{
	case '(':		
	case '>':
	case '<':
	case '=':
		return 0;
	case '+':
	case '-':
		return 1;
	case '*':
	case '/':
	case '%':
		return 2;
	case '^':
		return 3;
	case '!':
		return 4;
	default:
		return -1;
	}
}
// Khoi tao BIGINT
void init(BIGINT &x)
{
	x.pHead=NULL;
	x.pTail=NULL;
}
// Tao 1 NODE tu c
NODE *getnode(int c)
{
	NODE *p=new NODE;
	if (!p)
		return NULL;
	p->digit=c;
	p->pNext=NULL;
	p->pPrev=NULL;
	return p;
}
// Them NODE p vao dau BIGINT b
void addhead(BIGINT &b,NODE *p)
{	
	if (b.pHead==NULL)
		b.pHead=b.pTail=p;
	else
	{
		p->pNext=b.pHead;
		b.pHead->pPrev=p;
		b.pHead=p;
	}
}
// Them NODE p vao cuoi BIGINT b
void addtail(BIGINT &b,NODE *p)
{
	if (b.pHead==NULL)
		b.pHead=b.pTail=p;
	else
	{
		b.pTail->pNext=p;
		p->pPrev=b.pTail;
		b.pTail=p;
	}
}
// Xuat BIGINT ra man hinh
int xuat(BIGINT b)
{
	if (isEmpty(b))
	{
		printf("NULL");
		return 0;
	}
	if (b.dau==-1)
		printf("-");
	for (NODE *p=b.pHead;p;p=p->pNext)
		printf("%d",p->digit);	
	return 1;
}

// Tao 1 BIGINT tu 1 BIGINT
BIGINT createBIGINT(BIGINT x)
{
	BIGINT kq;
	init(kq);
	kq.dau=x.dau;
	NODE *q;
	for (NODE *p=x.pHead;p;p=p->pNext)
	{
		q=getnode(p->digit);
		addtail(kq,q);
	}
	return kq;
}
// Tao 1 BIGINT tu chuoi so
BIGINT createBIGINT(char *s)
{
	BIGINT temp;
	NODE *p;
	init(temp);
	if (*s=='-')
	{	
		temp.dau=-1;
		s++;
	}
	else
	{
		temp.dau=1;
		if (*s=='+')
			s++;
	}	
	// Them so 0 vao temp	
	p=getnode(0);
	addtail(temp,p);
	int k=0;
	for (;*s;s++)
	{
		if (*s-'0')
		{
			k=1;
			p=getnode(*s-'0');
			addtail(temp,p);
		}
		else
			// Neu *s='0' va *s khong o dau chuoi thi them so 0 
			// vao temp
			if (k)
			{
				p=getnode(0);
				addtail(temp,p);
			}		
	}
	xoa0(temp);
	return temp;
}
// Tao 1 BIGINT tu so
BIGINT createBIGINT(int n)
{
	BIGINT t;
	if (n<0)
	{
		t.dau=-1;
		n=-n;
	}
	else
		t.dau=1;
	init(t);
	NODE *p;
	do 
	{
		p=getnode(n%10);
		addhead(t,p);
		n/=10;
	} while (n);
	return t;
}
// Huy BIGINT
void deleteBIGINT(BIGINT &x)
{
	NODE *q;
	NODE *p=x.pHead;
	while (p)
	{
		q=p;
		p=p->pNext;
		delete q;
	}
	init(x);
}
// Tra ve chieu dai cua BIGINT
int length(BIGINT x)
{
	int len=0;
	for (NODE *p=x.pHead;p!=x.pTail->pNext;p=p->pNext,len++);
	return len;
}
// So sanh 2 so BIGINT
// 1 : a > b
// 0 : a = b
// -1: a < b
SO_SANH sosanh(BIGINT a,BIGINT b)
{	
	if (isEmpty(a) || isEmpty(b))
		return __NULL;
	// a>0 va b<0
	if (a.dau > b.dau)	
		return LON_HON;
	// a<0 va b>0
	if (a.dau < b.dau)			
		return NHO_HON;
	
	// 2 so cung dau
	int flag=0;
	for (NODE *p=a.pTail,*q=b.pTail;q && p;p=p->pPrev,q=q->pPrev)
	{
		if (p->digit>q->digit)
			flag=1;
		else
			if (p->digit<q->digit)
				flag=-1;
	}
	int kq;
	if (p)
		kq=a.dau;
	else
		if (q)
			kq=-b.dau;
		else
			kq=flag*a.dau;
	switch (kq)
	{
	case 1:
		return LON_HON;		
	case 0:
		return BANG_NHAU;
	case -1:
		return NHO_HON;	
	}	
}
// So sanh 2 so BIGINT (khong xet dau)
// 1 : abs(a) > abs(b)
// 0 : abs(a) = abs(b)
// -1: abs(a) < abs(b)
SO_SANH ssanh(BIGINT a,BIGINT b)
{	
	// Neu a < 0
	if (a.dau==-1)
		a.dau=-a.dau;	// a = -a		
	// Neu b < 0
	if (b.dau==-1)
		b.dau=-b.dau;	// b = -b
	SO_SANH kq=sosanh(a,b);	
	return kq;
}
// hieu 2 so BIGINT
BIGINT hieu(BIGINT a,BIGINT b)
{
	BIGINT c;
	init(c);
	if (isEmpty(a) || isEmpty(b))
		return c;
	// neu a, b trai dau
	if (a.dau*b.dau==-1)
	{
		b.dau=-b.dau;
		c=tong(a,b);		
	}
	// neu a, b cung dau
	else
	{		
		// Neu abs(a)<abs(b) thi hoan vi 2 so
		// Dau phu thuoc vao so co tri tuyet doi lon hon
		// Neu abs(a)>abs(b) : dau cua c la dau cua a
		// Neu abs(a)<abs(b) : dau cua c la dau cua -b
		
		if (ssanh(a,b)==NHO_HON)
		{
			// Dao dau cua so lon hon
			c.dau=-b.dau;
			BIGINT temp=a;
			a=b;
			b=temp;
		}		
		else
			// Lay dau cua so lon hon
			c.dau=a.dau;
		NODE *p=a.pTail;
		NODE *q=b.pTail;
		NODE *temp;
		int nho=0;
		char kq;
		while (q)
		{
			if (p->digit+nho<q->digit)
			{
				kq=10+nho+p->digit-q->digit;
				nho=-1;
			}
			else
			{
				kq=nho+p->digit-q->digit;
				nho=0;
			}
			temp=getnode(kq);
			addhead(c,temp);
			p=p->pPrev;
			q=q->pPrev;
		}
		while (p)
		{
			if (p->digit+nho<0)
			{
				kq=10+p->digit+nho;
				nho=-1;
			}
			else
			{
				kq=p->digit+nho;
				nho=0;
			}
			temp=getnode(kq);
			addhead(c,temp);
			p=p->pPrev;
		}		
		xoa0(c);
	}
	return c;
}
// tong 2 so BIGINT 
BIGINT tong(BIGINT a,BIGINT b)
{
	BIGINT c;
	init(c);
	if (isEmpty(a)||isEmpty(b))
		return c;
	// neu 2 so trai dau
	if (a.dau*b.dau == -1)
	{
		b.dau =-b.dau;
		c=hieu(a,b);		
	}
	// neu 2 so cung dau
	else
	{
		NODE *p=a.pTail;
		NODE *q=b.pTail;
		NODE *temp;
		char kq;
		int nho=0;
		// Tao dau cho c
		c.dau=a.dau;
		// p, q chay tu phai qua trai
		while (p && q)
		{
			kq=p->digit+q->digit+nho;
			temp=getnode(kq%10);
			nho=kq/10;
			addhead(c,temp);
			p=p->pPrev;
			q=q->pPrev;
		}
		// them cac chu so con lai cua so lon hon vao c
		if (q)
			p=q;
		while (p)
		{
			kq=p->digit+nho;
			temp=getnode(kq%10);
			nho=kq/10;
			addhead(c,temp);
			p=p->pPrev;
		}
		// Tao them 1 node neu nho!=0
		if (nho)
		{
			temp=getnode(nho);
			addhead(c,temp);
		}
	}
	return c;
}

// tich 2 so BIGINT
BIGINT tich(BIGINT a,BIGINT b)
{	
	BIGINT c;
	init(c);
	if (isEmpty(a)||isEmpty(b))
		return c;
	c=createBIGINT("0");
	if (kiemtra0(a) || kiemtra0(b))
		return c;	
	NODE *temp=c.pTail;
	// Cat bo cac so 0 o cuoi b va them vao c
	for (NODE *q=b.pTail;q->digit==0;q=q->pPrev)
	{	
		NODE *p=getnode(0);
		addtail(c,p);
	}
	// Cat bo cac so 0 o cuoi a va them vao c
	// giu dia chi node cuoi cua a
	for (;a.pTail->digit==0;a.pTail=a.pTail->pPrev)
	{
		NODE *p=getnode(0);
		addtail(c,p);
	}
	NODE *t=c.pTail;
	c.pTail=temp;
	temp=t;
	while (q)
	{
		if (q->digit)
		{			
			NODE *p=a.pTail;
			NODE *q1=c.pTail;			
			int nho=0;			
			while (p)
			{
				if (q1==NULL)
				{
					addhead(c,getnode(0));
					q1=c.pHead;
				}
				q1->digit+=nho+p->digit*q->digit;
				nho=q1->digit/10;
				q1->digit%=10;
				p=p->pPrev;
				q1=q1->pPrev;
			}
			while (nho)
			{				
				addhead(c,getnode(nho%10));
				nho/=10;
			}			
		}		
		if (!c.pTail->pPrev)
		{
			NODE *p=getnode(0);
			addhead(c,p);
		}
		c.pTail=c.pTail->pPrev;			
		q=q->pPrev;
	}
	c.pTail=temp;
	xoa0(c);
	c.dau = a.dau*b.dau;
	return c;
}
// thuong 2 so BIGINT gom phan nguyen va phan du
int thuong(BIGINT a,BIGINT b,BIGINT &kq,BIGINT &du)
{
	init(du);
	init(kq);
	if (isEmpty(a) || isEmpty(b))
		return 0;
	if (kiemtra0(b))
		return 0;
	du.dau=1;
	int dau=b.dau;
	b.dau=1;
	NODE *p=a.pHead;
	do
	{
		NODE *q=getnode(p->digit);
		addtail(du,q);
		int d=0;
		SO_SANH ss=ssanh(du,b);
		while (ss==LON_HON || ss==BANG_NHAU)
		{
			BIGINT t=du;
			du=du-b;
			deleteBIGINT(t);
			d++;
			ss=ssanh(du,b);
		}
		// Tranh them 0 vo nghia vao dau kq
		if (d!=0 || !isEmpty(kq))
		{
			q=getnode(d);
			addtail(kq,q);
		}
		p=p->pNext;
	} while (p);
	if (isEmpty(kq))
		addtail(kq,getnode(0));
	du.dau=a.dau*dau;
	kq.dau=du.dau;
	return 1;
}
// Tinh a^x
BIGINT pow(BIGINT a,int x)
{
	if (isEmpty(a))
	{
		BIGINT c;
		init(c);
		return c;
	}
	if (x==0)
		return createBIGINT(1);
	char *d=(char*) malloc(int(log(x)/log(2)+1)*sizeof(char));
	for (int n=0;x!=1;x/=2,n++)
		d[n]=x%2;
	BIGINT temp=createBIGINT(a);
	if (n==0)
		return temp;
	BIGINT temp1;
	for (;n;n--)
	{
		temp1=temp*temp;
		deleteBIGINT(temp);
		temp=temp1;
		if (d[n-1])
		{
			temp1=temp*a;
			deleteBIGINT(temp);
			temp=temp1;
		}
	}
	free(d);
	return temp;
}
// Tinh a^x
BIGINT pow(BIGINT a,BIGINT b)
{
	if (isEmpty(a) || isEmpty(b))
	{
		BIGINT c;
		init(c);
		return c;
	}
	int x=convert(b);
	return pow(a,x);
}
// Phan tich cac so ra thua so nguyen to roi tinh giai thua
BIGINT giaithua(int n)
{
	if (n<0)
	{
		BIGINT c;
		init(c);
		return c;
	}
	if (n==0)
		return createBIGINT(1);
	if (n==1)
		return createBIGINT(1);
	struct kdl 
	{
		int heso;
		int mu;
	};
	typedef struct kdl KDL;
	STACK l;
	init(l);
	// Phan tich n! thanh tich cac thua so nguyen to
	int j;
	for (int i=2;i<=n;i++)
	{
		j=i;
		for (NODESTACK *p=l.pHead;p;p=p->pNext)
		{	
			KDL *t=(KDL*) p->info.pInfo;
			while (j%t->heso==0)
			{
				t->mu++;
				j/=t->heso;
			}
		}
		if (j!=1)
		{
			KDL *temp=new KDL;
			temp->heso=j;
			temp->mu=1;
			I_NODE x;
			x.pInfo=temp;
			NODESTACK *p=getnode(x);
			push(l,p);
		}
	}
	//Dem so luong chu so 0 o cuoi n!
	int length=0;
	for (NODESTACK *p=l.pHead;p;p=p->pNext)
	{
		KDL *temp=(KDL*) p->info.pInfo;
		if (temp->heso<5)
			break;
		if (temp->heso==5)
		{
			length=temp->mu;			
			KDL *q=(KDL*) p->pNext->pNext->info.pInfo;// 2^n
			q->mu-=temp->mu;
			temp->mu=0;
			break;
		}
	}	
	// Tinh n!
	BIGINT c=createBIGINT(1);
	while (!isEmpty(l))
	{		
		I_NODE x=pop(l);
		KDL *t=(KDL *) x.pInfo;
		BIGINT temp=createBIGINT(t->heso);
		BIGINT temp2=pow(temp,t->mu);
		deleteBIGINT(temp);
		BIGINT temp3=c;
		c=c*temp2;
		deleteBIGINT(temp2);
		deleteBIGINT(temp3);
		delete t;
	}
	NODE *q;
	// Cac chu so 0 nam cuoi cua n!
	for (;length;length--)
	{
		q=getnode(0);
		addtail(c,q);
	}
	return c;
}
// Phan tich cac so ra thua so nguyen to roi tinh giai thua
BIGINT giaithua(BIGINT a)
{
	if (isEmpty(a))
	{
		BIGINT c;
		init(c);
		return c;
	}
	int n=convert(a);
	return giaithua(n);	
}

// Dinh nghia toan tu + cho BIGINT
BIGINT operator+(BIGINT a,BIGINT b)
{
	BIGINT c=tong(a,b);
	return c;
}
// Dinh nghia toan tu - cho BIGINT
BIGINT operator-(BIGINT a,BIGINT b)
{
	return hieu(a,b);
}
// Dinh nghia toan tu * cho BIGINT
BIGINT operator*(BIGINT a,BIGINT b)
{
	return tich(a,b);
}
// Dinh nghia toan tu / cho BIGINT
BIGINT operator/(BIGINT a,BIGINT b)
{
	BIGINT kq,du;
	thuong(a,b,kq,du);
	deleteBIGINT(du);
	return kq;
}
// Dinh nghia toan tu % cho BIGINT
BIGINT operator%(BIGINT a,BIGINT b)
{
	BIGINT kq,du;
	thuong(a,b,kq,du);
	deleteBIGINT(kq);
	return du;
}
// Xoa cac so 0 vo nghia cua x
void xoa0(BIGINT &x)
{
	NODE *p=x.pHead;	
	NODE *q;
	while (x.pHead->digit==0 && x.pHead->pNext)
	{		
		q=x.pHead;
		x.pHead=x.pHead->pNext;
		x.pHead->pPrev=NULL;		
		delete q;		
	}
	// Neu x la so 0
	if (kiemtra0(x))
		x.dau=1;
}
// Kiem tra xem x co bang 0 hay khong
// 1 : x=0
// 0 : x!=0
int kiemtra0(BIGINT x)
{
	return x.pHead->digit==x.pTail->digit && x.pTail->digit==0;
}
// Kiem tra x co rong hay khong
int isEmpty(BIGINT x)
{
	return x.pHead==NULL;
}
// Chuyen so BIGINT thanh kieu int 
int convert(BIGINT x)
{
	int kq=0;

	for (NODE *p=x.pHead;p;p=p->pNext)
		kq=kq*10+p->digit;
	if (x.dau==-1)
		kq=-kq;
	return kq;
}

// Tinh gia tri cua bieu thuc s
I_NODE *tinhbieuthuc(STACK &st)
{
	if (isEmpty(st))	
		return NULL;	
	BIGINT *temp;
	bool *temp1=NULL;
	SO_SANH kq;
	I_NODE x;
	// Chen 3 node vao dau stack
	// giu nhiem vu node temp
	NODESTACK *p3=new NODESTACK; 
	NODESTACK *p2=new NODESTACK; 
	NODESTACK *p1=new NODESTACK;
	NODESTACK *p=st.pHead;	
	char *c;
	temp=new BIGINT;
	init(*temp);
	p3->info.pInfo=temp;
	temp=new BIGINT;
	init(*temp);
	p2->info.pInfo=temp;
	temp=new BIGINT;
	init(*temp);
	p1->info.pInfo=temp;
	addhead(st,p3);
	addhead(st,p2);
	addhead(st,p1);	

	while (p)
	{
		x=p->info;
		if (x.loai==_CHAR)
		{			
			c=(char*) x.pInfo;
			x=p3->info;			
			BIGINT b=*((BIGINT *) x.pInfo);
			// Thuc hien phep tinh
			if (*c=='!')			
			{
				temp=new BIGINT;
				*temp=giaithua(b);			
			}
			else
			{		
				x=p2->info;
				BIGINT a=*((BIGINT *) x.pInfo);				
				switch (*c)
				{
				case '+':
					temp=new BIGINT;
					*temp=a + b;
					break;
				case '-':
					temp=new BIGINT;
					*temp=a - b;
					break;
				case '*':
					temp=new BIGINT;
					*temp=a * b;
					break;
				case '/':
					temp=new BIGINT;
					*temp=a / b;
					break;
				case '%':
					temp=new BIGINT;
					*temp=a % b;
					break;
				case '^':
					temp=new BIGINT;
					*temp=pow(a,b);
					break;
				case '>':
				case '=':
				case '<':				
					SO_SANH t;
					switch (*c)
					{
					case '>':
						t=LON_HON;
						break;
					case '<':
						t=NHO_HON;
						break;
					case '=':
						t=BANG_NHAU;
						break;
					}
					kq=sosanh(a,b);
					temp1=new bool;
					*temp1=(kq==t);
					// Truong hop >=, <=					
					if (c[1]!=0)					
						*temp1=*temp1 || kq==BANG_NHAU;					
					break;
				default:// Truong hop thieu )
					Empty(st);					
					return NULL;					
				}	
				deleteBIGINT(a);
			}
			deleteBIGINT(b);			
			// Ket qua la 1 so BIGINT
			if (temp1==NULL)
			{
				x.loai=_BIGINT;
				x.pInfo=temp;
				// Gap loi phep tinh
				if (isEmpty(*temp))
				{					
					// Xoa cac phan tu con lai trong Stack
					Empty(st);
					return NULL;
				}
			}
			else
			{
				x.loai=_BOOL;
				x.pInfo=temp1;
				// Gap loi phep so sanh
				if (kq==__NULL)
				{					
					// Xoa cac phan tu con lai trong Stack
					Empty(st);					
					return NULL;
				}
				temp1=NULL;
			}
			NODESTACK *q=getnode(x);
			char c1=*c;
			delafter(st,p3);
			delafter(st,p2);
			if (c1!='!')
			{
				delafter(st,p1);			
				addafter(st,p1,q);
			}
			else
				addafter(st,p2,q);

//			printf("\ns=");
//			xuat(st);

			p1=st.pHead;
			p2=p1->pNext;
			p3=p2->pNext;
			p=p3->pNext;
		}	
		p1=p2;
		p2=p3;
		p3=p;		
		p=p->pNext;
	}
	// Xoa 3 node temp ra khoi Stack
	delafter(st,NULL);
	delafter(st,NULL);
	delafter(st,NULL);

	I_NODE *k=new I_NODE;
	*k=pop(st);
	if (!isEmpty(st))
	{
		Empty(st);
		return NULL;
	}
	return k;
}
// Chuyen bieu thuc tu dang trung to sang hau to
STACK Trung_to_hau_to(char *s)
{
	BIGINT *temp=new BIGINT;
	STACK toantu,hau_to;
	// flag=0:	phan tu vua dua vao stack la BIGINT
	// flag=1:	phan tu vua dua vao stack la toantu
	int flag=1;
	I_NODE x;
	init(hau_to);
	init(toantu);
	init(*temp);
	temp->dau=1;
	char *c;
	while (*s!=0 &&*s!=10)
	{
		if (isdigit(*s))
		{
			// Dua cac chu so lan luot vao BIGINT *temp
			NODE *p=getnode(*s-'0');
			addtail(*temp,p);
		}
		else
		{			
			NODESTACK *p;
			// Them BIGINT vao STACK
			if (!isEmpty(*temp))
			{				
				xoa0(*temp);
				x.loai=_BIGINT;
				x.pInfo=temp;
				p=getnode(x);
				addtail(hau_to,p);
				temp=new BIGINT;
				init(*temp);
				temp->dau=1;
				flag=0;
			}

			if (*s==' ' || *s=='\t')
			{
				s++;
				continue;
			}
			
			if (*s==')')
			{
				// Dua cac toan tu vao Stack hau_to cho toi khi gap 
				// toan tu '(' thi dung lai
				x=pop(toantu);
				if (x.loai==_NULL) // Truong hop du dau ')'
				{
					// Xoa tat ca cac phan tu con lai trong STACK
					// hau_to
					Empty(hau_to);					
					return hau_to;
				}
				c=(char *) x.pInfo; 
				while (*c!='(')				
				{
					addtail(hau_to,getnode(x));
					x=pop(toantu);					
					if (x.loai==_NULL) // Truong hop du dau ')'
					{
						// Xoa tat ca cac phan tu con lai trong STACK
						// hau_to
						Empty(hau_to);						
						return hau_to;
					}
					c=(char *) x.pInfo;
				}
			}			
			else	// *s=(+-*/%^!
			{
				if (*s!='(')
				{
					int u1=uutien(*s); // Do uu tien cua *s
					// Gap cac ky tu khong phai la toan tu
					if (u1==-1)
					{
						// Xoa tat ca cac phan tu con lai trong STACK
						// hau_to va toantu
						Empty(hau_to);
						Empty(toantu);
						return hau_to;
					}
					// Truong hop *s la dau cua BIGINT 
					if (flag==1)
					{
						if (*s=='+' || *s=='-')
						{
							if (*s=='-')
								temp->dau=-temp->dau;
							flag=1;
							s++;
							continue;
						}						
					}
					// Lay do uu tien cua phan tu o dinh STACK
					int u2; 
					while (!isEmpty(toantu))
					{	
						x=top (toantu);
						c=(char *) x.pInfo;
						u2=uutien(*c);
						if (u2>=u1)
						{
							x=pop(toantu);
							addtail(hau_to,getnode(x));
						}						
						else
							break;
					}
				}
				// Them toan tu vao STACK toantu	
				x.loai=_CHAR;
				// Truong hop dau >=, <=
				if (*(s+1)!=0 && (*s=='>' || *s=='<') && *(s+1)=='=')
				{
					c=new char[3];
					c[0]=*s;
					c[1]='=';
					c[2]=0;
					s++;
				}
				else
				{
					c=new char[2];
					*c=*s;
					c[1]=0;
				}
				x.pInfo=c;
				p=getnode(x);
				push(toantu,p);
				flag=1;
			}						
		}
		s++;
	}
	// So nam o cuoi chuoi
	if (!isEmpty(*temp))
	{		
		xoa0(*temp);
		x.loai=_BIGINT;
		x.pInfo=temp;
		NODESTACK *p=getnode(x);
		addtail(hau_to,p);
	}
	// Dua cac toan tu con lai trong STACK toantu vao Stack hau_to
	while (!isEmpty(toantu))
	{
		x=pop(toantu);		
		addtail(hau_to,getnode(x));
	}	
	return hau_to;
}