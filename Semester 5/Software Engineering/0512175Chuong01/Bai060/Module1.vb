Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim t As Integer = n
        Dim donvi As Integer
        Dim k As Integer = 10
        Dim flag As Boolean = True
        While (t <> 0)
            donvi = t Mod 10
            If (k > donvi) Then
                k = donvi
            Else
                flag = False
            End If
            t \= 10
        End While

        If (flag = True) Then
            Console.WriteLine(n & "tang dan")
        Else
            Console.WriteLine(n & "khong tang dan")
        End If

    End Sub

End Module
