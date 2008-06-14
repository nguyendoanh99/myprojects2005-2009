// Cap nhat 8/4/2007, 17:50
#include "CCayKhung.h"

CCayKhung::CCayKhung(): CDoThiMTK()
{
	TimCayKhung();
}

CCayKhung::CCayKhung(int n, int **A): CDoThiMTK(n, A)
{
	TimCayKhung();
}

CCayKhung::CCayKhung(const CCayKhung& P): CDoThiMTK(P)
{
	m_DuLieu = P.m_DuLieu;
}

CCayKhung::CCayKhung(const CDoThiMTK& P): CDoThiMTK(P)
{
	TimCayKhung();
}

CCayKhung::~CCayKhung()
{
}

CCayKhung& CCayKhung::operator =(const CCayKhung& P)
{
	CDoThiMTK::operator =(P);
	m_DuLieu = P.m_DuLieu;

	return *this;
}

CCayKhung& CCayKhung::operator =(const CDoThiMTK& P)
{
	CDoThiMTK::operator =(P);
	TimCayKhung();

	return *this;
}

int CCayKhung::TimCayKhung()
{
	// Tao ma tran de chua ket qua
	int n = LaySoDinh();

	if (n == 0)
		return 0;

	int **A = new int*[n + 1];
	
	for (int i = 1; i <= n; ++i)
	{
		A[i] = new int[n + 1];
		
		for (int j = 1; j <= n; ++j)
			A[i][j] = 0;
	}

	// Bat dau tim cay khung	
	int *arrTapDinh = new int[n];		// Chua cac dinh da chon
	bool *arrFlag = new bool[n + 1];		// arrFlag[i] = true: dinh i da co trong tap dinh
										// arrFlag[i] = false: dinh i chua co trong tap dinh
	int dem = 0;	// Cho biet so dinh da duoc chon vao tap dinh
	
	for (i = 0; i <= n; ++i)
		arrFlag[i] = false;
	// Dua dinh 1 vao tap dinh va danh dau dinh 1
	arrTapDinh[dem++] = 1;
	arrFlag[1] = true;

	i = 0;

	while (i < dem)
	{
		for (int j = 1; j <= n; ++j)
			if (LayCanhNoi(arrTapDinh[i], j) == 1 && arrFlag[j] == false && A[arrTapDinh[i]][j] == 0)
			{
				// Dua dinh j vao tap dinh, danh dau dinh j, tao canh noi giua i va j trong A
				arrTapDinh[dem++] = j;
				arrFlag[j] = true;
				A[arrTapDinh[i]][j] = A[j][arrTapDinh[i]] = 1;
			}
	
		++i;
	}

	if (dem == n) // Co cay khung
		m_DuLieu.Tao(n, A);
	else // Khong co cay khung
		m_DuLieu.Tao(0, A);

	// Thu hoi bo nho da cap phat
	for (i = 1; i <= n; ++i)
		delete []A[i];
	
	delete []arrTapDinh;
	delete []arrFlag;

	return dem == n;
}

int CCayKhung::Output(char *filename)
{
	return m_DuLieu.Output(filename);
}

int CCayKhung::Input(char *filename)
{
	int flag = CDoThiMTK::Input(filename);
	TimCayKhung();

	return flag;
}