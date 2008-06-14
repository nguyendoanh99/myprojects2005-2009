Module Module1

    Sub Main()
        Dim n As Integer
        Dim x As Double

        Console.Write("Nhap x = ")
        x = Console.ReadLine()
        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim T As Double = 1
        Dim K As Double = 0
        Dim S As Double = 0
        Dim i As Integer = 1
        While (i <= n)
            T *= x
            K += i
            S += T / K
            i += 1
        End While
        Console.WriteLine("S(" & x & "," & n & ") = " & S)
    End Sub

End Module
