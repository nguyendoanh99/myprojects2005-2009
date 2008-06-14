#include <graphics.h>
#include <stdio.h>
#include <conio.h>

void A(int );
void B(int );
void C(int );
void D(int );

int x,y,h;
void A(int i)
{
	if (i>0)
	{
		A(i-1);
		x=x+h;
		y=y+h;
		lineto(x,y);
		
		B(i-1);
		x=x+2*h;
		lineto(x,y);

		D(i-1);
		x=x+h;
		y=y-h;
		lineto(x,y);

		A(i-1);
	}
}

void B(int i)
{
	if (i>0)
	{
		B(i-1);
		x=x-h;
		y=y+h;
		lineto(x,y);

		C(i-1);
		y=y+2*h;
		lineto(x,y);

		A(i-1);
		x=x+h;
		y=y+h;
		lineto(x,y);

		B(i-1);
	}
}

void C(int i)
{
	if (i>0)
	{
		C(i-1);
		x=x-h;
		y=y-h;
		lineto(x,y);

		D(i-1);
		x=x-2*h;
		lineto(x,y);

		B(i-1);
		x=x-h;
		y=y+h;
		lineto(x,y);

		C(i-1);
	}
}

void D(int i)
{
	if (i>0)
	{
		D(i-1);
		x=x+h;
		y=y-h;
		lineto(x,y);

		A(i-1);
		y=y-2*h;
		lineto(x,y);
		
		C(i-1);
		x=x-h;
		y=y-h;
		lineto(x,y);

		D(i-1);
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
	x=10;
	y=0;
	h=7;
	i=4;
	moveto(x,y);
	A(i);
	x=x+h;
	y=y+h;
	lineto(x,y);

	B(i);
	x=x-h;
	y=y+h;
	lineto(x,y);

	C(i);
	x=x-h;
	y=y-h;
	lineto(x,y);

	D(i);
	x=x+h;
	y=y-h;
	lineto(x,y);

	getch();
	closegraph();
}