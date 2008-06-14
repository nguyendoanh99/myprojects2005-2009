Module Module1

    Sub Main()
        Dim a As Double
        Dim b As Double
        Dim x As Double

        Console.Write("Nhap a = ")
        a = Console.ReadLine()
        Console.Write("Nhap b = ")
        b = Console.ReadLine()

        If (a = 0) Then
            If (b = 0) Then
                Console.WriteLine("Phuong trinh vo so nghiem")
            Else
                Console.WriteLine("Phuong trinh vo nghiem")
            End If
        Else
            x = -b / a
            Console.WriteLine("Phuong trinh co 1 nghiem x = " & x)
        End If
    End Sub

End Module
