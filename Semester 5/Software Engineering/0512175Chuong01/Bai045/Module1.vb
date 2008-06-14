Module Module1

    Sub Main()
        Dim n As Integer

        Console.Write("Nhap n = ")
        n = Console.ReadLine()

        Dim P As Integer = 1
        Dim t As Integer = n
        Dim donvi As Integer
        While (t <> 0)
            donvi = t Mod 10
            P *= donvi
            t \= 10
        End While

        Console.WriteLine("Tich cac chu so cua " & n & " la: " & P)
    End Sub

End Module
