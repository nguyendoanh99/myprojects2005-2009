Module Module1

    Sub Main()
        Dim n As Integer
        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim S As Double = 1
        Dim i As Integer = 1
        While (i <= n)
            S += 1 / (i * 2 + 1)
            i += 1
        End While
        Console.WriteLine("S(" & n & ") = " & S)
    End Sub

End Module
