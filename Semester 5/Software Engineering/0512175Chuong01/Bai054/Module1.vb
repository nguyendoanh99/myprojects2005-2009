Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim t As Integer = n
        Dim donvi As Integer
        Dim min As Integer = t Mod 10
        Dim dem As Integer = 0
        While (t <> 0)
            donvi = t Mod 10
            If (donvi < min) Then
                min = donvi
                dem = 1
            Else
                If (min = donvi) Then
                    dem += 1
                End If
            End If
            t \= 10
        End While

        Console.WriteLine("So luong chu so nho nhat cua " & n & " la: " & dem)
    End Sub

End Module
