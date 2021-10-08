'Option Strict On

Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Core
Imports Word = Microsoft.Office.Interop.Word
Imports System.Reflection
Imports System.IO
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class Template

    Public Ambil_Data As Boolean
    Public Form_Ambil_Data As String
    Private path As String = ""
    Dim pathImage As String = ""

    Private wdApp As Word.Application
    Private wdDocs As Word.Documents
    Private sPath As String = System.Windows.Forms.Application.StartupPath & "\"
    Private sFileName As String

    Private Function resizeImage(ByVal filename As String, ByVal size As Size) As Image
        Dim imgToResize As Image = Image.FromFile(filename)
        Dim sourceWidth As Integer = imgToResize.Width
        Dim sourceHeight As Integer = imgToResize.Height
        Dim nPercent As Single = 0
        Dim nPercentW As Single = 0
        Dim nPercentH As Single = 0
        nPercentW = (CSng(size.Width) / CSng(sourceWidth))
        nPercentH = (CSng(size.Height) / CSng(sourceHeight))

        If nPercentH < nPercentW Then
            nPercent = nPercentH
        Else
            nPercent = nPercentW
        End If

        Dim destWidth As Integer = CInt((sourceWidth * nPercent))
        Dim destHeight As Integer = CInt((sourceHeight * nPercent))
        Dim b As Bitmap = New Bitmap(destWidth, destHeight)
        Dim g As Graphics = Graphics.FromImage(CType(b, Image))
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.DrawImage(imgToResize, 0, 0, destWidth, destHeight)
        g.Dispose()
        Return CType(b, Image)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("isi nama file terlebih dahulu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim konfirmasi As MsgBoxResult
        Dim tempPath As String = ""

        konfirmasi = MsgBox("Apakah anda yakin ingin menyimpannya ?", CType(vbQuestion + vbYesNo, MsgBoxStyle), "Save as")
        If konfirmasi = vbYes Then
            sFileName = TextBox1.Text

            wdApp = New Word.Application
            wdDocs = wdApp.Documents

            Dim wdDoc As Word.Document = wdDocs.Add(sPath & "Template\" & txtTemplate.Text)
            Dim wdBooks As Word.Bookmarks = wdDoc.Bookmarks

            wdBooks("noRM").Range.Text = txtNoRM.Text.ToString()
            wdBooks("nama").Range.Text = txtNamaPasien.Text.ToString()
            wdBooks("tglUmur").Range.Text = txtTglLahir.Text.ToString() & " / " & txtUsia.Text.ToString() & " th"
            wdBooks("alamat").Range.Text = txtAlamat.Text.ToString()
            wdBooks("diagnosa").Range.Text = txtKetKlinis.Text.ToString()
            wdBooks("noReg").Range.Text = txtNoReg.Text.ToString()
            wdBooks("tglReg").Range.Text = txtDateReg.Text.ToString()
            wdBooks("jam").Range.Text = txtJam.Text.ToString()
            wdBooks("pemeriksaan").Range.Text = txtPemeriksaan.Text.ToString()
            wdBooks("pengirim").Range.Text = txtDokter1.Text.ToString()

            'Dim img As Image = resizeImage(pathImage, New Size(200, 90))
            'tempPath = System.Windows.Forms.Application.StartupPath & "\Images\~Temp\Temp.jpg"
            'img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Jpeg)
            'Dim oMissed As Object = wdDoc.Paragraphs(1).Range
            'Dim oLinkToFile As Object = False
            'Dim oSaveWithDocument As Object = True
            'wdDoc.InlineShapes.AddPicture(tempPath, oLinkToFile, oSaveWithDocument, oMissed)

            wdDoc.SaveAs2(sPath & "Hasil Bacaan\" & sFileName)

            ReleaseObject(wdBooks)
            wdDoc.Close(False)
            ReleaseObject(wdDoc)
            ReleaseObject(wdDocs)
            wdApp.Quit()

            TextBox1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True

            MsgBox("File hasil pemeriksaan berhasil dibuat", MsgBoxStyle.Information, "Information")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        wdApp = New Word.Application
        wdDocs = wdApp.Documents
        wdApp.Visible = True    'need to monitor process

        Dim wdDoc As Word.Document = wdDocs.Open(sPath & sFileName & ".docx")
        wdDoc.PrintOut()

        wdDoc.Close(False)
        ReleaseObject(wdDoc)
        ReleaseObject(wdDocs)
        wdApp.Quit()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        wdApp = New Word.Application
        wdDocs = wdApp.Documents

        Dim qword As Word.Application
        Dim qdoc As Word.Document

        Dim wdDoc As Word.Document = wdDocs.Open(sPath & "Hasil Bacaan\" & sFileName & ".docx")
        wdDoc.SaveAs2(sPath & sFileName, Word.WdSaveFormat.wdFormatHTML)

        wdDoc.Close(False)
        ReleaseObject(wdDoc)
        ReleaseObject(wdDocs)
        wdApp.Quit()

        WebBrowser1.Navigate(sPath & sFileName & ".htm")

        qword = CType(CreateObject("word.Application"), Application)
        qdoc = qword.Documents.Open(sPath & "Hasil Bacaan\" & sFileName & ".docx")
        qword.Visible = True

    End Sub

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If wdDocs IsNot Nothing Then
            ReleaseObject(wdDocs)
        End If
        If wdApp IsNot Nothing Then
            ReleaseObject(wdApp)
        End If

        Dim dt As Date
        Dim dtReg As Date
        If Ambil_Data = True Then
            Select Case Form_Ambil_Data
                Case "Cetak"
                    'txtNoRM.Text = Hasil.txtNoRM.Text
                    'txtNamaPasien.Text = Hasil.txtNamaPasien.Text
                    'dt = Convert.ToDateTime(Hasil.txtTglLahir.Text)
                    'txtTglLahir.Text = dt.ToString("dd MMMM yyyy", New System.Globalization.CultureInfo("id-ID"))
                    'txtUsia.Text = Hasil.txtUsia.Text.Substring(0, 2)
                    'txtAlamat.Text = Hasil.txtAlamat.Text
                    'txtKetKlinis.Text = Hasil.txtKetKlinis.Text
                    'txtNoReg.Text = Hasil.txtNoPermintaan.Text
                    'dtReg = Convert.ToDateTime(Hasil.txtDateReg.Text)
                    'txtDateReg.Text = dtReg.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                    'txtJam.Text = Hasil.txtJam.Text
                    'txtPemeriksaan.Text = Hasil.txtJenis.Text
                    'txtDokter1.Text = Hasil.txtDokter1.Text
            End Select
        End If
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Try
            With OpenFileDialog1
                .InitialDirectory = sPath & "Template"
                .Title = "Browse Template Docx"
                .FileName = ""
                .Filter = "Word Template | *.dotx"
                .ShowDialog()
                path = .FileName
                txtTemplate.Text = path.Substring(path.LastIndexOf("\") + 1)
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtTemplate_TextChanged(sender As Object, e As EventArgs) Handles txtTemplate.TextChanged
        If txtTemplate.Text IsNot Nothing Then
            TextBox1.Enabled = True
        End If
    End Sub

    Private Sub btnSelesai_Click(sender As Object, e As EventArgs) Handles btnSelesai.Click
        Try
            btnSelesai.Enabled = False
            ConvertWordToPDF(sPath & "Hasil Bacaan\" & sFileName & ".docx")
            'Hasil.txtHasil.Text = sFileName & ".pdf"
            'Hasil.txtHasil.Text = TextBox1.Text & ".docx"
        Catch ex As Exception
            MsgBox(ex.Message)
            btnSelesai.Enabled = True
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            With OpenFileDialog1
                .Title = "Browse Gambar"
                .FileName = ""
                .Filter = "*.jpg, *.jpeg, *.bmp, *.gif, *.png|*.jpg; *.jpeg; *.bmp; *gif; *.png"
                .ShowDialog()
                pathImage = .FileName
                TextBox8.Text = pathImage
                PictureBox1.Image = Image.FromFile(pathImage)
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

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

    Private Sub btnCari_MouseEnter(sender As Object, e As EventArgs) Handles btnCari.MouseEnter
        btnCari.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub btnCari_MouseLeave(sender As Object, e As EventArgs) Handles btnCari.MouseLeave
        btnCari.BackColor = Color.DodgerBlue
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.DodgerBlue
    End Sub

    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        Button3.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.DodgerBlue
    End Sub

    Private Sub btnSelesai_MouseEnter(sender As Object, e As EventArgs) Handles btnSelesai.MouseEnter
        btnSelesai.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub btnSelesai_MouseLeave(sender As Object, e As EventArgs) Handles btnSelesai.MouseLeave
        btnSelesai.BackColor = Color.DodgerBlue
    End Sub

    Private Sub Template_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        txtTemplate.Text = ""
        TextBox1.Text = ""
        TextBox1.Enabled = True
        btnSelesai.Enabled = True
        WebBrowser1.ResetText()
    End Sub
End Class