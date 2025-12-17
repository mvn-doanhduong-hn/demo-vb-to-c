' File: Level3_Architecture.vb
Imports System
Imports System.IO
Imports Microsoft.VisualBasic ' Thư viện đặc thù của VB

Namespace TestLevel3
    Public Class SystemLogger
        Private _logPath As String

        Public Sub New(path As String)
            _logPath = path
        End Sub

        ' Test xử lý lỗi và File I/O
        Public Sub WriteLog(message As String)
            Try
                ' Hàm Date.Now và định dạng chuỗi
                Dim timeStamp As String = Date.Now.ToString("yyyy-MM-dd HH:mm:ss")
                Dim content As String = $"[{timeStamp}] {message}" & vbCrLf

                ' Test hàm kiểm tra file tồn tại
                If Not File.Exists(_logPath) Then
                    File.Create(_logPath).Dispose()
                End If

                File.AppendAllText(_logPath, content)

            Catch ex As Exception
                Console.WriteLine("Error writing log: " & ex.Message)
            End Try
        End Sub

        ' Test các hàm đặc thù của VB (Legacy Functions)
        Public Function CheckLegacyInput(input As Object) As Boolean
            ' IsNumeric là hàm đặc trưng của VB, C# không có trực tiếp
            If IsNumeric(input) Then
                ' CInt cũng là hàm ép kiểu kiểu VB
                Dim val As Integer = CInt(input)
                Return val > 0
            End If
            Return False
        End Function

        ' Test tính toán ngày tháng
        Public Function GetNextWeekDate() As Date
            ' DateAdd là hàm VB cũ
            Return DateAdd(DateInterval.Day, 7, Date.Now)
        End Function
    End Class
End Namespace