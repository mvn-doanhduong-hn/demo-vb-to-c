' File: Level1_BasicLogic.vb
Imports System

Namespace TestLevel1
    Module StringAndMathUtils
        ' Test biến và tính toán cơ bản
        Public Function CalculateCircleArea(radius As Double) As Double
            Const PI As Double = 3.14159
            If radius <= 0 Then
                Return 0
            End If
            Return PI * (radius * radius)
        End Function

        ' Test cấu trúc điều khiển Select Case -> Switch Case
        Public Function GetDayName(dayIndex As Integer) As String
            Dim result As String = ""
            Select Case dayIndex
                Case 1
                    result = "Sunday"
                Case 2
                    result = "Monday"
                Case 3 To 7
                    result = "Workday"
                Case Else
                    result = "Invalid Day"
            End Select
            Return result
        End Function

        ' Test vòng lặp và xử lý chuỗi
        Public Sub PrintCountdown(startNum As Integer)
            Console.WriteLine("--- Countdown Start ---")
            ' Vòng lặp For lùi (Step -1) là đặc trưng VB
            For i As Integer = startNum To 1 Step -1
                Console.WriteLine("Counting: " & i.ToString())
            Next
            Console.WriteLine("--- End ---")
        End Sub
    End Module
End Namespace