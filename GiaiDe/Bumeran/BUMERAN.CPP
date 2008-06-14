#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <time.h>
struct INFO
{
       char *p;
       int n;
       int tong;
};
struct NODE 
{
       INFO info;
       NODE *pNext;
};
struct LIST 
{
       NODE *pHead;
       NODE *pTail;
};

LIST lst;
int kq;
FILE *fp;

NODE *getnode(INFO);
void addtail(LIST&,NODE *);
void enQueue(LIST&,INFO);
NODE *deQueue(LIST &);
void init(LIST&);
int isEmpty(LIST);
void input(char*);
void output(char*);
void bor();
void bor(NODE*);
void bof(NODE *);
void in(INFO);
int tim(NODE*,INFO);
int sosanh(INFO,INFO);
int main()
{
    input("C:\BUMERAN.INP");
    kq=0;
	fp=fopen("C:\BUMERAN.OUT","wt");
	time_t ltime1,ltime2;    
    time( &ltime1 );
	if (!isEmpty(lst))
	{
		bor();
		for (NODE *p=lst.pHead;p;p=p->pNext)
		{
			in(p->info);
			kq++;
		}
		bor(lst.pTail);
	}
	fprintf(fp,"\n%d",kq);
	printf("\n%d",kq);
	fclose(fp);
	time( &ltime2 );
	printf("\ntime=%d",ltime2-ltime1);
//	output("C:\BUMERAN.OUT");
//    getch();	
    return 0;   
}
void in(INFO f)
{
	int i=0;
	char *s=f.p;
     for (i=0;i<f.n;i++)
	 {
		printf("%d ",s[i]);
		fprintf(fp,"%d ",s[i]);
	 }
	if (s[0]==1)   
	{
		printf("F");
		fprintf(fp,"F");
	}
    else
	{
	 	printf("R");
		fprintf(fp,"R");
	}
     for (i=1;i<f.n;i++)
		if (s[i]-s[i-1]>0)       	
		{
			printf("F");
			fprintf(fp,"F");
		}
        else
		{
		 	printf("R");
			fprintf(fp,"R");
		}
 	printf("(%d)\n",f.tong);
	fprintf(fp,"(%d)\n",f.tong);
}
int sosanh(INFO f,INFO g)
{
	if (f.n!=g.n)
		return 0;
	for (int i=0;i<f.n;i++)
		if (f.p[i]!=g.p[i])
			return 0;
	return 1;
}
int tim(NODE *cur,INFO f)
{
	if (cur==NULL)
		return 0;
    for (NODE *p=cur->pNext;p;p=p->pNext)
        if (sosanh(p->info,f))
           return 1;
    return 0;
}
void bor()
{
	NODE *q;
	do     
     {           
           NODE *p=lst.pHead;
		   for (int j=0;j<p->info.n && p->info.p[j]>=0;j++);
		   if (j==p->info.n) 
			   return;
		   deQueue(lst);
           for (int i=j;i>0;i--)
               if (i==j || (p->info.p[i]-p->info.p[i-1]<0 &&	// s[i]='r'
				   p->info.p[i+1]-p->info.p[i]>0))	// s[i]='f'
               {
                  char *s=new char[p->info.n-1];
                  int tong=0;
                  int j=0;
                  for (j=0;j<i;j++)
                  {
                     s[j]=p->info.p[j];
                     tong+=s[j];
                  }
                  for (j=j+1;j<p->info.n;j++)
                  {
                      s[j-1]=p->info.p[j]+1;
                      tong+=s[j-1];                      
				  }	
				  INFO f;
                  f.p=s;
                  f.tong=tong;
                  f.n=p->info.n-1;
                  
                  if (!tim(lst.pHead,f))
				  {
//					  printf("kk ");
//					  in(f);
                      enQueue(lst,f);                  
				  }
                  else                  
                      delete[] s;                  
               }
           delete []p->info.p;
		   q=p;
           delete p;
     } while (1);
	 
}
void bor(NODE *cur)
{
	NODE *q;
	do     
     {           
           NODE *p=deQueue(lst);
           if (p->info.n==2)
              return;
           for (int i=p->info.n-2;i>0;i--)
               if (p->info.p[i]-p->info.p[i-1]<0 &&	// s[i]='r'
				   p->info.p[i+1]-p->info.p[i]>0)	// s[i]='f'
               {
                  char *s=new char[p->info.n-1];
                  int tong=0;
                  int j=0;
                  for (j=0;j<i;j++)
                  {
                     s[j]=p->info.p[j];
                     tong+=s[j];
                  }
                  for (j=j+1;j<p->info.n;j++)
                  {
                      s[j-1]=p->info.p[j]+1;
                      tong+=s[j-1];                      
				  }	
				  INFO f;
                  f.p=s;
                  f.tong=tong;
                  f.n=p->info.n-1;
                  
                  if (!tim(cur,f))
				  {
//					  in(f);
                      enQueue(lst,f);                  
				  }
                  else                  
                      delete[] s;                  
               }
           delete []p->info.p;
		   q=p;
           delete p;
     } while (q!=cur);
	 printf("\n");
	 fprintf(fp,"\n");
     bof(lst.pTail);
}
void bof(NODE *cur)
{     
	NODE *q;
	do
     
     {
           NODE *p=deQueue(lst);
           for (int i=p->info.n-2;i>0;i--)
               if (p->info.p[i]-p->info.p[i-1]>0 &&  // s[i]='f'
				   p->info.p[i+1]-p->info.p[i]<0)	// s[i]='r'
               {
                  char *s=new char[p->info.n-1];
                  int tong=0;
                  int j=0;
                  for (j=0;j<i;j++)
                  {
                     s[j]=p->info.p[j];
                     tong+=s[j];
                  }
				  int flag=1;
                  for (j=j+1;j<p->info.n;j++)
                  {
                      s[j-1]=p->info.p[j]-1;
					  if (s[j-1]<0)
					  {
						  flag=0;
						  break;
					  }
                      tong+=s[j-1];                     
				  }
				  INFO f;
                  f.p=s;
                  f.tong=tong;
                  f.n=p->info.n-1;
                  if (flag &&
					  !tim(cur,f))
                  {
					  kq++;                      
                      in(f);
                      enQueue(lst,f);
                  }
                  else                  
                      delete[] s;       
               }
           delete []p->info.p;
		   q=p;
           delete p;
     } while (q!=cur);

     bor(lst.pTail);
}
NODE *getnode(INFO info)
{
     NODE *p=new NODE;
     p->info=info;
     p->pNext=NULL;
     return p;
}
void addtail(LIST &l,NODE *p)
{
     if (l.pHead==NULL)
        l.pHead=l.pTail=p;
     else
     {
         l.pTail->pNext=p;
         l.pTail=p;
     }
}
void enQueue(LIST &l,INFO f)
{
     NODE *p=getnode(f);
     addtail(l,p);
}
NODE *deQueue(LIST &l)
{
     NODE *p=NULL;
     p=l.pHead;
     if (l.pHead)
          l.pHead=l.pHead->pNext;
	 if (l.pHead==NULL)
		 l.pTail=NULL;
     return p;
}
void init(LIST &l)
{
     l.pHead=l.pTail=NULL;
}
int isEmpty(LIST l)
{
     return l.pHead==NULL;
}
void input(char *filename)
{
     FILE *fp=fopen(filename,"rt");
     char s[255];
     fgets(s,255,fp);
     init(lst);
     int t=0;
     int tong=0;
	 // Bo F o ben trai cua s
	 for (int j=strlen(s)-1;j>=0 && s[j]=='F';j--)
		 ;
	 s[j+1]=0;
	 // Bo R o ben phai cua s
	 for (j=0;j<strlen(s) && s[j]=='R';j++);	 
     INFO f;
     int len=strlen(s)-j;
     f.p=new char[len];
     f.n=len;
     for (int i=j;i<strlen(s);i++)
     {
         if (s[i]=='F')
            t++;
         else       
            t--;
         f.p[i-j]=t;
         tong+=t;         
     }
     f.tong=tong;
	 if (f.n>0)
		enQueue(lst,f);     
     fclose(fp);
}
void output(char *filename)
{
     FILE *fp=fopen(filename,"wt");
	 fprintf(fp,"%d",kq);
     fclose(fp);
}
