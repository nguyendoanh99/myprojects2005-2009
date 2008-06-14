#include <stdio.h>
#include <conio.h>
#include <math.h>
struct DIEM
{
       float x;
       float y;
};
float xuly(DIEM[],int,float[],int);
float khoangcach(DIEM,DIEM);
void input(char *,DIEM [],int &,float [],int&);
void output(char *,float );
int main()
{
    DIEM mdiem[255];
    float bk[255];
    int n_diem;
    int n_bk;
    input("C:\BANKINH.INP",mdiem,n_diem,bk,n_bk);
    float bkinh=xuly(mdiem,n_diem,bk,n_bk);
    output("C:\BANKINH.OUT",bkinh);
    return 0;
}
float xuly(DIEM mdiem[],int n_diem,float bk[],int n_bk)
{
      DIEM min;
      DIEM max;
      min=max=mdiem[0];
      int i;
      for (i=0;i<n_diem;i++)
      {
          if (mdiem[i].x<min.x)
             min.x=mdiem[i].x;
          else
              if (mdiem[i].x>max.x)
                 max.x=mdiem[i].x;
          if (mdiem[i].y<min.y)
             min.y=mdiem[i].y;
          else
              if (mdiem[i].y>max.y)
                 max.y=mdiem[i].y;
      }
      
      DIEM tam;
      tam.x=(min.x+max.x)/2;
      tam.y=(min.y+max.y)/2;
      
      float _max=0;
      for (i=0;i<n_diem;i++)           
      {
          float d=khoangcach(tam,mdiem[i]);
          if (d>_max)
             _max=d;
      }            
      
      float bankinh=-1;
      for (i=0;i<n_bk;i++)
          if (_max<bk[i])
             if (bankinh=-1 || bankinh>bk[i])
                bankinh=bk[i];
      return bankinh;
}
float khoangcach(DIEM a,DIEM b)
{
      float dx=a.x-b.x;
      float dy=a.y-b.y;
      return sqrt(dx*dx+dy*dy);
}
void input(char *filename,DIEM mdiem[],int &n_diem,float bk[],int &n_bk)
{
     FILE *fp=fopen(filename,"rt");
     fscanf(fp,"%d",&n_diem);
     float t1;
     float t2;
     int i;
     for (i=0;i<n_diem;i++)
     {
         fscanf(fp,"%f %f",&t1,&t2);
         mdiem[i].x=t1;
         mdiem[i].y=t2;         
     }
     fscanf(fp,"%d",&n_bk);
     for (i=0;i<n_bk;i++)
     {
         fscanf(fp,"%f",&t1);
         bk[i]=t1;
     }
     fclose(fp);
}
void output(char *filename,float bk)
{
     FILE *fp=fopen(filename,"wt");
     fprintf(fp,"%.3f",bk);
     fclose(fp);
}
