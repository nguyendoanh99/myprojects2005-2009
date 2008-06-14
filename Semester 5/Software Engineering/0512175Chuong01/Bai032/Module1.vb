Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim i As Integer = 1
        Dim flag As Boolean = False

        While (i <= n)
            If (i * i = n) Then
                flag = True
            End If
            i += 1
        End While
        If (flag) Then
            Console.WriteLine(n & " la so chinh phuong")
        Else
            Console.WriteLine(n & " khong phai la so chinh phuong")
        End If

    End Sub

End Module
