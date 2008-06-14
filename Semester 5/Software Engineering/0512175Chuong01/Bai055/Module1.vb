Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim t As Integer = n
        While (t >= 10)
            t \= 10
        End While

        Dim m As Integer = t
        t = n
        Dim dv As Integer
        Dim dem As Integer = 0
        While (t <> 0)
            dv = t Mod 10
            If (dv = m) Then
                dem += 1
            End If
            t \= 10
        End While
        Console.WriteLine("So luong chu so dau tien cua " & n & " la: " & dem)
    End Sub

End Module
