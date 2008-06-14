Module Module1

    Sub Main()
        Dim n As Integer
        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim T As Integer = 1
        Dim i As Integer = 1
        While (i <= n)
            T *= i
            i += 1
        End While
        Console.WriteLine("T(" & n & ") = " & T)
    End Sub

End Module
