// stdafx.cpp : source file that includes just the standard includes
//	0512068_doan_p1.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H



// CAC THAO TAC TREN DSLK KEP (BIGINT)

void Init(BIGINT &b)
{
	b.pHead = NULL;
	b.pTail = NULL;
}

NODE *Get_node(int n)
{
	NODE *p;
	p = new NODE;
	if(p == NULL)
		return NULL;
	p->info = n;
	p->pNext = NULL;
	p->pPrev = NULL;
	return p;
}

void Add_head(BIGINT &b,NODE *p)
{
	if(b.pHead == NULL)
		b.pHead = b.pTail = p;
	else
	{
		p->pNext = b.pHead;
		b.pHead->pPrev = p;
		b.pHead = p;
	}
}

void Add_tail(BIGINT &b,NODE *p)
{
	if(b.pHead == NULL)
		b.pHead = b.pTail = p;
	else
	{
		b.pTail->pNext = p;
		p->pPrev = b.pTail;
		b.pTail = p;
	}
}



/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////

// CAC THAO TAC TREN DSLK DON (STACK)
void Push(STACK &S,NODE_ST *p)
{
	if (S.pHead == NULL)
		S.pHead = S.pTail = p;
	else
	{
		p->pNext = S.pHead;
		S.pHead = p;
	}
	S.so_node++;
}

char Pop(STACK &S)
{
	NODE_ST *p;
	char x;
	if (S.pHead == NULL)
		return -1;
	else
	{
		p = S.pHead;
		x = S.pHead->info;
		S.pHead = S.pHead->pNext;
		delete p;
		S.so_node--;
		if(S.pHead == NULL)
			S.pTail = NULL;
		return x;
	}
}

char Top(STACK S)
{
	if(S.pHead == NULL)
		return -1;
	return S.pHead->info;
}

NODE_ST *Getnode_stack(char x)
{
	NODE_ST *p = new NODE_ST;
	if (p == NULL)
		return NULL;
	p->info = x;
	p->pNext = NULL;
	return p;
}

void Init_stack(STACK &S)
{
	S.pHead = S.pTail = NULL;
	S.so_node = 0;
}

bool Is_empty(STACK S)
{
	if(S.pHead == NULL)
		return 1;
	return 0;
		
}

/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////

// CAC THAO TAC NHAP XUAT , DOC GHI FILE
void Input(BIGINT &b)
{
	char a[1000];
	fflush(stdin);
	gets(a);
	int l = strlen(a);
	int i = 0;
	int info;
	NODE *p;
	Init(b);
	b.dau = 1;

	do
	{
		if(a[i] == '-')
			b.dau = 0;
		else if(a[i] == '+')
				b.dau = 1;
/*		else if(isdigit(a[i]) == 0)
				break;
*/		else if(a[i]>'9' || a[i]<'0')
				break;
		else
		{
			info = a[i]-48;
			p = Get_node(info);
			Add_tail(b,p);
		}
		i++;
	}while(i < l);
}

void Output(BIGINT b)
{
	if(b.dau == 0)
		printf("-");

	for(NODE *p=b.pHead ; p->info == 0 && p->pNext; p=p->pNext);
	for( ; p!=NULL ; p=p->pNext)
		printf("%d",p->info); 
}



