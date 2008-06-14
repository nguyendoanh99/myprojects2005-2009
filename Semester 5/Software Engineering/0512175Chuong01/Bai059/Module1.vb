Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim P As Integer = 0
        Dim t As Integer = n
        Dim donvi As Integer
        While (t <> 0)
            donvi = t Mod 10
            P = P * 10 + donvi
            t \= 10
        End While

        If (P = n) Then
            Console.WriteLine(n & " la so doi xung")
        Else
            Console.WriteLine(n & " khong phai la so doi xung")
        End If

    End Sub

End Module
