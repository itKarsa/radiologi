Imports MySql.Data.MySqlClient
Public Class DaftarPasienSelesaiTindakan

    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Dim kdInstalasi, instalasi As String

    Sub dgv1_styleRow()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                DataGridView1.CurrentCell = Nothing
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
                DataGridView1.CurrentCell = Nothing
            End If
        Next
    End Sub

    Sub tampilData()
        Call koneksiServer()

        Dim query As String = ""
        'query = "SELECT
        '             noRekamedis,
        '             noRegistrasiRadiologiRajal,
        '             nmPasien,
        '             unitAsal,
        '             tglMasukRadiologiRajal,
        '             statusRadiologi 
        '            FROM
        '             vw_pasienradiologi
        '            WHERE
        '             (tglMasukRadiologiRajal BETWEEN  DATE_SUB(CURDATE(),INTERVAL 1 DAY) AND DATE_ADD(CURDATE(),INTERVAL 1 DAY))
        '            AND statusRadiologi = 'DALAM TINDAKAN'"
        query = "SELECT noRekamedis,noRegistrasiRadiologiRajal,nmPasien,
                        unitAsal,tglMasukRadiologiRajal,statusRadiologi 
                   FROM vw_pasienradiologi
                  WHERE statusRadiologi = 'DALAM TINDAKAN'"
        da = New MySqlDataAdapter(query, conn)
        ds = New DataSet
        da.Fill(ds, "vw_pasienradiologi")
        DataGridView1.DataSource = ds.Tables("vw_pasienradiologi")
        aturDGV()
    End Sub

    Sub aturDGV()
        Try
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 250
            DataGridView1.Columns(2).Width = 200
            DataGridView1.Columns(3).Width = 150
            DataGridView1.Columns(4).Width = 150
            DataGridView1.Columns(5).Width = 150
            'DataGridView1.Columns(6).Width = 80
            'DataGridView1.Columns(7).Width = 150
            'DataGridView1.Columns(8).Width = 150
            'DataGridView1.Columns(0).HeaderText = "NO.RM"
            'DataGridView1.Columns(1).HeaderText = "NO.REG RAJAL/RANAP"
            'DataGridView1.Columns(2).HeaderText = "NO.REG RAD"
            'DataGridView1.Columns(3).HeaderText = "NAMA PASIEN"
            'DataGridView1.Columns(4).HeaderText = "NO.TINDAKAN"
            'DataGridView1.Columns(5).HeaderText = "TINDAKAN"
            'DataGridView1.Columns(6).HeaderText = "ID"
            'DataGridView1.Columns(7).HeaderText = "STATUS"
            'DataGridView1.Columns(8).HeaderText = "TGL.SELESAI"

            DataGridView1.Columns(0).HeaderText = "NO.RM"
            DataGridView1.Columns(1).HeaderText = "NO.REG RAD"
            DataGridView1.Columns(2).HeaderText = "NAMA PASIEN"
            DataGridView1.Columns(3).HeaderText = "RUANG/POLI"
            DataGridView1.Columns(4).HeaderText = "TGL.MASUK"
            DataGridView1.Columns(5).HeaderText = "STATUS"

            'DataGridView1.Columns(8).DefaultCellStyle.Format = "dd/MM/yyyy"
            'DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DataGridView1.DefaultCellStyle.ForeColor = Color.Black
            'DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White
            'DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(4).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
            DataGridView1.DefaultCellStyle.ForeColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(1).Visible = False
            'DataGridView1.Columns(1).Visible = False
            'DataGridView1.Columns(2).Visible = False
            'DataGridView1.Columns(4).Visible = False
            'DataGridView1.Columns(6).Visible = False

            Dim btn As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btn)
            btn.HeaderText = "DETAIL"
            btn.Text = "Lihat Hasil"
            btn.Name = "btn"
            btn.Width = 150
            btn.FlatStyle = FlatStyle.Flat
            btn.UseColumnTextForButtonValue = True

            For i = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows(i).Cells(6).Style.BackColor = Color.DodgerBlue
                DataGridView1.Rows(i).Cells(6).Style.ForeColor = Color.White
            Next

            For Each column As DataGridViewColumn In DataGridView1.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            Call dgv1_styleRow()
        Catch ex As Exception

        End Try
    End Sub

    Sub tampilTextBoxPasien()
        Dim noReg As String

        If DataGridView1.CurrentRow Is Nothing Then Exit Sub
        Dim i As Integer = DataGridView1.CurrentRow.Index
        noReg = DataGridView1.Item(1, i).Value

        Try
            Call koneksiServer()
            Dim str As String
            str = "SELECT
	                    * 
                    FROM
	                    vw_pasienradiologi 
                   WHERE 
                        noRegistrasiRadiologiRajal = '" & noReg & "'
                   ORDER BY
	                    tglMasukRadiologiRajal DESC"
            cmd = New MySqlCommand(str, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                'Hasil.txtNoRM.Text = dr.Item("noRekamedis")
                'Hasil.txtNoReg.Text = dr.Item("noDaftar")
                'Hasil.txtNamaPasien.Text = dr.Item("nmPasien")
                'Hasil.txtTglLahir.Text = dr.Item("tglLahir")
                'Hasil.txtAlamat.Text = dr.Item("alamat")
                'Hasil.txtUnitAsal.Text = instalasi
                'Hasil.txtDokter1.Text = dr.Item("namapetugasMedis")
                'Hasil.txtNoPermintaan.Text = dr.Item("noRegistrasiRadiologiRajal")
                'Hasil.txtDateReg.Text = dr.Item("tglMasukRadiologiRajal")
                'Hasil.txtKetKlinis.Text = dr.Item("keterangan")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DaftarPasienSelesaiTindakan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampilData()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            kdInstalasi = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString.Substring(0, 2)

            Select Case kdInstalasi
                Case "RJ"
                    instalasi = "RAWAT JALAN"
                Case "RI"
                    instalasi = "RAWAT INAP"
            End Select

            tampilTextBoxPasien()
            'Hasil.Ambil_Data = True
            'Hasil.Form_Ambil_Data = "Dokter"
            Hasil.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            kdInstalasi = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString.Substring(0, 2)

            Select Case kdInstalasi
                Case "RJ"
                    instalasi = "RAWAT JALAN"
                Case "RI"
                    instalasi = "RAWAT INAP"
            End Select

            tampilTextBoxPasien()
            'Hasil.Ambil_Data = True
            'Hasil.Form_Ambil_Data = "Dokter"
            Hasil.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Label3_MouseEnter(sender As Object, e As EventArgs) Handles Label3.MouseEnter
        Label3.BackColor = Color.Red
    End Sub

    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs) Handles Label3.MouseLeave
        Label3.BackColor = Color.FromArgb(192, 0, 0)
    End Sub

    Private Sub DaftarPasienSelesaiTindakan_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If
    End Sub

    Private Sub DaftarPasienSelesaiTindakan_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DaftarPasienSelesaiTindakan_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
        LoginForm.Show()
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        For j As Integer = 0 To DataGridView1.RowCount - 1
            If DataGridView1.Rows(j).Cells(5).Value.ToString = "PERMINTAAN" Then
                DataGridView1.Rows(j).Cells(5).Style.BackColor = Color.Orange
                DataGridView1.Rows(j).Cells(5).Style.ForeColor = Color.White
            ElseIf DataGridView1.Rows(j).Cells(5).Value.ToString = "DALAM TINDAKAN" Then
                DataGridView1.Rows(j).Cells(5).Style.BackColor = Color.Green
                DataGridView1.Rows(j).Cells(5).Style.ForeColor = Color.White
            ElseIf DataGridView1.Rows(j).Cells(5).Value.ToString = "SELESAI" Then
                DataGridView1.Rows(j).Cells(5).Style.BackColor = Color.Red
                DataGridView1.Rows(j).Cells(5).Style.ForeColor = Color.White
                'DataGridView1.Rows(i).Visible = False
            End If
        Next
    End Sub
End Class