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
            If (donvi Mod 2 = 0) Then
                tong += donvi
            End If
            t \= 10
        End While

        Console.WriteLine("Tong cac chu so chan cua " & n & " la: " & tong)
    End Sub

End Module