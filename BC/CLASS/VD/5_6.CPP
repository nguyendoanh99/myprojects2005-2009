class M
	{
	 public:
	  int value;
	  M(int i): value(i) {}
	  M(char *cp): value(0) {}
	  M operator+(M);
	};

void main()
{
 M m1(3),m2(10),m3();
 m1=m2+"ABC";
 m1="ABC"+m2; 	// Loi
}

M M::operator+(M m)
{
 return M(value+m.value);
}