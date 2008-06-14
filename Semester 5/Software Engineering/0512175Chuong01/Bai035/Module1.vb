Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim i As Integer = n
        Dim S As Double = 0
        While (i > 0)
            S = Math.Sqrt(i + S)
            i -= 1
        End While

        Console.WriteLine("S(" & n & ") = " & S)
    End Sub

End Module
