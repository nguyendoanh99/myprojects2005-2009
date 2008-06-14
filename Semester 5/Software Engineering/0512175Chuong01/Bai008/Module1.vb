Module Module1

    Sub Main()
        Dim n As Integer
        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim S As Double = 0
        Dim i As Integer = 0
        While (i <= n)
            S += (2 * i + 1) / (2 * i + 2)
            i += 1
        End While
        Console.WriteLine("S(" & n & ") = " & S)
    End Sub

End Module
