#include <conio.h>
#include <stdio.h>
int n=5;
void minmax(...);
void main()
{
 float x,y;
 float a[5]={4,8,3,5,9};
 minmax(&x,&y,7.0,a[0],7.8,a[1],a[2]);
 printf("\n%3.3f %3.3f",x,y);
 getch();

}
void minmax(...)
{
 void *list=...;
 float *min,temp;
 float *max;
 min=*((float**)list)++;
 max=*((float**)list)++;
 *min=*max=(float)*((double*)list)++;
 for (int i=0;i<n-1;i++)
 {
  temp=(float)*((double*)list)++;
  if (temp>*max)
   *max=temp;
  else
   if (temp<*min)
    *min=temp;
 }
}