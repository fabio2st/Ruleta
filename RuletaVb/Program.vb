Imports System

Module Program
    Const totalNumbers As Byte = 36
    Enum Columns
        derecha
        central
        izquierda
    End Enum
    Sub Main(args As String())
        Dim value As String
        Dim boardNumbers As String() = GetBoard()
        Dim numbers As UShort() = New UShort(35) {}
        Do
            value = InputValue()

            Select Case value
                Case "*"
                    FinalReport(numbers)
                Case "0"
                    Console.WriteLine("Jugada anulada")
                Case Else
                    If IsNumber(value, boardNumbers) Then
                        Dim number As Byte = Convert.ToByte(value)
                        ReportNumber(number)
                        CountNumber(number, numbers)
                    Else
                        Console.WriteLine("Valor incorrecto")
                    End If
            End Select
        Loop Until value = "*"
    End Sub
    Sub FinalReport(ByVal numbers As UShort())
        For i As Integer = 0 To numbers.Length - 1
            If numbers(i) > 0 Then Console.WriteLine($"{i + 1} -> {numbers(i)}")
        Next
    End Sub
    Sub CountNumber(ByVal number As Byte, ByVal numeros As UShort())
        numeros(number - 1) += 1
    End Sub
    Function InputValue() As String
        Dim value As String
        Console.Write("Ingrese un número o * para salir: ")
        value = Console.ReadLine()
        Return value
    End Function
    Sub ReportNumber(ByVal number As Byte)
        Console.WriteLine(number)
        ReportColor(number)
        ReportColumn(number)
        ReportHalf(number)
        ReportEvenOrOdd(number)
    End Sub
    Sub ReportEvenOrOdd(ByVal number As Byte)
        If number Mod 2 = 0 Then
            Console.WriteLine("Es Par")
        Else
            Console.WriteLine("Es impar")
        End If
    End Sub
    Sub ReportHalf(ByVal number As Byte)
        If number <= totalNumbers / 2 Then
            Console.WriteLine("Es menor")
        Else
            Console.WriteLine("Es mayor")
        End If
    End Sub
    Sub ReportColumn(ByVal number As Byte)
        Dim column As Columns = getColumn(number)
        Console.WriteLine($"Columna {column}")
    End Sub
    Sub ReportColor(ByVal number As Byte)
        If IsRed(number) Then
            Console.WriteLine("Es rojo")
        Else
            Console.WriteLine("Es negro")
        End If
    End Sub
    Function getColumn(ByVal number As Byte) As Columns
        If number Mod 3 = 0 Then
            Return Columns.derecha
        ElseIf (number + 1) Mod 3 = 0 Then
            Return Columns.central
        Else
            Return Columns.izquierda
        End If
    End Function
    Function IsRed(ByVal number As Byte) As Boolean
        Dim reds As Byte() = {1, 3, 5, 7, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 30, 32, 34, 36}
        For Each red As Byte In reds
            If red = number Then Return True
        Next
        Return False
    End Function
    Function GetBoard() As String()
        Dim numbers As String() = New String(totalNumbers - 1) {}
        For x As Byte = 1 To totalNumbers
            numbers(x - 1) = Convert.ToString(x)
        Next
        Return numbers
    End Function
    Function IsNumber(ByVal value As String, ByVal numbers As String()) As Boolean
        For Each number As String In numbers
            If value = number Then Return True
        Next
        Return False
    End Function
End Module