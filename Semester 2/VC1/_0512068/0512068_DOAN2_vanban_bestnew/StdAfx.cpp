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

void Remove_head(BIGINT &b)
{
	if(b.pHead == NULL)
		return;

	NODE *p = b.pHead;
	b.pHead = b.pHead->pNext;
	b.pHead->pPrev = NULL;
	delete p;
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
int Input(BIGINT &b)
{
	char a[1000];
	fflush(stdin);
	gets(a); // nhap vao 1 chuoi kitu
	int l = strlen(a);
	int i = 0;
	int info;
	NODE *p;
	Init(b);
	b.dau = 1; // chu y

	// neu co dau o dau tien
	if(a[0] == '-')
	{
		b.dau = 0;
		i = 1;
	}
	else if(a[0] == '+')
	{
		b.dau = 1;
		i = 1;
	}

	// dua tung kitu_so vao b
	do
	{
		if(a[i]>57 || a[i]<48)
			return 0;
		else
		{
			info = a[i]-48;
			p = Get_node(info);
			Add_tail(b,p);
		}
		i++;
	}while(i < l);

	Refresh_bigint(b);
	return 1;

}


void Output(BIGINT b)
{
	if(b.dau == 0)
		printf("-");

	for(NODE *p=b.pHead ; p!=NULL ; p=p->pNext)
		printf("%d",p->info); 

}


/* Trog file vb , ma of kitu enter la 10 . If bt ket thuc = enter thi ko vde gi
nhug if ko thi bthuc do se ko luu dc bigint o vtri cuoi cug va bt do cug luu dc 
vao mang cac bt . Vi vay ta fai db luu y toi 2 thao tac cuoi cug of ham Read_file
Tuy nhien cug dat vde la if nguoi dung an nhieu fim enter sau moi bt thi ta se xu 
ly ntn ? De giai quyet vde nay ta se sdug them 1 chuc nag nua of kitu a1_truoc tai 
vtri xu li kitu enter nhu tren . Con ve kitu kcach thi ta ko can xet ,ko can dua no
vao trong bt . Tom lai , du lieu nguoi dug dua vao file co the mac suc xuong dog , 
mac suc kcach , nhug do o cho la khi so va toan tu vao ko hop le thi may van lam viec
va cho kq sai -> can cai tien viec krta hop le.
*/

// da ktra dc 2 toan tu lien nhau,2 bigint lien nhau(giua chung ko fai la 1 op),toan tu o dau
//,toan tu o cuoi
void Read_file(char *filename,BIEUTHUC bt[],int &n)
{
	char *a1; // doc tung kitu tu file
	a1 = new char[1000];
	int *a2;  // chua cac kitu_so de tao bigint
	a2 = new int[1000];
	char a1_truoc;  // luu lai kitu truoc a1+k
	int k = 0;  // chi so cua a1
	int i = 0;  // chi so cua a2
	int stt = 0;  // chi so cac ptu cua 1 bt
	n = 0;  // khoi gan so bt
	bt[n].kthl = 1;  // ban dau cho la bt thu 1 hop le 
	int flag = 0;   // ktra viec doc dc 2 bigint lien tiep

	FILE *f;
	f = fopen(filename,"rt");
	fscanf(f,"%c",a1+k);


	while(*(a1+k) > 0)
	{
		// th1: neu la kitu_so luu tam vao mang a2
		if(*(a1+k) >= 48 && *(a1+k) <= 57) 
		{	
			*(a2+i) = (int)*(a1+k) - 48;
			i++;
		}
		// th2: ko la kitu_so
		else 
		{
			if(i != 0) // lien truoc a1+k la 1 bigint thi dua bigint vao bt
			{
				if(flag == 0) // trc no la 1 toan tu
				{
					bt[n].un[stt].type = 0;				
					bt[n].un[stt].ptu.data = Create_bigint(a2,i);
					stt++;
					i = 0; // refresh a de chua cac kitu_so moi (*luuy)
					flag = 1;
				}
				else  //  ko fai la 1 toan tu
					bt[n].kthl = 0;
			}
			
			// dua toan tu vao bieu thuc
			if(*(a1+k)=='(' || *(a1+k)==')')
			{
				bt[n].un[stt].type = 2;
				bt[n].un[stt].ptu.op = *(a1+k);
				stt++;
				flag = 0;
			}
			else 
			{
				if(*(a1+k)=='+' || *(a1+k)=='-' || *(a1+k)=='*' || *(a1+k)=='/')
				{	
					if(a1_truoc=='+' || a1_truoc=='-' || a1_truoc=='*' || a1_truoc=='/')
						bt[n].kthl = 0;

					bt[n].un[stt].type = 1;
					bt[n].un[stt].ptu.op = *(a1+k);
					stt++;
					flag = 0;
				}
				if(*(a1+k)==10 && a1_truoc!=10) // la ki tu enter
				{
					bt[n].so_unit = stt;
					if(bt[n].un[0].type == 1) // if unit dau tien of bt la 1 op
						bt[n].kthl = 0;
					if(bt[n].un[stt-1].type == 1) // if unit cuoi cug of bt la 1 op
						bt[n].kthl = 0;
					n++;
					bt[n].kthl = 1;
					stt = 0; // refresh so thu tu 
					flag = 0;
				}
			}
		}
		
		a1_truoc = *(a1+k);
		k++;
		
		fscanf(f,"%c",a1+k);

	}

	// xu li cho bt cuoi neu khong ket thuc bang enter
	
	// dua so cuoi cung vao bt
	if(i != 0)
	{
		bt[n].un[stt].type = 0;
		bt[n].un[stt].ptu.data = Create_bigint(a2,i);
		stt ++;
	}
	// dua bt cuoi cung vao mang cac bt
	if( a1_truoc != 10) // if ket thuc = enter thi chac chan a1_truoc = 10 
	{
		bt[n].so_unit = stt;
		if(bt[n].un[0].type == 1) 
			bt[n].kthl = 0;
		n++; 
	}

	fclose(f);

}




void Xuat_ktra(BIEUTHUC bt[],int n)
{
	for(int i=0 ; i<n ; i++)
	{
		if(bt[i].so_unit == 0)
			printf("\n Bieu thuc rong!");
		if(bt[i].kthl == 0)
			printf("\n Bieu thuc thu %d ko hop le.",i+1);
		else
		{
			for(int j=0 ; j<bt[i].so_unit ; j++)
			{
				if(bt[i].un[j].type == 0)
					Output(bt[i].un[j].ptu.data);
				else if(bt[i].un[j].ptu.op=='+' || bt[i].un[j].ptu.op=='-' || bt[i].un[j].ptu.op=='*' || bt[i].un[j].ptu.op=='/')
					printf(" %c ",bt[i].un[j].ptu.op);
				else
					printf("%c",bt[i].un[j].ptu.op);
			}
		}
		printf("\n\n");
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
	Refresh_bigint(b);
	return b;
}


void Refresh_bigint(BIGINT &b)
{

	// bo cac so 0 o trc (neu co) nhung giu lai so 0 cuoi cung neu b=0
	while(b.pHead->info==0 && b.pHead->pNext!=NULL )
		Remove_head(b);

	// neu b=0 va b.dau=0 thi chuyen b.dau=1 (de khi xuat ko co dang -0)
	if(b.dau == 0)
		if(b.pHead->info == 0)
			b.dau = 1;

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
	if((a=='+'||a=='-') && (b=='*'||b=='/'))
		return -1;
	else
		return 0;
}
			
BIGINT Tinh(BIGINT b1,BIGINT b2,char x)
{
	BIGINT kq;
	if(x == '+')
		kq = b1+b2;
	else if(x == '-')
		kq = b1-b2;
	else if(x == '*')
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

	// # dau
	if(b1.dau != b2.dau)  
	{
		if(b1.dau == 0)
		{
			b1.dau = 1;
			b = b2-b1;
		}
		else
		{
			b2.dau = 1;
			b = b1-b2;
		}
	}
	// cung dau
	else
	{
		b.dau = b1.dau;  // xac dinh dau of b

		// thuc hien phep cong binh thuong
		NODE *p = b1.pTail;  
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

		if(p != NULL)   
			q = p; 
		while(q != NULL)
		{
			i = q->info + nho;
			r = Get_node(i%10);
			nho = i/10;
			Add_head(b,r);
			q = q->pPrev;
		}

		if(nho != 0) 
		{
			r = Get_node(nho);
			Add_head(b,r);
		}

	}

	Refresh_bigint(b);

	return b;
}
//Nhung loi tung sai :q=q->pNext ; if(q!=NULL) ; Get_node(1%10)



// II - Hieu 2 bigint
BIGINT Tru(BIGINT b1,BIGINT b2)
{
	BIGINT b;
	Init(b);

	// # dau
	if(b1.dau != b2.dau)  
	{
		if(b1.dau == 1)
			b2.dau = 1;		
		else
			b2.dau = 0;
		b = b1+b2;
	}
	// cung dau 
	else
	{
		// xac dinh dau of b
		if(Sosanh(b1,b2) == 1)  
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

		// thuc hien phep tru binh thuong
		NODE *p;   
		NODE *q;
		NODE *r;
		int nho = 0;
		int i;

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

	}

	Refresh_bigint(b);

	return b;
}
// Nhung loi tung sai : i<0 ; gop xac dinh dau of b va dam bao lay so lon tru so nho , xu li khi b1=b2 ; xet th nho!=0



// III - Tich 2 bigint
// The basic of all other development
BIGINT Nhan(BIGINT b1,BIGINT b2)
{
	BIGINT b,temp;
	Init(b);
	b.dau = 1; // phai mac dinh b trc de thuc hien phep cog chinh xac(temp.dau=1 va b.dau=1)
	int i = 0;

	for(NODE *p=b2.pTail ; p!=NULL ; p=p->pPrev)
	{
		temp = Nhan_khongdau(b1,p->info);
		Add_tail_0_nlan(temp,i);
		b = b+temp;
		i++;
	}

	if(b1.dau != b2.dau)
		b.dau = 0;

	Refresh_bigint(b);
	return b;
}
// Nhung loi tung sai : ko mac dinh dau b trc,xet dau b trc khi tinh gtri




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
	// # dau 
	if(b1.dau < b2.dau)
		return -1;
	else if(b1.dau > b2.dau)
		return 1;

	// cung dau -> # chieu dai
	if(Count_chuso(b1) > Count_chuso(b2))
		if(b1.dau == 1)
			return 1;
		else
			return -1;
	else if(Count_chuso(b1) < Count_chuso(b2))
		if(b1.dau == 1)
			return -1;
		else
			return 1;

	// cung chieu dai,cung dau
	NODE *p = b1.pHead;
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


/*
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
*/

BIEUTHUC Chuyenve_postfix(BIEUTHUC &bt)
{
	BIEUTHUC kq;
	kq.so_unit = 0;

	STACK st;
	Init_stack(st);
	st.so_node = 0;
	NODE_ST *p;
	int i=0 ;
	while(i < bt.so_unit)
	{
		// la '('
		if(bt.un[i].ptu.op == '(')
		{
			p = Getnode_stack('(');
			Push(st,p);
		}
		if(bt.un[i].ptu.op == ')')
		{
			for(int j=0 ; j<st.so_node && Pop(st)!='(' ; j++)
			{
				kq.un[kq.so_unit].type = 2;
				kq.un[kq.so_unit].ptu.op = Pop(st);
				kq.so_unit ++;
			}
		}
		if(bt.un[i].type == 1)
		{
			if(Do_uutien(bt.un[i].ptu.op,Top(st)) == 1 || Is_empty(st) == 1)
			{
				p = Getnode_stack(bt.un[i].ptu.op);
				Push(st,p);
			}
			else
			{
				kq.un[kq.so_unit].type = 1;
				kq.un[kq.so_unit].ptu.op = Pop(st);
				kq.so_unit ++;
			}
		}
		
	}

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
		if(bt[i].kthl == 1)
			bt[i].giatri = Tinh_bieuthuc(bt[i]);
	}

}


// and not in this file
