Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim t As Integer = n
        While (t >= 10)
            t \= 10
        End While

        Console.WriteLine("Chu so dau tien cua " & n & " la: " & t)
    End Sub

End Module
