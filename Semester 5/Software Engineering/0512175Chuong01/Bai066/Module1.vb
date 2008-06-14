Module Module1

    Sub Main()
        Dim a As Double
        Dim b As Double
        Dim c As Double
        Dim kqtemp As ArrayList = New ArrayList()

        Console.WriteLine("Giai phuong trinh trung phuong bac 4 ax^4+bx^2+c=0 (a<>0)")
        Console.Write("Nhap a = ")
        a = Console.ReadLine()
        Console.Write("Nhap b = ")
        b = Console.ReadLine()
        Console.Write("Nhap c = ")
        c = Console.ReadLine()

        Dim delta As Double = b * b - 4 * a * c
        If (delta > 0) Then
            Dim temp As Double = Math.Sqrt(delta)
            kqtemp.Add((-b + temp) / (2 * a))
            kqtemp.Add((-b - temp) / (2 * a))
        Else
            If (delta = 0) Then
                kqtemp.Add(-b / (2 * a))
            End If
        End If

        Dim i As Integer = 0
        Dim kq As ArrayList = New ArrayList()
        While (i < kqtemp.Count)
            If (kqtemp(i) > 0) Then
                kq.Add(Math.Sqrt(kqtemp(i)))
                kq.Add(-Math.Sqrt(kqtemp(i)))
            Else
                If (kqtemp(i) = 0) Then
                    kq.Add(0)
                End If
            End If
            i += 1
        End While

        If (kq.Count = 0) Then
            Console.WriteLine("Phuong trinh vo nghiem")
        Else
            Console.WriteLine("Phuong trinh co " & kq.Count & "nghiem")
            i = 0
            While (i < kq.Count)
                Console.WriteLine("x" & i + 1 & " = " & kq(i))
                i += 1
            End While
        End If

    End Sub

End Module
