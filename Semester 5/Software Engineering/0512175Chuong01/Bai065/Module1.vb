Module Module1

    Sub Main()
        Dim a As Double
        Dim b As Double
        Dim c As Double
        Dim kq As ArrayList = New ArrayList()

        Console.WriteLine("Giai phuong trinh bac 2 ax^2+bx+c=0 (a<>0)")
        Console.Write("Nhap a = ")
        a = Console.ReadLine()
        Console.Write("Nhap b = ")
        b = Console.ReadLine()
        Console.Write("Nhap c = ")
        c = Console.ReadLine()

        Dim delta As Double = b * b - 4 * a * c
        If (delta > 0) Then
            Dim temp As Double = Math.Sqrt(delta)
            kq.Add((-b + temp) / (2 * a))
            kq.Add((-b - temp) / (2 * a))
        Else
            If (delta = 0) Then
                kq.Add(-b / (2 * a))
            End If
        End If

        Select Case kq.Count
            Case 0
                Console.WriteLine("Phuong trinh vo nghiem")
            Case 1
                Console.WriteLine("Phuong trinh co nghiem kep x = " & kq(0))
            Case 2
                Console.WriteLine("Phuong trinh co 2 nghiem phan biet")
                Console.WriteLine("x1 = " & kq(0))
                Console.WriteLine("x2 = " & kq(1))
        End Select

    End Sub

End Module
