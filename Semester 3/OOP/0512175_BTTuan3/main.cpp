// Ho ten: Nguyen Dang Khoa
// MSSV: 0512175
// Hoc ca 2 chieu thu 6

#include "LMangT.h"
	
void main()
{
	LMangT<float> t(4);	
	t[0] = 2;
	t[1] = 1;
	t[2] = 3;
	t[3] = 6;

	LMangT<float> q(t);
	
	cout << "Mang q moi khoi tao tu mang t: " << q << endl << endl;	

	cout << "Mang t chua sap xep: " << t << endl;	

	int i = 1;
	cout << "Vi tri cua so '" << i << "' trong mang t la : " << t.Tim(i) << endl;

	t.SapXep();
	cout << "Mang t sau khi da sap xep: " << t << endl;

	q = t;
	cout << endl << "Mang q sau khi gan: " << q << endl;

	cout << "Nhap mang q: "<<endl;
	cin >> q;
	cout << endl << "Mang q sau khi nhap lai: " << q;
}
