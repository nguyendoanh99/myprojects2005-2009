class Example
	{
	 public:
	  int word;
	  Example(): word(0) {};
	};
class Couter
	{
	  int value;
	 public:
	  Couter(): value(0) {};
	  Couter(Example e): value(e.word) {};
	};
void foo(Couter c){};

void main()
{
 Example f;

 foo(f);
}