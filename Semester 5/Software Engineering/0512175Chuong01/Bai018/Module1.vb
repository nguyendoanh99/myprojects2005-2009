Module Module1

    Sub Main()
        Dim n As Integer
        Dim x As Double

        Console.Write("Nhap x = ")
        x = Console.ReadLine()
        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim T As Double = 1
        Dim K As Double = 1
        Dim S As Double = 1
        Dim i As Integer = 2
        While (i <= 2 * n)
            T *= x * x
            K *= i * (i - 1)
            S += T / K
            i += 2
        End While
        Console.WriteLine("S(" & x & "," & n & ") = " & S)
    End Sub

End Module
