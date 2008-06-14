Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim P As Integer = 0
        Dim t As Integer = n
        Dim donvi As Integer
        While (t <> 0)
            donvi = t Mod 10
            P = P * 10 + donvi
            t \= 10
        End While

        Console.WriteLine("So dao nguoc cua " & n & " la: " & P)
    End Sub

End Module
