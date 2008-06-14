Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim i As Integer = 1
        Dim S As Integer = 0
        While (i <= n)
            If (n Mod i = 0) Then
                S += i
            End If
            i += 1
        End While
        Console.WriteLine("Tong uoc so cua " & n & " la " & S)
    End Sub

End Module
