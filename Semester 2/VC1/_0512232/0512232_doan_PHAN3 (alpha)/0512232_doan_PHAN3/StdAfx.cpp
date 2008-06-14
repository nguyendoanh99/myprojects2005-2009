// stdafx.cpp : source file that includes just the standard includes
//	0512232_doan_PHAN1.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H

void init(BigInt &l)
{
	l.pHead=NULL;
	l.pTail=NULL;
	l.sign=0;
}



NODE *getnode1(unsigned char x)
{
	NODE *p;

	p=new NODE;
	if(p==NULL)
		return NULL;
	
	p->t.cinfo = x;
	p->pNext=NULL;
	p->pPrev=NULL;
	return p;
}

NODE *getnode2(char *x)
{
	NODE *p;
	
	p=new NODE;
	if(p==NULL)
		return NULL;
	p->t.sinfo = x;
	p->pNext=NULL;
	p->pPrev=NULL;
	return p;
}

void addtail(BigInt &l,NODE *p)
{
	if(l.pTail == NULL)
		l.pHead = l.pTail = p;
	else
	{
		l.pTail->pNext = p;
		p->pPrev = l.pTail;
		l.pTail = p;
	}
}

void addhead(BigInt &l,NODE *p)
{
	if(l.pHead == NULL)
		l.pHead = l.pTail = p;
	else
	{
		p->pNext = l.pHead;
		l.pHead->pPrev = p;
		l.pHead = p;
	}
}

int ktlatoantu(char x)
{
	if(x=='+' || x=='-' || x=='*' || x=='(' || x==')')
		return 1;
	return 0;
}

int OPERATION(char *filename)
{
	BigInt bieuthuc;
	init(bieuthuc);
	FILE *fp = fopen(filename,"rt");
	if(!fp)
		return 0;
	
	char *x;
	char *u;
	x=new char[100];
	u=new char[100];
	if(fscanf(fp,"%s",u) == 0)
			return 0;
	do
	{
		strcpy(x,u);
		int n=strlen(x);
		do
		{
			tach_to_bigint(x,bieuthuc);
			if(fscanf(fp,"%s",u) == -1)
				break;
			//if((bieuthuc.pTail->t.sinfo == ")") && (u[0] == '('))
				//break;
			if(x[n-1] == ')' && u[0] == '(')
				break;
			char *y=new char;
			strcpy(y,u);
			NODE *p=getnode2(y);		// ***** neu getnode2(x) thi khi tro ve dieu kien lap : x thay doi --> pTail thay doi, nguy hiem, nguy hiem !!
			addtail(bieuthuc,p);
			fscanf(fp,"%s",x);
			n=strlen(x);
		}while(1);
		
		bieuthuc.pHead=bieuthuc.pHead->pNext;
		bieuthuc.pTail=bieuthuc.pTail->pPrev;
		bieuthuc.pTail->pNext=NULL;
		printf("\n");
		output_s(bieuthuc);
		BigInt k=hauto(bieuthuc.pHead,bieuthuc.pTail);
		BigInt kq=tinhmotbieuthuc(k);
		printf(" = ");
		output_c(kq);
		init(bieuthuc);
	}while(feof(fp) == 0);
	fclose(fp);
	return 1;
}


void tach_to_bigint(char *x,BigInt &bieuthuc)
{
	NODE *p;
	int n=strlen(x);
	if(x[0] == '(')
	{
		for(int i=0;x[i] == '(';i++)
		{
			char *y=new char[2];
			y[0]=x[i];
			y[1]=NULL;
			
			p=getnode2(y);
			addtail(bieuthuc,p);
		}
		char *y = new char[n];
		for(int t=0;i<n;i++,t++)
			y[t] = x[i];
		y[t]=NULL;
		
		p=getnode2(y);
		addtail(bieuthuc,p);
	}

	else if(x[n-1] == ')')
	{	
		char *y=new char[n];
		for(int i=0;x[i] != ')';i++)
			y[i] = x[i];
	
		y[i]=NULL;
		p=getnode2(y);
		addtail(bieuthuc,p);
		for(;i<n;i++)
		{
			char *y=new char[2];
			y[0]=x[i];
			y[1]=NULL;
			p=getnode2(y);
			addtail(bieuthuc,p);
		}
	}
}

void output_s(BigInt l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
	{
		
		printf(" %s ",p->t.sinfo);
	}
}


void output_c(BigInt l)
{
	for(NODE *p=l.pHead ; p->t.cinfo == 0 && p->pNext != NULL; p=p->pNext);
	if(l.sign == 1 && p->t.cinfo != 0)
		printf("-");
	
	for(;p;p=p->pNext)
		printf("%d",p->t.cinfo);
}

