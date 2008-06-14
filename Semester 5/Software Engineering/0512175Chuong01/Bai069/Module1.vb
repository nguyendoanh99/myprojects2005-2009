Module Module1

    Sub Main()
        Dim n As Integer
        Dim x As Double

        Console.Write("Nhap x = ")
        x = Console.ReadLine()
        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim T As Double = x
        Dim S As Double = x
        Dim i As Integer = 3
        While (i <= 2 * n + 1)
            T = -T * x * x
            S += T
            i += 2
        End While
        Console.WriteLine("S(" & x & "," & n & ") = " & S)
    End Sub

End Module
