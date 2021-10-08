Public Class PreviewCitra

    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Private Sub PreviewCitra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String = ""
        Dim filename As String

        'If Ambil_Data = True Then
        '    Select Case Form_Ambil_Data
        '        Case "Preview"
        '            'path = Hasil.textBoxes(Hasil.noId).Text
        '            'If path = Nothing Then
        '            '    Return
        '            'Else
        '            '    PictureBox1.Image = Image.FromFile(Hasil.textBoxes(Hasil.noId).Text)
        '            End If
        '    End Select
        'End If

        filename = System.IO.Path.GetFileName(path)
        Label1.Text = filename

    End Sub
End Class