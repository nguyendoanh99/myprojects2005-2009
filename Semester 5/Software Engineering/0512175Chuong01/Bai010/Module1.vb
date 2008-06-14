Module Module1

    Sub Main()
        Dim n As Integer
        Dim x As Double

        Console.Write("Nhap x = ")
        x = Console.ReadLine()
        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim T As Double = 1
        Dim i As Integer = 1
        While (i <= n)
            T *= x
            i += 1
        End While
        Console.WriteLine("T(" & x & "," & n & ") = " & T)
    End Sub

End Module
