Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim i As Integer = 1
        Dim S As Integer = 0
        While (i < n)
            If (n Mod i = 0) Then
                S += i
            End If
            i += 1
        End While
        If (S = n) Then
            Console.WriteLine(n & " la so hoan thien")
        Else
            Console.WriteLine(n & "khong phai la so hoan thien")
        End If
    End Sub

End Module
