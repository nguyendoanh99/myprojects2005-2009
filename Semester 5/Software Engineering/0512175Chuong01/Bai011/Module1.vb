Module Module1

    Sub Main()
        Dim n As Integer
        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim S As Integer = 0
        Dim T As Integer = 1
        Dim i As Integer = 1
        While (i <= n)
            T *= i
            S += T
            i += 1
        End While
        Console.WriteLine("S(" & n & ") = " & S)
    End Sub

End Module
