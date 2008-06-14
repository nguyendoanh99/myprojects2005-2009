#include <graphics.h>
#include <stdio.h>
#include <conio.h>

int x,y,h;

void A(int );
void B(int );
void C(int );
void D(int );

void A(int i)
{
	if (i>0)
	{
		D(i-1);
		x=x-h;
		lineto(x,y);

		A(i-1);
		y=y+h;
		lineto(x,y);

		A(i-1);
		x=x+h;
		lineto(x,y);

		B(i-1);
	}
}

void B(int i)
{
	if (i>0)
	{
		C(i-1);
		y=y-h;
		lineto(x,y);

		B(i-1);
		x=x+h;
		lineto(x,y);

		B(i-1);
		y=y+h;
		lineto(x,y);

		A(i-1);
	}
}

void C(int i)
{
	if (i>0)
	{
		B(i-1);
		x=x+h;
		lineto(x,y);

		C(i-1);
		y=y-h;
		lineto(x,y);

		C(i-1);
		x=x-h;
		lineto(x,y);

		D(i-1);
	}
}

void D(int i)
{
	if (i>0)
	{
		A(i-1);
		y=y+h;
		lineto(x,y);

		D(i-1);
		x=x-h;
		lineto(x,y);
		
		D(i-1);
		y=y-h;
		lineto(x,y);

		C(i-1);
	}
}

void main()
{
	int gd,gm;
	int i;
	gd=DETECT;
	initgraph(&gd,&gm,"e:\\borlandc\\bgi");
	if (graphresult()!=grOk)
	{
		printf("Graphic mode failed!");
		return;
	}
	x=500;
	y=0;
	h=5;
	moveto(x,y);
	A(6);
	getch();
	closegraph();
}