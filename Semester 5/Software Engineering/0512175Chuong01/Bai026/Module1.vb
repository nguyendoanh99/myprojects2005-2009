Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim i As Integer = 1
        Dim T As Integer = 1
        While (i <= n)
            If (n Mod i = 0 And i Mod 2 <> 0) Then
                T *= i
            End If
            i += 1
        End While
        Console.WriteLine("Tich uoc so le cua " & n & " la " & T)
    End Sub

End Module
