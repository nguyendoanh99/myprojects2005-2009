#include <iostream.h>
#include <fstream.h>

int A[1001]; // Mang chua day so cua de bai
int n; // So phan tu cua mang
int T[1001]; // T[i] = j la chi so j cua phan tu dung ngay truoc A[i] trong day ket qua
int D[1001]; // do dai cua day ket qua khi bai toan chi xet A1, ..., Ai

void Input(char *filename); // Doc file
void Output(char *filename); // Ghi file
void Tinh_T_D(); // Tinh mang T va mang D
void Xuat(int a[], int n); 
int MaxD(); // Tim vi tri i ma tai D[i] la lon nhat
int DanhDau(); // Danh dau ket qua vua tim duoc

void main()
{
	Input("BL.inp");
	Tinh_T_D();
	
	cout << "T ";
	Xuat(T, n);

	cout << "D ";
	Xuat(D, n);
	Output("BL.out");	
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);
	
	f >> n;
	for (int i = 1; i <= n; ++i)
		f >> A[i];
}

void Tinh_T_D()
{
	// Khoi tao gia tri ban dau
	T[1] = 0;
	D[1] = 1;

	for (int i = 2; i <= n; ++i)
	{
	// Tinh T[i], D[i]
		int dTemp = 0;
		int TTemp = 0;

		for (int j = 1; j < i; ++j)
			if (D[j] > dTemp && A[j] <= A[i])
			{
				dTemp = D[j];
				TTemp = j;
			}
		// T[i] = vi tri j co D[j] lon nhat trong so cac vi tri j thoa man A[j] <= A[i]
		// D[i] = D[j] + 1
		T[i] = TTemp;
		D[i] = dTemp + 1;
	}
}

int MaxD()
{
	// Tim vt voi D[vt] lon nhat, do chinh la phan tu cuoi cung cua day ket qua
	int vt = 1;
	for (int i = 2; i <= n; ++i)
		if (D[vt] < D[i])
			vt = i;

	return vt;
}

int DanhDau()
{
	// Day ket qua vua tim duoc se duoc danh dau bang cach cho D[i] am
	int dem = 0;
	int j = MaxD();
	
	do
	{
		D[j] = -D[j];
		j = T[j];
		++dem;		
	} while (j != 0);

	return dem;
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);

	int k = DanhDau();

	f << k << endl;
	int d = 0;
	for (int i = 1; i <= n; ++i)
		if (D[i] < 0)
		{
			f << A[i] << " ";
			++d;

			if (d == k) 				
				break;			

			if (d % 10 == 0)	
				f << endl;
			
		}
}

void Xuat(int a[], int n)
{
	for (int i = 1; i <= n; ++i)
		cout << a[i] << " ";
	cout << endl;
}
