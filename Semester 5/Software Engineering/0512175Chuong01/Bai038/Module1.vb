Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim i As Integer = 1
        Dim S As Double = 0
        While (i <= n)
            S = Math.Pow(i + S, 1 / (i + 1))
            i += 1
        End While

        Console.WriteLine("S(" & n & ") = " & S)
    End Sub

End Module