BigInt hauto(NODE *q,NODE *p)
{
	//NODE *t=q;
//	NODE *u=p;
	BigInt stack,hauto;
	init(stack);
	init(hauto);
	
	while(q)
	{
		if(ktlatoantu(q->t.sinfo[0]))
		{
			if(q->t.sinfo[0] == ')')
			{
				while(1)
				{
					NODE *k=pop(stack);
					if(k->t.sinfo[0] != '(')
						addtail(hauto,k);
					else
						break;
				}
			}
		
			else
			{	
				NODE *temp=new NODE;
				*temp=*q;
				temp->pNext=temp->pPrev=NULL;
				push(stack,temp);
			}
		}
		else
		{
			
			NODE *temp=new NODE;
			*temp=*q;
			temp->pNext=temp->pPrev=NULL;
			addtail(hauto,q);
		}
		q=q->pNext;
	}
	while(!IsEmpty(stack))
	{
		NODE *p=pop(stack);
		addtail(hauto,p);
	}
	return hauto;
}


BigInt CreateBigInt(char *x)
{
	BigInt l;
	init(l);
	int n=strlen(x);
	for(int i=0;i<n;i++)
	{
		unsigned char a=x[i] - 48;
		//char s[2]={x[i],NULL};
		//unsigned char a=atoi(s);
		NODE *p=getnode1(a);
		addtail(l,p);
	}
	return l;
}


BigInt tinhmotbieuthuc(BigInt l)
{
	BigInt g;
	init(g);
	BigInt stack[100];
	int t=0;
	
	for(NODE *p=l.pHead;p;p=p->pNext)
	{
		char x=p->t.sinfo[0];
  		if(!ktlatoantu(x))
		{
			BigInt temp=CreateBigInt(p->t.sinfo);
			push_bigint(stack,t,temp);
		}
		else
		{
			BigInt q=pop_bigint(stack,t);
			BigInt r=pop_bigint(stack,t);
			g=tinh2xau(r,q,x);
			remove_0(g);        // loai nhung so 0 o dau va mac dinh 0 la so duong
			push_bigint(stack,t,g);
			
		}
	}
	return g;
}


BigInt tinh2xau(BigInt l,BigInt h,char x)
{
	BigInt kq;
	init(kq);
	if(x == '+')
	{
		if(l.sign == 0)
			kq=l+h;
		else
		{
			if(sosanh2soduong(l,h) == 1)
			{
				kq=l-h;
				kq.sign = 1;
			}
			else if(sosanh2soduong(l,h) == -1)
				kq=h-l;
			else
			{
				NODE *p=getnode1(0);
				addtail(l,p);
			}
		}
	}
	else if(x == '-')
	{
		if(l.sign == 1)
		{
			kq=l+h;
			kq.sign = 1;
		}
		else
		{
			if(sosanh2soduong(l,h) == 1)
				kq=l-h;
			else if(sosanh2soduong(l,h) == -1)
			{
				kq=h-l;
				kq.sign = 1;
			}
			else
			{
				NODE *p=getnode1(0);
				addtail(kq,p);
			}
		}
	}
	else   // x=='*';
	{
		kq=l*h;
		kq.sign = l.sign;
	}
	return kq;
}

void remove_0(BigInt &l)
{
	for(NODE *p=l.pHead;p->t.cinfo==0 && p->pNext!=NULL;p=p->pNext);
	l.pHead = p;
	l.pHead->pPrev = NULL;
	if(l.pHead->t.cinfo == 0)
		l.sign = 0;
}


/*
BigInt tinhmotbieuthuc(char *a[],int n)
{
	BigInt l;
	BigInt h;
	init(l);
	init(h);
	taoxautuchuoi(l,a[0]);
	int i=1;
	while(i<n)
	{
		char toantu=a[i][0];
		i++;
		taoxautuchuoi(h,a[i]);
		i++;
		if(toantu == '+')
		{
			if(l.sign == 1)
			{
				if(sosanh2soduong(l,h) == -1)
				{
					l = h - l;
					l.sign = 0;
				}
				else if(sosanh2soduong(l,h) == 1)       ///// !!!!!!! chu y
				{
					l = l - h;
				}
				else
				{
					l = l - h;
					l.sign = 0;
				}
			}
			else
				l = l + h;
		}
		if(toantu == '-')
		{
			if(l.sign == 1)
			{
				l = l + h;
				l.sign = 1;
			}
			else
			{
				if(sosanh2soduong(l,h) == -1)
				{
					l = h - l;
					l.sign = 1;
				}
				else
				{
					l = l - h;
				}
			
			}
		}
	}
	return l;
}
*/
int IsEmpty(BigInt stack)
{
	if(stack.pHead == NULL)
		return 1;
	return 0;
}

