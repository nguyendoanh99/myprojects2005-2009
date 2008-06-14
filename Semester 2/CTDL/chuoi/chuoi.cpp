// chuoi.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

int main(int argc, char* argv[])
{
	char s[30],d[30];
	strcpy(d,"Nguyen");
	strncpy(s,"Nguyen",3);
	strcat(s,"Dang Khoa");
	strncat(s,"Nguyen",01);
	strlwr(d);
	strlwr(d);
	int t=strlen("");
	return 0;
}