void Read_file(char *filename,BIEUTHUC bt[],int &n)
{
	char *a1;
	a1 = new char;
	char a1_truoc; // luu lai kitu trc *a1
	int *a2; // luu cac kitu_so tam thoi
	a2 = new int;
	int i=0;
	FILE *f;
	f = fopen(filename,"rb");
	if(f == NULL)
		return;
	int stt = 0;
	n = 0; // khoi gan so bieu thuc


	while(fread(a1,sizeof(char),1,f) != 0)
	{
		// th1: neu la kitu_so luu tam vao mang a2
		if(*a1 >= 48 && *a1 <= 57) 
		{	
			*(a2+i) = ( int)*a1 - 48;
			i++;
		}
		// th2: ko la kitu_so
		else 
		{
			if(i != 0) // lien truoc no khong phai la toan_tu
			{
				// dua so vao bieu thuc
				bt[n].un[stt].type = 0;
				bt[n].un[stt++].ptu.data = Create_bigint(a2,i);
				i = 0; // refresh a de chua cac kitu_so moi
			}
			
			// dua toan tu vao bieu thuc
			if(*a1=='(' || *a1==')')
			{
				bt[n].un[stt].type = 2;
				bt[n].un[stt++].ptu.op = *a1;
			}
			else 
			{
				if(*a1 == '+' || *a1 == '-' || *a1 == '*' || *a1 == '/')
				{
						bt[n].un[stt].type = 1;
						bt[n].un[stt++].ptu.op = *a1;
				}
				if(*a1 == 13) // la ki tu xuong dong
				{
					bt[n].so_unit = stt;
					n++;
					stt = 0; // refresh so thu tu 
				}
			}
		}
		
		a1_truoc = *a1;

	}

	if(i != 0)
	{
		// dua so vao bieu thuc lan cuoi
		bt[n].un[stt].type = 0;
		bt[n].un[stt++].ptu.data = Create_bigint(a2,i);
	}

	if(a1_truoc != 10)
	{
		// xu li cho bt cuoi : khong ket thuc bang enter
		bt[n].so_unit = stt;
		n++; // tang lan cuoi cung
	}

	fclose(f);

}

void Xuat_ktra(BIEUTHUC bt[],int n)
{
	for(int i=0 ; i<n ; i++)
	{
		if(bt[i].so_unit==0)
			printf("\n Bieu thuc rong!");

		for(int j=0 ; j<bt[i].so_unit ; j++)
		{
			if(bt[i].un[j].type == 0)
				Output(bt[i].un[j].ptu.data);
			else
				printf("%c",bt[i].un[j].ptu.op);
		}
		printf("\n");
	}
}	



/////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////

// CAC THAO TAC PHU (HO TRO)
int Count_chuso(BIGINT b)
{
	int dem = 0;
	NODE *p=b.pHead;
	while(p!=NULL)
	{
//		if((isdigit(p->info) == 1))
		dem++;
		p=p->pNext;
	}
	return dem;
}


BIGINT Nhan_khongdau(BIGINT b,int n)
{
	BIGINT kq;
	Init(kq);
	NODE *q;
	int i;
	int nho = 0;
	for(NODE *p=b.pTail ; p!=NULL ; p=p->pPrev)
	{
		i = p->info*n+nho;
		nho = i/10;
		q = Get_node(i%10);
		Add_head(kq,q);
	}
	if(nho != 0)
	{
		q = Get_node(nho);
		Add_head(kq,q);
	}
	kq.dau = 1;
	return kq;
}

void Add_tail_0_nlan(BIGINT &temp,int n)
{
	NODE *p;
	for(int i=0 ; i<n ; i++)
	{
		p = Get_node(0);
		Add_tail(temp,p);
	}
}

void Create_tam(BIGINT &b,int n)
{
	Init(b);
	NODE *p;
	for(int i=1 ; i<=n ; i++)
	{
		p = Get_node(0);
		Add_tail(b,p);
	}
}


BIGINT Create_bigint(int *a,int n)
{
	BIGINT b;
	Init(b);
	b.dau = 1;
	NODE *p;
	for(int i=0 ; i<n ; i++)
	{
		p = Get_node(*(a+i));
		Add_tail(b,p);
	}
	return b;
}


int Ktra_bangkhong(BIGINT b)
{
	return b.pHead->info == 0;
}


int Compare_khongdau(BIGINT b1,BIGINT b2)
{
	if(Count_chuso(b1) > Count_chuso(b2)) 
			return 1;
	else if(Count_chuso(b1) < Count_chuso(b2))
			return -1;

	NODE *p = b1.pHead; 
	NODE *q = b2.pHead;
	while(p != NULL)
	{
		if(p->info > q->info)
			return 1;
		else if(p->info < q->info)
			return -1;
		p = p->pNext;
		q = q->pNext;
	}
	return 0;
}

