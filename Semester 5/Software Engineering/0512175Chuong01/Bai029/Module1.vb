Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim i As Integer = n
        While (i Mod 2 = 0)
            i = i \ 2
        End While
        Console.WriteLine("Uoc so le lon nhat cua  " & n & " la " & i)
    End Sub

End Module
