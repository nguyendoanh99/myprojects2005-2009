class Couter
{
  int value;
 public:
  Couter(): value(0) {};      // default constructor
  Couter(int i): value(i) {};   // Chuyen kieu tu int
  Couter(long l): value(l) {};  // Chuyen kieu tu long
  Couter(double d): value(d) {};// Chuyen kieu tu double
};
void foo(Couter &c){};

void main()
{
 Couter c;
 foo(1);
 foo(2l);
 foo(3.14);
 foo(c);
}