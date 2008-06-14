#include "LNgay.h"
#include "iostream.h"

void main()
{
	LNgay x,y,z,t;
	x.KhoiDong(1,1,2000);	
	y.KhoiDong(1,12,2000);
	z.KhoiDong(y);
	t.KhoiDong(1,2,2001);
	cout<<"x: ";
	x.In();
	cout<<endl<<"y: ";
	y.In();
	cout<<endl<<"z: ";
	z.In();
	cout<<endl<<"t: ";
	t.In();
	cout<<endl;
	cout<<"Tu dau nam cua x: "<<x.TuDauNam();
	cout<<"\nTu dau nam cua y: "<<y.TuDauNam();
	z.KhoiDong(28,12,2006);
	cout<<"\nTu dau cong nguyen cua z "<<z.TuDauCN();
	cout<<"\nKhoang cach giua y va t la "<<t.KhoangCach(y);
	cout<<"\nz: La thu "<<z.LaThu();
	int n=365;
	cout<<"\nx: Ngay tuong lai :";
	x.NgayTL(n).In();
	cout<<"\nx: Ngay qua khu :";
	x.NgayQK(n).In();
}