int Do_uutien(char a,char b)
{
	if(a == b)
		return 0;
	if((a=='*'||a=='/') && (b=='+'||b=='-'))
		return 1;
	if( (a=='+'||a=='-') && (b=='*'||b=='/') )
		return -1;
	else
		return 0;
}
			
BIGINT Tinh(BIGINT b1,BIGINT b2,char x)
{
	BIGINT kq;
	if(x == '+')
		kq = b1+b2;
	if(x == '-')
		kq = b1-b2;
	if(x == '*')
		kq = b1*b2;

	return kq;
}

void Dichtrai_2nac(BIEUTHUC &bt,int vtri)
{
	for(int i=vtri ; i<bt.so_unit-2 ; i++)
		bt.un[i] = bt.un[i+2];

	bt.so_unit -= 2;
}

BIGINT operator+(BIGINT b1,BIGINT b2)
{
	return Cong(b1,b2);
}

BIGINT operator-(BIGINT b1,BIGINT b2)
{
	return Tru(b1,b2);
}

BIGINT operator*(BIGINT b1,BIGINT b2)
{
	return Nhan(b1,b2);
}



//////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////

// CAC THAO TAC CHINH
// I - Tong 2 bigint
BIGINT Cong(BIGINT b1,BIGINT b2)
{
	BIGINT b;
	Init(b);

	if(b1.dau != b2.dau)  // 2 so trai dau
	{
		if(b1.dau == 0)
		{
			b1.dau = 1;
			return Tru(b2,b1);
		}
		b2.dau = 1;
		return Tru(b1,b2);
	}
	
	b.dau = b1.dau;   // neu 2 so cung dau

	NODE *p = b1.pTail;  // thuc hien phep cong binh thuong tu trai wa phai
	NODE *q = b2.pTail;
	NODE *r;
	int nho = 0;
	int i;
	while(p!=NULL && q!=NULL)
	{
		i = p->info + q->info + nho;
		r = Get_node(i%10);
		nho = i/10;
		Add_head(b,r);
		p = p->pPrev;
		q = q->pPrev;
	}
	if(p)   // ket thuc vong lap but 1 trong 2 so van con ptu 
		q = p; // very good NA !!!
	while(q)
	{
		i = q->info + nho;
		r = Get_node(i%10);
		nho = i/10;
		Add_head(b,r);
		q = q->pPrev;
	}
	if(nho)  // neu nho != 0
	{
		r = Get_node(nho);
		Add_head(b,r);
	}

	return b;
}


// II - Hieu 2 bigint

BIGINT Tru(BIGINT b1,BIGINT b2)
{

	if(b1.dau != b2.dau)  // 2 so trai dau
	{
		if(b1.dau == 1)
			b2.dau = 1;		
		else
			b2.dau = 0;
		return Cong(b1,b2);
	}

	BIGINT b;
	Init(b);

	if(Sosanh(b1,b2) == 1)  // neu 2 so cung dau thi phai xac dinh dau of hieu
		b.dau = 1;
	else 
	{
		if(Sosanh(b1,b2) == -1)
			b.dau = 0;
		else
		{
			NODE *p = Get_node(0);
			Add_head(b,p);
			return b;
		}
	}

	NODE *p;   // thuc hien phep tru binh thuong
	NODE *q;
	NODE *r;
	if(Compare_khongdau(b1,b2) == 1) // dam bao lay so co || lon hon tru so nho
	{
		p = b1.pTail;
		q = b2.pTail;
	}
	else
	{
		q = b1.pTail;
		p = b2.pTail;
	}
	
	int nho = 0;
	int i;
	while(p!=NULL && q!=NULL)
	{			
		i = p->info - q->info - nho;
		if(i < 0)
		{
			i += 10;
			nho = 1;
		}
		else
			nho = 0;
		r = Get_node(i);
		Add_head(b,r);	
		p = p->pPrev;
		q = q->pPrev;
	}
	if(p != NULL)
		q = p;
	while(q != NULL)
	{
		i = q->info - nho;
		if(i < 0)
		{
			i += 10;
			nho = 1;
		}
		else
			nho = 0;
		r = Get_node(i);
		Add_head(b,r);	
		q = q->pPrev;
	}

	return b;
}

