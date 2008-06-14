Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim t As Integer = n
        Dim flag As Boolean = True
        If (t > 0) Then
            While (t <> 1)
                If (t Mod 2 <> 0) Then
                    flag = False
                    t = 1
                Else
                    t \= 2
                End If

            End While
        Else
            flag = False
        End If
        If (flag = True) Then
            Console.WriteLine(n & " co dang 2^k")
        Else
            Console.WriteLine(n & " khong co dang 2^k")
        End If

    End Sub

End Module
