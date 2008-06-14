using System;
class MainClass
{
    static void Main()
    {
        Console.WriteLine(+5);        // unary plus
        Console.WriteLine(5 + 5);     // addition
        Console.WriteLine(5 + .5);    // addition
        Console.WriteLine("5" + "5"); // string concatenation
        Console.WriteLine(5.0 + "5"); // string concatenation
        // note automatic conversion from double to string
    }
}
