#include "CDijkstra_MTK.h"
#include "iostream.h"
void main()
{
	CDijkstra_MTK a;
	if (a.Input("dijkstra.txt"))
	{
		a.Output("0512175.txt");
	}
	else
		cout << "Khong mo duoc file";
}