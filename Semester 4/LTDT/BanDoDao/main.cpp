#include "CBanDoDao.h"

void main()
{
	CBanDoDao a;
	a.Input("bando.txt");
	cout << "So dao : " << a << endl;
	a.Output("dao.txt");

}