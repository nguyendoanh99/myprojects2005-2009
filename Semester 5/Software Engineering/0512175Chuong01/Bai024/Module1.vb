Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()
        Console.WriteLine("Cac uoc so le cua " & n & " la ")
        Dim i As Integer = 1
        While (i <= n)
            If (n Mod i = 0 And i Mod 2 <> 0) Then
                Console.Write(i & " ")
            End If
            i += 1
        End While
    End Sub

End Module
