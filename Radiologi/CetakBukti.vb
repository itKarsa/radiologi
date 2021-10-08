Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class CetakBukti

    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Private Sub CetakBukti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim noRmParam As New ReportParameter("noRM", Form1.txtNoRM.Text)
        Dim dokterParam As New ReportParameter("dokterPengirim", If(Form1.txtDokter.Text.Equals(Nothing), "-", Form1.txtDokter.Text))
        Dim namaParam As New ReportParameter("namaPasien", Form1.txtNamaPasien.Text)
        Dim ruangParam As New ReportParameter("ruang", Form1.unit)
        Dim tglLahirParam As New ReportParameter("tglLahir", Form1.txtTglLahir.Text)
        'Dim jkParam As New ReportParameter("jk", Form1.txt)

        ReportViewer1.LocalReport.SetParameters(noRmParam)
        ReportViewer1.LocalReport.SetParameters(dokterParam)
        ReportViewer1.LocalReport.SetParameters(namaParam)
        ReportViewer1.LocalReport.SetParameters(ruangParam)
        ReportViewer1.LocalReport.SetParameters(tglLahirParam)
        'ReportViewer1.LocalReport.SetParameters(jkParam)

        Call koneksiServer()

        If Ambil_Data = True Then
            Select Case Form_Ambil_Data
                Case "Cetak"
                    Dim noTindakan As String
                    noTindakan = Form1.noTindakanRadiologi

                    'MsgBox()

                    Dim dt As New DataTable
                    da = New MySqlDataAdapter("SELECT * FROM vw_pasienradiologidetail
                                                       WHERE noTindakanRadiologiRajal = '" & noTindakan & "'", conn)
                    ds = New DataSet
                    da.Fill(dt)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Dim rpt As New ReportDataSource("CetakBuktiPembayaran", dt)
                    ReportViewer1.LocalReport.DataSources.Add(rpt)
            End Select
        End If

        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class