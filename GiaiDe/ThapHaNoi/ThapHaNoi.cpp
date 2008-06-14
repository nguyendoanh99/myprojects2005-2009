#include <iostream>
using namespace std;
int tong='A'+'B'+'C';
void ChuyenDia(int,char,char);
void main()
{
	ChuyenDia(4,'A','C');
}
void ChuyenDia(int n,char nguon,char dich)
{
	if (n==1)
		cout<<"dia "<<n<<" tu cot "<<nguon<<" sang cot "<<dich<<endl;
	else
	{
		ChuyenDia(n-1,nguon,tong-(nguon+dich));
		cout<<"dia "<<n<<" tu cot "<<nguon<<" sang cot "<<dich<<endl;
		ChuyenDia(n-1,tong-(nguon+dich),dich);
	}
}