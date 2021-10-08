Public Class tes

    Dim button As Button = New Button
    Dim tambah As Button = New Button
    Dim picBox As PictureBox = New PictureBox
    Dim buttons(3) As Button
    Dim labels(3) As Label
    Dim picBoxes(3) As PictureBox
    Dim counts(3) As Integer

    Private sPath As String = System.Windows.Forms.Application.StartupPath & "\"
    Private path As String = ""
    Dim W As IO.StreamWriter

    Private Sub ConvertWordToPDF(filename As String)
        Dim wordApplication As New Microsoft.Office.Interop.Word.Application
        Dim wordDocument As Microsoft.Office.Interop.Word.Document = Nothing
        Dim outputFilename As String

        Try
            wordDocument = wordApplication.Documents.Open(filename)
            outputFilename = System.IO.Path.ChangeExtension(filename, "pdf")

            If Not wordDocument Is Nothing Then
                wordDocument.ExportAsFixedFormat(outputFilename, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, False, Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForOnScreen, Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument, 0, 0, Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent, True, True, Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks, True, True, False)
            End If
        Catch ex As Exception
            'TODO: handle exception
        Finally
            If Not wordDocument Is Nothing Then
                wordDocument.Close(False)
                wordDocument = Nothing
            End If

            If Not wordApplication Is Nothing Then
                wordApplication.Quit()
                wordApplication = Nothing
            End If
        End Try

    End Sub

    Sub propertyofbutton()
        button.Height = 75
        button.Width = 100
        button.Left = 550
        button.Top = 50

        Me.Controls.Add(button)
    End Sub

    Sub propofpicbox()
        picBox.Height = 227
        picBox.Width = 188
        picBox.Left = 100
        picBox.Top = 50
        picBox.BorderStyle = BorderStyle.Fixed3D
        picBox.Tag = "picBox"
        picBox.SizeMode = PictureBoxSizeMode.StretchImage

        Me.Controls.Add(picBox)

        button.Height = 25
        button.Width = 188
        button.Left = 100
        button.Top = 280
        button.Text = "PILIH GAMBAR"
        button.Tag = "btnPilih"
        AddHandler button.Click, AddressOf picBoxHandler
        Me.Controls.Add(button)

    End Sub

    Private Sub tes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'For i = 0 To picBoxes.Length - 1
        'buttons(i) = New Button
        'buttons(i).Height = 75
        'buttons(i).Width = 100
        'buttons(i).Left = 120 * i + 20
        'buttons(i).Top = 50
        'buttons(i).Tag = i
        'AddHandler buttons(i).Click, AddressOf buttonHandler
        'Me.Controls.Add(buttons(i))

        'labels(i) = New Label
        'labels(i).Height = 75
        'labels(i).Width = 100
        'labels(i).Left = 120 * i + 60
        'labels(i).Top = 160
        'labels(i).Text = 0
        'Me.Controls.Add(labels(i))

        'picBoxes(i) = New PictureBox
        'picBoxes(i).Height = 227
        'picBoxes(i).Width = 188
        'picBoxes(i).Left = 200 * i + 20
        'picBoxes(i).Top = 50
        'picBoxes(i).BorderStyle = BorderStyle.Fixed3D
        'picBoxes(i).Tag = i
        'picBoxes(i).SizeMode = PictureBoxSizeMode.StretchImage
        'Me.Controls.Add(picBoxes(i))

        'buttons(i) = New Button
        'buttons(i).Height = 25
        'buttons(i).Width = 188
        'buttons(i).Left = 200 * i + 20
        'buttons(i).Top = 280
        'buttons(i).Text = "PILIH GAMBAR"
        'buttons(i).Tag = i
        'AddHandler buttons(i).Click, AddressOf picBoxHandler
        'Me.Controls.Add(buttons(i))
        'Next

        'Call propofpicbox()

    End Sub

    Sub buttonHandler(sender As Button, e As EventArgs)

        Dim id As Integer = Integer.Parse(sender.Tag)
        counts(id) += 1
        labels(id).Text = counts(id)

        'Call propertyofbutton()
    End Sub

    Sub picBoxHandler(sender As Button, e As EventArgs)

        Dim id As Integer = Integer.Parse(sender.Tag)
        Dim nama As String

        Try
            With OpenFileDialog1
                .Title = "Browse Gambar"
                .FileName = ""
                .Filter = "*.jpg, *.jpeg, *.bmp, *.gif, *.png|*.jpg; *.jpeg; *.bmp; *gif; *.png"
                .ShowDialog()
                path = .FileName
                picBoxes(id).Image = Image.FromFile(path)
                TextBox1.Text += path.Substring(path.LastIndexOf("\") + 1) + ";"
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        nama = TextBox1.Text

        Dim words As String() = nama.Split(New Char() {";"})
        Dim word As String

        ListBox1.Items.Clear()

        For Each word In words
            ListBox1.Items.Add(word)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim i As Integer
        'Dim strBasePath As String
        'Dim strFileName As String

        'ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1)

        'strBasePath = Application.StartupPath & "\image"

        'For i = 0 To ListBox1.Items.Count - 1
        '    strFileName = ListBox1.Items.Item(i)
        '    Call picBoxes(i).Image.Save(strBasePath & "\" & strFileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        'Next

        'W = New IO.StreamWriter("D:\RSU\Radiologi\Radiologi\bin\Debug\image\ImageList.txt")
        'For i = 0 To ListBox1.Items.Count - 1
        '    W.WriteLine("D:\RSU\Radiologi\Radiologi\bin\Debug\image\" + ListBox1.Items.Item(i))
        'Next
        'W.Close()

        '=======================================================================================

        'If Not IsNumeric(Me.TextBox1.Text) Then
        '    Me.ErrorProvider1.SetError(Me.TextBox1, "Please enter a number")
        'Else
        '    Me.ErrorProvider1.SetError(Me.TextBox1, "")
        'End If

        '=======================================================================================

        LoadingForm.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            With OpenFileDialog2
                .Title = "Browse File Docx"
                .FileName = ""
                .Filter = "Word Document | *.docx"
                .ShowDialog()
                path = .FileName
                'TextBox1.Text = path.Substring(path.LastIndexOf("\") + 1)
                TextBox1.Text = path
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ConvertWordToPDF(TextBox1.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LoginForm.Close()
    End Sub
End Class