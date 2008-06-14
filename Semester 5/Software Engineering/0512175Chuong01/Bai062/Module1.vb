Module Module1

    Sub Main()
        Dim a As Integer
        Dim b As Integer

        Console.Write("Nhap a = ")
        a = Console.ReadLine()
        Console.Write("Nhap b = ")
        b = Console.ReadLine()

        Dim m As Integer = a
        Dim n As Integer = b
        Dim temp As Integer
        While (n <> 0)
            temp = m Mod n
            m = n
            n = temp
        End While

        Dim ucln As Integer = m

        Console.Write("UCLN(" & a & "," & b & ") = " & ucln)
    End Sub

End Module
