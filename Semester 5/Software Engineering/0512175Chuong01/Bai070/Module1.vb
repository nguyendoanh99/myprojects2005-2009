Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim T As Double = 0
        Dim S As Double = 0
        Dim i As Integer = 1
        Dim P As Integer = -1
        While (i <= n)
            P = -P
            T += i
            S += P / T
            i += 1
        End While
        Console.WriteLine("S(" & n & ") = " & S)
    End Sub

End Module
