Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim flag As Boolean = True
        Dim t As Integer = n

        While (t <> 0)
            If (t Mod 2 = 0) Then
                flag = False
            End If
            t \= 10
        End While

        If (flag = True) Then
            Console.WriteLine(n & " toan chu so le")
        Else
            Console.WriteLine(n & " khong toan so le")
        End If

    End Sub

End Module
