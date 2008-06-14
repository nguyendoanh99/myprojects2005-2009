Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim i As Integer = 1
        Dim dem As Integer = 0
        While (i <= n)
            If (n Mod i = 0) Then
                dem += 1
            End If
            i += 1
        End While
        If (dem = 2) Then
            Console.WriteLine(n & " la so nguyen to")
        Else
            Console.WriteLine(n & " khong phai la so nguyen to")
        End If

    End Sub

End Module