void push(BigInt & stack,NODE *p)
{
	addhead(stack,p);
}

NODE *pop(BigInt & stack)
{
	if(IsEmpty(stack))
		return NULL;
	NODE *x=stack.pHead;
	stack.pHead = stack.pHead ->pNext;
	x->pNext = x->pPrev = NULL;
	return x;
}

void push_bigint(BigInt stack[],int &t,BigInt x)
{
	stack[t] = x;
	t++;
}

BigInt pop_bigint(BigInt stack[],int &t)
{
	t--;
	BigInt x=stack[t];
	return x;
}

/*char *pop_char(BigInt &stack)
{
	if(IsEmpty(stack))
		return NULL;
	char *x=stack.pHead->t.sinfo;
	stack.pHead = stack.pHead ->pNext;
	return x;
}
*/
/*int kiemtrauutien(char x,char y)
{
	if(y==NULL || (x == '(') || (x == '*' && y != '*'))
		return 1;
	return 0;
}*/


BigInt operator + (BigInt &l,BigInt h)
{

	unsigned char nho = 0;
	unsigned char x;
	NODE *p=l.pTail;
	NODE *q=h.pTail;
	while(p && q)
	{
		x=p->t.cinfo + q->t.cinfo + nho;
		if(x>=10)
			nho=1;
		else
			nho=0;
		p->t.cinfo = x%10;
		p=p->pPrev;
		q=q->pPrev;
	}
	while(p != NULL)
	{
		if(p->t.cinfo == 9 && nho == 1)
		{
			p->t.cinfo = 0;
			nho=1;
		}
		else
		{
			x=p->t.cinfo + nho;
			p->t.cinfo = x;
			nho=0;
		}
		p=p->pPrev;
	}
	while(q != NULL)
	{
		NODE *k;
		if(q->t.cinfo == 9 && nho == 1)
		{
			k=getnode1(0);
			addhead(l,k);
			nho=1;
		}
		else
		{
			x= q->t.cinfo + nho;
			k=getnode1(x);
			addhead(l,k);
			nho=0;
		}
		q=q->pPrev;
	}
	if(nho == 1)
	{
		NODE *k=getnode1(nho);
		addhead(l,k);
	}
	return l;
}


BigInt operator - (BigInt &l,BigInt h)
{
	
	char nho=0;
	unsigned char x;
	NODE *p=l.pTail;
	NODE *q=h.pTail;

	while(p && q)
	{
		if(p->t.cinfo >= (q->t.cinfo + nho) )
		{
			x=p->t.cinfo - q->t.cinfo - nho;
			nho=0;
		}
		else
		{
			x= 10 + p->t.cinfo - q->t.cinfo - nho;
			nho=1;
		}

		p->t.cinfo=x;
		p=p->pPrev;
		q=q->pPrev;
	}

	while(p != NULL)
	{
		if( p->t.cinfo < nho)
		{
			x= 10 - nho;
			nho = 1;
			p->t.cinfo = x;
		}
		else
		{
			x= p->t.cinfo - nho;
			nho = 0;
			p->t.cinfo = x;
		}

		p=p->pPrev;
	}
	return l;

}


BigInt operator*(BigInt l,BigInt h)
{
	BigInt tich;
	BigInt g;
	init(g);
	int dem=0;
	int temp=0;

	for(NODE *q=h.pTail;q;q=q->pPrev)
	{
		tich=nhanxauvoiso(l,q->t.cinfo);
		while(temp)
		{
			NODE *k=getnode1(0);
			addtail(tich,k);
			temp--;
		}
		dem++;
		temp=dem;
		g=g+tich;
	}

	return g;
}

BigInt nhanxauvoiso(BigInt l,unsigned char k)
{
	BigInt g;
	init(g);
	unsigned char x;
	unsigned char nho = 0 ;
	NODE *t;

	for(NODE *p=l.pTail;p;p=p->pPrev)
	{
		x =  k * p->t.cinfo + nho;
		t=getnode1(x%10);
		addhead(g,t);
		nho = x/10;
	}

	if(nho != 0)
	{
		t=getnode1(nho);
		addhead(g,t);
	}

	return g;
}

int sosanh2soduong(BigInt l,BigInt h)
{
	NODE *p=l.pTail;
	NODE *q=h.pTail;
	while(p && q)
	{
		p=p->pPrev;
		q=q->pPrev;
	}
	if(p != NULL)
		return 1;
	if(q != NULL)
		return -1;
	for(p=l.pHead, q=h.pHead; p && q; p=p->pNext, q=q->pNext)
	{
		if(p->t.cinfo > q->t.cinfo)
			return 1;
		if(p->t.cinfo < q->t.cinfo)
			return -1;
	}
	return 0;
}





