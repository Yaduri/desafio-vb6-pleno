Imports System.IO

Public Module Logger
    Private ReadOnly LogDirectory As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")
    Private ReadOnly LogPath As String = Path.Combine(LogDirectory, $"log_{DateTime.Now:yyyyMMdd}.txt")

    Public Sub LogError(ex As Exception, Optional contextualInfo As String = "")
        Try
            If Not Directory.Exists(LogDirectory) Then
                Directory.CreateDirectory(LogDirectory)
            End If

            Using writer As New StreamWriter(LogPath, True)
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [ERRO] {contextualInfo}")
                writer.WriteLine($"Mensagem: {ex.Message}")
                writer.WriteLine($"StackTrace: {ex.StackTrace}")
                writer.WriteLine(New String("-"c, 80))
            End Using
        Catch
        End Try
    End Sub
End Module