// III - Tich 2 bigint
// The basic
BIGINT Nhan(BIGINT b1,BIGINT b2)
{
	BIGINT b,temp;
	Init(b);
	b.dau = 1;  // phai mac dinh b.dau =1 trc if ko khi thuc hien phep cog thi 2 so dua vao se khac dau(temp.dau luon =0)
	int i=0;

	for(NODE *p=b2.pTail ; p!=NULL ; p=p->pPrev)
	{
		temp = Nhan_khongdau(b1,p->info);
		Add_tail_0_nlan(temp,i);
		b = Cong(b,temp);
		i++;
	}

	if(b1.dau != b2.dau) // ko dc dua viec xet dau len trc vi li do nhu tren
		b.dau = 0;
	if(Ktra_bangkhong(b) == 1) // xet neu b=0 thi bo di dau tru if co
		b.dau = 1;

	return b;
}

/*
//  First improve edition
BIGINT Nhan(BIGINT b1,BIGINT b2)
{
	BIGINT b,temp;
	Init(b);
	Create_tam(temp,Count_chuso(b1)+1); // tao 1 bigint co toi da n ptu(n la so chu so of b1)
	NODE *p,*q,*r,*r_temp;
	int nho1,nho2;
	int i,j;
	p = b2.pTail;
	while(p != NULL)
	{
		nho1 = 0;
		nho2 = 0;
		q = b1.pTail;
		r_temp = temp.pTail;
		while(q != NULL)
		{
			i = p->info * q->info + nho1;
			j = r_temp->info + i%10 + nho2;
			r_temp->info = j%10;
			nho1 = i/10;
			nho2 = j/10;
			q = q->pPrev;
			r_temp = r_temp->pPrev;
		}
		r = temp.pTail;
		Remove_tail(temp);
		Add_head(b,r);
	}
	return b;
}

void Remove_tail(BIGINT &b)
{
	b.pTail = b.pTail->pPrev;
	b.pTail->pNext->pPrev = NULL;
	b.pTail->pNext = NULL;
}

*/
/*
BIGINT Nhan(BIGINT b1,BIGINT b2)
{
	BIGINT b;
	int dem = ; // Con xet lai
	Create_tam(b,dem);
	if(b1.dau == b2.dau)
		b.dau = 1;
	else
		b.dau = 0;
	NODE *r;
	r = b.pTail;
	int nho1,nho2,i,t;
	for(NODE *p=b2.pTail ; p!=NULL ; p=p->pPrev)
	{
		
		nho1 = 0;
		nho2 = 0;
		for(NODE *q=b1.pTail ; q!=NULL ; q=q->pPrev)
		{
			i = p->info*q->info + nho1;
			nho1 = i/10;
			t = r->info + i%10 + nho2;
			r->info = t%10;
			nho2 = t/10;
			r = r->pPrev;
		}
		r = r->pPrev;		
	}
	return b;
}


*/
// IV - So sanh 2 bigint
int Sosanh(BIGINT b1,BIGINT b2)
{
	if(b1.dau > b2.dau) // So sanh dau
		return 1;
	else if(b1.dau < b2.dau)
		return -1;

	if(Count_chuso(b1) > Count_chuso(b2)) // so sanh chieu dai of 2 so
		if(b1.dau == 1)
			return 1;
		else
			return -1;
	else if(Count_chuso(b1) < Count_chuso(b2))
		if(b1.dau == 1)
			return -1;
		else
			return 1;

	NODE *p = b1.pHead; // so sanh khi 2 so co chieu dai = nhau va cung dau
	NODE *q = b2.pHead;
	while(p != NULL)
	{
		if(p->info > q->info)
			if(b1.dau == 1)
				return 1;
			else
				return -1;
		else if(p->info < q->info)
			if(b1.dau == 1)
				return -1;
			else
				return 1;
		p = p->pNext;
		q = q->pNext;
	}
	return 0;
}


