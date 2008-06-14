Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim tong As Integer = 0
        Dim t As Integer = n
        Dim donvi As Integer
        While (t <> 0)
            donvi = t Mod 10
            tong += donvi
            t \= 10
        End While

        Console.WriteLine("Tong cac chu so cua " & n & " la: " & tong)
    End Sub

End Module
