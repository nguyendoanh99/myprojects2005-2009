#ifndef _CHUOI_
#define _CHUOI_

class LChuoi
{
private:
	char *p;
	int n;
public:
	LChuoi();
	LChuoi(char *);
	LChuoi(const LChuoi&);
	~LChuoi();
	LChuoi operator+(const LChuoi&);
	LChuoi& operator=(const LChuoi&);
};
#endif