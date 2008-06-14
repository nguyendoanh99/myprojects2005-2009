Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim S As Integer = 0
        Dim k As Integer = 0
        While (S < n)
            k += 1
            S += k
        End While

        Console.WriteLine("K = " & k)
    End Sub

End Module
