Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim dem As Integer = 0
        Dim t As Integer = n
        While (t <> 0)
            If (t Mod 2 <> 0) Then
                dem += 1
            End If
            t \= 10
        End While

        Console.WriteLine("So luong chu so le cua " & n & " la: " & dem)
    End Sub

End Module
