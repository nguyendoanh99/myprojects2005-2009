Module Module1

    Sub Main()
        Dim n As Integer
        Dim x As Double

        Console.Write("Nhap x = ")
        x = Console.ReadLine()
        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim T As Double = x
        Dim S As Double = 0
        Dim i As Integer = 1
        While (i <= 2 * n + 1)
            S += T
            T *= x * x
            i += 2
        End While
        Console.WriteLine("S(" & x & "," & n & ") = " & S)
    End Sub

End Module
