Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim t As Integer = n
        Dim donvi As Integer
        Dim lc As Integer = t Mod 10
        While (t <> 0)
            donvi = t Mod 10
            If (donvi > lc) Then
                lc = donvi
            End If
            t \= 10
        End While

        Console.WriteLine("Chu so lon nhat cua " & n & " la: " & lc)
    End Sub

End Module
