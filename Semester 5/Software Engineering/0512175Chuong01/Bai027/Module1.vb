Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim i As Integer = 1
        Dim dem As Integer = 0
        While (i <= n)
            If (n Mod i = 0 And i Mod 2 = 0) Then
                dem += 1
            End If
            i += 1
        End While
        Console.WriteLine("So luong uoc so chan cua " & n & " la " & dem)
    End Sub

End Module
