class Example
	{
	  long value;
	  int time;
	 public:
	  long getvalue() { return value; }
	  long gettime() { return time+value; }
	};
void main()
{
 long (Example::*fp)()=&Example::getvalue;
 Example e;
 long v=(e.*fp)();
 fp=&Example::gettime;
 long t=(e.*fp)();
}