// V - Tinh gia tri cua cac bieu thuc bigint = thuat toan Balan nguoc
BIEUTHUC Chuyenve_postfix(BIEUTHUC &bt)
{
	BIEUTHUC temp;
	temp.so_unit = 0;
	char kitu_temp1;
	char kitu_temp2;
	char top_st;

	STACK st;
	Init_stack(st);
	NODE_ST *p;

//b1:
	for(int i=0 ; i<bt.so_unit ; i++) // duyet tung phan tu cua bieu thuc
	{
//b2: la so
		if(bt.un[i].type == 0)	// la so: output it
		{
			temp.un[temp.so_unit].type = 0;
			temp.un[temp.so_unit].ptu.data = bt.un[i].ptu.data;
			temp.so_unit++;
		}
//b3: la (
		if(bt.un[i].type == 2 && bt.un[i].ptu.op == '(')
		{
			p = Getnode_stack('(');
			Push(st,p);
		}
//b4: la operation
		int co = 0;
		while(bt.un[i].type == 1 && co==0)
		{
			if(Is_empty(st) == 1)
			{
				p = Getnode_stack(bt.un[i].ptu.op);
				Push(st,p);
				co = 1;
			}
			else
			{
				if(Top(st) == '(')
				{
					p = Getnode_stack(bt.un[i].ptu.op);
					Push(st,p);
					co = 1;
				}
				else
				{
					top_st = Top(st);
					if(Do_uutien(top_st,bt.un[i].ptu.op) < 0)
					{
						p = Getnode_stack(bt.un[i].ptu.op);
						Push(st,p);
						co =1;
					}
					else
					{
						temp.un[temp.so_unit].type = 1;
						temp.un[temp.so_unit].ptu.op = Pop(st);
						temp.so_unit++;
					}
				}
			}
		}
//b5: la )
		if(bt.un[i].type == 2 && bt.un[i].ptu.op == ')')
		{
			kitu_temp2 = Pop(st);
			while(kitu_temp2 != '(')
			{
				temp.un[temp.so_unit].type = 1;
				temp.un[temp.so_unit].ptu.op = kitu_temp2;
				temp.so_unit++;
				kitu_temp2 = Pop(st);
			}
		}
	}
//b7:
	while(st.so_node != 0)
	{
		kitu_temp1 = Pop(st);
		if(kitu_temp1!='(' && kitu_temp1!=')')
		{
			temp.un[temp.so_unit].type = 1;
			temp.un[temp.so_unit++].ptu.op = kitu_temp1;
		}
	}

	return temp;
}


BIGINT Tinh_postfix(BIEUTHUC bt)
{
	BIGINT kq;
	
	for(int i=0 ; i<bt.so_unit ; i++)
	{
		if(bt.un[i].type == 1)
		{
			bt.un[i-2].ptu.data = Tinh(bt.un[i-2].ptu.data,bt.un[i-1].ptu.data,bt.un[i].ptu.op);
			Dichtrai_2nac(bt,i-1);
			i -= 2; //lui i lai 2 nac
		}
	}
	return kq = bt.un[0].ptu.data;
}


BIGINT Tinh_bieuthuc(BIEUTHUC bt)
{
	BIEUTHUC pf;
	pf = Chuyenve_postfix(bt);

	BIGINT kq;
	kq = Tinh_postfix(pf);

	return kq;
}

void Tinh_cacbieuthuc(BIEUTHUC bt[],int n)
{
	for(int i=0 ; i<n ; i++)
	{
		bt[i].giatri = Tinh_bieuthuc(bt[i]);
	}

}


// and not in this file
