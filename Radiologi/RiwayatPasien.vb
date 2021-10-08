Imports MySql.Data.MySqlClient
Imports System.IO
Public Class RiwayatPasien
    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Dim noHasilRad As String = ""
    Dim noReg, noRM, tglMasuk, unit, idDetail, tindakan, dokter As String
    Dim hasil, noHasil As String

    Sub setColor(button As Button)
        btnDash.BackColor = SystemColors.HotTrack
        btnRiwayat.BackColor = SystemColors.HotTrack
        button.BackColor = Color.DodgerBlue
    End Sub

    Sub autoNoHasil()
        Try
            Call koneksiServer()
            Dim query As String = ""
            Dim kode As String = ""

            query = "SELECT SUBSTR(noHasilPemeriksaanRadiologi,16,4) FROM t_hasilpemeriksaanpasienradiologi ORDER BY CAST(SUBSTR(noHasilPemeriksaanRadiologi,16,4) AS UNSIGNED) DESC LIMIT 1"

            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                dr.Read()
                noHasilRad = "HL" + Format(Now, "ddMMyyHHmmss") + "-" + (Val(Trim(dr.Item(0).ToString)) + 1).ToString
            Else
                noHasilRad = "HL" + Format(Now, "ddMMyyHHmmss") + "-1"
            End If
            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation, "NO.HASIL")
        End Try
    End Sub

    Sub caridata()
        Call koneksiServer()
        Dim query As String
        'query = "CALL riwayatRadALL('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "')"
        query = "SELECT * FROM vw_pasienradiologi
                  WHERE (tglMasukRadiologiRajal BETWEEN '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' 
                         AND '" & Format(DateAdd(DateInterval.Day, 1, DateTimePicker2.Value), "yyyy-MM-dd") & "')
                    AND (totalTindakanRadiologiRajal IS NOT NULL AND totalTindakanRadiologiRajal != 0)
                  ORDER BY tglMasukRadiologiRajal DESC"

        Try
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            DataGridView1.Rows.Clear()
            Do While dr.Read
                DataGridView1.Rows.Add(dr.Item("noRekamedis"), dr.Item("nmPasien"), dr.Item("unitAsal"),
                                       dr.Item("tglMasukRadiologiRajal"), dr.Item("namapetugasMedis"),
                                       dr.Item("statusRadiologi"), dr.Item("noRegistrasiRadiologiRajal"))
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Tidak ada riwayat pasien pada tanggal tsb.", MsgBoxStyle.Information, "Information")
        End If

    End Sub

    Sub tampilData(noReg As String)
        Call koneksiServer()
        Dim query As String
        query = "CALL riwayatRadALL('" & noReg & "')"

        Try
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            DataGridView2.Rows.Clear()
            Do While dr.Read
                DataGridView2.Rows.Add(dr.Item("idTindakanRadiologiRanap"), dr.Item("tindakan"), dr.Item("hasil"), dr.Item("noHasilPemeriksaanRadiologi"))
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()

        If DataGridView2.Rows.Count = 0 Then
            MsgBox("Tidak ada riwayat tindakan pada pasien tsb.", MsgBoxStyle.Information, "Information")
        End If

    End Sub

    Sub cariDataPasien()
        Call koneksiServer()
        Dim query As String
        'query = "CALL riwayatRadALL('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "')"
        query = "SELECT * FROM vw_pasienradiologi
                  WHERE (noRekamedis LIKE '%" & txtNoRM.Text & "%' OR nmPasien LIKE '%" & txtNoRM.Text & "%')
                    AND (totalTindakanRadiologiRajal IS NOT NULL AND totalTindakanRadiologiRajal != 0)
                  ORDER BY tglMasukRadiologiRajal DESC"

        Try
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            DataGridView1.Rows.Clear()
            Do While dr.Read
                DataGridView1.Rows.Add(dr.Item("noRekamedis"), dr.Item("nmPasien"), dr.Item("unitAsal"),
                                       dr.Item("tglMasukRadiologiRajal"), dr.Item("namapetugasMedis"),
                                       dr.Item("statusRadiologi"), dr.Item("noRegistrasiRadiologiRajal"))
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Tidak ada riwayat pasien dengan No.RM/Nama " & txtNoRM.Text, MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Sub aturDGV()
        Try
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 250
            DataGridView1.Columns(2).Width = 120
            DataGridView1.Columns(3).Width = 190
            DataGridView1.Columns(4).Width = 250
            DataGridView1.Columns(5).Width = 300
            DataGridView1.Columns(6).Width = 300
            DataGridView1.Columns(7).Width = 200
            DataGridView1.Columns(0).HeaderText = "NO. RM"
            DataGridView1.Columns(1).HeaderText = "NAMA PASIEN"
            DataGridView1.Columns(2).HeaderText = "TGL. MASUK"
            DataGridView1.Columns(3).HeaderText = "ASAL RUANG / POLI"
            DataGridView1.Columns(4).HeaderText = "TINDAKAN"
            DataGridView1.Columns(5).HeaderText = "DOKTER PENGIRIM"
            DataGridView1.Columns(6).HeaderText = "DOKTER LABORATORIUM"
            DataGridView1.Columns(7).HeaderText = "FILE HASIL"

            DataGridView1.Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
            DataGridView1.DefaultCellStyle.ForeColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(7).Visible = False

            Dim btn As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btn)
            btn.HeaderText = "DETAIL"
            btn.Text = "Lihat Hasil"
            btn.Name = "btn"
            btn.Width = 150
            btn.FlatStyle = FlatStyle.Flat
            btn.UseColumnTextForButtonValue = True

            For i = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows(i).Cells(8).Style.BackColor = Color.DodgerBlue
                DataGridView1.Rows(i).Cells(8).Style.ForeColor = Color.White
            Next

            For Each column As DataGridViewColumn In DataGridView1.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub addHasil(hasil As String)
        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Call koneksiServer()
        Try
            Dim str As String
            str = "INSERT INTO t_hasilpemeriksaanpasienradiologi
                          (noHasilPemeriksaanRadiologi,noRegistrasiRadiologi,noRM,tglMasuk,
                           unitAsal,idDetail,tindakan,dokter,
                           hasil,userCreate,dateCreate) 
                   VALUES ('" & noHasilRad & "','" & noReg & "','" & noRM & "','" & tglMasuk & "',
                           '" & unit & "','" & idDetail & "','" & tindakan & "','" & dokter & "',
                           @hasil,'" & LoginForm.txtUsername.Text & "','" & dt & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.Parameters.AddWithValue("@hasil", hasil)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            MsgBox("Insert data hasil pemeriksaan berhasil", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox("Insert data hasil pemeriksaan gagal.", MsgBoxStyle.Critical, "Error")
        End Try
        conn.Close()
    End Sub

    Sub updateHasil(hasil As String)
        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Call koneksiServer()
        Try
            Dim str As String
            str = "UPDATE t_hasilpemeriksaanpasienradiologi
                      SET hasil = @hasil
                    WHERE noHasilPemeriksaanRadiologi = '" & noHasil & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.Parameters.AddWithValue("@hasil", hasil)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            MsgBox("Update data hasil pemeriksaan berhasil", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox("Insert data hasil pemeriksaan gagal.", MsgBoxStyle.Critical, "Error")
        End Try
        conn.Close()
    End Sub

    Private Sub RiwayatPasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.Manual
        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        pnlStats.Height = btnRiwayat.Height
        pnlStats.Top = btnRiwayat.Top
        btnRiwayat.BackColor = Color.DodgerBlue

        'Call tampilData()
    End Sub

    Private Sub txtNoRM_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoRM.KeyDown
        If e.KeyCode = Keys.Enter And txtNoRM.Text = "" Then
            MessageBox.Show("Masukkan No.RM Pasien", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf e.KeyCode = Keys.Enter Then
            Call cariDataPasien()
        End If
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.EnableHeadersVisualStyles = False

        For i As Integer = 0 To DataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
            End If
        Next

        'If e.RowIndex > 0 And e.ColumnIndex = 0 Then
        '    If DataGridView1.Item(0, e.RowIndex - 1).Value = e.Value Then
        '        e.Value = ""
        '    End If
        'End If

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(5).Value.ToString = "PERMINTAAN" Then
                DataGridView1.Rows(i).Cells(5).Style.BackColor = Color.Orange
                DataGridView1.Rows(i).Cells(5).Style.ForeColor = Color.White
            ElseIf DataGridView1.Rows(i).Cells(5).Value.ToString = "DALAM TINDAKAN" Then
                DataGridView1.Rows(i).Cells(5).Style.BackColor = Color.Green
                DataGridView1.Rows(i).Cells(5).Style.ForeColor = Color.White
            ElseIf DataGridView1.Rows(i).Cells(5).Value.ToString = "SELESAI" Then
                DataGridView1.Rows(i).Cells(5).Style.BackColor = Color.Red
                DataGridView1.Rows(i).Cells(5).Style.ForeColor = Color.White
            End If
        Next
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Form1.Show()
        Form1.pnlStats.Height = Form1.btnDash.Height
        Form1.pnlStats.Top = Form1.btnDash.Top
        Me.Close()
    End Sub

    Private Sub btnDash_Click(sender As Object, e As EventArgs) Handles btnDash.Click
        Form1.pnlStats.Height = Form1.btnDash.Height
        Form1.pnlStats.Top = Form1.btnDash.Top
        Form1.btnDash.BackColor = Color.DodgerBlue
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub btnRiwayat_Click(sender As Object, e As EventArgs) Handles btnRiwayat.Click
        pnlStats.Height = btnRiwayat.Height
        pnlStats.Top = btnRiwayat.Top

        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Call caridata()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex = -1 Then
            Return
        End If

        noRM = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        unit = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
        tglMasuk = Format(CDate(DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString), "yyyy-MM-dd HH:mm:ss")
        dokter = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
        noReg = DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString

        Call tampilData(noReg)

    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex = -1 Then
            Return
        End If

        idDetail = DataGridView2.Rows(e.RowIndex).Cells(0).Value.ToString
        tindakan = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
        hasil = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
        noHasil = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Select Case e.ColumnIndex
            Case 4
                If hasil = "" Then
                    'MsgBox("Belum ada hasil pemeriksaan")
                    Return
                Else
                    'MsgBox("Proses Lihat Hasil " & hasil)
                    Process.Start(hasil)
                End If
            Case 5
                If hasil = "" Then
                    Call autoNoHasil()
                    'MsgBox(noHasilRad)
                    Dim result As DialogResult = OpenFileDialog1.ShowDialog()
                    If result = Windows.Forms.DialogResult.OK Then
                        Dim namafile As String = OpenFileDialog1.FileName       ' Get the file name.
                        Try
                            'Dim text As String = File.ReadAllText(path)        ' Read in text.
                            Dim pathfile As String = Path.GetFullPath(namafile)
                            Call addHasil(pathfile)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                        End Try
                    End If
                    Call tampilData(noReg)
                Else
                    Dim result As DialogResult = OpenFileDialog1.ShowDialog()
                    If result = Windows.Forms.DialogResult.OK Then
                        Dim namafile As String = OpenFileDialog1.FileName
                        Try
                            Dim pathfile As String = Path.GetFullPath(namafile)
                            Call updateHasil(pathfile)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                        End Try
                    End If
                    Call tampilData(noReg)
                End If
        End Select
    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged
        If DataGridView2.IsCurrentCellDirty Then
            DataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim dg As DataGridView = DirectCast(sender, DataGridView)
        ' Current row record
        Dim rowNumber As String = (e.RowIndex + 1).ToString()

        ' Format row based on number of records displayed by using leading zeros
        'While rowNumber.Length < dg.RowCount.ToString().Length
        '    rowNumber = "0" & rowNumber
        'End While

        ' Position text
        Dim size As SizeF = e.Graphics.MeasureString(rowNumber, Me.Font)
        If dg.RowHeadersWidth < CInt(size.Width + 20) Then
            dg.RowHeadersWidth = CInt(size.Width + 20)
        End If

        ' Use default system text brush
        Dim b As Brush = SystemBrushes.ControlText

        ' Draw row number
        e.Graphics.DrawString(rowNumber, dg.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub DataGridView2_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView2.RowPostPaint
        Dim dg As DataGridView = DirectCast(sender, DataGridView)
        ' Current row record
        Dim rowNumber As String = (e.RowIndex + 1).ToString()

        ' Format row based on number of records displayed by using leading zeros
        'While rowNumber.Length < dg.RowCount.ToString().Length
        '    rowNumber = "0" & rowNumber
        'End While

        ' Position text
        Dim size As SizeF = e.Graphics.MeasureString(rowNumber, Me.Font)
        If dg.RowHeadersWidth < CInt(size.Width + 20) Then
            dg.RowHeadersWidth = CInt(size.Width + 20)
        End If

        ' Use default system text brush
        Dim b As Brush = SystemBrushes.ControlText

        ' Draw row number
        e.Graphics.DrawString(rowNumber, dg.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        For i As Integer = 0 To DataGridView2.RowCount - 1
            Dim buttonCell1 As DataGridViewDisableButtonCell = CType(DataGridView2.Rows(i).Cells(4), DataGridViewDisableButtonCell)
            If DataGridView2.Rows(i).Cells(2).Value.ToString = "" Then
                buttonCell1.Enabled = False
            Else
                buttonCell1.Enabled = True
            End If
        Next
    End Sub

    Private Sub btnCari2_Click(sender As Object, e As EventArgs) Handles btnCari2.Click
        Call cariDataPasien()
    End Sub
End Class